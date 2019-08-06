namespace HotelBeds.Api.TransferContents
{
    public class TransferContentApiBaseUrl : ITransferContentApiBaseUrl
    {
        public string BaseUrl { get; set; }
        public string GetUrl()
        {
            return BaseUrl;
        }

        public void SetUrl(string url)
        {
            BaseUrl = url;
        }
    }
}