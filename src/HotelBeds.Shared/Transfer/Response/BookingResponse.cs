using System.Collections.Generic;
using HotelBeds.Shared.Transfer.Dto;

namespace HotelBeds.Shared.Transfer.Response
{
    public class BookingResponse : BaseResponse
    {
        public List<Booking> Bookings { get; set; }
    }
}