using HotelBeds.Shared.Transfer.Domain;

namespace HotelBeds.Shared.Transfer.Request
{
    public class AvailabilityRequest
    {
        public string Language { get; }
        public TransferPointType FromType { get; }
        public string FromCode { get; }
        public TransferPointType ToType { get; }
        public string ToCode { get; }
        public string Outbound { get; }
        public string Inbound { get; }
        public int Adults { get; }
        public int Children { get; }
        public int Infants { get; }


        public AvailabilityRequest(
            string language, 
            TransferPointType fromType, 
            string fromCode, 
            TransferPointType toType,
            string toCode, 
            string outbound, 
            string inbound, 
            int adults,
            int children, 
            int infants)
        {
            Language = language;
            FromType = fromType;
            FromCode = fromCode;
            ToType = toType;
            ToCode = toCode;
            Outbound = outbound;
            Inbound = inbound;
            Adults = adults;
            Children = children;
            Infants = infants;
        }

        public AvailabilityRequest(
            string language, 
            TransferPointType fromType, 
            string fromCode, 
            TransferPointType toType,
            string toCode, 
            string outbound, 
            int adults,
            int children, 
            int infants)
        {
            Language = language;
            FromType = fromType;
            FromCode = fromCode;
            ToType = toType;
            ToCode = toCode;
            Outbound = outbound;
            Adults = adults;
            Children = children;
            Infants = infants;
            Inbound = null;
        }
    }
}