using System.Collections.Generic;
using System.Text;
using HotelBeds.Shared.Activities.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HotelBeds.Shared.Activities.Dto
{
    public class FeatureGroup
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public FeatureGroupType GroupCode { get; set; }
        public List<FeatureDetail> Excluded { get; set; }
        public List<FeatureDetail> Included { get; set; }

        public FeatureGroup()
        {
        }

        public FeatureGroup(FeatureGroupType groupCode, List<FeatureDetail> excluded, List<FeatureDetail> included)
        {
            this.GroupCode = groupCode;
            this.Excluded = excluded;
            this.Included = included;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("GroupCode=").Append(GroupCode).Append(",");
            sb.Append("Excluded=").Append(Excluded).Append(",");
            sb.Append("Included=").Append(Included);

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 11 * hash + GroupCode.GetHashCode();
            hash = 11 * hash + Excluded.GetHashCode();
            hash = 11 * hash + Included.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            FeatureGroup other = (FeatureGroup)obj;
            if (GroupCode != other.GroupCode) return false;
            if (!Excluded.Equals(other.Excluded)) return false;
            if (!Included.Equals(other.Included)) return false;

            return true;
        }



    }
}