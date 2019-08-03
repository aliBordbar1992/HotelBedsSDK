using HotelBeds.Shared.Activities.Domain;

namespace HotelBeds.Shared.Transfer.Domain
{
    public class TransferStatusType : EnumType<TransferStatusType>, IDomainType
    {
        public static readonly TransferStatusType Confirmed = new TransferStatusType("CONFIRMED");
        public static readonly TransferStatusType Cancelled = new TransferStatusType("CANCELLED");
        public static readonly TransferStatusType Modified = new TransferStatusType("MODIFIED");
        public static readonly TransferStatusType Unknown = new TransferStatusType("?");

        public IDomainType Default => Unknown;

        TransferStatusType(string code) : base(code)
        {
        }

        public string GetCode()
        {
            return Code;
        }
    }
}