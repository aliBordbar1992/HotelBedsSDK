namespace HotelBeds.Shared.Activities.Domain
{
    public class PointOfInterestType : EnumType<PointOfInterestType>, IDomainType
    {
        public static readonly PointOfInterestType Landmark = new PointOfInterestType("LANDMARK");
        public static readonly PointOfInterestType Address = new PointOfInterestType("ADDRESS");
        public static readonly PointOfInterestType Other = new PointOfInterestType("OTHER");

        public IDomainType Default => Other;

        PointOfInterestType(string code) : base(code)
        {
        }

        public string GetCode()
        {
            return Code;
        }
    }
}