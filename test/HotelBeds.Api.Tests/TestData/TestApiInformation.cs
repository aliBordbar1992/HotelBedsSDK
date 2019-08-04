using System;
using System.Security.Cryptography;
using System.Text;
using HotelBeds.Api.Activities;
using HotelBeds.Api.Transfer;

namespace HotelBeds.Api.Tests.TestData
{
    public class TestApiInformation
    {
        public static string ActivityApiKey => "9z8f4jry8dhuk5j65c58sgha";
        public static string ActivitySecret => "FDBDYq3b2Y";

        public static IActivityApi ActivityApiClient =>
            new ActivityApi(new ApiClient(TestApiInformation.ActivityApiKey, TestApiInformation.ActivitySecret),
                new ActivityApiBaseUrl {BaseUrl = "https://api.test.hotelbeds.com/activity-api"},
                new ActivityApiVersion(ActivityApiVersion.Versions.V3));

        public static ITransferApi TransferApiClient =>
            new TransferApi(new ApiClient(TestApiInformation.ActivityApiKey, TestApiInformation.ActivitySecret),
                new TransferApiBaseUrl() {BaseUrl = "https://api.test.hotelbeds.com/transfer-api"},
                new TransferApiVersion());

        public static string Signature
        {
            get
            {
                string signature;
                using (var sha = SHA256.Create())
                {
                    long ts = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds / 1000;
                    Console.WriteLine("Timestamp: " + ts);
                    var computedHash = sha.ComputeHash(Encoding.UTF8.GetBytes(ActivityApiKey + ActivitySecret + ts));
                    signature = BitConverter.ToString(computedHash).Replace("-", "");
                }

                return signature;
            }
        }
    }
}