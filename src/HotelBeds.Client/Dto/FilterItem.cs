namespace HotelBeds.Client.Dto
{
    public class FilterItem
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
    }
}