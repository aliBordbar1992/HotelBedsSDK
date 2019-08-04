using System;
using System.Collections.Generic;
using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HotelBeds.Shared.Activities.Dto
{
    public class PurchasedService
    {
        public List<BundledService> Bundles { get; set; }
        public ActivityPickup Pickup { get; set; }
        public string Id { get; set; }
        public int RateKey { get; set; }
        public AgencyCommission AgencyCommission { get; set; }
        public string Currency { get; set; }
        public ContactInfo ContactInfo { get; set; }
        public AmountDetail AmountDetail { get; set; }
        public List<BookingExtraData> ExtraData { get; set; }
        public ProviderInformation ProviderInformation { get; set; }
        public FactsheetActivity Content { get; set; }
        public string ActivityReference { get; set; } // serviceReference
        public string Code { get; set; } // activityCode
        public string Name { get; set; } // activityName
        public Modality Modality { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public PriceBreakdown RateBreakdown { get; set; }
        public List<CancellationPolicy> CancellationPolicies { get; set; }
        public List<PaxResponse> Paxes { get; set; }
        public List<QuestionResponse> Questions { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public BookingStatus Status { get; set; }
        public SupplierInformation Supplier { get; set; }
        public List<Comment> Comments { get; set; }
        [JsonConverter(typeof(EnumTypeConverter<ActivityType>))]
        public ActivityType Type { get; set; }
        public string PriceType { get; set; }
        public string ExternalSupplierReference { get; set; }
        public List<Voucher> Vouchers { get; set; }
    }
}