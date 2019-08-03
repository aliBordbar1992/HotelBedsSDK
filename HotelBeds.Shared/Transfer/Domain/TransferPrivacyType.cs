using HotelBeds.Shared.Activities.Domain;

namespace HotelBeds.Shared.Transfer.Domain
{
    public class TransferPrivacyType : EnumType<TransferPrivacyType>, IDomainType
    {
        public static readonly TransferPrivacyType Private = new TransferPrivacyType("PRIVATE");
        public static readonly TransferPrivacyType Shared = new TransferPrivacyType("SHARED");
        public static readonly TransferPrivacyType Unknown = new TransferPrivacyType("?");

        public IDomainType Default => Unknown;

        TransferPrivacyType(string code) : base(code)
        {
        }

        public string GetCode()
        {
            return Code;
        }
    }
}