namespace HotelBeds.Api.Transfer
{
    public class TransferApiVersion : ITransferVersionSelector
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