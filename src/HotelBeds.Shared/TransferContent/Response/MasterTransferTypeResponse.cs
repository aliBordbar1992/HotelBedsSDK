using System.Collections.Generic;
using HotelBeds.Shared.TransferContent.Dto;

namespace HotelBeds.Shared.TransferContent.Response
{
    public class MasterTransferTypeResponse : BaseResponse
    {
        public List<TransferType> TransferTypes { get; set; }
    }
}