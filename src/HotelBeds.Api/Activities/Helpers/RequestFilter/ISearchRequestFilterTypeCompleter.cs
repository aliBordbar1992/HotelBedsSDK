using System.Collections.Generic;
using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Api.Activities.Helpers.RequestFilter
{
    public interface ISearchRequestFilterTypeCompleter
    {
        ISearchRequestFilterTypeSelector And();
        SearchRequestFilterBuilder Or();
        List<ActivitySearchFilterItemList> Build();
    }
}