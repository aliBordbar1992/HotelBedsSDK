using HotelBeds.Shared.Converters;
using HotelBeds.Shared.Transfer.Domain;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Transfer.Dto
{
    public class TransferRemark
    {
        public string Description { get; set; }
        public bool Mandatory { get; set; }
        [JsonConverter(typeof(EnumTypeConverter<TransferRemarkType>))]
        public TransferRemarkType Type { get; set; }
    }
}