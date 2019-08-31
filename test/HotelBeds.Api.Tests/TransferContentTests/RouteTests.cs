using FluentAssertions;
using HotelBeds.Api.Tests.TestData;
using Xunit;

namespace HotelBeds.Api.Tests.TransferContentTests
{
    public class RouteTests
    {
        [Fact]
        public void retrieving_routes_with_default_parameters_should_return_all_routes()
        {
            var api = TestApiInformation.TransferContentApiClient;
            var response = api.Routes("PMI", offset: 1, limit:5);

            response.Routes.Should().NotBeNullOrEmpty();
        }
    }
}