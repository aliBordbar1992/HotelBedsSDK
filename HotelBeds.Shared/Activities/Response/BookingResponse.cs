using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Shared.Activities.Response
{
    public class BookingResponse : BaseResponse
    {
        public Booking Booking { get; set; }
    }
}