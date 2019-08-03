using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBeds.Shared.Activities.Dto
{
    public class RoutePoint : IComparable<RoutePoint>
    {
        public string Type { get; set; }
        public int Order { get; set; }
        public bool Stop { get; set; }
        public string Description { get; set; }
        public List<DuoTypeDescription> Descriptions { get; set; }
        public PointOfInterest PointOfInterest { get; set; }
        public Duration StopTime { get; set; }
        public string TimeFrom { get; set; } //HH:MM
        public string TimeTo { get; set; } //HH:MM

        public RoutePoint()
        {
        }

        public RoutePoint(string description, List<DuoTypeDescription> descriptions, int order, PointOfInterest pointOfInterest, bool stop, Duration stopTime, string timeFrom, string timeTo, string type)
        {
            this.Description = description;
            this.Descriptions = descriptions;
            this.Order = order;
            this.PointOfInterest = pointOfInterest;
            this.Stop = stop;
            this.StopTime = stopTime;
            this.TimeFrom = timeFrom;
            this.TimeTo = timeTo;
            this.Type = type;
        }


        public int CompareTo(RoutePoint o)
        {
            return Order.CompareTo(o.Order);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Type=").Append(Type).Append(",");
            sb.Append("Order=").Append(Order).Append(",");
            sb.Append("Stop=").Append(Stop).Append(",");
            sb.Append("Description=").Append(Description).Append(",");
            sb.Append("Descriptions=").Append(Descriptions).Append(",");
            sb.Append("PointOfInterest=").Append(PointOfInterest).Append(",");
            sb.Append("StopTime=").Append(StopTime).Append(",");
            sb.Append("TimeFrom=").Append(TimeFrom).Append(",");
            sb.Append("TimeTo=").Append(TimeTo);

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 3;
            hash = 89 * hash + Type.GetHashCode();
            hash = 89 * hash + Order.GetHashCode();
            hash = 89 * hash + Description.GetHashCode();
            hash = 89 * hash + Descriptions.GetHashCode();
            hash = 89 * hash + PointOfInterest.GetHashCode();
            hash = 89 * hash + StopTime.GetHashCode();
            hash = 89 * hash + TimeFrom.GetHashCode();
            hash = 89 * hash + TimeTo.GetHashCode();
            hash = 89 * hash + (Stop ? 1 : 0);
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            RoutePoint other = (RoutePoint)obj;
            if (!Type.Equals(other.Type)) return false;
            if (!Order.Equals(other.Order)) return false;
            if (!Description.Equals(other.Description)) return false;
            if (!Descriptions.Equals(other.Descriptions)) return false;
            if (!PointOfInterest.Equals(other.PointOfInterest)) return false;
            if (!StopTime.Equals(other.StopTime)) return false;
            if (!TimeFrom.Equals(other.TimeFrom)) return false;
            if (!TimeTo.Equals(other.TimeTo)) return false;
            if (Stop != other.Stop) return false;
            return true;
        }



    }
}