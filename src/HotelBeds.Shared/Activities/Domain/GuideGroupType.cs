namespace HotelBeds.Shared.Activities.Domain
{
    public class GuideGroupType : EnumType<GuideGroupType>, IDomainType
    {
        public static readonly GuideGroupType Private = new GuideGroupType("PRIVATE");
        public static readonly GuideGroupType Shared = new GuideGroupType("SHARED");
        public static readonly GuideGroupType Unknown = new GuideGroupType("UNKNOWN");

        public IDomainType Default => Unknown;

        GuideGroupType(string code) : base(code)
        {
        }

        public string GetCode()
        {
            return Code;
        }
    }
}