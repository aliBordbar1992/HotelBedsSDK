using System;
using HotelBeds.Shared.Activities.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HotelBeds.Shared.Activities.Dto
{
    public class BookingExtraData
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public BookingExtraDataType Id{get;set;}
        public String Value{get;set;}

        public BookingExtraData()
        {
        }

        public BookingExtraData(BookingExtraDataType id, String value)
        {
            this.Id = id;
            this.Value = value;
        }
    }
}