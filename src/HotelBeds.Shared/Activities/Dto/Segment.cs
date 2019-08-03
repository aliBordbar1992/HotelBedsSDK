using System.Collections.Generic;
using System.Text;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Segment
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public List<SubSegment> SubSegments { get; set; }

        public Segment()
        {
        }

        public Segment(int code, string name, string icon, List<SubSegment> subSegments)
        {
            Code = code;
            Name = name;
            Icon = icon;
            SubSegments = subSegments;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Code=").Append(Code).Append(",");
            sb.Append("Name=").Append(Name).Append(",");
            sb.Append("Icon=").Append(Icon).Append(",");
            sb.Append("SubSegments=").Append(SubSegments);

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 71 * hash + Code.GetHashCode();
            hash = 71 * hash + Name.GetHashCode();
            hash = 71 * hash + Icon.GetHashCode();
            hash = 71 * hash + SubSegments.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            Segment other = (Segment)obj;
            if (!Code.Equals(other.Code)) return false;
            if (!Name.Equals(other.Name)) return false;
            if (!Icon.Equals(other.Icon)) return false;
            if (!SubSegments.Equals(other.SubSegments)) return false;

            return true;
        }


    }
}