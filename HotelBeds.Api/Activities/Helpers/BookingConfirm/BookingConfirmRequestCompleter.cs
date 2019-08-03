using System.Collections.Generic;
using HotelBeds.Shared.Activities.Dto;
using HotelBeds.Shared.Activities.Request;

namespace HotelBeds.Api.Activities.Helpers.BookingConfirm
{
    public class BookingConfirmRequestCompleter
    {
        private readonly List<BookingConfirmService> _activities;
        private readonly BookingHolder _holder;
        private readonly string _clientReference;
        private readonly string _language;

        public BookingConfirmRequestCompleter(List<BookingConfirmService> activities, BookingHolder holder, string clientReference, string language)
        {
            _activities = activities;
            _holder = holder;
            _clientReference = clientReference;
            _language = language;
        }

        public BookingConfirmRequest Build()
        {
            return new BookingConfirmRequest(_language, _clientReference, _holder, _activities);
        }
    }
}