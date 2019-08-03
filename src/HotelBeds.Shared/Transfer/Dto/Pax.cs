using HotelBeds.Shared.Converters;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Transfer.Dto
{
    public class Pax
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Age { get; set; }
        [JsonConverter(typeof(EnumTypeConverter<PaxType, PaxType>))]
        public PaxType Type { get; set; }
    }
}