using HotelBeds.Shared.Converters;
using Newtonsoft.Json;

namespace HotelBeds.Shared.TransferContent.Dto
{
    public class Route
    {
        public string Code { get; set; }
        public RoutePoint From { get; set; }
        public RoutePoint To { get; set; }
    }

    public class RoutePoint
    {
        public string Code { get; set; }
        [JsonConverter(typeof(EnumTypeConverter<TransferPointType>))]
        public TransferPointType Type { get; set; }
    }
}