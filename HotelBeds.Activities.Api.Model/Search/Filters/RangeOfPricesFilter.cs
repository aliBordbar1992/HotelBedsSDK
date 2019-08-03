using System.Collections.Generic;

namespace HotelBeds.Activities.Api.Model.Search.Filters
{
    

    public class RangeOfPricesFilter : SearchFilterItems
    {

        public RangeOfPricesFilter(string from, string to)
        {
            var fromPrice = new PriceFromFilter(from);
            var toPrice = new PriceToFilter(to);
            AddFilterItem(fromPrice);
            AddFilterItem(toPrice);
        }

        private class PriceToFilter : SearchFilterItem
        {
            public PriceToFilter(string value)  : base(FilterType.PriceTo, value)
            {
                
            }
        }

        private class PriceFromFilter : SearchFilterItem
        {
            public PriceFromFilter(string value) : base(FilterType.PriceFrom, value)
            {
                
            }
        }
    }
}