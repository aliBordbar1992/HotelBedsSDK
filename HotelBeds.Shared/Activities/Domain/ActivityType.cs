namespace HotelBeds.Shared.Activities.Domain
{
    public class ActivityType : EnumType<ActivityType>, IDomainType
    {
        public static readonly ActivityType Ticket = new ActivityType("TICKET");
        public static readonly ActivityType Excursion = new ActivityType("EXCURSION");
        //public static readonly ActivityType Coche = new ActivityType("C"); // (C)ar hire
        //public static readonly ActivityType Bundle = new ActivityType("B"); // (B)undle
        public static readonly ActivityType Unknown = new ActivityType("?");

        public IDomainType Default => Unknown;

        ActivityType(string code) : base(code)
        {
        }

        public string GetCode()
        {
            return Code;
        }
    }
}