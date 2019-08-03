using System.Collections.Generic;
using System.Text;
using HotelBeds.Shared.Activities.Domain;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Redeem
    {
        public RedeemType Type { get; set; }
        public bool DirectEntrance { get; set; }
        public List<DuoTypeDescription> Comments { get; set; }

        public Redeem()
        {
        }

        public Redeem(bool directEntrance, RedeemType type, List<DuoTypeDescription> comments)
        {
            DirectEntrance = directEntrance;
            Type = type;
            Comments = comments;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DirectEntrance=").Append(DirectEntrance).Append(",");
            sb.Append("Type=").Append(Type).Append(",");
            sb.Append("Commments=").Append(Comments);

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 3;
            hash = 53 * hash + Type.GetHashCode();
            hash = 53 * hash + Comments.GetHashCode();
            hash = 53 * hash + (DirectEntrance ? 1 : 0);
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            Redeem other = (Redeem)obj;
            if (Type != other.Type) return false;
            if (DirectEntrance != other.DirectEntrance) return false;
            if (!Comments.Equals(other.Comments)) return false;

            return true;
        }

    }
}