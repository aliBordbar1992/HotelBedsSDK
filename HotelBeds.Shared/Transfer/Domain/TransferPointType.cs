using HotelBeds.Shared.Activities.Domain;

namespace HotelBeds.Shared.Transfer.Domain
{
    public class TransferPointType : EnumType<TransferPointType>, IDomainType
    {
        public static readonly TransferPointType Giata = new TransferPointType("GIATA");
        public static readonly TransferPointType Atlas = new TransferPointType("ATLAS");
        public static readonly TransferPointType Iata = new TransferPointType("IATA");
        public static readonly TransferPointType Port = new TransferPointType("PORT");
        public static readonly TransferPointType Station = new TransferPointType("STATION");
        public static readonly TransferPointType Gps = new TransferPointType("GPS");
        public static readonly TransferPointType Unknown = new TransferPointType("?");

        public IDomainType Default => Unknown;

        TransferPointType(string code) : base(code)
        {
        }

        public string GetCode()
        {
            return Code;
        }
    }
}