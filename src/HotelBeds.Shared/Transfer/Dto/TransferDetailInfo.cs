using HotelBeds.Shared.Converters;
using HotelBeds.Shared.Transfer.Domain;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Transfer.Dto
{
    public class TransferDetailInfo
    {
        public string Description { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        [JsonConverter(typeof(EnumTypeConverter<TransferDetailsType, TransferDetailsType>))]
        public TransferDetailsType Type { get; set; }
    }
}