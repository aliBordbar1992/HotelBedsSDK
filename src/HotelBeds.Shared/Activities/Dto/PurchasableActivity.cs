using System.Collections.Generic;
using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Converters;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Activities.Dto
{
    public class PurchasableActivity
    {
        public string ActivityCode { get; set; }
        public string Url { get; set; }
        public Country Country { get; set; }
        public List<OperationDay> OperationDays { get; set; }
        public List<Modality> Modalities { get; set; }
        public int OriginServices { get; set; }
        public string CurrencyName { get; set; }
        public List<PaxPrice> AmountsFrom { get; set; }
        public FactsheetActivity Content { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string Code { get; set; }
        public string ContentId { get; set; }
        [JsonConverter(typeof(EnumTypeConverter<ActivityType>))]
        public ActivityType Type { get; set; }

    }
}