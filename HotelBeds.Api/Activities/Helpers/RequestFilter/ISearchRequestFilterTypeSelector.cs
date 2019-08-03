using System;
using System.Collections.Generic;

namespace HotelBeds.Api.Activities.Helpers.RequestFilter
{
    public interface ISearchRequestFilterTypeSelector
    {
        ISearchRequestFilterTypeCompleter TypeOf(string type, string value);
        ISearchRequestFilterTypeCompleter TypeOf(string type, decimal lat, decimal @long);

        ISearchRequestFilterTypeCompleter Hotel(string value);
        ISearchRequestFilterTypeCompleter HotelGiata(string value);
        ISearchRequestFilterTypeCompleter HotelTti(string value);
        ISearchRequestFilterTypeCompleter Destination(string value);
        ISearchRequestFilterTypeCompleter DestinationIso(string value);
        ISearchRequestFilterTypeCompleter Gps(decimal lat, decimal @long);
        ISearchRequestFilterTypeCompleter Factsheet(string value);
        ISearchRequestFilterTypeCompleter Text(string value);
        //ISearchRequestFilterTypeCompleter SegmentFilter(string value);
        ISearchRequestFilterTypeCompleter Country(string value);
        ISearchRequestFilterTypeCompleter Service(string value);
        ISearchRequestFilterTypeCompleter ServiceModality(string value);
        ISearchRequestFilterTypeCompleter Segment(string destination, string segment);
        ISearchRequestFilterTypeCompleter PriceRange(string from, string to);




        /*
public SearchRequestFilterBuilder WithHotel(string value) =>
            WithSearchItem(new ActivitySearchFilterItem(ActivityFilterType.Hotel, value));

        public SearchRequestFilterBuilder WithHotelGiata(string value) =>
            WithSearchItem(new ActivitySearchFilterItem(ActivityFilterType.HotelGiata, value));

        public SearchRequestFilterBuilder WithHotelTti(string value) =>
            WithSearchItem(new ActivitySearchFilterItem(ActivityFilterType.HotelTti, value));

        public SearchRequestFilterBuilder WithDestination(string value) =>
            WithSearchItem(new ActivitySearchFilterItem(ActivityFilterType.Destination, value));

        public SearchRequestFilterBuilder WithDestinationIso(string value) =>
            WithSearchItem(new ActivitySearchFilterItem(ActivityFilterType.DestinationIso, value));

        public SearchRequestFilterBuilder WithGps(decimal lat, decimal @long) =>
            WithSearchItem(new ActivitySearchFilterItem(ActivityFilterType.Gps, lat, @long));

        public SearchRequestFilterBuilder WithFactsheet(string value) =>
            WithSearchItem(new ActivitySearchFilterItem(ActivityFilterType.Factsheed, value));

        public SearchRequestFilterBuilder WithText(string value) =>
            WithSearchItem(new ActivitySearchFilterItem(ActivityFilterType.Text, value));

        private SearchRequestFilterBuilder WithSegmentFilter(string value) =>
            WithSearchItem(new ActivitySearchFilterItem(ActivityFilterType.Segment, value));

        public SearchRequestFilterBuilder WithCountry(string value) =>
            WithSearchItem(new ActivitySearchFilterItem(ActivityFilterType.Country, value));

        public SearchRequestFilterBuilder WithService(string value) =>
            WithSearchItem(new ActivitySearchFilterItem(ActivityFilterType.Hotel, value));

        public SearchRequestFilterBuilder WithServiceModality(string value) =>
            WithSearchItem(new ActivitySearchFilterItem(ActivityFilterType.ServiceModality, value));

        private SearchRequestFilterBuilder WithPriceFrom(string value) =>
            WithSearchItem(new ActivitySearchFilterItem(ActivityFilterType.PriceFrom, value));

        private SearchRequestFilterBuilder WithPriceTo(string value) =>
            WithSearchItem(new ActivitySearchFilterItem(ActivityFilterType.PriceTo, value));

        public SearchRequestFilterBuilder WithSegment(string destination, string segment) =>
            WithDestination(destination).WithSegmentFilter(segment);

        public SearchRequestFilterBuilder WithPriceRange(string from, string to)
        {
            return WithPriceFrom(from).WithPriceTo(to);
        }
         */
        SomeAwesomeClass<TFilter> ListOf<TFilter>(IList<TFilter> filters);
    }

    public class SomeAwesomeClass<TFilter>
    {
        public SomeAwesomeClass2<TFilterItem> WithItems<TFilterItem>(Func<TFilter, IList<TFilterItem>> filterItem)
        {
            return null;
        }
    }

    public class SomeAwesomeClass2<TFilterItem>
    {
        public ISearchRequestFilterTypeCompleter WithProperties(
            Func<TFilterItem, string> typeProp,
            Func<TFilterItem, string> valueProp,
            Func<TFilterItem, decimal?> latitudeProp,
            Func<TFilterItem, decimal?> longitudeProp)
        {
            return null;
        }
    }
}