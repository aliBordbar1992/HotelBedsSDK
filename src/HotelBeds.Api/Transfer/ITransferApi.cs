using System.Collections.Generic;
using System.Security;
using HotelBeds.Shared.Transfer.Dto;
using HotelBeds.Shared.Transfer.Request;
using HotelBeds.Shared.Transfer.Response;

namespace HotelBeds.Api.Transfer
{
    public interface ITransferApi
    {
        AvailabilityResponse Availability(AvailabilityRequest request);
        AvailabilityResponse AvailabilityRoutes(List<RouteRequest> routeRequests, string language, int adults, int children, int infants);

        BookingResponse Confirm(ConfirmRequest request);
        BookingResponse Details(string language, string reference);
        BookingResponse Cancel(string language, string reference);

        List<Voucher> GenerateVoucher(List<Booking> booking);
    }
}