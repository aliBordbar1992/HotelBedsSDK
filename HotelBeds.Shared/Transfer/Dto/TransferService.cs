using System.Collections.Generic;
using HotelBeds.Shared.Converters;
using HotelBeds.Shared.Transfer.Domain;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Transfer.Dto
{
    public class TransferService
    {
        public long Id { get; set; }

        [JsonConverter(typeof(EnumTypeConverter<TransferStatusType, TransferStatusType>))]
        public TransferStatusType Status { get; set; }

        [JsonConverter(typeof(EnumTypeConverter<DirectionType, DirectionType>))]
        public DirectionType Direction { get; set; }

        [JsonConverter(typeof(EnumTypeConverter<TransferPrivacyType, TransferPrivacyType>))]
        public TransferPrivacyType TransferType { get; set; }

        public Category Vehicle { get; set; }
        public Category Category { get; set; }
        public PickupInformation PickupInformation { get; set; }
        public List<Pax> Paxes { get; set; }
        public TransferServiceContent Content { get; set; }
        public Price Price { get; set; }
        public List<CancellationPolicy> CancellationPolicies { get; set; }
        public long FactsheetId { get; set; }
        public string ArrivalFlightNumber { get; set; }
        public string DepartureFlightNumber { get; set; }
        public string ArrivalShipName { get; set; }
        public string DepartureShipName { get; set; }
        public TrainInfo ArrivalTrainInfo { get; set; }
        public TrainInfo DepartureTrainInfo { get; set; }
        public List<TransferDetail> TransferDetails { get; set; }
        public string SourceMarketEmergencyNumber { get; set; }
        public List<Link> Links { get; set; }
        public long? MinPaxCapacity { get; set; }
        public long? MaxPaxCapacity { get; set; }
        public string RateKey { get; set; }
    }
}