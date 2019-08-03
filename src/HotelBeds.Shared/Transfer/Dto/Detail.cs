using HotelBeds.Shared.Transfer.Request;

namespace HotelBeds.Shared.Transfer.Dto
{
    public class Detail
    {
        public string ArrivalFlightNumber { get; set; }
        public string ArrivalShipName { get; set; }
        public TrainInfo ArrivalTrainInfo { get; set; }
        public string DepartureFlightNumber { get; set; }
        public string DepartureShipName { get; set; }
        public TrainInfo DepartureTrainInfo { get; set; }
    }
}