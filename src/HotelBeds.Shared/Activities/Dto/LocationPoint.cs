using System.Collections.Generic;
using System.Text;

namespace HotelBeds.Shared.Activities.Dto
{
    public class LocationPoint
    {
        public string Type { get; set; }
        public PointOfInterest MeetingPoint { get; set; }
        public List<DuoTypeDescription> PickupInstructions { get; set; }

        public LocationPoint()
        {
        }

        public LocationPoint(string type, PointOfInterest meetingPoint, List<DuoTypeDescription> pickupInstructions)
        {
            this.Type = type;
            this.MeetingPoint = meetingPoint;
            this.PickupInstructions = pickupInstructions;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Type=").Append(Type).Append(",");
            sb.Append("MeetingPoint=").Append(MeetingPoint).Append(",");
            sb.Append("PickupInstructions=").Append(PickupInstructions).Append(",");

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 3;
            hash = 53 * hash + Type.GetHashCode();
            hash = 53 * hash + MeetingPoint.GetHashCode();
            hash = 53 * hash + PickupInstructions.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            LocationPoint other = (LocationPoint)obj;
            if (!Type.Equals(other.Type)) return false;
            if (!MeetingPoint.Equals(other.MeetingPoint)) return false;
            if (!PickupInstructions.Equals(other.PickupInstructions)) return false;

            return true;
        }
    }
}