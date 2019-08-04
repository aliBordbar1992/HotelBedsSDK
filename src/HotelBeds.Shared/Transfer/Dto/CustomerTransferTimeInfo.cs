using HotelBeds.Shared.Converters;
using HotelBeds.Shared.Transfer.Domain;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Transfer.Dto
{
    public class CustomerTransferTimeInfo
    {
        public string Metric { get; set; }
        [JsonConverter(typeof(EnumTypeConverter<TransferTimeType>))]
        public TransferTimeType Type { get; set; }
        public long Value { get; set; }
    }
}