namespace HotelBeds.Api.TransferContents
{
    public class TransferContentVersionSelector : ITransferContentVersionSelector
    {
        public TransferContentVersionSelector()
        {
        }

        public string GetVersion()
        {
            return "1.0";
        }
    }
}