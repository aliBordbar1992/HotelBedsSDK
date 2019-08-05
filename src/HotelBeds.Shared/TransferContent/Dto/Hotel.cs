using System.Collections.Generic;

namespace HotelBeds.Shared.TransferContent.Dto
{
    public class Hotel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string CountryCode { get; set; }
        public string DestinationCode { get; set; }
        public string City { get; set; }
        public Coordinate Coordinates { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public List<string> Terminals { get; set; }
    }
}