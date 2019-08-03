using System.Collections.Generic;
using System.Text;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Route
    {
        public Duration Duration { get; set; }
        public string Description { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
        public List<RoutePoint> Points { get; set; }
        public Frequency Frequency { get; set; }

        public Route()
        {
        }

        public Route(string code, string description, Duration duration, string timeFrom, string timeTo, List<RoutePoint> points, Frequency frequency)
        {
            Description = description;
            Duration = duration;
            TimeFrom = timeFrom;
            TimeTo = timeTo;
            Points = points;
            Frequency = frequency;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Duration=").Append(Duration).Append(",");
            sb.Append("Description=").Append(Description).Append(",");
            sb.Append("TimeFrom=").Append(TimeFrom).Append(",");
            sb.Append("TimeTo=").Append(TimeTo).Append(",");
            sb.Append("Points=").Append(Points);

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 5;
            hash = 37 * hash + Duration.GetHashCode();
            hash = 37 * hash + Description.GetHashCode();
            hash = 37 * hash + TimeFrom.GetHashCode();
            hash = 37 * hash + TimeTo.GetHashCode();
            hash = 37 * hash + Points.GetHashCode();
            hash = 37 * hash + Frequency.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            Route other = (Route)obj;
            if (!Duration.Equals(other.Duration)) return false;
            if (!Description.Equals(other.Description)) return false;
            if (!TimeFrom.Equals(other.TimeFrom)) return false;
            if (!TimeTo.Equals(other.TimeTo)) return false;
            if (!Points.Equals(other.Points)) return false;
            if (!Frequency.Equals(other.Frequency)) return false;

            return true;
        }
    }
}