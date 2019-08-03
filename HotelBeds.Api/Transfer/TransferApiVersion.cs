namespace HotelBeds.Api.Transfer
{
    public class TransferApiVersion : IApiVersionSelector
    {
        public TransferApiVersion()
        {
        }

        public string GetVersion()
        {
            return "1.0";
        }
    }
}