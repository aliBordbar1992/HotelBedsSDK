using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Shared.Activities.Request
{
    public class BookingModificationAddRequest : AbstractBookingModificationRequest
    {
        public BookingConfirmService ServiceToAdd { get; set; }

        public BookingModificationAddRequest()
        {
        }

        public BookingModificationAddRequest(BookingConfirmService serviceToAdd, string clientReference, string agencyComments) : base(clientReference, agencyComments)
        {
            ServiceToAdd = serviceToAdd;
        }
    }
}