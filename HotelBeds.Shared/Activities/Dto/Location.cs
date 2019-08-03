using System.Collections.Generic;
using System.Text;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Location
    {
        public List<LocationPoint> EndPoints { get; set; }
        public List<LocationPoint> StartingPoints { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("EndPoints=").Append(EndPoints).Append(",");
            sb.Append("StartPoints=").Append(StartingPoints);

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 41 * hash + EndPoints.GetHashCode();
            hash = 41 * hash + StartingPoints.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            Location other = (Location)obj;
            if (!EndPoints.Equals(other.EndPoints)) return false;
            if (!StartingPoints.Equals(other.StartingPoints)) return false;

            return true;
        }



    }
}