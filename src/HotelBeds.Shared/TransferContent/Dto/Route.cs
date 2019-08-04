namespace HotelBeds.Shared.TransferContent.Dto
{
    public class Route
    {
        public string Code { get; set; }
        public RoutePoint From { get; set; }
        public RoutePoint To { get; set; }
    }
}