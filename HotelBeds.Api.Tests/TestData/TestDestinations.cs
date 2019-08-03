namespace HotelBeds.Api.Tests.TestData
{
    public class TestDestinations
    {
        public static TestCountryDto Barcelona => new TestCountryDto {CountryCode = "ES", DestinationCode = "BCN"};
        public static TestCountryDto Berlin => new TestCountryDto { CountryCode = "DE", DestinationCode = "BER" };
        public static TestCountryDto Tenerife => new TestCountryDto { CountryCode = "ES", DestinationCode = "TFS" };
        public static TestCountryDto Krakow => new TestCountryDto { CountryCode = "PL", DestinationCode = "KRK" };
        public static TestCountryDto Orlando => new TestCountryDto { CountryCode = "US", DestinationCode = "MCO" }; 
    }
}