using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Converters;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Activities.Dto
{
    public class PaxDistribution
    {
        public int Age { get; set; }
        [JsonConverter(typeof(EnumTypeConverter<PaxType, PaxType>))]
        public PaxType Type { get; set; }
    }
}