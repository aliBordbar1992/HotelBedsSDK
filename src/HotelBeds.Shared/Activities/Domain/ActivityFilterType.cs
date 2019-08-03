using System.Collections.Generic;
using System.Text;

namespace HotelBeds.Shared.Activities.Domain
{
    public class ActivityFilterType : EnumType<ActivityFilterType>, IDomainType
    {
        public static readonly ActivityFilterType Hotel = new ActivityFilterType("hotel");
        public static readonly ActivityFilterType HotelGiata = new ActivityFilterType("giata");
        public static readonly ActivityFilterType HotelTti = new ActivityFilterType("tti");
        public static readonly ActivityFilterType Destination = new ActivityFilterType("destination");
        public static readonly ActivityFilterType DestinationIso = new ActivityFilterType("destination-iso");
        public static readonly ActivityFilterType Gps = new ActivityFilterType("gps");
        public static readonly ActivityFilterType Factsheed = new ActivityFilterType("factsheet");
        public static readonly ActivityFilterType Text = new ActivityFilterType("text");
        public static readonly ActivityFilterType Segment = new ActivityFilterType("segment");
        public static readonly ActivityFilterType Country = new ActivityFilterType("country");
        public static readonly ActivityFilterType Service = new ActivityFilterType("service");
        public static readonly ActivityFilterType ServiceModality = new ActivityFilterType("service_modality");
        public static readonly ActivityFilterType PriceFrom = new ActivityFilterType("priceFrom");
        public static readonly ActivityFilterType PriceTo = new ActivityFilterType("priceTo");


        public IDomainType Default => null;

        ActivityFilterType(string code) : base(code)
        {
        }

        public string GetCode()
        {
            return Code;
        }


        public static string GetAllowedTypes()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ActivityFilterType filter in Values)
            {
                if (sb.Length > 0) { sb.Append(", "); }
                sb.Append(filter.GetType());
            }
            return sb.ToString();
        }

        public static List<ActivityFilterType> GetHotelFilters()
        {
            return new List<ActivityFilterType>()
            {
                Hotel,
                HotelGiata,
                HotelTti
            };
        }

        public static List<ActivityFilterType> GetDestinationFilters()
        {
            return new List<ActivityFilterType>
            {
                Destination,
                DestinationIso
            };
        }

        public static List<ActivityFilterType> GetPriceFilters()
        {
            return new List<ActivityFilterType>
            {
                PriceFrom,
                PriceTo
            };
        }
    }
}