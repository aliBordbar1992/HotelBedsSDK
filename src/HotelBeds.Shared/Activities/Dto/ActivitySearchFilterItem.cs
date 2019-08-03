using System.Collections.Generic;
using HotelBeds.Shared.Activities.Domain;

namespace HotelBeds.Shared.Activities.Dto
{
    public class ActivitySearchFilterItem
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public ActivitySearchFilterItem()
        {
        }

        public ActivitySearchFilterItem(ActivityFilterType type, string value)
        {
            Type = type.GetCode();
            Value = value;
        }

        public ActivitySearchFilterItem(ActivityFilterType type, decimal latitude, decimal longitude)
        {
            Type = type.GetCode();
            Latitude = latitude;
            Longitude = longitude;
        }

        public static List<ActivitySearchFilterItem> PriceFilterItems(string from, string to)
        {
            return new List<ActivitySearchFilterItem>
            {
                new ActivitySearchFilterItem(ActivityFilterType.PriceFrom, from),
                new ActivitySearchFilterItem(ActivityFilterType.PriceTo, to)
            };
        }

        public static List<ActivitySearchFilterItem> SegmentFilterItems(string destination, string segment)
        {
            return new List<ActivitySearchFilterItem>
            {
                new ActivitySearchFilterItem(ActivityFilterType.Destination, destination),
                new ActivitySearchFilterItem(ActivityFilterType.Segment, segment)
            };
        }

        public override string ToString()
        {
            return "ActivitySearchFilterItem{" +
                   "type=" + Type +
                   ", value='" + Value + '\'' +
                   ", latitude=" + Latitude +
                   ", longitude=" + Longitude +
                   '}';
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 71 * hash + Type.GetHashCode();
            hash = 71 * hash + Value.GetHashCode();
            hash = 71 * hash + Latitude.GetHashCode();
            hash = 71 * hash + Longitude.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            ActivitySearchFilterItem other = (ActivitySearchFilterItem)obj;
            if (Type != other.Type) return false;
            if (!Value.Equals(other.Value)) return false;
            if (!Latitude.Equals(other.Latitude)) return false;
            if (!Longitude.Equals(other.Longitude)) return false;

            return true;
        }
    }
}