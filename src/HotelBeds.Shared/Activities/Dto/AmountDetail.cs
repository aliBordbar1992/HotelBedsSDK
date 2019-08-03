using System.Collections.Generic;

namespace HotelBeds.Shared.Activities.Dto
{
    public class AmountDetail
    {
        public List<PaxPrice> PaxAmounts { get; set; }
        public PaxPrice TotalAmount { get; set; }
    }
}