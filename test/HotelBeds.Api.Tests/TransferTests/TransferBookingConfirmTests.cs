using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using HotelBeds.Api.Tests.TestData;
using HotelBeds.Shared;
using HotelBeds.Shared.Transfer.Domain;
using HotelBeds.Shared.Transfer.Dto;
using HotelBeds.Shared.Transfer.Request;
using Xunit;

namespace HotelBeds.Api.Tests.TransferTests
{
    public class TransferBookingConfirmTests
    {
        [Fact]
        public void booking_confirm_a_one_way_trip_should_result_no_error()
        {
            //Setup
            string outboundDate = DateTime.Now.AddDays(2).ToString("yyyy-MM-ddTHH:mm:ss");

            var client = TestApiInformation.TransferApiClient;
            var availabilityResponse = client.Availability(new AvailabilityRequest("en", TransferPointType.Atlas, "85841", TransferPointType.Port,
                "PPMI", outboundDate, 2, 1, 0));


            string clientReference = "test12345";
            string welcomeMessage = "Welcome my friend!";
            string remark = "Booking remarks are to be written here.";
            string language = "en";

            Pax holder = new Pax()
            {
                Title = "Mr",
                Name = "John",
                Surname = "Doe",
                Email = "john.doe@hotelbeds.com",
                Phone = "+16543245812"
            };

            var transfer = new Shared.Transfer.Dto.Transfer()
            {
                RateKey = availabilityResponse.Services.First().RateKey,
                Detail = new Detail()
                {
                    ArrivalFlightNumber = "XR1234",
                    DepartureFlightNumber = "XR5678"
                }
            };


            var request = new ConfirmRequest
            {
                Holder = holder,
                Language = language,
                ClientReference = clientReference,
                Remark = remark,
                Transfers = new List<Shared.Transfer.Dto.Transfer>
                {
                    transfer
                },
                WelcomeMessage = welcomeMessage
            };

            //Exercise
            var response = client.Confirm(request);

            //Verify
            response.Error.Should().BeNull();

            //CleanUp
            Cancel(language, response.Bookings.First().Reference);
        }

        [Fact]
        public void booking_confirm_a_two_way_trip_should_result_no_error()
        {
            //Setup
            string outboundDate = DateTime.Now.AddDays(2).ToString("yyyy-MM-ddTHH:mm:ss");
            string inboundDate = DateTime.Now.AddDays(3).ToString("yyyy-MM-ddTHH:mm:ss");

            var client = TestApiInformation.TransferApiClient;
            var availabilityResponse = client.Availability(new AvailabilityRequest("en", TransferPointType.Atlas, "85841", TransferPointType.Port,
                "PPMI", outboundDate, inboundDate, 2, 1, 0));


            string clientReference = "test12345";
            string welcomeMessage = "Welcome my friend!";
            string remark = "Booking remarks are to be written here.";
            string language = "en";

            Pax holder = new Pax()
            {
                Title = "Mr",
                Name = "John",
                Surname = "Doe",
                Email = "john.doe@hotelbeds.com",
                Phone = "+16543245812"
            };

            var request = new ConfirmRequest
            {
                Holder = holder,
                Language = language,
                ClientReference = clientReference,
                Remark = remark,
                Transfers = new List<Shared.Transfer.Dto.Transfer>
                {
                    new Shared.Transfer.Dto.Transfer()
                    {
                        RateKey = availabilityResponse.Services.First(x => x.Direction == DirectionType.Departure).RateKey,
                        Detail = new Detail { ArrivalFlightNumber = "XR1234",DepartureFlightNumber = "XR5678" }
                    },
                    new Shared.Transfer.Dto.Transfer()
                    {
                        RateKey = availabilityResponse.Services.First(x => x.Direction == DirectionType.Return).RateKey,
                        Detail = new Detail { ArrivalFlightNumber = "XR1234",DepartureFlightNumber = "XR5678" }
                    }
                },
                WelcomeMessage = welcomeMessage
            };

            //Exercise
            var response = client.Confirm(request);

            //Verify
            response.Error.Should().BeNull();

            //CleanUp
            Cancel(language, response.Bookings.First().Reference);
        }

        private void Cancel(string language, string reference)
        {
            var client = TestApiInformation.TransferApiClient;
            client.Cancel(language, reference);
        }
    }
}