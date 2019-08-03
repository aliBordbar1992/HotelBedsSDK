using HotelBeds.Shared.Activities.Domain;

namespace HotelBeds.Shared.Transfer.Domain
{
    public class TransferRemarkType : EnumType<TransferRemarkType>, IDomainType
    {
        public static readonly TransferRemarkType Contract = new TransferRemarkType("CONTRACT");
        public static readonly TransferRemarkType Agency = new TransferRemarkType("AGENCY");
        public static readonly TransferRemarkType Unknown = new TransferRemarkType("?");

        public IDomainType Default => Unknown;

        TransferRemarkType(string code) : base(code)
        {
        }

        public string GetCode()
        {
            return Code;
        }
    }
}