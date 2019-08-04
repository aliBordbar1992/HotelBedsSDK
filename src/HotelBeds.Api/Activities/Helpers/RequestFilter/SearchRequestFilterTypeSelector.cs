using System.Collections.Generic;
using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Api.Activities.Helpers.RequestFilter
{
    public class SearchRequestFilterTypeSelector : ISearchRequestFilterTypeSelector
    {
        private readonly ActivitySearchFilterItemList _filter;
        private readonly FilterHolder _holder;


        public SearchRequestFilterTypeSelector()
        {
            _filter = new ActivitySearchFilterItemList();
            _holder = new FilterHolder(){ ActiveList = _filter };
        }

        public SearchRequestFilterTypeSelector(FilterHolder holder)
        {
            _filter = new ActivitySearchFilterItemList();
            _holder = holder;
            if (_holder.ActiveList == null) _holder.ActiveList = _filter;
        }

        public ISearchRequestFilterTypeCompleter TypeOf(string type, string value)
        {
            var item = new ActivitySearchFilterItem(ActivityFilterType.FromCode(type), value);
            return Completer(item);
        }

        public ISearchRequestFilterTypeCompleter TypeOf(string type, decimal lat, decimal @long)
        {
            var item = new ActivitySearchFilterItem(ActivityFilterType.FromCode(type), lat, @long);
            return Completer(item);
        }

        public ISearchRequestFilterTypeCompleter Hotel(string value)
        {
            var item = new ActivitySearchFilterItem(ActivityFilterType.Hotel, value);
            return Completer(item);
        }

        public ISearchRequestFilterTypeCompleter HotelGiata(string value)
        {
            var item = new ActivitySearchFilterItem(ActivityFilterType.HotelGiata, value);
            return Completer(item);
        }

        public ISearchRequestFilterTypeCompleter HotelTti(string value)
        {
            var item = new ActivitySearchFilterItem(ActivityFilterType.HotelTti, value);
            return Completer(item);
        }

        public ISearchRequestFilterTypeCompleter Destination(string value)
        {
            var item = new ActivitySearchFilterItem(ActivityFilterType.Destination, value);
            return Completer(item);
        }

        public ISearchRequestFilterTypeCompleter DestinationIso(string value)
        {
            var item = new ActivitySearchFilterItem(ActivityFilterType.DestinationIso, value);
            return Completer(item);
        }

        public ISearchRequestFilterTypeCompleter Gps(decimal lat, decimal @long)
        {
            var item = new ActivitySearchFilterItem(ActivityFilterType.Gps, lat, @long);
            return Completer(item);
        }

        public ISearchRequestFilterTypeCompleter Factsheet(string value)
        {
            var item = new ActivitySearchFilterItem(ActivityFilterType.Factsheed, value);
            return Completer(item);
        }

        public ISearchRequestFilterTypeCompleter Text(string value)
        {
            var item = new ActivitySearchFilterItem(ActivityFilterType.Text, value);
            return Completer(item);
        }

        public ISearchRequestFilterTypeCompleter Country(string value)
        {
            var item = new ActivitySearchFilterItem(ActivityFilterType.Country, value);
            return Completer(item);
        }

        public ISearchRequestFilterTypeCompleter Service(string value)
        {
            var item = new ActivitySearchFilterItem(ActivityFilterType.Service, value);
            return Completer(item);
        }

        public ISearchRequestFilterTypeCompleter ServiceModality(string value)
        {
            var item = new ActivitySearchFilterItem(ActivityFilterType.ServiceModality, value);
            return Completer(item);
        }

        public ISearchRequestFilterTypeCompleter Segment(string destination, string segment)
        {
            var item = ActivitySearchFilterItem.SegmentFilterItems(destination, segment);
            _filter.SearchFilterItems.AddRange(item);
            _holder.AddFilterItems(item);

            return new SearchRequestFilterTypeCompleter(_holder);
        }

        public ISearchRequestFilterTypeCompleter PriceRange(string f, string t)
        {
            var item = ActivitySearchFilterItem.PriceFilterItems(f, t);
            _filter.SearchFilterItems.AddRange(item);
            _holder.AddFilterItems(item);

            return new SearchRequestFilterTypeCompleter(_holder);
        }

        private ISearchRequestFilterTypeCompleter Completer(ActivitySearchFilterItem item)
        {
            _filter.SearchFilterItems.Add(item);
            _holder.AddFilterItem(item);

            return new SearchRequestFilterTypeCompleter(_holder);
        }
    }
}