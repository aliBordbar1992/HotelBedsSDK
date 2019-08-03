using System;

namespace HotelBeds.Api.Activities.Helpers.BookingConfirm
{
    public class BookingConfirmRequestBuilder
    {
        private readonly string _clientReference;
        private readonly string _language;

        public BookingConfirmRequestBuilder(string clientReference, string language = "")
        {
            _clientReference = clientReference;
            _language = language;
        }

        public BookingConfirmRequestActivityBuilder WithAHolder(Action<BookingHolderBuilder> holderBuilder)
        {
            var b = new BookingHolderBuilder();
            holderBuilder(b);
            var completer = b.GetCompleter();
            var holder = completer.Build();

            return new BookingConfirmRequestActivityBuilder(holder, _clientReference, _language);
        }
    }
}
