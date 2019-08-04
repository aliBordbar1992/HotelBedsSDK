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
        ISearchRequestFilterTypeCompleter Country(string value);
        ISearchRequestFilterTypeCompleter Service(string value);
        ISearchRequestFilterTypeCompleter ServiceModality(string value);
        ISearchRequestFilterTypeCompleter Segment(string destination, string segment);
        ISearchRequestFilterTypeCompleter PriceRange(string from, string to);
        RequestFilterItemSelector<TFilter> ListOf<TFilter>(IList<TFilter> filters);
    }
}