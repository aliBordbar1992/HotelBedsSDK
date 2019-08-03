using HotelBeds.Shared.Converters;
using HotelBeds.Shared.Transfer.Domain;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Transfer.Dto
{
    public class TransferPoint
    {
        public string Code { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(EnumTypeConverter<TransferPointType, TransferPointType>))]
        public TransferPointType Type { get; set; }
    }
}