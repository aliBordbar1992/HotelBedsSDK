namespace HotelBeds.Activities.Api.Model.Search.Filters
{
    public class TextFilter : SearchFilterItem
    {
        public TextFilter(string value) : base(FilterType.Text, value)
        {
            
        }
    }
}