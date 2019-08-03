using System;
using System.Collections.Generic;

namespace HotelBeds.Shared.Activities.Dto
{
    public class MediaVideo : MediaBase
    {
        public List<String> Language { get; set; }

        public MediaVideo()
        {
        }

        public MediaVideo(List<String> language)
        {
            this.Language = language;
        }


        public override int GetHashCode()
        {
            int hash = 5;
            hash = 41 * hash + Language.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            if (!base.Equals(obj)) return false;

            MediaVideo other = (MediaVideo)obj;
            if (!Language.Equals(other.Language)) return false;

            return true;
        }

    }
}