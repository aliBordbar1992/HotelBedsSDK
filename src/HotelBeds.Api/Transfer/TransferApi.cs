using HotelBeds.Shared.Transfer.Request;
using HotelBeds.Shared.Transfer.Response;
using System;
using System.Collections.Generic;
using HotelBeds.Shared.Transfer.Dto;

namespace HotelBeds.Api.Transfer
{
    public class TransferApi : ITransferApi
    {
        private readonly IHotelBedsApiClient _api;

        public TransferApi(IHotelBedsApiClient api, ITransferApiBaseUrl baseUrl, ITransferVersionSelector versionSelector)
        {
            _api = api;
            _api.SetBaseUrl(baseUrl.GetUrl());
            _api.SetVersion(versionSelector);
        }

        public AvailabilityResponse Availability(AvailabilityRequest request)
        {
            var pathNoInbound = new Paths.AvailabilityNoInbound();
            var path = new Paths.Availability();

            var @params = new List<Tuple<string, string>>
            {
                new Tuple<string, string>(path.GetParams().Language, request.Language),
                new Tuple<string, string>(path.GetParams().Adults, request.Adults.ToString()),
                new Tuple<string, string>(path.GetParams().Children, request.Children.ToString()),
                new Tuple<string, string>(path.GetParams().Infants, request.Infants.ToString()),
                new Tuple<string, string>(path.GetParams().FromType, request.FromType.GetCode()),
                new Tuple<string, string>(path.GetParams().FromCode, request.FromCode),
                new Tuple<string, string>(path.GetParams().ToType, request.ToType.GetCode()),
                new Tuple<string, string>(path.GetParams().ToCode, request.ToCode),
                new Tuple<string, string>(path.GetParams().Outbound, request.Outbound)
            };

            if (request.Inbound == null)
            {
                var response = _api.CallRemoteApi<AvailabilityResponse>(pathNoInbound, @params);
                return response;
            }
            else
            {
                @params.Add(new Tuple<string, string>(path.GetParams().Inbound, request.Inbound));

                var response = _api.CallRemoteApi<AvailabilityResponse>(path, @params);
                return response;
            }


        }

        public AvailabilityResponse AvailabilityRoutes(List<RouteRequest> routeRequests, string language, int adults, int children, int infants)
        {
            var path = new Paths.AvailabilityRoutes();

            var @params = new List<Tuple<string, string>>
            {
                new Tuple<string, string>(path.GetParams().Language, language),
                new Tuple<string, string>(path.GetParams().Adults, adults.ToString()),
                new Tuple<string, string>(path.GetParams().Children, children.ToString()),
                new Tuple<string, string>(path.GetParams().Infants, infants.ToString())
            };

            var response = _api.CallRemoteApi<List<RouteRequest>, AvailabilityResponse>(routeRequests, path, @params);
            return response;
        }

        public BookingResponse Confirm(ConfirmRequest request)
        {
            var path = new Paths.BookingConfirm();

            var response = _api.CallRemoteApi<ConfirmRequest, BookingResponse>(request, path, null);
            return response;
        }

        public BookingResponse Details(string language, string reference)
        {
            var path = new Paths.ConfirmedBookingDetails();

            var @params = new List<Tuple<string, string>>
            {
                new Tuple<string, string>(path.GetParams().Language, language),
                new Tuple<string, string>(path.GetParams().Reference, reference)
            };

            var response = _api.CallRemoteApi<BookingResponse>(path, @params);
            return response;
        }

        public BookingResponse Cancel(string language, string reference)
        {
            var path = new Paths.CancelBooking();

            var @params = new List<Tuple<string, string>>
            {
                new Tuple<string, string>(path.GetParams().Language, language),
                new Tuple<string, string>(path.GetParams().Reference, reference)
            };

            var response = _api.CallRemoteApi<BookingResponse>(path, @params);
            return response;
        }

        public List<Voucher> GenerateVoucher(List<Booking> bookings)
        {
            List<Voucher> vouchers = new List<Voucher>();
            foreach (var booking in bookings)
            {
                vouchers.Add(new Voucher(booking));
            }

            return vouchers;
        }
    }
}