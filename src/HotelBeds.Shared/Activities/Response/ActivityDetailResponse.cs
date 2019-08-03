using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Shared.Activities.Response
{
    public class ActivityDetailResponse : BaseResponse
    {
        public PurchasableActivity Activity { get; set; }
    }
}