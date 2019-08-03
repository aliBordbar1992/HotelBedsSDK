namespace HotelBeds.Shared.Activities.Dto
{
    public class DuoTypeDescription
    {
        public string Description { get; set; }
        public string Code { get; set; }

        public DuoTypeDescription()
        {
        }

        public DuoTypeDescription(string code, string description)
        {
            this.Code = code;
            this.Description = description;
        }

        public override int GetHashCode()
        {
            int hash = 5;
            hash = 89 * hash + Description.GetHashCode();
            hash = 89 * hash + Code.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            DuoTypeDescription other = (DuoTypeDescription)obj;
            if (!Description.Equals(other.Description)) return false;
            if (!Code.Equals(other.Code)) return false;

            return true;
        }



    }
}