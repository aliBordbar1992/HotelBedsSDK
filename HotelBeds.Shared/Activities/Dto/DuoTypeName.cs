namespace HotelBeds.Shared.Activities.Dto
{
    public class DuoTypeName
    {

        public string Name { get; set; }
        public string Code { get; set; }

        public DuoTypeName()
        {
        }

        public DuoTypeName(string code, string name)
        {
            Code = code;
            Name = name;
        }


        public override int GetHashCode()
        {
            int hash = 5;
            hash = 97 * hash + Name.GetHashCode();
            hash = 97 * hash + Code.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            DuoTypeName other = (DuoTypeName)obj;
            if (!Name.Equals(other.Name)) return false;
            if (!Code.Equals(other.Code)) return false;

            return true;
        }



    }
}