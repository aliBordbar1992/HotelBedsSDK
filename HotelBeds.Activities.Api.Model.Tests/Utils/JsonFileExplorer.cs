namespace HotelBeds.Shared.Tests.Utils
{
    internal class JsonFileExplorer
    {
        public class Search
        {
            public class Filter
            {
                public static string SimpleFilterWithoutLatAndLong =>
                    @"D:\Repo\HotelBeds\HotelBeds.Activities.Api.Model.Tests\Jsons\Search\Filter\SimpleFilterWithoutLatAndLong.json";

                public static string SimpleFilterWithLatAndLong =>
                    @"D:\Repo\HotelBeds\HotelBeds.Activities.Api.Model.Tests\Jsons\Search\Filter\SimpleFilterWithLatAndLong.json";

                public static string SimpleFilterPriceRange =>
                    @"D:\Repo\HotelBeds\HotelBeds.Activities.Api.Model.Tests\Jsons\Search\Filter\SimpleFilterPriceRange.json";

                public static string SimpleFilterSegment =>
                    @"D:\Repo\HotelBeds\HotelBeds.Activities.Api.Model.Tests\Jsons\Search\Filter\SimpleFilterSegment.json";
            }
        }
    }
}