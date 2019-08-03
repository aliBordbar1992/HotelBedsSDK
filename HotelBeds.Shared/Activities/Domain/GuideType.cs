namespace HotelBeds.Shared.Activities.Domain
{
    public class GuideType : EnumType<GuideType>, IDomainType
    {
        public static readonly GuideType TourGuide = new GuideType("TOURGUIDE");
        public static readonly GuideType AudioGuide = new GuideType("AUDIOGUIDE");
        public static readonly GuideType None = new GuideType("NONE");

        public IDomainType Default => None;

        GuideType(string code) : base(code)
        {
        }

        public string GetCode()
        {
            return Code;
        }
    }
}