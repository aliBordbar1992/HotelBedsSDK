using System;
using System.Collections.Generic;

namespace HotelBeds.Client.Dto
{
    public class SearchRequest
    {
        public List<Filter> Filters { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}