namespace HotelBeds.Shared.TransferContent.Dto
{
    public class Terminal
    {
        public string Code { get; set; }
        public Content Content { get; set; }
        public string CountryCode { get; set; }
        public Coordinate Coordinate { get; set; }
        public string Language { get; set; }
    }
}