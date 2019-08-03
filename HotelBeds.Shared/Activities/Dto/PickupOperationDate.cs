using System;
using System.Collections.Generic;

namespace HotelBeds.Shared.Activities.Dto
{
    public class PickupOperationDate
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public PaxPrice TotalAmount { get; set; }
        public List<PaxPrice> PaxAmounts { get; set; }
        public List<PaxQuestion> PaxQuestions { get; set; }
        public List<CancellationPolicy> CancellationPolicies { get; set; }
    }
}