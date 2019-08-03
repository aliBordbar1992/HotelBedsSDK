namespace HotelBeds.Shared.Activities.Dto
{
    public class Error
    {

        public string Code { get; set; }
        public string Text { get; set; }
        public string InternalDescription { get; set; }


        public override string ToString()
        {
            return $"Error [code={Code}, clientDescription={Text}, internalDescription={InternalDescription}]";
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 71 * hash + Code.GetHashCode();
            hash = 71 * hash + Text.GetHashCode();
            hash = 71 * hash + InternalDescription.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            Error other = (Error)obj;

            if (!Code.Equals(other.Code)) return false;
            if (!Text.Equals(other.Text)) return false;
            if (!InternalDescription.Equals(other.InternalDescription)) return false;

            return true;
        }
    }
}