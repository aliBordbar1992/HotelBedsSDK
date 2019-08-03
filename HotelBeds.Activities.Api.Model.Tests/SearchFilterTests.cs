using System;
using System.Collections.Generic;
using FluentAssertions;
using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Activities.Dto;
using HotelBeds.Shared.Activities.Request;
using HotelBeds.Shared.Tests.Utils;
using Xunit;

namespace HotelBeds.Shared.Tests
{
    public class SearchFilterTests
    {
        [Fact]
        public void test_search_request_filter_json_string()
        {
            var filter = new ActivitySearchFilterItemList();
            filter.SearchFilterItems.Add(new ActivitySearchFilterItem(ActivityFilterType.Country, "PT"));
            filter.SearchFilterItems.Add(new ActivitySearchFilterItem(ActivityFilterType.Destination, "MCO"));

            var req = new ActivitySearchRequest(new List<ActivitySearchFilterItemList>
            {
                filter
            }, DateTime.Now, DateTime.Now);

            string json = req.ToString();
        }

        [Fact]
        public void filter_json_for_items_without_lat_and_long_should_match_with_api_requested_json()
        {
            var filter = SomeFiltersWithoutLatAndLong();
            string json = filter.ToJsonString();

            string expected = ExpectedJsonApi.FilterWithoutLatAndLong;

            json.Should().Be(expected);
        }



        [Fact]
        public void filter_json_for_items_with_lat_and_long_should_match_with_api_requested_json()
        {
            var filter = SomeFiltersWithLatAndLong();
            string json = filter.ToJsonString();

            string expected = ExpectedJsonApi.FilterWithLatAndLong;

            json.Should().Be(expected);
        }

        [Fact]
        public void filter_json_for_range_of_price_should_contain_two_search_items()
        {
            var filter = new ActivitySearchFilterItemList();
            filter.SearchFilterItems.AddRange(ActivitySearchFilterItem.PriceFilterItems("50", "60"));

            string json = filter.ToJsonString();

            string expected = ExpectedJsonApi.FilterForPriceRange;

            json.Should().Be(expected);
        }

        [Fact]
        public void filter_json_for_segment_should_contain_two_search_items()
        {
            var filter = new ActivitySearchFilterItemList();
            filter.SearchFilterItems.AddRange(ActivitySearchFilterItem.SegmentFilterItems("MCO", "3"));

            string json = filter.ToJsonString();

            string expected = ExpectedJsonApi.FilterForSegment;

            json.Should().Be(expected);
        }

        private static ActivitySearchFilterItemList SomeFiltersWithoutLatAndLong()
        {
            var filter = new ActivitySearchFilterItemList();
            filter.SearchFilterItems.Add(new ActivitySearchFilterItem(ActivityFilterType.Country, "ES"));
            filter.SearchFilterItems.Add(new ActivitySearchFilterItem(ActivityFilterType.Destination, "BCN"));
            filter.SearchFilterItems.Add(new ActivitySearchFilterItem(ActivityFilterType.Service, "E-E10-EXPER"));
            return filter;
        }

        private static ActivitySearchFilterItemList SomeFiltersWithLatAndLong()
        {
            var filter = new ActivitySearchFilterItemList();
            filter.SearchFilterItems.Add(new ActivitySearchFilterItem(ActivityFilterType.Gps, 41.49004m, 2.08161m));
            filter.SearchFilterItems.Add(new ActivitySearchFilterItem(ActivityFilterType.Destination, "BCN"));
            filter.SearchFilterItems.Add(new ActivitySearchFilterItem(ActivityFilterType.Service, "E-E10-EXPER"));
            return filter;
        }
    }
}