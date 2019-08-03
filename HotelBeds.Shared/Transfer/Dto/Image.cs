using HotelBeds.Shared.Converters;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Transfer.Dto
{
    public class Image
    {
        [JsonConverter(typeof(ImageSizeConverter))]
        public ImageSize Type { get; set; }
        public string Url { get; set; }
    }
}