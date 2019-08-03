using System;
using System.Collections.Generic;
using System.Linq;
using HotelBeds.Activities.Api.Model.Search.Filters;
using Newtonsoft.Json;

namespace HotelBeds.Activities.Api.Model.Search
{
    public class SearchRequest
    {
        public List<Filter> Filters { get; }
        [JsonConverter(typeof(ApiDateFormat))]
        public DateTime From { get; }
        [JsonConverter(typeof(ApiDateFormat))]
        public DateTime To { get; }
        public string Language { get; set; }
        public List<Pax> Paxes { get; set; }
        public Pagination Pagination { get; set; }
        public string Order { get; set; }

        public SearchRequest(
            List<Filter> filters
            , DateTime from
            , DateTime to
            , Order order
            , string language = default
            , List<Pax> paxes = null
            , Pagination pagination = null)
        {
            Filters = filters;
            From = @from;
            To = to;
            Language = language;
            Paxes = paxes;
            Pagination = pagination;
            if (order != null) Order = order.By();
        }
    }
}