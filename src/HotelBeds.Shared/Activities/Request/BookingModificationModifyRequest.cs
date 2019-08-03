using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Shared.Activities.Request
{
    public class BookingModificationModifyRequest
    {
        public BookingConfirmService ServiceToModify { get; set; }
        public BookingModificationModifyRequest()
        {
        }

        public BookingModificationModifyRequest(BookingConfirmService serviceToModify)
        {
            ServiceToModify = serviceToModify;
        }
    }
}