using System.Collections.Generic;
using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Converters;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Activity
    {
        public string Url { get; set; }
        public List<Promotion> Promotions { get; set; }
        public List<SearchModality> Modalities { get; set; }
        public FactsheetActivity Content { get; set; }
        public int Order { get; set; }
        public List<PaxPrice> AmountsFrom { get; set; }
        public string CurrencyName { get; set; }
        public Country Country { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string Code { get; set; }
        public string ContentId { get; set; }

        [JsonConverter(typeof(EnumTypeConverter<ActivityType>))]
        public ActivityType Type { get; set; }


        public override int GetHashCode()
        {
            int hash = 7;
            hash = 67 * hash + Url.GetHashCode();
            hash = 67 * hash + Promotions.GetHashCode();
            hash = 67 * hash + Modalities.GetHashCode();
            hash = 67 * hash + Content.GetHashCode();
            hash = 67 * hash + Order.GetHashCode();
            hash = 67 * hash + AmountsFrom.GetHashCode();
            hash = 67 * hash + CurrencyName.GetHashCode();
            hash = 67 * hash + Country.GetHashCode();
            hash = 67 * hash + Name.GetHashCode();
            hash = 67 * hash + Currency.GetHashCode();
            hash = 67 * hash + Code.GetHashCode();
            hash = 67 * hash + ContentId.GetHashCode();
            hash = 67 * hash + Type.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;


            Activity other = (Activity)obj;
            if (!Url.Equals(other.Url)) return false;
            if (!Promotions.Equals(other.Promotions)) return false;
            if (!Modalities.Equals(other.Modalities)) return false;
            if (!Content.Equals(other.Content)) return false;
            if (!Order.Equals(other.Order)) return false;
            if (!AmountsFrom.Equals(other.AmountsFrom)) return false;
            if (!CurrencyName.Equals(other.CurrencyName)) return false;
            if (!Country.Equals(other.Country)) return false;
            if (!Name.Equals(other.Name)) return false;
            if (!Currency.Equals(other.Currency)) return false;
            if (!Code.Equals(other.Code)) return false;
            if (!ContentId.Equals(other.ContentId)) return false;
            if (Type != other.Type) return false;

            return true;
        }
    }
}