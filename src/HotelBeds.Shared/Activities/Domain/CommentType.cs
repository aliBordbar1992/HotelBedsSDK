namespace HotelBeds.Shared.Activities.Domain
{
    public class CommentType : EnumType<CommentType>, IDomainType
    {
        public static readonly CommentType ContractRemarks = new CommentType("CONTRACT_REMARKS");
        public static readonly CommentType Voucher = new CommentType("VOUCHER");
        public static readonly CommentType OfficeRemarks = new CommentType("OFFICE_REMARKS");
        public static readonly CommentType Unknown = new CommentType("UNKNOWN");

        public IDomainType Default => Unknown;

        CommentType(string code) : base(code)
        {
        }

        public string GetCode()
        {
            return Code;
        }
    }
}