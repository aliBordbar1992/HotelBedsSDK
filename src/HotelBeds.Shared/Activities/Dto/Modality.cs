using System.Collections.Generic;
using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Converters;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Modality
    {
        public Duration Duration { get; set; }
        public List<QuestionDetail> Questions { get; set; }
        public List<Comment> Comments { get; set; }
        public SupplierInformation SupplierInformation { get; set; }
        public ProviderInformation ProviderInformation { get; set; }
        public string DestinationCode { get; set; }
        public int MinChildrenAge { get; set; }
        public int MaxChildrenAge { get; set; }
        public List<Promotion> Promotions { get; set; }
        public List<Language> Languages { get; set; }
        public List<PaxPrice> AmountsFrom { get; set; }
        public List<Rate> Rates { get; set; }

        [JsonConverter(typeof(EnumTypeConverter<ModalityUnitType, ModalityUnitType>))]
        public ModalityUnitType AmountUnitType { get; set; }
        public FactsheetActivity SpecificContent { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}