using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Note
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime VisibleFrom { get; set; }
        public DateTime VisibleTo { get; set; }
        public List<DuoTypeDescription> Descriptions { get; set; }

        public Note()
        {
        }

        public Note(DateTime dateFrom, DateTime dateTo, DateTime visibleFrom, DateTime visibleTo, List<DuoTypeDescription> descriptions)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
            VisibleFrom = visibleFrom;
            VisibleTo = visibleTo;
            Descriptions = descriptions;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DateFrom=").Append(DateFrom).Append(",");
            sb.Append("DateTo=").Append(DateTo).Append(",");
            sb.Append("VisibleFrom=").Append(VisibleFrom).Append(",");
            sb.Append("VisibleTo=").Append(VisibleTo).Append(",");
            sb.Append("Descriptions=").Append(Descriptions);

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 97 * hash + DateFrom.GetHashCode();
            hash = 97 * hash + DateTo.GetHashCode();
            hash = 97 * hash + VisibleFrom.GetHashCode();
            hash = 97 * hash + VisibleTo.GetHashCode();
            hash = 97 * hash + Descriptions.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            Note other = (Note)obj;
            if (!DateFrom.Equals(other.DateFrom)) return false;
            if (!DateTo.Equals(other.DateTo)) return false;
            if (!VisibleFrom.Equals(other.VisibleFrom)) return false;
            if (!VisibleTo.Equals(other.VisibleTo)) return false;
            if (!Descriptions.Equals(other.Descriptions)) return false;

            return true;
        }
    }
}