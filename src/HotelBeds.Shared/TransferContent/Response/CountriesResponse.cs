using System.Collections.Generic;
using HotelBeds.Shared.TransferContent.Dto;

namespace HotelBeds.Shared.TransferContent.Response
{
    public class CountriesResponse : BaseResponse
    {
        public List<Country> Countries { get; set; }
    }
}