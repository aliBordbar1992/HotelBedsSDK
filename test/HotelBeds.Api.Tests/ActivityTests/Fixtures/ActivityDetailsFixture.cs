using System;
using System.Linq;
using HotelBeds.Api.Activities.Helpers;
using HotelBeds.Api.Activities.Helpers.PaxDistribution;
using HotelBeds.Api.Tests.TestData;

namespace HotelBeds.Api.Tests.ActivityTests.Fixtures
{
    public class ActivityDetailsFixture : IDisposable
    {
        public string RateKey { get; }
        public ActivityDetailsFixture()
        {
            var paxes = new PaxDistributionBuilder()
                .APax().WithAge(20)
                .APax().WithAge(20)
                .Build();

            var request = new ActivityDetailRequestBuilder(MiscTestInformation.ActivityDetailsCode, DateTime.Now, DateTime.Now.AddDays(5), paxes).Build();

            var activity = TestApiInformation.ActivityApiClient;
            var activityDetailsResponse = activity.Details(request);

            RateKey = activityDetailsResponse.Activity.Modalities.First().Rates.First().RateDetails.First().RateKey;
        }

        public void Dispose()
        {
        }
    }
}