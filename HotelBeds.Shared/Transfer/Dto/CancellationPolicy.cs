using System;
using System.Collections.Generic;
using HotelBeds.Shared.Transfer.Request;

namespace HotelBeds.Shared.Transfer.Dto
{
    public class CancellationPolicy
    {
        public long Amount { get; set; }
        public DateTimeOffset From { get; set; }
        public string CurrencyId { get; set; }
    }


}