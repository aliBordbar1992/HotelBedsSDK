using System.Collections.Generic;

namespace HotelBeds.Shared
{
    public class ImageSize
    {
        public static readonly ImageSize Small = new ImageSize("S", "SMALL");
        public static readonly ImageSize Medium = new ImageSize("M", "MEDIUM");
        public static readonly ImageSize Large = new ImageSize("L", "LARGE", "BIG");
        public static readonly ImageSize Large2 = new ImageSize("L2", "LARGE2");
        public static readonly ImageSize Xlarge = new ImageSize("XL", "XLARGE", "EXTRALARGE");
        public static readonly ImageSize Raw = new ImageSize("RAW", "RAW");
        public static readonly ImageSize Unknown = new ImageSize("?");


        public static IEnumerable<ImageSize> Values
        {
            get
            {
                yield return Small;
                yield return Medium;
                yield return Large;
                yield return Large2;
                yield return Xlarge;
                yield return Raw;
                yield return Unknown;
            }
        }

        private string[] _tabconType;

        ImageSize(params string[] tabconType)
        {
            _tabconType = tabconType;
        }

        public string GetTabconType()
        {
            return _tabconType[0];
        }

        public static ImageSize FromTabcon(string tabconType)
        {
            foreach (var size in Values)
            {
                foreach (var type in size._tabconType)
                {
                    if (type.ToLower().Equals(tabconType.ToLower()))
                        return size;
                }
            }

            return Unknown;
        }
    }
}