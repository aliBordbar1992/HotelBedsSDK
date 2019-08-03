namespace HotelBeds.Shared.Activities.Domain
{
    public class ModalityUnitType : EnumType<ModalityUnitType>, IDomainType
    {
        public static readonly ModalityUnitType Pax = new ModalityUnitType("PAX");
        public static readonly ModalityUnitType Service = new ModalityUnitType("SERVICE");
        public static readonly ModalityUnitType Unknown = new ModalityUnitType("?");
        public IDomainType Default => Unknown;

        ModalityUnitType(string code) : base(code)
        {
        }

        public string GetCode()
        {
            return Code;
        }
    }
}