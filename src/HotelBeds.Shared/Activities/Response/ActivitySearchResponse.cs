using System.Collections.Generic;
using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Shared.Activities.Response
{
    public class ActivitySearchResponse : BaseResponse
    {
        public List<Activity> Activities { get; set; }

        
        public PaginationResponse Pagination { get; set; }

        public void AddAllActivities(List<Activity> activities)
        {
            if (Activities == null) Activities =new List<Activity>();

            Activities.AddRange(activities);
        }

        public override string ToString()
        {
            return this.ToJsonString();
        }

        public override int GetHashCode()
        {
            int hash = 3;
            hash = 43 * hash + Activities.GetHashCode();
            hash = 43 * hash + Pagination.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            ActivitySearchResponse other = (ActivitySearchResponse)obj;
            if (!Activities.Equals(other.Activities)) return false;
            if (!Pagination.Equals(other.Pagination)) return false;

            return true;
        }
    }
}