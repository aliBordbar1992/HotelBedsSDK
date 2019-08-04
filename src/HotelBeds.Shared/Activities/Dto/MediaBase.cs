using System;
using System.Collections.Generic;
using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Converters;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Activities.Dto
{
    public class MediaBase : IComparable<MediaBase>
    {

        public int VisualizationOrder { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(EnumTypeConverter<MediaMimeType>))]
        public MediaMimeType MimeType { get; set; }
        public MediaTagType Tag { get; set; }
        public List<MediaUrl> Urls { get; set; }
        public Duration Duration { get; set; }

        public MediaBase()
        {
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 29 * hash + VisualizationOrder.GetHashCode();
            hash = 29 * hash + Name.GetHashCode();
            hash = 29 * hash + Description.GetHashCode();
            hash = 29 * hash + MimeType.GetHashCode();
            hash = 29 * hash + Tag.GetHashCode();
            hash = 29 * hash + Urls.GetHashCode();
            hash = 29 * hash + Duration.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            MediaBase other = (MediaBase)obj;
            if (MimeType != other.MimeType) return false;
            if (Tag != other.Tag) return false;
            if (!VisualizationOrder.Equals(other.VisualizationOrder)) return false;
            if (!Name.Equals(other.Name)) return false;
            if (!Description.Equals(other.Description)) return false;
            if (!Urls.Equals(other.Urls)) return false;
            if (!Duration.Equals(other.Duration)) return false;

            return true;
        }


        public int CompareTo(MediaBase other)
        {
            return VisualizationOrder.CompareTo(other.VisualizationOrder);
        }
    }
}