namespace HotelBeds.Shared.Transfer.Dto
{
    public class Price
    {
        public string CurrencyId { get; set; }
        public long NetAmount { get; set; }
        public long TotalAmount { get; set; }
    }
}