using HotelBeds.Api.Activities;
using HotelBeds.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Api
{
    public class ApiClient : IHotelBedsApiClient
    {
        private IApiVersionSelector _version;
        private readonly string _apiKey;
        private readonly string _secret;
        private string _baseUrl;


        public ApiClient(string apiKey, string secret)
        {
            _apiKey = apiKey;
            _secret = secret;
        }


        public TRes CallRemoteApi<TRes>(ApiPathsBase path, List<Tuple<string, string>> param)
        {
            return CallRemoteApiAsync<TRes>(path, param).Result;
        }
        public TRes CallRemoteApi<TReq, TRes>(TReq request, ApiPathsBase path, List<Tuple<string, string>> param)
        {
            return CallRemoteApiAsync<TReq, TRes>(request, path, param).Result;
        }


        public async Task<TRes> CallRemoteApiAsync<TRes>(ApiPathsBase path, List<Tuple<string, string>> param)
        {
            try
            {
                TRes response;

                using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip }))
                {
                    string signature = XSignature();
                    SetupClient(client, path, signature);

                    response = await ProcessRequestAsync<TRes>(client, path, param);
                }

                return response;
            }
            catch (ApiSdkException e)
            {
                throw e;
            }
        }
        public async Task<TRes> CallRemoteApiAsync<TReq, TRes>(TReq request, ApiPathsBase path, List<Tuple<string, string>> param)
        {
            try
            {
                TRes response;

                using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip }))
                {
                    string signature = XSignature();
                    SetupClient(client, path, signature);

                    response = await ProcessRequestAsync<TReq, TRes>(client, request, path, param);
                }

                return response;
            }
            catch (ApiSdkException e)
            {
                throw e;
            }
        }




        #region AsyncMethods

        private async Task<TRes> ProcessRequestAsync<TRes>(HttpClient client, ApiPathsBase path, List<Tuple<string, string>> param)
        {
            string uri = path.GetEndPoint();
            if (param != null) uri = path.GetEndPoint(param);

            HttpResponseMessage resp = null;

            if (path.GetHttpMethod() == HttpMethod.Get) resp = await ProcessGetRequestAsync(client, uri);
            if (path.GetHttpMethod() == HttpMethod.Delete) resp = await ProcessDeleteRequestAsync(client, uri);

            if (resp == null) throw new HttpRequestException($"{path.GetHttpMethod()} is not a valid request.");

            try
            {
                var response = await resp.Content.ReadAsAsync<TRes>();
                return response;
            }
            catch (Exception e)
            {
                var response = await resp.Content.ReadAsStringAsync();

                string errorCode = "Unknown Error";

                Regex pattern = new Regex("<h1>(.*?)</h1>");
                if (pattern.IsMatch(response))
                {
                    var match = pattern.Match(response);
                    errorCode = match.Value;
                }

                var err = new Error()
                {
                    Code = errorCode,
                    Text = errorCode,
                    InternalDescription =
                        $"{e.Message} ____ {String.Join(" ____ ", e.GetInnerExceptions().Select(x => x.Message))}"
                };

                throw new ApiSdkException(err);
            }
        }
        private async Task<TRes> ProcessRequestAsync<TReq, TRes>(HttpClient client, TReq request, ApiPathsBase path, List<Tuple<string, string>> param)
        {
            string uri = path.GetEndPoint();
            if (param != null) uri = path.GetEndPoint(param);

            HttpResponseMessage resp = null;

            if (path.GetHttpMethod() == HttpMethod.Get) resp = await ProcessGetRequestAsync(client, uri);
            if (path.GetHttpMethod() == HttpMethod.Delete) resp = await ProcessDeleteRequestAsync(client, uri);

            if (request == null) throw new Exception($"Object request can't be null in a {path.GetHttpMethod()} request");

            if (path.GetHttpMethod() == HttpMethod.Post)
            {
                string objectSerialized = request.ToJsonString();
                var contentToSend = new StringContent(objectSerialized, Encoding.UTF8, "application/json");

                resp = await ProcessPostRequestAsync(contentToSend, path, param, client);
            }

            if (path.GetHttpMethod() == HttpMethod.Put)
            {
                string objectSerialized = request.ToJsonString();
                var contentToSend = new StringContent(objectSerialized, Encoding.UTF8, "application/json");

                resp = await ProcessPutRequestAsync(contentToSend, path, param, client);
            }

            if (resp == null) throw new HttpRequestException($"{path.GetHttpMethod()} is not a valid request.");

            try
            {
                var response = await resp.Content.ReadAsAsync<TRes>();
                return response;
            }
            catch (Exception e)
            {
                var response = await resp.Content.ReadAsStringAsync();

                string errorCode = "Unknown Error";

                Regex pattern = new Regex("<h1>(.*?)</h1>");
                if (pattern.IsMatch(response))
                {
                    var match = pattern.Match(response);
                    errorCode = match.Value;
                }

                var err = new Error()
                {
                    Code = errorCode,
                    Text = errorCode,
                    InternalDescription =
                        $"{e.Message} ____ {String.Join(" ____ ", e.GetInnerExceptions().Select(x => x.Message))}"
                };

                throw new ApiSdkException(err);
            }
        }

        private async Task<HttpResponseMessage> ProcessPostRequestAsync(StringContent contentToSend, ApiPathsBase path, List<Tuple<string, string>> param, HttpClient client)
        {
            return param == null
                ? await client.PostAsync(path.GetEndPoint(), contentToSend)
                : await client.PostAsync(path.GetEndPoint(param), contentToSend);

            //var response = await resp.Content.ReadAsAsync<TRes>();
            //return response;
        }
        private async Task<HttpResponseMessage> ProcessPutRequestAsync(StringContent contentToSend, ApiPathsBase path, List<Tuple<string, string>> param, HttpClient client)
        {
            return param == null
                ? await client.PutAsync(path.GetEndPoint(), contentToSend)
                : await client.PutAsync(path.GetEndPoint(param), contentToSend);

            //var response = resp.Content.ReadAsAsync<TRes>().Result;
            //return response;
        }
        private async Task<HttpResponseMessage> ProcessDeleteRequestAsync(HttpClient client, string uri)
        {
            return await client.DeleteAsync(uri);
            //var response = await resp.Content.ReadAsAsync<TRes>();
            //return response;
        }
        private async Task<HttpResponseMessage> ProcessGetRequestAsync(HttpClient client, string uri)
        {
            return await client.GetAsync(uri);
        }

        #endregion


        private void SetupClient(HttpClient client, ApiPathsBase path, string signature)
        {
            client.BaseAddress = path.HasCustomBaseUrl
                ? new Uri(path.GetUrl())
                : new Uri(path.GetUrl(_baseUrl, _version));

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Api-Key", _apiKey);
            client.DefaultRequestHeaders.Add("X-Signature", signature);
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json; charset=utf-8");
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "hotel-api-sdk-net");
        }
        public void SetBaseUrl(string url)
        {
            _baseUrl = url;
        }

        public void SetVersion(IApiVersionSelector versionSelector)
        {
            _version = versionSelector;
        }

        private string XSignature()
        {
            string signature;
            using (var sha = SHA256.Create())
            {
                long ts = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds /
                          1000;
                Console.WriteLine("Timestamp: " + ts);
                var computedHash = sha.ComputeHash(Encoding.UTF8.GetBytes(_apiKey + _secret + ts));
                signature = BitConverter.ToString(computedHash).Replace("-", "");
            }

            return signature;
        }
    }
}