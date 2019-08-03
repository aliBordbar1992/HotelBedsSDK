using System.Text;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Area
    {
        public string Code { get; set; }
        public Coordinate Geolocation { get; set; }
        public string Description { get; set; }

        public Area()
        {
        }

        public Area(string code, Coordinate geolocation, string description)
        {
            Code = code;
            Geolocation = geolocation;
            Description = description;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Code=").Append(Code).Append(",");
            sb.Append("Description=").Append(Description).Append(",");
            sb.Append("Geolocation=").Append(Geolocation).Append(",");

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 5;
            hash = 29 * hash + Code.GetHashCode();
            hash = 29 * hash + Geolocation.GetHashCode();
            hash = 29 * hash + Description.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            Area other = (Area)obj;
            if (!Code.Equals(other.Code)) return false;
            if (!Geolocation.Equals(other.Geolocation)) return false;
            if (!Description.Equals(other.Description)) return false;
            return true;
        }



    }
}