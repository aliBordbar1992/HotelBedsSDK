using System;
using System.Collections.Generic;
using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Shared.Activities.Request
{
    public class ActivityDetailRequest
    {
        public string Code { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public List<PaxDistribution> Paxes { get; set; }
        public string Language { get; set; }

        public ActivityDetailRequest(string code, DateTime from, DateTime to, List<PaxDistribution> paxes)
        {
            Code = code;
            From = from;
            To = to;
            Paxes = paxes ?? throw new ArgumentException("Pax is mandatory, with at least Age parameter provided.");
        }
    }
}