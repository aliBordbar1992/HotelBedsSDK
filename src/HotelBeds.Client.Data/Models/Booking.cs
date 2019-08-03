using System;

namespace HotelBeds.Client.Data.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string ClientReference { get; set; }
        public string Reference { get; set; }
        public string Status { get; set; }
        public string HolderName { get; set; }
        public string HolderSurname { get; set; }
    }
}