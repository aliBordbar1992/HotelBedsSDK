using System.Collections.Generic;

namespace HotelBeds.Shared.Activities.Dto
{
    public class RateDetail
    {
        public string RateKey { get; set; }
        public string RetrieveSeatingKey { get; set; }
        public string RetrievePickupsKey { get; set; }
        public List<OperationDate> OperationDates { get; set; }
        public List<Language> Languages { get; set; }
        public List<Session> Sessions { get; set; }
        public Duration MinimumDuration { get; set; }
        public Duration MaximumDuration { get; set; }
        public PaxPrice TotalAmount { get; set; }
        public List<PaxPrice> PaxAmounts { get; set; }
        public AgencyCommission AgencyCommission { get; set; }
        public ActivityPickup Pickup { get; set; }
    }
}