namespace HotelBeds.Shared.Activities.Request
{
    public abstract class AbstractBookingModificationRequest
    {
        public string ClientReference { get; set; }
        public string AgencyComments {get;set;}

        protected AbstractBookingModificationRequest()
        {
        }

        protected AbstractBookingModificationRequest(string clientReference, string agencyComments)
        {
            ClientReference = clientReference;
            AgencyComments = agencyComments;
        }
    }
}