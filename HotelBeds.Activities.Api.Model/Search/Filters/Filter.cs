using System.Collections.Generic;
using Newtonsoft.Json;

namespace HotelBeds.Activities.Api.Model.Search.Filters
{
    public class Filter
    {
        [JsonProperty("searchFilterItems")]
        private readonly List<SearchFilterItem> _searchFilterItems;


        public Filter()
        {
            _searchFilterItems = new List<SearchFilterItem>();
        }

        public void AddFilter(SearchFilterItem filterItem)
        {
            _searchFilterItems.Add(filterItem);
        }

        public List<SearchFilterItem> GetFilterItems()
        {
            return _searchFilterItems;
        }

        public void AddFilters(SearchFilterItems filterItems)
        {
            foreach (SearchFilterItem filterItem in filterItems.FilterItems)
            {
                AddFilter(filterItem);
            }
        }
    }
}