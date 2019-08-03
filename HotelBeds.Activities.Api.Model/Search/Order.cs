namespace HotelBeds.Activities.Api.Model.Search
{
    public class Order
    {
        private string _by;

        private Order(string by)
        {
            _by = by;
        }

        public static Order ByDefault()
        {
            return new Order("DEFAULT");
        }

        public static Order ByName()
        {
            return new Order("NAME");
        }

        public static Order ByPrice()
        {
            return new Order("PRICE");
        }

        public string By()
        {
            return string.IsNullOrEmpty(_by) ? "DEFAULT" : _by;
        }
    }
}