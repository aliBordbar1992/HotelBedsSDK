namespace HotelBeds.Api.Transfer
{
    public class TransferApiBaseUrl: ITransferApiBaseUrl
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

    public interface ITransferApiBaseUrl : IHotelBedsBaseUrl
    {

    }
}