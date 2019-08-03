using System.Collections.Generic;
using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Api.Activities.Helpers.BookingConfirm
{
    public class BookingConfirmRequestActivityBuilder
    {
        private readonly BookingHolder _holder;
        private readonly string _clientReference;
        private readonly string _language;

        public BookingConfirmRequestActivityBuilder(BookingHolder holder, string clientReference, string language)
        {
            _holder = holder;
            _clientReference = clientReference;
            _language = language;
        }

        public BookingConfirmRequestCompleter WithActivities(List<BookingConfirmService> activities)
        {
            return new BookingConfirmRequestCompleter(activities, _holder, _clientReference, _language);
        }
    }
}