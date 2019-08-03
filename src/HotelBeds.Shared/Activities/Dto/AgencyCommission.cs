namespace HotelBeds.Shared.Activities.Dto
{
    public class AgencyCommission
    {
        public decimal Percentage { get; set; }
        public decimal Amount { get; set; }
        public decimal VatPercentage { get; set; }
        public decimal VatAmount { get; set; }

        public AgencyCommission()
        {
        }

        public AgencyCommission(decimal percentage, decimal amount, decimal vatAmount)
        {
            Percentage = percentage;
            Amount = amount;
            VatAmount = vatAmount;
        }
    }
}