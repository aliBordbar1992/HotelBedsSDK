using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Shared.Activities.Request
{
    public interface IWithPaginationRequest
    {
        PaginationRequest GetPagination();
    }
}