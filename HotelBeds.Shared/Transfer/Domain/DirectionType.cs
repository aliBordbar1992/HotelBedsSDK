using HotelBeds.Shared.Activities.Domain;

namespace HotelBeds.Shared.Transfer.Domain
{
    public class DirectionType : EnumType<DirectionType>, IDomainType
    {
        public static readonly DirectionType Arrival = new DirectionType("ARRIVAL");
        public static readonly DirectionType Departure = new DirectionType("DEPARTURE");
        public static readonly DirectionType Return = new DirectionType("RETURN");
        public static readonly DirectionType Unknown = new DirectionType("?");

        public IDomainType Default => Unknown;

        DirectionType(string code) : base(code)
        {
        }

        public string GetCode()
        {
            return Code;
        }
    }
}