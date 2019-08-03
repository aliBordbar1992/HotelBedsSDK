using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using HotelBeds.Api.Activities;
using HotelBeds.Api.Transfer;
using HotelBeds.Shared;

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

            if (path.GetHttpMethod() == HttpMethod.Get) return await ProcessGetRequestAsync<TRes>(client, uri);
            if (path.GetHttpMethod() == HttpMethod.Delete) return await ProcessDeleteRequestAsync<TRes>(client, uri);

            throw new HttpRequestException($"{path.GetHttpMethod()} is not a valid request.");
        }
        private async Task<TRes> ProcessRequestAsync<TReq, TRes>(HttpClient client, TReq request, ApiPathsBase path, List<Tuple<string, string>> param)
        {
            string uri = path.GetEndPoint();
            if (param != null) uri = path.GetEndPoint(param);

            if (path.GetHttpMethod() == HttpMethod.Get) return await ProcessGetRequestAsync<TRes>(client, uri);
            if (path.GetHttpMethod() == HttpMethod.Delete) return await ProcessDeleteRequestAsync<TRes>(client, uri);

            if (request == null) throw new Exception($"Object request can't be null in a {path.GetHttpMethod()} request");

            if (path.GetHttpMethod() == HttpMethod.Post)
            {
                string objectSerialized = request.ToJsonString();
                var contentToSend = new StringContent(objectSerialized, Encoding.UTF8, "application/json");

                return await ProcessPostRequestAsync<TRes>(contentToSend, path, param, client);
            }

            if (path.GetHttpMethod() == HttpMethod.Put)
            {
                string objectSerialized = request.ToJsonString();
                var contentToSend = new StringContent(objectSerialized, Encoding.UTF8, "application/json");

                return await ProcessPutRequestAsync<TRes>(contentToSend, path, param, client);
            }

            throw new HttpRequestException($"{path.GetHttpMethod()} is not a valid request.");
        }

        private async Task<TRes> ProcessPostRequestAsync<TRes>(StringContent contentToSend, ApiPathsBase path, List<Tuple<string, string>> param, HttpClient client)
        {
            var resp = param == null
                ? await client.PostAsync(path.GetEndPoint(), contentToSend)
                : await client.PostAsync(path.GetEndPoint(param), contentToSend);

            var response = await resp.Content.ReadAsAsync<TRes>();
            return response;
        }
        private async Task<TRes> ProcessPutRequestAsync<TRes>(StringContent contentToSend, ApiPathsBase path, List<Tuple<string, string>> param, HttpClient client)
        {
            var resp = param == null
                ? await client.PutAsync(path.GetEndPoint(), contentToSend)
                : await client.PutAsync(path.GetEndPoint(param), contentToSend);

            var response = resp.Content.ReadAsAsync<TRes>().Result;
            return response;
        }
        private async Task<TRes> ProcessDeleteRequestAsync<TRes>(HttpClient client, string uri)
        {
            HttpResponseMessage resp = await client.DeleteAsync(uri);
            var response = await resp.Content.ReadAsAsync<TRes>();
            return response;
        }
        private async Task<TRes> ProcessGetRequestAsync<TRes>(HttpClient client, string uri)
        {
            HttpResponseMessage resp = await client.GetAsync(uri);
            var response = await resp.Content.ReadAsAsync<TRes>();
            return response;
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