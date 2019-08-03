using System;
using HotelBeds.Shared.Activities.Domain;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Converters
{
    public class PointOfInterestTypeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string value = (string) reader.Value;
            return PointOfInterestType.FromCode(value);
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}