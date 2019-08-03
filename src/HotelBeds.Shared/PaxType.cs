using HotelBeds.Shared.Activities.Domain;

namespace HotelBeds.Shared
{
    public class PaxType : EnumType<PaxType>, IDomainType
    {
        public static readonly PaxType Adult = new PaxType("ADULT");
        public static readonly PaxType Child = new PaxType("CHILD");
        public static readonly PaxType Infant = new PaxType("INFANT");

        public IDomainType Default => null;

        PaxType(string code) : base(code)
        {
        }

        public string GetCode()
        {
            return Code;
        }
    }
}