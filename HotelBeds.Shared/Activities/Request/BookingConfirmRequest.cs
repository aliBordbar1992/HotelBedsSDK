using System.Collections.Generic;
using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Shared.Activities.Request
{
    public class BookingConfirmRequest
    {
        public string Language { get; set; }
        public string ClientReference { get; set; }
        public BookingHolder Holder { get; set; }
        public List<BookingConfirmService> Activities { get; set; }

        public BookingConfirmRequest(string language,
            string clientReference, BookingHolder holder,
            List<BookingConfirmService> activities)
        {
            Language = language;
            ClientReference = clientReference;
            Holder = holder;
            Activities = activities;
        }
    }
}