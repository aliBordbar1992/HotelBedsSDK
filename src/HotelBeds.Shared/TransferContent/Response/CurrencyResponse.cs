using System.Collections.Generic;
using HotelBeds.Shared.TransferContent.Dto;

namespace HotelBeds.Shared.TransferContent.Response
{
    public class CurrencyResponse : BaseResponse
    {
        public List<Currency> Pickup { get; set; }
    }
}