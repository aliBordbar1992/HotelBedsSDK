using System;
using System.Collections.Generic;

namespace HotelBeds.Shared.Activities.Domain
{
    public abstract class EnumType<T> where T : IDomainType
    {
        public static IEnumerable<T> Values
        {
            get
            {
                Type childType = typeof(T);
                var fields = childType.GetFields();
                foreach (var field in fields)
                {
                    if (field.FieldType == typeof(T))
                    {
                        yield return (T) field.GetValue(null);
                    }
                }
            }
        }

        protected string Code;

        protected EnumType(string code)
        {
            Code = code;
        }

        public static T FromCode(string code)
        {
            T @default = default(T);
            foreach (var type in Values)
            {
                @default = (T) type.Default;
                if (type.GetCode().ToLower().Equals(code.ToLower()))
                    return type;
            }

            return @default;
        }
    }
}