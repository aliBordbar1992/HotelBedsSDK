using System;
using System.Collections.Generic;

namespace HotelBeds.Shared.Activities.Dto
{
    public class BookingConfirmService
    {
        public string ActivityId { get; set; } //serviceId
        public string RateKey { get; set; } //purchasableServiceId
        public List<Pax> Paxes { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string ZoneCode { get; set; }
        public string Session { get; set; }
        public string Language { get; set; }
        public List<QuestionResponse> Answers { get; set; }
        public List<string> Comments { get; set; }
        public List<BookingExtraData> ExtraData { get; set; }
        public string PreferredLanguage { get; set; }
        public string ServiceLanguage { get; set; }

        public BookingConfirmService(DateTime from, DateTime to, string rateKey)
        {
            From = @from;
            To = to;
            RateKey = rateKey;
            Paxes = new List<Pax>();
        }

        public void AddPaxes(List<PaxDistribution> paxes)
        {
            foreach (var pax in paxes)
            {
                Paxes.Add(new Pax("", "", pax.Age, pax.Type));
            }
        }
    }
}