namespace HotelBeds.Activities.Api.Model.Search.Filters
{
    public class CountryFilter : SearchFilterItem
    {
        public CountryFilter(string value) : base(FilterType.Country, value)
        {
        }
    }
}