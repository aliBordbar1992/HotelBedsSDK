using System;

namespace HotelBeds.Shared.Transfer.Dto
{
    public class PickupInformation
    {
        public TransferPoint From { get; set; }
        public TransferPoint To { get; set; }
        public DateTimeOffset Date { get; set; }
        public DateTimeOffset? Time { get; set; }
        public Pickup Pickup { get; set; }
    }
}