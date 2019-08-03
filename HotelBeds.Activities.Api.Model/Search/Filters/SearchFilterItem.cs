using System.Collections.Generic;

namespace HotelBeds.Activities.Api.Model.Search.Filters
{
    public abstract class  SearchFilterItem
    {
        internal SearchFilterItem(string type, string value)
        {
            Value = value;
            Type = type;
            Latitude = null;
            Longitude = null;
        }
        internal SearchFilterItem(string type, float latitude, float longitude)
        {
            Type = type;
            Value = null;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Type { get; }
        public float? Latitude { get; }
        public float? Longitude { get; }
        public string Value { get; }
    }

    public abstract class SearchFilterItems
    {
        public List<SearchFilterItem> FilterItems { get;  }

        internal SearchFilterItems()
        {
            FilterItems = new List<SearchFilterItem>();
        }

        public void AddFilterItem(SearchFilterItem filterItem)
        {
            FilterItems.Add(filterItem);
        }
    }
}