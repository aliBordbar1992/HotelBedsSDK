using System.Collections.Generic;
using HotelBeds.Shared.TransferContent.Dto;

namespace HotelBeds.Shared.TransferContent.Response
{
    public class TerminalsResponse : BaseResponse
    {
        public List<Terminal> Terminals { get; set; }
    }
}