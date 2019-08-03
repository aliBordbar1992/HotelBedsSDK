using System.Collections.Generic;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Rate
    {
        public string RateCode { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public List<PaxQuestion> PaxQuestions { get; set; }
        public List<RateDetail> RateDetails { get; set; }
    }
}