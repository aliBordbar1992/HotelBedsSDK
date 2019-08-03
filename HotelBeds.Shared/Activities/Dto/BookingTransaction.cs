namespace HotelBeds.Shared.Activities.Dto
{
    public class BookingTransaction
    {
        public string TransactionReference { get; set; }
        public string PaymentResponse { get; set; }
        public string PaymentType { get; set; }
        public decimal Amount { get; set; }
        public decimal Charge { get; set; }
        public string AuthorizationCode { get; set; }
        public string Currency { get; set; }
        public string MaskedCardNumber { get; set; }
        public string Remarks { get; set; }
    }
}