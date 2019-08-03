using System.Collections.Generic;

namespace HotelBeds.Shared.Activities.Dto
{
    public class PriceBreakdown
    {
        public List<Supplement> RateSupplements { get; set; }
        public List<Supplement> RateDiscounts { get; set; }
        public List<Fee> RateFees { get; set; }
    }
}