using System;
using HotelBeds.Shared.Activities.Domain;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Converters
{
    public class ImageSizeConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = (ImageSize)value;
            string code = t.GetTabconType();
            writer.WriteValue(code);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string value = (string)reader.Value;
            return ImageSize.FromTabcon(value);
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}