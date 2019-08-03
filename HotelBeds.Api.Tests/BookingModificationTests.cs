using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using HotelBeds.Api.Activities;
using HotelBeds.Api.Activities.Helpers;
using HotelBeds.Api.Activities.Helpers.BookingConfirm;
using HotelBeds.Api.Activities.Helpers.PaxDistribution;
using HotelBeds.Api.Tests.Fixtures;
using HotelBeds.Api.Tests.TestData;
using HotelBeds.Shared;
using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Activities.Dto;
using HotelBeds.Shared.Activities.Request;
using HotelBeds.Shared.Activities.Response;
using Xunit;

namespace HotelBeds.Api.Tests
{
    public class BookingModificationTests
    {
        [Fact]
        public void adding_a_new_service_to_a_confirmed_booking_should_result_with_no_errors()
        {
            //Setup
            var activity = TestApiInformation.ActivityApiClient;
            string clientReference = "test12345";
            string language = "en";

            var confirmedBooking = BookAnActivity(activity, clientReference, language);

            var paxes = new PaxDistributionBuilder().AnAdult().WithAge(37).AnAdult().WithAge(20).Build();

            var newActivity = NewActivity(activity, paxes);
            newActivity.Paxes = new List<Pax>()
            {
                new Pax("Ali", "Bordbar", 37, PaxType.Adult),
                new Pax("Jack", "Smith", 20, PaxType.Adult)
            };

            var addRequest = new BookingModificationAddRequest(newActivity, clientReference, "some comments");

            //Exercise
            var addResponse = activity.ModifyBookingAddService(addRequest, language, confirmedBooking.Booking.Reference);

            //Verify
            addResponse.Errors.Should().BeNullOrEmpty();

            //CleanUp
            Cancel("en", addResponse.Booking.Reference);
        }

        [Fact]
        public void modifying_an_activity_in_a_confirmed_booking_should_reflect_changes()
        {
            //TODO this error is probably from the api

            var apiClient = TestApiInformation.ActivityApiClient;
            string clientReference = "test12345";
            string language = "en";

            var oldPaxes = new PaxDistributionBuilder().AnAdult().WithAge(30).AnAdult().WithAge(25).Build();

            var activities = GetActivities(apiClient, oldPaxes);

            var bookingConfirmRequest = new BookingConfirmRequestBuilder(clientReference, language)
                .WithAHolder(h => h.Mr("John", "Smith"))
                .WithActivities(activities)
                .Build();

            var confirmedResponse = apiClient.ConfirmBooking(bookingConfirmRequest);

            var newPaxes = new PaxDistributionBuilder().AnAdult().WithAge(37).AnAdult().WithAge(20).Build();

            var newActivity = NewActivity(apiClient, newPaxes);
            newActivity.AddPaxes(newPaxes);
            newActivity.ActivityId = confirmedResponse.Booking.Activities.First().Id;

            var modifyRequest = new BookingModificationModifyRequest(newActivity);

            //Exercise
            var modifyResponse = apiClient.ModifyBookingModifyService(modifyRequest, language, confirmedResponse.Booking.Reference);

            //Verify
            modifyResponse.Errors.Should().BeNullOrEmpty();

            //CleanUp
            Cancel("en", modifyResponse.Booking.Reference);
        }


        private BookingResponse BookAnActivity(IActivityApi activity, string clientReference, string language)
        {
            var paxes = new PaxDistributionBuilder().AnAdult().WithAge(30).AnAdult().WithAge(25).Build();

            var activities = GetActivities(activity, paxes);

            var bookingConfirmRequest = new BookingConfirmRequestBuilder(clientReference, language)
                .WithAHolder(h => h.Mr("John", "Smith"))
                .WithActivities(activities)
                .Build();

            var confirmedResponse = activity.ConfirmBooking(bookingConfirmRequest);
            return confirmedResponse;
        }

        private List<BookingConfirmService> GetActivities(IActivityApi activity, List<PaxDistribution> paxes)
        {
            return new List<BookingConfirmService> { NewActivity(activity, paxes) };
        }

        private static BookingConfirmService NewActivity(IActivityApi activity, List<PaxDistribution> paxes)
        {
            var activityDetailRequest1 = new ActivityDetailRequestBuilder(MiscTestInformation.ActivityDetailsCode, DateTime.Now, DateTime.Now.AddDays(5), paxes).Build();
            var activityDetailsResponse = activity.Details(activityDetailRequest1);

            string rateKey = activityDetailsResponse.Activity.Modalities.ElementAt(0).Rates.First().RateDetails.First().RateKey;

            var a = new BookingConfirmService(DateTime.Now, DateTime.Now, rateKey);

            return a;
        }

        private void Cancel(string language, string reference)
        {
            var activity = TestApiInformation.ActivityApiClient;
            activity.CancelBooking(language, reference, false);
        }
    }
}