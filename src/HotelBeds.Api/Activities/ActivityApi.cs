using System;
using System.Collections.Generic;
using HotelBeds.Shared.Activities.Dto;
using HotelBeds.Shared.Activities.Request;
using HotelBeds.Shared.Activities.Response;

namespace HotelBeds.Api.Activities
{
    public class ActivityApi : IActivityApi
    {
        private readonly IHotelBedsApiClient _api;

        public ActivityApi(IHotelBedsApiClient api)
        {
            _api = api;
        }

        public ActivitySearchResponse Search(ActivitySearchRequest request)
        {
            var path = new Paths.ActivitySearch();
            var response =
                _api.CallRemoteApi<ActivitySearchRequest, ActivitySearchResponse>(request, path, null);

            return response;
        }

        public ActivityDetailResponse Details(ActivityDetailRequest request)
        {
            var path = Paths.ActivityDetails.Simple();
            var response =
                _api.CallRemoteApi<ActivityDetailRequest, ActivityDetailResponse>(request, path, null);

            return response;
        }

        public ActivityDetailResponse FullDetails(ActivityDetailRequest request)
        {
            var path = Paths.ActivityDetails.Full();
            var response = _api.CallRemoteApi<ActivityDetailRequest, ActivityDetailResponse>(request, path, null);

            return response;
        }

        public BookingResponse ConfirmBooking(BookingConfirmRequest request)
        {
            var path = new Paths.BookingConfirm();
            var response =
                _api.CallRemoteApi<BookingConfirmRequest, BookingResponse>(request, path, null);

            return response;
        }

        public BookingResponse PreConfirmBooking(BookingConfirmRequest request)
        {
            var path = new Paths.BookingPreConfirm();
            var response =
                _api.CallRemoteApi<BookingConfirmRequest, BookingResponse>(request, path, null);

            return response;
        }

        public BookingResponse ReconfirmBooking(BookingReconfirmRequest request)
        {
            var path = new Paths.BookingReConfirm();
            var response =
                _api.CallRemoteApi<BookingReconfirmRequest, BookingResponse>(request, path, null);

            return response;
        }

        public BookingResponse CancelBooking(string language, string reference, bool simulation)
        {
            var path = new Paths.Cancel();
            var response =
                _api.CallRemoteApi<BookingResponse>(path, new List<Tuple<string, string>>
                {
                    new Tuple<string, string>(path.GetParams().Lang, language),
                    new Tuple<string, string>(path.GetParams().Reference, reference),
                    new Tuple<string, string>(path.GetParams().SimulationOrCancel, simulation ? "SIMULATION" : "CANCELLATION")
                });

            return response;
        }

        public BookingResponse BookingDetails(string language, string bookingReference)
        {
            var path = new Paths.BookingDetailsByBookingReference();
            var response =
                _api.CallRemoteApi<BookingResponse>(path, new List<Tuple<string, string>>
                {
                    new Tuple<string, string>(path.GetParams().Lang, language),
                    new Tuple<string, string>(path.GetParams().BookingReference, bookingReference)
                });

            return response;
        }

        public BookingResponse BookingDetails(string language, string clientReference, string holderName, string holderSurname,
            DateTime startDate, DateTime endDate)
        {
            var path = new Paths.BookingDetailsByClientReference();
            var response =
                _api.CallRemoteApi<BookingResponse>(path, new List<Tuple<string, string>>
                {
                    new Tuple<string, string>(path.GetParams().Lang, language),
                    new Tuple<string, string>(path.GetParams().ClientReference, clientReference),
                    new Tuple<string, string>(path.GetParams().HolderName, holderName),
                    new Tuple<string, string>(path.GetParams().HolderSurname, holderSurname),
                    new Tuple<string, string>(path.GetParams().StartDate, startDate.ToString("YYYY-MM-dd")),
                    new Tuple<string, string>(path.GetParams().EndDate, endDate.ToString("YYYY-MM-dd"))
                });

            return response;
        }

        public BookingListResponse BookingList(string language, DateTime startDate, DateTime endDate, FilterType filterType,
            bool includeCancelled)
        {
            var path = new Paths.BookingList();
            var response =
                _api.CallRemoteApi<BookingListResponse>(path, new List<Tuple<string, string>>
                {
                    new Tuple<string, string>(path.GetParams().Lang, language),
                    new Tuple<string, string>(path.GetParams().StartDate, startDate.ToString("YYYY-MM-dd")),
                    new Tuple<string, string>(path.GetParams().EndDate, endDate.ToString("YYYY-MM-dd")),
                    new Tuple<string, string>(path.GetParams().IncludeCancelled, includeCancelled ? "cancelled" : "no"),
                    new Tuple<string, string>(path.GetParams().FilterType, filterType.ToString())
                });

            return response;
        }

        public BookingResponse ModifyBookingAddService(BookingModificationAddRequest request, string language, string reference)
        {
            var path = new Paths.BookingModificationAddRequest();
            var response = _api.CallRemoteApi<BookingModificationAddRequest, BookingResponse>(request, path,
                new List<Tuple<string, string>>
                {
                    new Tuple<string, string>(path.GetParams().Lang, language),
                    new Tuple<string, string>(path.GetParams().Reference, reference)
                });

            return response;
        }

        public BookingResponse ModifyBookingModifyService(BookingModificationModifyRequest request, string language, string reference)
        {
            var path = new Paths.BookingModificationModifyRequest();
            var response = _api.CallRemoteApi<BookingModificationModifyRequest, BookingResponse>(request, path,
                new List<Tuple<string, string>>
                {
                    new Tuple<string, string>(path.GetParams().Lang, language),
                    new Tuple<string, string>(path.GetParams().Reference, reference)
                });

            return response;
        }

        public GeneratedVoucher GenerateVoucher(Booking booking)
        {
            return new GeneratedVoucher(booking);
        }
    }
}