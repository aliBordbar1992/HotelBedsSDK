namespace HotelBeds.Shared.Activities.Dto
{
    public class Language
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public Language()
        {
        }

        public Language(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}