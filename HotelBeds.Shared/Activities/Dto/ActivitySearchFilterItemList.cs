using System.Collections.Generic;

namespace HotelBeds.Shared.Activities.Dto
{
    public class ActivitySearchFilterItemList
    {
        public List<ActivitySearchFilterItem> SearchFilterItems { get; set; }

        public ActivitySearchFilterItemList()
        {
            SearchFilterItems = new List<ActivitySearchFilterItem>();
        }

        public override int GetHashCode()
        {
            int hash = 3;
            hash = 29 * hash + SearchFilterItems.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            ActivitySearchFilterItemList other = (ActivitySearchFilterItemList)obj;
            if (!SearchFilterItems.Equals(other.SearchFilterItems)) return false;
            return true;
        }
    }
}