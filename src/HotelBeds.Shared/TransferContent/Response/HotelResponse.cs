using System.Collections.Generic;
using HotelBeds.Shared.TransferContent.Dto;

namespace HotelBeds.Shared.TransferContent.Response
{
    public class HotelResponse : BaseResponse
    {
        public List<Hotel> Pickup { get; set; }
    }
}