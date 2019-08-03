using System.Collections.Generic;
using HotelBeds.Shared.Transfer.Dto;
using HotelBeds.Shared.Transfer.Request;

namespace HotelBeds.Shared.Transfer.Response
{
    public class AvailabilityResponse : BaseResponse
    {
        public Search Search { get; set; }
        public List<TransferService> Services { get; set; }
    }
}