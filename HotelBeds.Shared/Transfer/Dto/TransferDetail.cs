using HotelBeds.Shared.Converters;
using HotelBeds.Shared.Transfer.Domain;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Transfer.Dto
{
    public class TransferDetail
    {
        public string Code { get; set; }
        public string CompanyName { get; set; }
        [JsonConverter(typeof(EnumTypeConverter<DirectionType, DirectionType>))]
        public DirectionType Direction { get; set; }
        [JsonConverter(typeof(EnumTypeConverter<TransferType, TransferType>))] 
        public TransferType Type { get; set; }
    }
}