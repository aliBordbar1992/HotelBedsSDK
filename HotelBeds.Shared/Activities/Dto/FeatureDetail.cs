using System.Text;
using HotelBeds.Shared.Activities.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HotelBeds.Shared.Activities.Dto
{
    public class FeatureDetail
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public FeatureIncExcType FeatureType { get; set; }
        public string Description { get; set; }

        public FeatureDetail()
        {
        }

        public FeatureDetail(FeatureIncExcType featureType, string description)
        {
            this.FeatureType = featureType;
            this.Description = description;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("FeatureType=").Append(FeatureType).Append(",");
            sb.Append("Description=").Append(Description);

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 97 * hash + FeatureType.GetHashCode();
            hash = 97 * hash + Description.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            FeatureDetail other = (FeatureDetail)obj;
            if (FeatureType != other.FeatureType)
                return false;

            if (!Description.Equals(other.Description))
                return false;

            return true;
        }



    }
}