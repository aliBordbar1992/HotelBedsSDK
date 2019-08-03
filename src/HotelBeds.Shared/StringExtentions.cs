using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace HotelBeds.Shared
{
    public static class StringExtentions
    {
        public static string ToJsonString(this object inp)
        {
            return JsonConvert.SerializeObject(
                inp
                , Formatting.None
                , new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }

    }

    internal class ApiDateFormat : IsoDateTimeConverter
    {
        public ApiDateFormat()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }

    
}