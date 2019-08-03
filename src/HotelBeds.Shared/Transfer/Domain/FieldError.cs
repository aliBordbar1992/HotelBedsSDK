namespace HotelBeds.Shared.Transfer.Domain
{
    public class FieldError
    {
        public string Code { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }
    }
}