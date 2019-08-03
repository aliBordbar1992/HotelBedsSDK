namespace HotelBeds.Shared.Activities.Dto
{
    public class MediaOther : MediaBase
    {
        public string Language { get; set; }

        public MediaOther()
        {
        }

        public MediaOther(string language)
        {
            Language = language;
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 29 * hash + Language.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            if (!base.Equals(obj)) return false;

            MediaOther other = (MediaOther)obj;
            if (!Language.Equals(other.Language)) return false;

            return true;
        }

    }
}