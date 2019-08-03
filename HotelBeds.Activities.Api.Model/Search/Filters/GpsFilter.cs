namespace HotelBeds.Activities.Api.Model.Search.Filters
{
    public class GpsFilter : SearchFilterItem
    {
        public GpsFilter(float latitude, float longitude): base(FilterType.Gps, latitude, longitude)
        {
            
        }
    }
}