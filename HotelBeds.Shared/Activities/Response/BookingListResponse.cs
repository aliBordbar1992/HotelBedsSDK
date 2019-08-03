using System.Collections.Generic;
using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Shared.Activities.Response
{
    public class BookingListResponse : BaseResponse
    {
        public List<Booking> Bookings { get; set; }
        public PaginationResponse Pagination { get; set; }
    }
}