using System.Collections.Generic;
using System.Text;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public List<DuoTypeName> Destinations { get; set; }

        public Country()
        {
        }

        public Country(string code, string name, List<DuoTypeName> destinations)
        {
            this.Code = code;
            this.Name = name;
            this.Destinations = destinations;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("CountryCode=")
                .Append(Code)
                .Append(",");

            sb.Append("CountryName=")
                .Append(Name)
                .Append(",");

            sb.Append(Destinations.ToString());

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 43 * hash + Code.GetHashCode();
            hash = 43 * hash + Name.GetHashCode();
            hash = 43 * hash + Destinations.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;


            Country other = (Country)obj;
            if (!Code.Equals(other.Code)) return false;
            if (!Name.Equals(other.Name)) return false;
            if (!Destinations.Equals(other.Destinations)) return false;

            return true;
        }


    }
}