using System.Collections.Generic;
using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Api.Activities.Helpers.RequestFilter
{
    public class SearchRequestFilterBuilder
    {
        private readonly List<ActivitySearchFilterItemList> _filters;
        private readonly ActivitySearchFilterItemList _filter;
        private readonly FilterHolder _holder;

        public SearchRequestFilterBuilder()
        {
            _filters = new List<ActivitySearchFilterItemList>();
            _filter = new ActivitySearchFilterItemList();
            _holder = null;
        }

        public SearchRequestFilterBuilder(FilterHolder holder)
        {
            _holder = holder;
            _filters = new List<ActivitySearchFilterItemList>();
            _filter = new ActivitySearchFilterItemList { SearchFilterItems = holder.GetFilters() };

        }

        public ISearchRequestFilterTypeSelector With()
        {
            return _holder == null ? new SearchRequestFilterTypeSelector() : new SearchRequestFilterTypeSelector(_holder);
        }
    }
}