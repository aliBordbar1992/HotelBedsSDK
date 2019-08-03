namespace HotelBeds.Shared.Transfer.Dto
{
    public class Pickup
    {
        public string Address { get; set; }
        public object Number { get; set; }
        public string Town { get; set; }
        public string Zip { get; set; }
        public string Description { get; set; }
        public double? Altitude { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public CheckPickup CheckPickup { get; set; }
        public long PickupId { get; set; }
        public string StopName { get; set; }
        public string Image { get; set; }
    }
}