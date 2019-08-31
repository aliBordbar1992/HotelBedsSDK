using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using HotelBeds.Api.Activities.Helpers.BookingConfirm;
using HotelBeds.Shared.Activities.Dto;
using Xunit;

namespace HotelBeds.Api.Tests.ActivityTests.HelperTests
{
    public class BookingConfirmRequestBuilderTests
    {
        [Fact]
        public void booking_confirm_request_builder_should_create_request()
        {
            string clientReference = "test12345";
            string language = "en";
            var activities = new List<BookingConfirmService>
            {
                new BookingConfirmService(DateTime.Now, DateTime.Now, "someKey")
            };
            var req = new BookingConfirmRequestBuilder(clientReference, language)
                .WithAHolder(h => h.Mr("John", "Smith"))
                .WithActivities(activities)
                .Build();

            req.Activities.Count.Should().Be(1);
            req.ClientReference.Should().Be(clientReference);
            req.Language.Should().Be(language);
            req.Holder.Name.Should().Be("John");
            req.Holder.Surname.Should().Be("Smith");
        }

        [Fact]
        public void holder_builder_should_return_holder_with_mr()
        {
            var holder = new BookingHolderBuilder()
                .Mr("John", "Smith").Build();

            holder.Title.Should().Be("Mr");
            holder.Name.Should().Be("John");
            holder.Surname.Should().Be("Smith");
        }

        [Fact]
        public void holder_builder_should_return_holder_with_ms()
        {
            var holder = new BookingHolderBuilder()
                .Ms("Ellen", "Harper").Build();

            holder.Title.Should().Be("Ms");
            holder.Name.Should().Be("Ellen");
            holder.Surname.Should().Be("Harper");
        }

        [Fact]
        public void holder_builder_should_should_chain_more_options()
        {
            var holder = new BookingHolderBuilder()
                .Miss("Ellen", "Harper")
                .LivesIn("ES", "Cami Son Fangos 100", "07007")
                .HasPhoneNumber("123456789", "123456798")
                .HasEmail("j.smith@hotelbeds.com", false)
                .WantsToReceiveCommunicationsViaEmail()
                .Build();

            holder.Country.Should().Be("ES");
            holder.Address.Should().Be("Cami Son Fangos 100");
            holder.ZipCode.Should().Be("07007");
            holder.Email.Should().Be("j.smith@hotelbeds.com");
            holder.Mailing.Should().BeTrue();
            holder.Telephones.First().Should().Be("123456789");
        }
    }
}