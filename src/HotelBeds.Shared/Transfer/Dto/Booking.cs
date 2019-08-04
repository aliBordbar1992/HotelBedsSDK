using System;
using System.Collections.Generic;
using HotelBeds.Shared.Converters;
using HotelBeds.Shared.Transfer.Domain;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Transfer.Dto
{
    public class Booking
    {
        public string Reference { get; set; }
        public string BookingFileId { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        [JsonConverter(typeof(EnumTypeConverter<TransferStatusType>))]
        public TransferStatusType Status { get; set; }
        public ModificationsPolicies ModificationsPolicies { get; set; }
        public Pax Holder { get; set; }
        public List<TransferService> Transfers { get; set; }
        public string ClientReference { get; set; }
        public string Currency { get; set; }
        public string Remark { get; set; }
        public InvoiceCompany InvoiceCompany { get; set; }
        public Supplier Supplier { get; set; }
        public long TotalAmount { get; set; }
        public long TotalNetAmount { get; set; }
        public long PendingAmount { get; set; }
        public List<Link> Links { get; set; }
    }
}