using HotelBeds.Shared.Activities.Domain;

namespace HotelBeds.Shared.Activities.Dto
{
    public class ConfirmationCode
    {
        public string Code { get; set; }
        public ModalityUnitType UnitType { get; set; }
    }
}