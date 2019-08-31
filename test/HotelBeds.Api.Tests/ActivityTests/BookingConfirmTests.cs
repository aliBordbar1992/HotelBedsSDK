using System;
using System.Collections.Generic;
using FluentAssertions;
using HotelBeds.Api.Activities.Helpers.BookingConfirm;
using HotelBeds.Api.Tests.ActivityTests.Fixtures;
using HotelBeds.Api.Tests.TestData;
using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Activities.Dto;
using HotelBeds.Shared.Activities.Request;
using Xunit;

namespace HotelBeds.Api.Tests.ActivityTests
{
    public class BookingConfirmTests
    {
        private readonly ActivityDetailsFixture _fixture;

        public BookingConfirmTests()
        {
            ActivityDetailsFixture fixture = new ActivityDetailsFixture();
            _fixture = fixture;
        }

        [Fact]
        public void booking_confirm_an_activity_should_result_no_error()
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

            //Exercise
            var response = activity.ConfirmBooking(request);

            //Verify
            response.Errors.Should().BeNullOrEmpty();

            //CleanUp
            Cancel(language, response.Booking.Reference);
        }

        [Fact]
        public void booking_with_pre_confirm_request_should_result_response_with_PRECONFIRMED_status()
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

            //Exercise
            var response = activity.PreConfirmBooking(request);

            //Verify
            response.Errors.Should().BeNullOrEmpty();
            response.Booking.Status.Should().Be(BookingStatus.PRECONFIRMED);

            //CleanUp
            var reconfirmRequest = new BookingReconfirmRequest(response.Booking.Reference, language);
            var cnfrm = activity.ReconfirmBooking(reconfirmRequest);
            cnfrm.Booking.Status.Should().Be(BookingStatus.CONFIRMED);
            Cancel(language, cnfrm.Booking.Reference);
        }

        [Fact]
        public void reconfirming_a_pre_confirmed_booking_should_result_response_with_CONFIRMED_status()
        {
            //Setup
            string clientReference = "test12345";
            string language = "en";
            var activities = new List<BookingConfirmService>
            {
                new BookingConfirmService(DateTime.Now, DateTime.Now, _fixture.RateKey)
            };
            var preConfirmRequest = new BookingConfirmRequestBuilder(clientReference, language)
                .WithAHolder(h => h.Mr("John", "Smith"))
                .WithActivities(activities)
                .Build();

            var activity = TestApiInformation.ActivityApiClient;

            var preConfirm = activity.PreConfirmBooking(preConfirmRequest);

            var reconfirmRequest = new BookingReconfirmRequest(preConfirm.Booking.Reference, language);

            //Exercise
            var response = activity.ReconfirmBooking(reconfirmRequest);

            //Verify
            response.Booking.Status.Should().Be(BookingStatus.CONFIRMED);

            //CleanUp
            Cancel(language, response.Booking.Reference);
        }

        private void Cancel(string language, string reference)
        {
            var activity = TestApiInformation.ActivityApiClient;
            activity.CancelBooking(language, reference, false);
        }
    }
}