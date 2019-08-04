using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Converters;
using Newtonsoft.Json;

namespace HotelBeds.Shared.Activities.Dto
{
    public class Comment
    {
        [JsonConverter(typeof(EnumTypeConverter<CommentType>))]
        public CommentType Type { get; set; }
        public string Text { get; set; }
    }
}