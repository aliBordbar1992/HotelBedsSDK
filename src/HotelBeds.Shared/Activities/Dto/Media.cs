using System.Collections.Generic;
using System.Text;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Media
    {
        public List<MediaOther> Audios { get; set; }
        public List<MediaOther> Documents { get; set; }
        public List<MediaOther> Images { get; set; }
        public List<MediaOther> Others { get; set; }
        public List<MediaVideo> Videos { get; set; }

        public Media()
        {
        }

        public Media(List<MediaOther> audios, List<MediaOther> documents, List<MediaOther> images, List<MediaOther> others, List<MediaVideo> videos)
        {
            this.Audios = audios;
            this.Documents = documents;
            this.Images = images;
            this.Others = others;
            this.Videos = videos;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Audios=").Append(Audios).Append(",");
            sb.Append("Documents=").Append(Documents).Append(",");
            sb.Append("Images=").Append(Images).Append(",");
            sb.Append("Others=").Append(Others).Append(",");
            sb.Append("Videos=").Append(Videos).Append(",");

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash = 79 * hash + Audios.GetHashCode();
            hash = 79 * hash + Documents.GetHashCode();
            hash = 79 * hash + Images.GetHashCode();
            hash = 79 * hash + Others.GetHashCode();
            hash = 79 * hash + Videos.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            Media other = (Media)obj;
            if (!Audios.Equals(other.Audios)) return false;
            if (!Documents.Equals(other.Documents)) return false;
            if (!Images.Equals(other.Images)) return false;
            if (!Others.Equals(other.Others)) return false;
            if (!Videos.Equals(other.Videos)) return false;

            return true;
        }
    }
}