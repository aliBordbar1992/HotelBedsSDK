namespace HotelBeds.Shared.Activities.Domain
{
    public class MediaMimeType : EnumType<MediaMimeType>, IDomainType
    {
        public static readonly MediaMimeType Mp3 = new MediaMimeType("audio/mpeg3");
        public static readonly MediaMimeType Pdf = new MediaMimeType("application/pdf");
        public static readonly MediaMimeType Png = new MediaMimeType("image/png");
        public static readonly MediaMimeType Avi = new MediaMimeType("video/avi");
        public static readonly MediaMimeType Jpg = new MediaMimeType("image/jpeg");
        public static readonly MediaMimeType Gif = new MediaMimeType("image/gif");
        public static readonly MediaMimeType Html = new MediaMimeType("text/html");
        public static readonly MediaMimeType Word = new MediaMimeType("application/msword");
        public static readonly MediaMimeType Mpeg4 = new MediaMimeType("video/mpeg4");
        public static readonly MediaMimeType TextPlain = new MediaMimeType("text/plain");

        public IDomainType Default => Pdf;

        MediaMimeType(string code) : base(code)
        {
        }

        public string GetCode()
        {
            return Code;
        }

        public override string ToString()
        {
            return Code;
        }
    }
}