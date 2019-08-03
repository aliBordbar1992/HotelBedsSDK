using System;
using System.Collections.Generic;
using System.Text;
using HotelBeds.Shared.Activities.Domain;

namespace HotelBeds.Shared.Activities.Dto
{
    public class ScheduleInfo
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string OpeningTime { get; set; } //HHMM
        public string CloseTime { get; set; } //HHMM
        public string LastAdmissionTime { get; set; } //HHMM
        public List<WeekDayType> WeekDays { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("From=").Append(From).Append(",");
            sb.Append("To=").Append(To).Append(",");
            sb.Append("WeekDays=").Append(WeekDays);
            sb.Append("OpeningTime=").Append(OpeningTime);
            sb.Append("ClosingTime=").Append(CloseTime);
            sb.Append("LastAdmissionTime=").Append(LastAdmissionTime);

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 5;
            hash = 29 * hash + From.GetHashCode();
            hash = 29 * hash + To.GetHashCode();
            hash = 29 * hash + OpeningTime.GetHashCode();
            hash = 29 * hash + CloseTime.GetHashCode();
            hash = 29 * hash + LastAdmissionTime.GetHashCode();
            hash = 29 * hash + WeekDays.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            ScheduleInfo other = (ScheduleInfo)obj;
            if (!From.Equals(other.From)) return false;
            if (!To.Equals(other.To)) return false;
            if (!OpeningTime.Equals(other.OpeningTime)) return false;
            if (!CloseTime.Equals(other.CloseTime)) return false;
            if (!LastAdmissionTime.Equals(other.LastAdmissionTime)) return false;
            if (!WeekDays.Equals(other.WeekDays)) return false;

            return true;
        }
    }
}