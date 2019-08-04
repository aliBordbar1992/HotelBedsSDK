using System.Collections.Generic;
using System.Text;
using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Converters;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Activities.Dto
{
    public class PointOfInterest
    {
        [JsonConverter(typeof(EnumTypeConverter<PointOfInterestType>))]
        public PointOfInterestType Type { get; set; }
        public Coordinate Geolocation { get; set; }
        public string Address { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public List<Area> Area { get; set; }
        public string Zip { get; set; }
        public string Description { get; set; }

        public PointOfInterest()
        {
        }

        public PointOfInterest(PointOfInterestType type, Coordinate geolocation, string address, Country country, string city, List<Area> area, string zip, string description)
        {
            Type = type;
            Geolocation = geolocation;
            Address = address;
            Country = country;
            City = city;
            Area = area;
            Zip = zip;
            Description = description;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Address=").Append(Address).Append(",");
            sb.Append("City=").Append(City).Append(",");
            sb.Append("Country=").Append(Country).Append(",");
            sb.Append("Description=").Append(Description).Append(",");
            sb.Append("Geolocation=").Append(Geolocation).Append(",");
            sb.Append("Type=").Append(Type).Append(",");
            sb.Append("Zip=").Append(Zip).Append(",");
            sb.Append("Area=").Append(Area);

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 5;
            hash = 37 * hash + Type.GetHashCode();
            hash = 37 * hash + Geolocation.GetHashCode();
            hash = 37 * hash + Address.GetHashCode();
            hash = 37 * hash + Country.GetHashCode();
            hash = 37 * hash + City.GetHashCode();
            hash = 37 * hash + Area.GetHashCode();
            hash = 37 * hash + Zip.GetHashCode();
            hash = 37 * hash + Description.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            PointOfInterest other = (PointOfInterest)obj;
            if (Type != other.Type) return false;
            if (!Geolocation.Equals(other.Geolocation)) return false;
            if (!Address.Equals(other.Address)) return false;
            if (!Country.Equals(other.Country)) return false;
            if (!City.Equals(other.City)) return false;
            if (!Area.Equals(other.Area)) return false;
            if (!Zip.Equals(other.Zip)) return false;
            if (!Description.Equals(other.Description)) return false;

            return true;
        }



    }
}