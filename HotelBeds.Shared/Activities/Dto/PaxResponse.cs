using System;

namespace HotelBeds.Shared.Activities.Dto
{
    public class PaxResponse : BookingHolder
    {
        public string CustomerId { get; set; }
        public int Age { get; set; }
        public string PaxType { get; set; }
        public DateTime BirthDate { get; set; }
        public string Passport { get; set; }
        public ConfirmationCode ConfirmationCode { get; set; }
        public Seat Seat { get; set; }
    }
}