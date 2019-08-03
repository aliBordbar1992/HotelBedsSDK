using System.Collections.Generic;
using System.Text;

namespace HotelBeds.Shared.Activities.Dto
{
    public class SegmentGroup
    {
        public long Code { get; set; }
        public string Name { get; set; }
        public List<Segment> Segments { get; set; }

        public SegmentGroup()
        {
        }

        public SegmentGroup(long code, string name, List<Segment> segments)
        {
            Code = code;
            Name = name;
            Segments = segments;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Code=").Append(Code).Append(",");
            sb.Append("Name=").Append(Name).Append(",");
            sb.Append("Segments=").Append(Segments);

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 3;
            hash = 23 * hash + Code.GetHashCode();
            hash = 23 * hash + Name.GetHashCode();
            hash = 23 * hash + Segments.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            SegmentGroup other = (SegmentGroup)obj;
            if (!Code.Equals(other.Code)) return false;
            if (!Name.Equals(other.Name)) return false;
            if (!Segments.Equals(other.Segments)) return false;

            return true;
        }
    }
}