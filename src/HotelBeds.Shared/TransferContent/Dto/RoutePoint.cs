using HotelBeds.Shared.Converters;
using Newtonsoft.Json;

namespace HotelBeds.Shared.TransferContent.Dto
{
    public class RoutePoint
    {
        public string Code { get; set; }
        [JsonConverter(typeof(EnumTypeConverter<TransferPointType>))]
        public TransferPointType Type { get; set; }
    }
}