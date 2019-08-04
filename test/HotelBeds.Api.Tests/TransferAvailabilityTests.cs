using System;
using FluentAssertions;
using HotelBeds.Api.Tests.TestData;
using HotelBeds.Shared;
using HotelBeds.Shared.Transfer.Domain;
using HotelBeds.Shared.Transfer.Request;
using Xunit;

namespace HotelBeds.Api.Tests
{
    public class TransferAvailabilityTests
    {
        [Fact]
        public void sending_a_one_way_availability_get_request_should_result_response()
        {
            string outboundDate = DateTime.Now.AddDays(2).ToString("yyyy-MM-ddTHH:mm:ss");

            var client = TestApiInformation.TransferApiClient;
            var response = client.Availability(new AvailabilityRequest("en", TransferPointType.Atlas, "733", TransferPointType.Iata,
                "PMI", outboundDate, 2, 1, 0));

            response.Error.Should().BeNull();
            response.Search.Should().NotBeNull();
            response.Services.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void sending_a_two_way_availability_get_request_should_result_response()
        {
            string outboundDate = DateTime.Now.AddDays(2).ToString("yyyy-MM-ddTHH:mm:ss");
            string inboundDate = DateTime.Now.AddDays(3).ToString("yyyy-MM-ddTHH:mm:ss");

            var client = TestApiInformation.TransferApiClient;
            var response = client.Availability(new AvailabilityRequest("en", TransferPointType.Atlas, "85841", TransferPointType.Port,
                "PPMI", outboundDate, inboundDate, 2, 1, 0));

            response.Error.Should().BeNull();
            response.Search.Should().NotBeNull();
            response.Services.Should().NotBeNullOrEmpty();
        }
    }
}