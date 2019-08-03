using System;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Examples
{
    class Program
    {
        public static void Main()
        {
            const string apiKey = "9z8f4jry8dhuk5j65c58sgha";
            const string secret = "FDBDYq3b2Y";
            while (true)
            {
                var signature = XSignature(apiKey, secret);

                Console.WriteLine("Signature: " + signature);
                Console.WriteLine("rege? y/n");
                string key = Console.ReadLine();
                if (key == "n") break;
            }
            

        }

        private static string XSignature(string apiKey, string secret)
        {
            string signature;
            using (var sha = SHA256.Create())
            {
                long ts = (long) (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds /
                          1000;
                Console.WriteLine("Timestamp: " + ts);
                var computedHash = sha.ComputeHash(Encoding.UTF8.GetBytes((string) (apiKey + secret + ts)));
                signature = BitConverter.ToString(computedHash).Replace("-", "");
            }

            return signature;
        }
    }
}