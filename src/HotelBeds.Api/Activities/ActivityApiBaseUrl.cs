namespace HotelBeds.Api.Activities
{
    public class ActivityApiBaseUrl: IHotelBedsBaseUrl
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