using System.Text;
using HotelBeds.Shared.Activities.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Duration
    {
        public double Value { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public MetricType Metric { get; set; }

        public Duration()
        {
        }

        public Duration(double value, MetricType metric)
        {
            Value = value;
            Metric = metric;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("value=" + Value);
            sb.Append("Metric=" + Metric);

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 3;
            hash = 37 * hash + Value.GetHashCode();
            hash = 37 * hash + Metric.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            Duration other = (Duration)obj;
            if (!Value.Equals(other.Value)) return false;
            if (Metric != other.Metric) return false;

            return true;
        }
    }
}