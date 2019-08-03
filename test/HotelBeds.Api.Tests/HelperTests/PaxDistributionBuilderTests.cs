using System.Linq;
using FluentAssertions;
using HotelBeds.Api.Activities.Helpers.PaxDistribution;
using Xunit;

namespace HotelBeds.Api.Tests.HelperTests
{
    public class PaxDistributionBuilderTests
    {
        [Fact]
        public void pax_might_not_have_type_but_should_have_age()
        {
            var paxes = new PaxDistributionBuilder()
                .APax().WithAge(20)
                .Build();

            paxes.First().Age.Should().Be(20);
        }

        [Fact]
        public void adult_pax_should_have_correct_type()
        {
            var paxes = new PaxDistributionBuilder()
                .AnAdult().WithAge(20)
                .Build();

            paxes.First().Type.GetCode().Should().Be("ADULT");
        }

        [Fact]
        public void child_pax_should_have_correct_type()
        {
            var paxes = new PaxDistributionBuilder()
                .AChild().WithAge(5)
                .Build();

            paxes.First().Type.GetCode().Should().Be("CHILD");
        }

        [Fact]
        public void infant_pax_should_have_correct_type()
        {
            var paxes = new PaxDistributionBuilder()
                .AnInfant().WithAge(2)
                .Build();

            paxes.First().Type.GetCode().Should().Be("INFANT");
        }

        [Fact]
        public void should_create_correct_pax_with_a()
        {
            var paxes = new PaxDistributionBuilder()
                .A("CHILD").WithAge(2)
                .Build();

            paxes.First().Type.GetCode().Should().Be("CHILD");
        }

        [Fact]
        public void should_create_correct_pax_with_an()
        {
            var paxes = new PaxDistributionBuilder()
                .An("ADULT").WithAge(2)
                .Build();

            paxes.First().Type.GetCode().Should().Be("ADULT");
        }

        [Fact]
        public void chaining_pax_type_methods_should_result_multiple_paxes_in_result_list()
        {
            var paxes = new PaxDistributionBuilder()
                .APax().WithAge(20)
                .APax().WithAge(19)
                .Build();

            paxes.Count.Should().Be(2);
            paxes.ElementAt(0).Age.Should().Be(20);
            paxes.ElementAt(1).Age.Should().Be(19);
        }

        [Fact]
        public void chaining_different_pax_type_methods_should_result_correct_list()
        {
            var paxes = new PaxDistributionBuilder()
                .AnAdult().WithAge(20)
                .AChild().WithAge(19)
                .APax().WithAge(40)
                .Build();

            paxes.Count.Should().Be(3);
            paxes.ElementAt(0).Age.Should().Be(20);
            paxes.ElementAt(0).Type.GetCode().Should().Be("ADULT");

            paxes.ElementAt(1).Age.Should().Be(19);
            paxes.ElementAt(1).Type.GetCode().Should().Be("CHILD");

            paxes.ElementAt(2).Age.Should().Be(40);
            paxes.ElementAt(2).Type.Should().BeNull();
        }
    }
}