using HotelBeds.Shared.TransferContent.Request;
using HotelBeds.Shared.TransferContent.Response;
using System;
using System.Collections.Generic;

namespace HotelBeds.Api.TransferContents
{
    public class TransferContentApi : ITransferContentApi
    {
        private readonly IHotelBedsApiClient _api;

        public TransferContentApi(IHotelBedsApiClient api, ITransferContentApiBaseUrl baseUrl, ITransferContentVersionSelector versionSelector)
        {
            _api = api;
            _api.SetBaseUrl(baseUrl.GetUrl());
            _api.SetVersion(versionSelector);
        }

        public RouteResponse Routes(string destinationCode, string fields = "ALL", int offset = 0, int limit = 0)
        {
            var path = new Paths.Routes();

            var @params = new List<Tuple<string, string>>
            {
                new Tuple<string, string>(path.GetParams().Fields, fields),
                new Tuple<string, string>(path.GetParams().Destination, destinationCode),
                new Tuple<string, string>(path.GetParams().Offset, offset.ToString()),
                new Tuple<string, string>(path.GetParams().Limit, limit.ToString())
            };

            var response = _api.CallRemoteApi<RouteResponse>(path, @params);
            return response;
        }

        public PickupResponse Pickups(string fields = "ALL", string language = "en", string codes = "", int offset = 0, int limit = 0)
        {
            var path = new Paths.Pickups();

            var @params = new List<Tuple<string, string>>
            {
                new Tuple<string, string>(path.GetParams().Fields, fields),
                new Tuple<string, string>(path.GetParams().Language, language),
                new Tuple<string, string>(path.GetParams().Codes, codes),
                new Tuple<string, string>(path.GetParams().Offset, offset.ToString()),
                new Tuple<string, string>(path.GetParams().Limit, limit.ToString())
            };

            var response = _api.CallRemoteApi<PickupResponse>(path, @params);
            return response;
        }

        public HotelResponse Hotels(HotelRequest request)
        {
            var path = new Paths.Hotels();

            var @params = new List<Tuple<string, string>>
            {
                new Tuple<string, string>(path.GetParams().Fields, request.Fields),
                new Tuple<string, string>(path.GetParams().Language, request.Language),
                new Tuple<string, string>(path.GetParams().Countries, request.CountryCodes),
                new Tuple<string, string>(path.GetParams().Destinations, request.DestinationCodes),
                new Tuple<string, string>(path.GetParams().Giatas, request.GiataCodes),
                new Tuple<string, string>(path.GetParams().Offset, request.Offset.ToString()),
                new Tuple<string, string>(path.GetParams().Limit, request.Limit.ToString()),
            };

            var response = _api.CallRemoteApi<HotelResponse>(path, @params);
            return response;
        }

        public CurrencyResponse Currencies(string fields = "ALL", string language = "en", string codes = "", int offset = 0, int limit = 0)
        {
            var path = new Paths.Pickups();

            var @params = new List<Tuple<string, string>>
            {
                new Tuple<string, string>(path.GetParams().Fields, fields),
                new Tuple<string, string>(path.GetParams().Language, language),
                new Tuple<string, string>(path.GetParams().Codes, codes),
                new Tuple<string, string>(path.GetParams().Offset, offset.ToString()),
                new Tuple<string, string>(path.GetParams().Limit, limit.ToString())
            };

            var response = _api.CallRemoteApi<CurrencyResponse>(path, @params);
            return response;
        }

        public MasterTransferTypeResponse TransferType(string fields = "ALL", string language = "en", string codes = "", int offset = 0, int limit = 0)
        {
            var path = new Paths.MasterTransferType();

            var @params = new List<Tuple<string, string>>
            {
                new Tuple<string, string>(path.GetParams().Fields, fields),
                new Tuple<string, string>(path.GetParams().Language, language),
                new Tuple<string, string>(path.GetParams().Codes, codes),
                new Tuple<string, string>(path.GetParams().Offset, offset.ToString()),
                new Tuple<string, string>(path.GetParams().Limit, limit.ToString())
            };

            var response = _api.CallRemoteApi<MasterTransferTypeResponse>(path, @params);
            return response;
        }

