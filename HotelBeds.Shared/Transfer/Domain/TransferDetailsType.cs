using HotelBeds.Shared.Activities.Domain;

namespace HotelBeds.Shared.Transfer.Domain
{
    public class TransferDetailsType : EnumType<TransferDetailsType>, IDomainType
    {
        public static readonly TransferDetailsType GeneralInfo = new TransferDetailsType("GENERAL_INFO");
        public static readonly TransferDetailsType GenericGuidelines = new TransferDetailsType("GENERIC_GUIDELINES");
        public static readonly TransferDetailsType Unknown = new TransferDetailsType("?");

        public IDomainType Default => Unknown;

        TransferDetailsType(string code) : base(code)
        {
        }

        public string GetCode()
        {
            return Code;
        }
    }
}