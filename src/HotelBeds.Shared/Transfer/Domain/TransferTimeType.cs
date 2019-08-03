using HotelBeds.Shared.Activities.Domain;

namespace HotelBeds.Shared.Transfer.Domain
{
    public class TransferTimeType : EnumType<TransferTimeType>, IDomainType
    {
        public static readonly TransferTimeType CustomerMaxWaitingTime = new TransferTimeType("CUSTOMER_MAX_WAITING_TIME");
        public static readonly TransferTimeType SupplierMaxWaitingTimeDomestic = new TransferTimeType("SUPPLIER_MAX_WAITING_TIME_DOMESTIC");
        public static readonly TransferTimeType SupplierMaxWaitingTimeInternational = new TransferTimeType("SUPPLIER_MAX_WAITING_TIME_INTERNATIONAL");
        public static readonly TransferTimeType Unknown = new TransferTimeType("?");

        public IDomainType Default => Unknown;

        TransferTimeType(string code) : base(code)
        {
        }

        public string GetCode()
        {
            return Code;
        }
    }
}