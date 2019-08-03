namespace HotelBeds.Shared.Activities.Response
{
    public class PaginationResponse
    {
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
        public int TotalItems { get; set; }

        public override int GetHashCode()
        {
            int hash = 3;
            hash = 13 * hash + ItemsPerPage.GetHashCode();
            hash = 13 * hash + Page.GetHashCode();
            hash = 13 * hash + TotalItems.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            PaginationResponse other = (PaginationResponse)obj;
            if (!ItemsPerPage.Equals(other.ItemsPerPage)) return false;
            if (!Page.Equals(other.Page)) return false;
            if (!TotalItems.Equals(other.TotalItems)) return false;

            return true;
        }

    }
}