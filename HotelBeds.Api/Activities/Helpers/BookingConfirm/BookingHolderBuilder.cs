namespace HotelBeds.Api.Activities.Helpers.BookingConfirm
{
    public class BookingHolderBuilder
    {
        private BookingHolderCompleter _completer;
        public BookingHolderCompleter Holder(string name, string surname)
        {
            _completer = new BookingHolderCompleter("", name, surname);
            return _completer;
        }
        public BookingHolderCompleter Mr(string name, string surname)
        {
            _completer = new BookingHolderCompleter("Mr", name, surname);
            return _completer;
        }

        public BookingHolderCompleter Ms(string name, string surname)
        {
            _completer = new BookingHolderCompleter("Ms", name, surname);
            return _completer;
        }

        public BookingHolderCompleter Miss(string name, string surname)
        {
            _completer = new BookingHolderCompleter("Miss", name, surname);
            return _completer;
        }

        public BookingHolderCompleter GetCompleter()
        {
            return _completer;
        }
    }
}