namespace HotelBeds.Shared.Activities.Request
{
    public class BookingReconfirmRequest
    {
        public string Reference { get; set; }
        public string Language { get; set; }

        public BookingReconfirmRequest(string reference, string language)
        {
            this.Reference = reference;
            this.Language = language;
        }
    }
}