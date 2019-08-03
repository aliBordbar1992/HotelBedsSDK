using System.Collections.Generic;

namespace HotelBeds.Shared.Transfer.Request
{
    public class ConfirmRequest
    {
        public string ClientReference { get; set; }
        public Dto.Pax Holder { get; set; }
        public string Language { get; set; }
        public string Remark { get; set; }
        public List<Dto.Transfer> Transfers { get; set; }
        public string WelcomeMessage { get; set; }
    }
}