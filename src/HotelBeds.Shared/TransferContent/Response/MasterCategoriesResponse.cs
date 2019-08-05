using System.Collections.Generic;
using HotelBeds.Shared.TransferContent.Dto;

namespace HotelBeds.Shared.TransferContent.Response
{
    public class MasterCategoriesResponse : BaseResponse
    {
        public List<Category> Categories { get; set; }
    }
}