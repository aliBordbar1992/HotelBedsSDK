using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using HotelBeds.Api.Activities.Helpers.RequestFilter;
using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Activities.Dto;
using Xunit;

namespace HotelBeds.Api.Tests.ActivityTests.HelperTests
{
    public class SearchRequestFilterBuilderTests
    {
        [Fact]
        public void adding_only_one_item()
        {
            var filter = new SearchRequestFilterBuilder().With()
                .Country("test")
                .Build();

            filter.Count.Should().Be(1);
            filter.SelectMany(x => x.SearchFilterItems).Should()
                .Contain(new ActivitySearchFilterItem(ActivityFilterType.Country, "test"));
        }

        [Fact]
        public void adding_two_items_with_and()
        {
            var filter = new SearchRequestFilterBuilder().With()
                .Country("test").And()
                .Destination("BCN")
                .Build();

            filter.Count.Should().Be(1);
            filter.SelectMany(x => x.SearchFilterItems).Should().Contain(new ActivitySearchFilterItem(ActivityFilterType.Country, "test"));
            filter.SelectMany(x => x.SearchFilterItems).Should().Contain(new ActivitySearchFilterItem(ActivityFilterType.Destination, "BCN"));
        }

        [Fact]
        public void adding_price_range_should_add_two_items()
        {
            var filter = new SearchRequestFilterBuilder().With()
                .PriceRange("50", "60")
                .Build();

            filter.Count.Should().Be(1);
            filter.First().SearchFilterItems.Count.Should().Be(2);
        }


        [Fact]
        public void adding_segment_should_add_two_items()
        {
            var filter = new SearchRequestFilterBuilder().With()
                .Segment("Tehran", "60")
                .Build();

            filter.Count.Should().Be(1);
            filter.First().SearchFilterItems.Count.Should().Be(2);
        }

        [Fact]
        public void adding_two_items_with_or_should_have_two_filters()
        {
            var filter = new SearchRequestFilterBuilder().With()
                .Country("test")
                .Or().With()
                .Country("test2")
                .Build();

            filter.Count.Should().Be(2);
            filter.ElementAt(0).SearchFilterItems.Should().Contain(new ActivitySearchFilterItem(ActivityFilterType.Country, "test"));
            filter.ElementAt(1).SearchFilterItems.Should().Contain(new ActivitySearchFilterItem(ActivityFilterType.Country, "test2"));
        }

        [Fact]
        public void
            adding_two_items_with_and_in_a__two_item_or_clause_should_contain_a_list_containing_two_items_each_have_two()
        {
            var filter = new SearchRequestFilterBuilder().With()
                .Country("test").And().Destination("Paris")
                .Or().With()
                .Country("test2").And().Destination("Tehran")
                .Build();

            filter.Count.Should().Be(2);

            filter.ElementAt(0).SearchFilterItems.Should().Contain(new ActivitySearchFilterItem(ActivityFilterType.Country, "test"));
            filter.ElementAt(0).SearchFilterItems.Should().Contain(new ActivitySearchFilterItem(ActivityFilterType.Destination, "Paris"));

            filter.ElementAt(1).SearchFilterItems.Should().Contain(new ActivitySearchFilterItem(ActivityFilterType.Country, "test2"));
            filter.ElementAt(1).SearchFilterItems.Should().Contain(new ActivitySearchFilterItem(ActivityFilterType.Destination, "Tehran"));
        }

        [Fact]
        public void creating_a_filter_request_with_a_custom_list_structure()
        {
            IList<Filter> filters = new List<Filter>
            {
                new Filter()
                {
                    FilterItems = new List<FilterItem>()
                    {
                        new FilterItem() { Type = "country", Value = "ES" },
                        new FilterItem() { Type = "destination", Value = "BCN" }
                    }
                }
            };

            var filter = new SearchRequestFilterBuilder()
                .With().ListOf(filters)
                .WithItems(x => x.FilterItems)
                .WithProperties(
                    x => x.Type,
                    x => x.Value,
                    x => x.Latitude,
                    x => x.Longitude)
                .Build();

            filter.Count.Should().Be(1);
            filter.First().SearchFilterItems.Count.Should().Be(2);
        }

        [Fact]
        public void creating_a_filter_request_with_a_custom_list_structure_more_complex()
        {
            IList<Filter> filters = new List<Filter>
            {
                new Filter()
                {
                    FilterItems = new List<FilterItem>()
                    {
                        new FilterItem() { Type = "country", Value = "ES" },
                        new FilterItem() { Type = "destination", Value = "BCN" }
                    }
                },
                new Filter()
                {
                    FilterItems = new List<FilterItem>()
                    {
                        new FilterItem() { Type = "country", Value = "ES" },
                        new FilterItem() { Type = "destination", Value = "BCN" }
                    }
                },
                new Filter()
                {
                    FilterItems = new List<FilterItem>()
                    {
                        new FilterItem() { Type = "country", Value = "ES" },
                        new FilterItem() { Type = "destination", Value = "BCN" }
                    }
                }

            };

            var filter = new SearchRequestFilterBuilder()
                .With().ListOf(filters)
                .WithItems(x => x.FilterItems)
                .WithProperties(
                    x => x.Type,
                    x => x.Value,
                    x => x.Latitude,
                    x => x.Longitude)
                .Build();

            filter.Count.Should().Be(3);
            filter.First().SearchFilterItems.Count.Should().Be(2);
        }

        internal class Filter
        {
            public List<FilterItem> FilterItems { get; set; }
        }

        internal class FilterItem
        {
            public string Value { get; set; }
            public string Type { get; set; }
            public decimal? Latitude { get; set; }
            public decimal? Longitude { get; set; }
        }
    }
}
