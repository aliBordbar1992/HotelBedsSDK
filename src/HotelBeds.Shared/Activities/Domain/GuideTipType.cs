namespace HotelBeds.Shared.Activities.Domain
{
    public class GuideTipType : EnumType<GuideTipType>, IDomainType
    {

        public static readonly GuideTipType INCLUDED = new GuideTipType("INCLUDED");
        public static readonly GuideTipType EXCLUDED = new GuideTipType("EXCLUDED");

        GuideTipType(string code) : base(code)
        {
        }

        public IDomainType Default => EXCLUDED;
        public string GetCode()
        {
            return Code;
        }
    }
}