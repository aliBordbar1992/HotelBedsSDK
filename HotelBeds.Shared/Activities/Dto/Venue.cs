using System.Text;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Venue
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public Venue()
        {
        }

        public Venue(string type, string value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Type=").Append(Type).Append(",");
            sb.Append("Value=").Append(Value);

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 71 * hash + Type.GetHashCode();
            hash = 71 * hash + Value.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            Venue other = (Venue)obj;
            if (!Type.Equals(other.Type)) return false;
            if (!Value.Equals(other.Value)) return false;

            return true;
        }
    }
}