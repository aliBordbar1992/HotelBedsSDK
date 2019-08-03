using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelBeds.Api
{
    public interface IHotelBedsApiClient
    {
        TRes CallRemoteApi<TReq, TRes>(TReq request, ApiPathsBase path, List<Tuple<string, string>> param);
        TRes CallRemoteApi<TRes>(ApiPathsBase path, List<Tuple<string, string>> param);
        Task<TRes> CallRemoteApiAsync<TReq, TRes>(TReq request, ApiPathsBase path, List<Tuple<string, string>> param);
        Task<TRes> CallRemoteApiAsync<TRes>(ApiPathsBase path, List<Tuple<string, string>> param);
        void SetBaseUrl(string url);
        void SetVersion(IApiVersionSelector versionSelector);
    }
}