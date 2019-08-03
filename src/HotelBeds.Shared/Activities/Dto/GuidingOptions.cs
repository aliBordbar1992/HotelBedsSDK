using System.Text;
using HotelBeds.Shared.Activities.Domain;

namespace HotelBeds.Shared.Activities.Dto
{
    public class GuidingOptions
    {
        public GuideGroupType GroupType { get; set; }
        public GuideType GuideType { get; set; }
        public bool Included { get; set; }
        public int MaxGroupSize { get; set; }
        public GuideTipType Tips { get; set; }

        public GuidingOptions()
        {
        }

        public GuidingOptions(GuideGroupType groupType, GuideType guideType, bool included, int maxGroupSize, GuideTipType tips)
        {
            GroupType = groupType;
            GuideType = guideType;
            Included = included;
            MaxGroupSize = maxGroupSize;
            Tips = tips;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("GroupType=").Append(GroupType).Append(",");
            sb.Append("GuideType=").Append(GuideType).Append(",");
            sb.Append("Included=").Append(Included).Append(",");
            sb.Append("MaxGroupSize=").Append(MaxGroupSize).Append(",");
            sb.Append("Tips=").Append(Tips).Append(",");
            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 3;
            hash = 37 * hash + GroupType.GetHashCode();
            hash = 37 * hash + GuideType.GetHashCode();
            hash = 37 * hash + (Included ? 1 : 0);
            hash = 37 * hash + MaxGroupSize.GetHashCode();
            hash = 37 * hash + Tips.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;

            GuidingOptions other = (GuidingOptions)obj;
            if (GroupType != other.GroupType) return false;
            if (GuideType != other.GuideType) return false;
            if (Included != other.Included) return false;
            if (Tips != other.Tips) return false;
            if (!MaxGroupSize.Equals(other.MaxGroupSize)) return false;

            return true;
        }



    }

    

}