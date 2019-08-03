using System;
using System.Collections.Generic;
using FluentAssertions;
using HotelBeds.Api.Activities.Helpers;
using HotelBeds.Api.Activities.Helpers.PaxDistribution;
using HotelBeds.Api.Activities.Helpers.RequestFilter;
using HotelBeds.Api.Tests.TestData;
using HotelBeds.Shared.Activities.Dto;
using Xunit;

namespace HotelBeds.Api.Tests.HelperTests
{
    public class SearchRequestBuilderTests
    {
        [Fact]
        public void request_builder_constructor_should_accept_filters_as_list()
        {
            var filter = new SearchRequestFilterBuilder()
                .With().Country(TestDestinations.Barcelona.CountryCode)
                .And().Destination(TestDestinations.Barcelona.DestinationCode)
                .Build();

            var request = new SearchRequestBuilder(filter, DateTime.MinValue, DateTime.MaxValue).Build();

            request.Filters.Count.Should().Be(1);
        }

        [Fact]
        public void request_builder_constructor_should_accept_filters_builder()
        {
            var filterBuilder = new SearchRequestFilterBuilder()
                .With().Country(TestDestinations.Barcelona.CountryCode)
                .And().Destination(TestDestinations.Barcelona.DestinationCode);

            var request = new SearchRequestBuilder(filterBuilder, DateTime.Now, DateTime.Now.AddDays(5))
                .Paginated(1, 1)
                .Build();

            request.Filters.Count.Should().Be(1);
        }
    }

    public class ActivityDetailsRequestBuilderTests
    {
        [Fact]
        public void details_builder_constructor_should_accept_paxes_as_list()
        {
            var paxes = new PaxDistributionBuilder()
                .APax().WithAge(30)
                .APax().WithAge(20)
                .Build();

            var request = new ActivityDetailRequestBuilder("code", DateTime.Now, DateTime.Now.AddDays(5), paxes).Build();

            request.Paxes.Count.Should().Be(2);
        }

        [Fact]
        public void details_builder_constructor_should_accept_pax_builder()
        {
            var paxBuilder = new PaxDistributionBuilder()
                .APax().WithAge(30)
                .APax().WithAge(20);

            var request = new ActivityDetailRequestBuilder("code", DateTime.Now, DateTime.Now.AddDays(5), paxBuilder).Build();

            request.Paxes.Count.Should().Be(2);
        }



        [Fact]
        public void passing_null_as_paxes_should_throw_argument_exception()
        {
            List<PaxDistribution> paxes = null;
            Action act = () => new ActivityDetailRequestBuilder("code", DateTime.Now, DateTime.Now.AddDays(5), paxes);

            act.Should().Throw<ArgumentException>();
        }
    }
}