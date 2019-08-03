using HotelBeds.Shared.Activities.Domain;

namespace HotelBeds.Shared.Transfer.Domain
{
    public class TransferType : EnumType<TransferType>, IDomainType
    {
        public static readonly TransferType Flight = new TransferType("FLIGHT");
        public static readonly TransferType Cruise = new TransferType("CRUISE");
        public static readonly TransferType Train = new TransferType("TRAIN");
        public static readonly TransferType Unknown = new TransferType("?");

        public IDomainType Default => Unknown;

        TransferType(string code) : base(code)
        {
        }

        public string GetCode()
        {
            return Code;
        }
    }
}