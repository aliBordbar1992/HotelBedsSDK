namespace HotelBeds.Api.Activities
{
    public class ActivityApiBaseUrl: IActivityApiBaseUrl
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

    public interface IActivityApiBaseUrl : IHotelBedsBaseUrl
    {

    }
}