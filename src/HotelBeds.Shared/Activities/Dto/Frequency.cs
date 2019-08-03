using System.Text;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Frequency
    {
        public Duration Maximum { get; set; }
        public Duration Minimum { get; set; }

        public Frequency()
        {
        }

        public Frequency(Duration maximum, Duration minimum)
        {
            Maximum = maximum;
            Minimum = minimum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Maximum=").Append(Maximum).Append(",");
            sb.Append("Minimum=").Append(Minimum);

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 83 * hash + Maximum.GetHashCode();
            hash = 83 * hash + Minimum.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            Frequency other = (Frequency)obj;
            if (!Maximum.Equals(other.Maximum)) return false;
            if (!Minimum.Equals(other.Minimum)) return false;

            return true;
        }
    }
}