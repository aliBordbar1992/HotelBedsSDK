namespace HotelBeds.Shared.TransferContent.Dto
{
    public class Pickup
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string HotelCode { get; set; }
        public string IsTerminal { get; set; }
        public string CompanyCode { get; set; }
        public int OfficeCode { get; set; }
        public int ReceptiveCode { get; set; }
        public string ServiceType { get; set; }
        public string CountryCode { get; set; }
        public string ProviderCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string ZoneCode { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public bool WebCheckPickup { get; set; }
    }
}