namespace HotelBeds.Shared.Activities.Dto
{
    public class PaymentInformationResponse
    {
        public string Type { get; set; }
        public InvoiceCompany InvoiceCompany { get; set; }
        public string Info { get; set; }
        public string Status { get; set; }
    }
}