using System.Collections.Generic;
using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Api.Activities.Helpers.RequestFilter
{
    public class SearchRequestFilterTypeCompleter : ISearchRequestFilterTypeCompleter
    {
        private readonly FilterHolder _holder;
        private readonly List<ActivitySearchFilterItemList> _filters;
        private readonly ActivitySearchFilterItemList _filter;

        public SearchRequestFilterTypeCompleter(FilterHolder holder)
        {
            _holder = holder;
            _filters = new List<ActivitySearchFilterItemList>();
            _filter = new ActivitySearchFilterItemList { SearchFilterItems = holder.GetFilters()};
        }

        public ISearchRequestFilterTypeSelector And()
        {
            return new SearchRequestFilterTypeSelector(_holder);
        }

        public SearchRequestFilterBuilder Or()
        {
            _holder.FlushActive();

            return new SearchRequestFilterBuilder(_holder);
        }

        public List<ActivitySearchFilterItemList> Build()
        {
            _holder.FlushActive();
            return _holder.GetFilterList();
        }
    }
}