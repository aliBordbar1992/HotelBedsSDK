using System;
using System.Collections.Generic;
using FluentAssertions;
using HotelBeds.Api.Activities;
using HotelBeds.Api.Activities.Helpers.BookingConfirm;
using HotelBeds.Api.Tests.ActivityTests.Fixtures;
using HotelBeds.Api.Tests.TestData;
using HotelBeds.Shared.Activities.Dto;
using Xunit;

namespace HotelBeds.Api.Tests.ActivityTests
{
    public class BookingDetailsTests
    {
        private readonly ActivityDetailsFixture _fixture;

        public BookingDetailsTests()
        {
            ActivityDetailsFixture fixture = new ActivityDetailsFixture();
            _fixture = fixture;
        }

        [Fact]
        public void getting_booking_details_with_reference_should_result_with_no_errors()
        {
            //Setup
            string clientReference = "test12345";
            string language = "en";
            var activities = new List<BookingConfirmService>
            {
                new BookingConfirmService(DateTime.Now, DateTime.Now, _fixture.RateKey)
            };
            var request = new BookingConfirmRequestBuilder(clientReference, language)
                .WithAHolder(h => h.Mr("John", "Smith"))
                .WithActivities(activities)
                .Build();

            var activity = TestApiInformation.ActivityApiClient;
            var confirmedResponse = activity.ConfirmBooking(request);

            //Exercise
            var details = activity.BookingDetails(language, confirmedResponse.Booking.Reference);

            //Verify
            details.Errors.Should().BeNullOrEmpty();

            //CleanUp
            Cancel(language, confirmedResponse.Booking.Reference);
        }

        [Fact]
        public void getting_booking_details_with_client_reference_should_result_with_no_errors()
        {
            //TODO this error is probably from the api

            //Setup
            string clientReference = "test12345";
            string language = "en";
            var activities = new List<BookingConfirmService>
            {
                new BookingConfirmService(DateTime.Now, DateTime.Now, _fixture.RateKey)
            };
            var request = new BookingConfirmRequestBuilder(clientReference, language)
                .WithAHolder(h => h.Mr("John", "Smith"))
                .WithActivities(activities)
                .Build();

            var activity = TestApiInformation.ActivityApiClient;
            var confirmedResponse = activity.ConfirmBooking(request);

            //Exercise
            var details = activity.BookingDetails(language, clientReference, "John", "Smith", DateTime.Now, DateTime.Now);

            //Verify
            details.Errors.Should().BeNullOrEmpty();

            //CleanUp
            Cancel(language, confirmedResponse.Booking.Reference);
        }

        [Fact]
        public void getting_booking_list_should_result_with_no_errors()
        {
            //Setup
            string language = "en";

            var activity = TestApiInformation.ActivityApiClient;

            //Exercise
            var details = activity.BookingList(language, DateTime.Now.AddDays(-2), DateTime.Now, FilterType.CREATION, true);

            //Verify
            details.Errors.Should().BeNullOrEmpty();
        }

        private void Cancel(string language, string reference)
        {
            var activity = TestApiInformation.ActivityApiClient;
            activity.CancelBooking(language, reference, false);
        }
    }
}