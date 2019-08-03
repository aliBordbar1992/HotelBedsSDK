namespace HotelBeds.Shared.Activities.Dto
{
    public class PaymentData
    {
        public PaymentType PaymentType { get; set; }
        public InvoiceCompany InvoicingCompany { get; set; }
        public string Description { get; set; }

        public PaymentData()
        {
        }

        public PaymentData(PaymentType paymentType, InvoiceCompany invoicingCompany, string description)
        {
            PaymentType = paymentType;
            InvoicingCompany = invoicingCompany;
            Description = description;
        }
    }
}