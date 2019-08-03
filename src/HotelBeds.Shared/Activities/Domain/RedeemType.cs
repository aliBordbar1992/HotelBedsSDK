namespace HotelBeds.Shared.Activities.Domain
{
    public class RedeemType : EnumType<RedeemType>, IDomainType
    {
        public static readonly RedeemType Evoucher = new RedeemType("EVOUCHER");
        public static readonly RedeemType Printed = new RedeemType("PRINTED");
        public static readonly RedeemType Vocuherless = new RedeemType("VOCUHERLESS");
        public static readonly RedeemType None = new RedeemType("NONE");



        public IDomainType Default => None;

        RedeemType(string code) : base(code)
        {
        }

        public string GetCode()
        {
            return Code;
        }
    }
}