namespace HotelBeds.Shared.Activities.Domain
{
    public class MediaTagType : EnumType<MediaTagType>, IDomainType
    {
        public static readonly MediaTagType Map = new MediaTagType("MAP");
        public static readonly MediaTagType Leaflet = new MediaTagType("LEAFLET");
        public static readonly MediaTagType Recommendations = new MediaTagType("RECOMMENDATIONS");
        public static readonly MediaTagType AdvancedTips = new MediaTagType("ADVANCED_TIPS");
        public static readonly MediaTagType Other = new MediaTagType("OTHER");

        public IDomainType Default => Other;

        MediaTagType(string code) : base(code)
        {
        }

        public string GetCode()
        {
            return Code;
        }
    }
}