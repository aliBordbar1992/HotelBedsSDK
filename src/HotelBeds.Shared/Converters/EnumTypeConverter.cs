using System;
using HotelBeds.Shared.Activities.Domain;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Converters
{
    public class EnumTypeConverter<T> : JsonConverter where T : EnumType<T>, IDomainType
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value.GetType() == typeof(T))
            {
                var t = (T)value;
                string code = t.GetCode();
                writer.WriteValue(code);
            }

            
            //JProperty jp = new JProperty(writer.Path, code);
            //jp.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof(T))
            {
                string value = (string)reader.Value;
                return EnumType<T>.FromCode(value);
            }

            return null;
        }

        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }
    }
}