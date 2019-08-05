using System.Collections.Generic;
using HotelBeds.Shared.TransferContent.Dto;

namespace HotelBeds.Shared.TransferContent.Response
{
    public class DestinationsResponse : BaseResponse
    {
        public List<Destination> Destinations { get; set; }
    }
}