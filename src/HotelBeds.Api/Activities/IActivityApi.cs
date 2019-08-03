using System;
using HotelBeds.Shared.Activities.Dto;
using HotelBeds.Shared.Activities.Request;
using HotelBeds.Shared.Activities.Response;

namespace HotelBeds.Api.Activities
{
    public interface IActivityApi
    {
        ActivitySearchResponse Search(ActivitySearchRequest request);
        ActivityDetailResponse Details(ActivityDetailRequest request);
        ActivityDetailResponse FullDetails(ActivityDetailRequest request);
        BookingResponse ConfirmBooking(BookingConfirmRequest request);
        BookingResponse PreConfirmBooking(BookingConfirmRequest request);
        BookingResponse ReconfirmBooking(BookingReconfirmRequest request);
        BookingResponse CancelBooking(string language, string reference, bool simulation);
        BookingResponse BookingDetails(string language, string bookingReference);
        BookingResponse BookingDetails(string language, string clientReference, string holderName, string holderSurname, DateTime startDate, DateTime endDate);
        BookingListResponse BookingList(string language, DateTime startDate, DateTime endDate, FilterType filterType,bool includeCancelled);
        BookingResponse ModifyBookingAddService(BookingModificationAddRequest request, string language, string reference);
        BookingResponse ModifyBookingModifyService(BookingModificationModifyRequest request, string language, string reference);
        GeneratedVoucher GenerateVoucher(Booking booking);

    }
}