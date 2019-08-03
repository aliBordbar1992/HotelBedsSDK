using System.Collections.Generic;

namespace HotelBeds.Shared.Transfer.Dto
{
    public class Transfer
    {
        public Detail Detail { get; set; }
        public string RateKey { get; set; }
        public List<TransferDetail> TransferDetails { get; set; }
    }
}