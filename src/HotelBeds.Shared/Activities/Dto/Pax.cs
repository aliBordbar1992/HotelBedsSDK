using System.Collections.Generic;
using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Converters;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Pax
    {
        [JsonConverter(typeof(EnumTypeConverter<PaxType>))]
        public PaxType Type{get;set;}
        public string Surname{get;set;}
        public int Age{get;set;}
        public List<PaxAnswer> Answers{get;set;}
        public string Name{get;set;}

        public Pax()
        {
            
        }

        public Pax(string name, string surname, int age) : this(name, surname, age, null)
        {
        }

        public Pax(string name, string surname, int age, PaxType type)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Type = type;
        }
    }

    
}