using System.Collections.Generic;

namespace HotelBeds.Shared.Activities.Dto
{
    public class SearchModality
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Duration Duration { get; set; }
        public List<PaxPrice> AmountsFrom { get; set; }
        public List<CancellationPolicy> CancellationPolicies { get; set; }
        public FactsheetActivity SpecificContent { get; set; }


        public override string ToString()
        {
            return this.ToJsonString();
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 41 * hash + Code.GetHashCode();
            hash = 41 * hash + Name.GetHashCode();
            hash = 41 * hash + Duration.GetHashCode();
            hash = 41 * hash + AmountsFrom.GetHashCode();
            hash = 41 * hash + CancellationPolicies.GetHashCode();
            hash = 41 * hash + SpecificContent.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            SearchModality other = (SearchModality)obj;
            if (!Code.Equals(other.Code)) return false;
            if (!Name.Equals(other.Name)) return false;
            if (!Duration.Equals(other.Duration)) return false;
            if (!AmountsFrom.Equals(other.AmountsFrom)) return false;
            if (!CancellationPolicies.Equals(other.CancellationPolicies)) return false;
            if (!SpecificContent.Equals(other.SpecificContent)) return false;

            return true;
        }
    }
}