namespace HotelBeds.Shared.Activities.Dto
{
    public class PaginationRequest
    {
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }

        public override string ToString()
        {
            return "PaginationRequest{"
                   + "itemsPerPage=" + ItemsPerPage
                   + ", page=" + Page
                   + "}";
        }

        public override int GetHashCode()
        {
            int hash = 3;
            hash = 71 * hash + ItemsPerPage.GetHashCode();
            hash = 71 * hash + Page.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            PaginationRequest other = (PaginationRequest)obj;
            if (!ItemsPerPage.Equals(other.ItemsPerPage)) return false;
            if (!Page.Equals(other.Page)) return false;

            return true;
        }



    }
}