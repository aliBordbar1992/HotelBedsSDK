using System;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Voucher
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string CustomerId { get; set; }
        public string Code { get; set; }
        public string Language { get; set; }
        public string Url { get; set; }
        public string MimeType { get; set; }
    }
}