using System;
using System.Collections.Generic;
using System.Net.Http;
using HotelBeds.Api.Activities;

namespace HotelBeds.Api
{
    public class ApiPathsBase
    {
        protected ApiPathsBase()
        {
            HasCustomBaseUrl = false;
        }

        protected string UrlTemplate = "${path}/${version}/";
        protected HttpMethod HttpMethod;
        protected string Endpoint;
        public bool HasCustomBaseUrl { get; protected set; }

        private string _customBasePath;
        private string _customVersion;

        protected void SetCustomUrl(IActivityApiBaseUrl baseUrl,IApiVersionSelector version)
        {
            _customBasePath = baseUrl.GetUrl();
            _customVersion = version.GetVersion();
        }

        public string GetUrl()
        {
            return UrlTemplate
                .Replace("${path}", _customBasePath)
                .Replace("${version}", _customVersion);
        }

        public string GetUrl(string basePath, IApiVersionSelector version)
        {
            string versionString = version.GetVersion();

            return UrlTemplate
                .Replace("${path}", basePath)
                .Replace("${version}", versionString);
        }

        public HttpMethod GetHttpMethod()
        {
            return HttpMethod;
        }

        public string GetEndPoint()
        {
            return Endpoint;
        }

        public string GetEndPoint(List<Tuple<string, string>> param)
        {
            if (param != null)
            {
                foreach (var t in param)
                    Endpoint = Endpoint.Replace(t.Item1, t.Item2);
            }


            return (param != null) ? Endpoint : Endpoint + "/";
        }
    }
}