using System.Collections.Generic;
using System.Text;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Schedule
    {
        public Duration Duration { get; set; }
        public List<ScheduleInfo> Closed { get; set; }
        public List<ScheduleInfo> Opened { get; set; }

        public Schedule()
        {
        }

        public Schedule(List<ScheduleInfo> closed, List<ScheduleInfo> opened, Duration duration)
        {
            Closed = closed;
            Opened = opened;
            Duration = duration;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Duration=").Append(Duration).Append(",");
            sb.Append("Closed=").Append(Closed).Append(",");
            sb.Append("Opened=").Append(Opened);

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 79 * hash + Duration.GetHashCode();
            hash = 79 * hash + Closed.GetHashCode();
            hash = 79 * hash + Opened.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            Schedule other = (Schedule)obj;
            if (!Duration.Equals(other.Duration)) return false;
            if (!Closed.Equals(other.Closed)) return false;
            if (!Opened.Equals(other.Opened)) return false;

            return true;
        }
    }
}