using System.Collections.Generic;
using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Api.Activities.Helpers.RequestFilter
{
    public class FilterHolder
    {
        public ActivitySearchFilterItemList ActiveList { get; set; }

        private readonly List<ActivitySearchFilterItemList> _filterList;
        private List<ActivitySearchFilterItem> _filterItems;

        public FilterHolder()
        {
            _filterList = new List<ActivitySearchFilterItemList>();
            _filterItems = new List<ActivitySearchFilterItem>();
        }

        public void FlushActive()
        {
            ActiveList.SearchFilterItems = GetFilters();
            _filterList.Add(ActiveList);
            _filterItems = new List<ActivitySearchFilterItem>();

            ActiveList = null;
        }

        public List<ActivitySearchFilterItemList> GetFilterList()
        {
            return _filterList;
        }

        public void AddFilterItems(List<ActivitySearchFilterItem> filters)
        {
            _filterItems.AddRange(filters);
        }
        public void AddFilterItem(ActivitySearchFilterItem filter)
        {
            _filterItems.Add(filter);
        }

        public List<ActivitySearchFilterItem> GetFilters()
        {
            return _filterItems;
        }
    }
}