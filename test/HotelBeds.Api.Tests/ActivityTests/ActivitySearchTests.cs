using System;
using FluentAssertions;
using HotelBeds.Api.Activities.Helpers;
using HotelBeds.Api.Activities.Helpers.RequestFilter;
using HotelBeds.Api.Tests.TestData;
using Xunit;

namespace HotelBeds.Api.Tests.ActivityTests
{
    public class ActivitySearchTests
    {
        [Fact]
        public void sending_a_search_request_should_not_contain_errors()
        {
            var filterBuilder = new SearchRequestFilterBuilder()
                .With().Country(TestDestinations.Barcelona.CountryCode)
                .And().Destination(TestDestinations.Barcelona.DestinationCode);

            var request = new SearchRequestBuilder(filterBuilder, DateTime.Now.AddDays(1), DateTime.Now.AddDays(5))
                .Paginated(1, 1)
                .Build();

            var activity = TestApiInformation.ActivityApiClient;
            var searchResponse = activity.Search(request);

            searchResponse.Errors.Should().BeNullOrEmpty();
        }

        [Fact]
        public void sending_a_search_request_with_past_date_should_return_errors_in_response()
        {
            var filterBuilder = new SearchRequestFilterBuilder()
                .With().Country(TestDestinations.Barcelona.CountryCode)
                .And().Destination(TestDestinations.Barcelona.DestinationCode);

            var request = new SearchRequestBuilder(filterBuilder, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(5))
                .Paginated(1, 1) 
                .Build();

            var activity = TestApiInformation.ActivityApiClient;
            var searchResponse = activity.Search(request);

            searchResponse.Errors.Should().NotBeNullOrEmpty();
        }
    }
}
