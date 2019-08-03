using System;
using System.Collections.Generic;

namespace HotelBeds.Shared.Activities.Dto
{
    public class BookingHolder
    {
        public string Surname { get; set; }
        public List<string> Telephones { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public bool Mailing { get; set; }
        public DateTime MailUpdDate { get; set; }
        public string Country { get; set; }
    }
}