namespace HotelBeds.Api.Activities
{
    public class ActivityApiVersion : IActivityVersionSelector
    {
        public enum Versions { V1, V3 };

        public Versions Version { get; }

        public ActivityApiVersion(Versions version)
        {
            Version = version;
        }

        public string GetVersion()
        {
            string v = "1.0";
            if (Version == Versions.V1) return v;
            if (Version == Versions.V3) v = "3.0";

            return v;
        }
    }
}