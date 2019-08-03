using HotelBeds.Api.Tests.Fixtures;
using HotelBeds.Api.Tests.TestData;
using System;
using System.Collections.Generic;
using FluentAssertions;
using HotelBeds.Api.Activities.Helpers.BookingConfirm;
using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Activities.Dto;
using Xunit;

namespace HotelBeds.Api.Tests
{
    public class BookingCancelTests : IClassFixture<ActivityDetailsFixture>
    {
        private readonly ActivityDetailsFixture _fixture;

        public BookingCancelTests(ActivityDetailsFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void should_simulate_and_cancel_a_confirmed_booking()
        {
            string clientReference = "test12345";
            string language = "en";
            var activities = new List<BookingConfirmService>
            {
                new BookingConfirmService(DateTime.Now, DateTime.Now, _fixture.RateKey)
            };
            var confirmRequest = new BookingConfirmRequestBuilder(clientReference, language)
                .WithAHolder(h => h.Mr("John", "Smith"))
                .WithActivities(activities)
                .Build();

            var activity = TestApiInformation.ActivityApiClient;
            var confirmResponse = activity.ConfirmBooking(confirmRequest);

            var reference = confirmResponse.Booking.Reference;

            var simulationResponse = activity.CancelBooking(language, reference, true);

            simulationResponse.Errors.Should().BeNullOrEmpty();
            simulationResponse.Booking.Status.Should().Be(BookingStatus.CONFIRMED);

            var cancelSimulationResponse = activity.CancelBooking(language, reference, false);

            cancelSimulationResponse.Errors.Should().BeNullOrEmpty();
            cancelSimulationResponse.Booking.Status.Should().Be(BookingStatus.CANCELLED);
        }
    }
}