        public MasterCategoriesResponse Categories(string fields = "ALL", string language = "en", string codes = "", int offset = 0, int limit = 0)
        {
            var path = new Paths.MasterCategories();

            var @params = new List<Tuple<string, string>>
            {
                new Tuple<string, string>(path.GetParams().Fields, fields),
                new Tuple<string, string>(path.GetParams().Language, language),
                new Tuple<string, string>(path.GetParams().Codes, codes),
                new Tuple<string, string>(path.GetParams().Offset, offset.ToString()),
                new Tuple<string, string>(path.GetParams().Limit, limit.ToString())
            };

            var response = _api.CallRemoteApi<MasterCategoriesResponse>(path, @params);
            return response;
        }

        public MasterVehiclesResponse Vehicles(string fields = "ALL", string language = "en", string codes = "", int offset = 0, int limit = 0)
        {
            var path = new Paths.MasterVehicles();

            var @params = new List<Tuple<string, string>>
            {
                new Tuple<string, string>(path.GetParams().Fields, fields),
                new Tuple<string, string>(path.GetParams().Language, language),
                new Tuple<string, string>(path.GetParams().Codes, codes),
                new Tuple<string, string>(path.GetParams().Offset, offset.ToString()),
                new Tuple<string, string>(path.GetParams().Limit, limit.ToString())
            };

            var response = _api.CallRemoteApi<MasterVehiclesResponse>(path, @params);
            return response;
        }

        public CountriesResponse Countries(string fields = "ALL", string language = "en", string codes = "", int offset = 0, int limit = 0)
        {
            var path = new Paths.Countries();

            var @params = new List<Tuple<string, string>>
            {
                new Tuple<string, string>(path.GetParams().Fields, fields),
                new Tuple<string, string>(path.GetParams().Language, language),
                new Tuple<string, string>(path.GetParams().Codes, codes),
                new Tuple<string, string>(path.GetParams().Offset, offset.ToString()),
                new Tuple<string, string>(path.GetParams().Limit, limit.ToString())
            };

            var response = _api.CallRemoteApi<CountriesResponse>(path, @params);
            return response;
        }

        public DestinationsResponse Destinations(string fields = "ALL", string language = "en", string countryCode = "", string codes = "", int offset = 0, int limit = 0)
        {
            var path = new Paths.Destinations();

            var @params = new List<Tuple<string, string>>
            {
                new Tuple<string, string>(path.GetParams().Fields, fields),
                new Tuple<string, string>(path.GetParams().Language, language),
                new Tuple<string, string>(path.GetParams().Country, countryCode),
                new Tuple<string, string>(path.GetParams().Codes, codes),
                new Tuple<string, string>(path.GetParams().Offset, offset.ToString()),
                new Tuple<string, string>(path.GetParams().Limit, limit.ToString())
            };

            var response = _api.CallRemoteApi<DestinationsResponse>(path, @params);
            return response;
        }

        public TerminalsResponse Terminals(string fields = "ALL", string language = "en", string countryCode = "", string codes = "", int offset = 0, int limit = 0)
        {
            var path = new Paths.Terminals();

            var @params = new List<Tuple<string, string>>
            {
                new Tuple<string, string>(path.GetParams().Fields, fields),
                new Tuple<string, string>(path.GetParams().Language, language),
                new Tuple<string, string>(path.GetParams().Country, countryCode),
                new Tuple<string, string>(path.GetParams().Codes, codes),
                new Tuple<string, string>(path.GetParams().Offset, offset.ToString()),
                new Tuple<string, string>(path.GetParams().Limit, limit.ToString())
            };

            var response = _api.CallRemoteApi<TerminalsResponse>(path, @params);
            return response;
        }
    }
}
