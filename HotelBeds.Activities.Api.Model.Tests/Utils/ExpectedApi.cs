using System.IO;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Tests.Utils
{
    internal class ExpectedJsonApi
    {
        public static string FilterWithoutLatAndLong
        {
            get
            {
                string address= JsonFileExplorer.Search.Filter.SimpleFilterWithoutLatAndLong;
                using (StreamReader r = new StreamReader(address))
                {
                    string json = r.ReadToEnd();
                    var obj = JsonConvert.DeserializeObject(json);
                    return obj.ToJsonString();
                }
            }
        }
        public static string FilterWithLatAndLong
        {
            get
            {
                string address= JsonFileExplorer.Search.Filter.SimpleFilterWithLatAndLong;
                using (StreamReader r = new StreamReader(address))
                {
                    string json = r.ReadToEnd();
                    var obj = JsonConvert.DeserializeObject(json);
                    return obj.ToJsonString();
                }
            }
        }

        public static string FilterForPriceRange
        {
            get
            {
                string address= JsonFileExplorer.Search.Filter.SimpleFilterPriceRange;
                using (StreamReader r = new StreamReader(address))
                {
                    string json = r.ReadToEnd();
                    var obj = JsonConvert.DeserializeObject(json);
                    return obj.ToJsonString();
                }
            }
        }

        public static string FilterForSegment
        {
            get
            {
                string address = JsonFileExplorer.Search.Filter.SimpleFilterSegment;
                using (StreamReader r = new StreamReader(address))
                {
                    string json = r.ReadToEnd();
                    var obj = JsonConvert.DeserializeObject(json);
                    return obj.ToJsonString();
                }
            }
        }
    }
}