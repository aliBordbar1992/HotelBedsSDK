namespace HotelBeds.Api.Transfer
{
    public class TransferApiBaseUrl: IHotelBedsBaseUrl
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