using System;
using System.Collections.Generic;
using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Api.Activities.Helpers.RequestFilter
{
    public class RequestFilterItemSelector<TFilter>
    {
        private readonly List<ActivitySearchFilterItemList> _lst;
        private readonly IList<TFilter> _filters;

        public RequestFilterItemSelector(List<ActivitySearchFilterItemList> lst, IList<TFilter> filters)
        {
            _lst = lst;
            _filters = filters;
        }

        public RequestFilterPropertySelector<TFilter, TFilterItem> WithItems<TFilterItem>(Func<TFilter, IList<TFilterItem>> filterItem)
        {
            return new RequestFilterPropertySelector<TFilter, TFilterItem>(_lst, _filters, filterItem);
        }
    }
}