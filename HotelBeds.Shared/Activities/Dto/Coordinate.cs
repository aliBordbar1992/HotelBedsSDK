namespace HotelBeds.Shared.Activities.Dto
{
    public class Coordinate
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 89 * hash + Latitude.GetHashCode();
            hash = 89 * hash + Longitude.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            Coordinate other = (Coordinate)obj;
            if (!Latitude.Equals(other.Latitude)) return false;
            if (!Longitude.Equals(other.Longitude)) return false;

            return true;
        }

    }
}