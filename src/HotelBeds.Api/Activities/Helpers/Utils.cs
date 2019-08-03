using System.Runtime.CompilerServices;

namespace HotelBeds.Api.Activities.Helpers
{
    public static class Utils
    {
        public static string GetCaller([CallerMemberName] string caller = null)
        {
            return caller;
        }
    }
}