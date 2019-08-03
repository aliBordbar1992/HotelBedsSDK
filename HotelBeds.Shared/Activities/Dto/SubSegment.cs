using System;
using System.Text;

namespace HotelBeds.Shared.Activities.Dto
{
    public class SubSegment : IComparable<SubSegment>
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string Icon { get; set; }

        public SubSegment()
        {
        }

        public SubSegment(int code, int order, string name, string icon)
        {
            Code = code;
            Order = order;
            Name = name;
            Icon = icon;
        }

        public int CompareTo(SubSegment o)
        {
            return Order.CompareTo(o.Order);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Code=").Append(Code).Append(",");
            sb.Append("Name=").Append(Name).Append(",");
            sb.Append("Order=").Append(Order).Append(",");
            sb.Append("Icon=").Append(Icon);

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 71 * hash + Code.GetHashCode();
            hash = 71 * hash + Name.GetHashCode();
            hash = 71 * hash + Order.GetHashCode();
            hash = 71 * hash + Icon.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            SubSegment other = (SubSegment)obj;
            if (!Code.Equals(other.Code)) return false;
            if (!Name.Equals(other.Name)) return false;
            if (!Order.Equals(other.Order)) return false;
            if (!Icon.Equals(other.Icon)) return false;

            return true;
        }



    }
}