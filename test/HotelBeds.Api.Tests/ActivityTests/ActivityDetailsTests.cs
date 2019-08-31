using System;
using FluentAssertions;
using HotelBeds.Api.Activities.Helpers;
using HotelBeds.Api.Activities.Helpers.PaxDistribution;
using HotelBeds.Api.Tests.TestData;
using Xunit;

namespace HotelBeds.Api.Tests.ActivityTests
{
    public class ActivityDetailsTests
    {
        [Fact]
        public void sending_an_activity_details_request_should_not_contain_errors()
        {
            var paxes = new PaxDistributionBuilder()
                .APax().WithAge(20)
                .APax().WithAge(20)
                .Build();

            var request = new ActivityDetailRequestBuilder(MiscTestInformation.ActivityDetailsCode, DateTime.Now, DateTime.Now.AddDays(5), paxes).Build();

            var activity = TestApiInformation.ActivityApiClient;
            var activityDetailsResponse = activity.Details(request);

            activityDetailsResponse.Errors.Should().BeNullOrEmpty();
        }
    }
}