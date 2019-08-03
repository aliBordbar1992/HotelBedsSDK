using System;
using System.Collections.Generic;
using HotelBeds.Shared.Activities.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Booking
    {
        public DateTime CreationDate { get; set; }
        public string CreationUser { get; set; }
        public PaymentData PaymentData { get; set; }
        public string ClientReference { get; set; }
        public BookingHolder Holder { get; set; }
        public decimal Total { get; set; }
        public decimal TotalNet { get; set; }
        public List<PurchasedService> Activities { get; set; }
        public string Reference { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public BookingStatus Status { get; set; }
        public string Currency { get; set; }
        public decimal PendingAmount { get; set; }
        public PaymentInformationResponse PaymentInformation { get; set; }
        public List<BookingTransaction> Transactions { get; set; }
    }
}