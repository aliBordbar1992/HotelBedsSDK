using System.Collections.Generic;
using HotelBeds.Shared.TransferContent.Dto;

namespace HotelBeds.Shared.TransferContent.Response
{
    public class MasterVehiclesResponse : BaseResponse
    {
        public List<Vehicle> Vehicles { get; set; }
    }
}