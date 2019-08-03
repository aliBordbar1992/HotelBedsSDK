using System.Text;
using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Converters;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Activities.Dto
{
    public class MediaUrl
    {
        public int Dpi { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Resource { get; set; }
        [JsonConverter(typeof(ImageSizeConverter))]
        public ImageSize SizeType { get; set; }

        public MediaUrl()
        {
        }

        public MediaUrl(int dpi, int height, int width, string resource)
        {
            this.Dpi = dpi;
            this.Height = height;
            this.Width = width;
            this.Resource = resource;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Dpi=").Append(Dpi).Append(",");
            sb.Append("Height=").Append(Height).Append(",");
            sb.Append("Width=").Append(Width).Append(",");
            sb.Append("Resource=").Append(Resource).Append(",");
            sb.Append("ImageSize=" + SizeType).Append(",");

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 5;
            hash = 83 * hash + Dpi.GetHashCode();
            hash = 83 * hash + Height.GetHashCode();
            hash = 83 * hash + Width.GetHashCode();
            hash = 83 * hash + Resource.GetHashCode();
            hash = 83 * hash + SizeType.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            MediaUrl other = (MediaUrl)obj;
            if (!Dpi.Equals(other.Dpi)) return false;
            if (!Height.Equals(other.Height)) return false;
            if (!Width.Equals(other.Width)) return false;
            if (!Resource.Equals(other.Resource)) return false;
            if (SizeType != other.SizeType) return false;

            return true;
        }



    }
}