using System;
using System.IO;
using System.Text.RegularExpressions;

namespace HotelBeds.Shared.Tests.Utils
{
    internal class JsonFileExplorer
    {
        public class Search
        {
            public class Filter
            {
                private static string GetCurrentUrl()
                {
                    var exePath = Path.GetDirectoryName(System.Reflection
                        .Assembly.GetExecutingAssembly().CodeBase);
                    Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
                    var appRoot = appPathMatcher.Match(exePath).Value;
                    return appRoot;
                }
                public static string SimpleFilterWithoutLatAndLong =>
                    $@"{GetCurrentUrl()}\Jsons\Search\Filter\SimpleFilterWithoutLatAndLong.json";

                public static string SimpleFilterWithLatAndLong =>
                    $@"{GetCurrentUrl()}\Jsons\Search\Filter\SimpleFilterWithLatAndLong.json";

                public static string SimpleFilterPriceRange =>
                    $@"{GetCurrentUrl()}\Jsons\Search\Filter\SimpleFilterPriceRange.json";

                public static string SimpleFilterSegment =>
                    $@"{GetCurrentUrl()}\Jsons\Search\Filter\SimpleFilterSegment.json";
            }
        }
    }
}