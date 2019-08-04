using System;
using System.Collections.Generic;
using System.Linq;
using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Api.Activities.Helpers.RequestFilter
{
    public class RequestFilterPropertySelector<TFilter, TFilterItem>
    {
        private readonly List<ActivitySearchFilterItemList> _list;
        private readonly IList<TFilter> _filters;
        private readonly Func<TFilter, IList<TFilterItem>> _filterItem;

        public RequestFilterPropertySelector(List<ActivitySearchFilterItemList> list, IList<TFilter> filters, Func<TFilter, IList<TFilterItem>> filterItem)
        {
            _list = list;
            _filters = filters;
            _filterItem = filterItem;
        }

        public ISearchRequestFilterTypeCompleter WithProperties(
            Func<TFilterItem, string> typeProp,
            Func<TFilterItem, string> valueProp,
            Func<TFilterItem, decimal?> latitudeProp,
            Func<TFilterItem, decimal?> longitudeProp)
        {
            foreach (var filter in _filters)
            {
                var filterItems = _filterItem(filter);
                var newFilterItems = new List<ActivitySearchFilterItem>();
                foreach (var filterItem in filterItems)
                {
                    var tp = typeProp(filterItem);
                    var vp = valueProp(filterItem);
                    var ltp = latitudeProp(filterItem);
                    var lgp = longitudeProp(filterItem);

                    ActivitySearchFilterItem newFilterItem;

                    if (ltp != null && lgp != null)
                    {
                        newFilterItem =
                            new ActivitySearchFilterItem(ActivityFilterType.FromCode(tp), ltp.Value, lgp.Value);
                    }
                    else
                    {
                        newFilterItem =
                            new ActivitySearchFilterItem(ActivityFilterType.FromCode(tp), vp);
                    }

                    newFilterItems.Add(newFilterItem);
                }

                _list.Add(new ActivitySearchFilterItemList
                {
                    SearchFilterItems = newFilterItems
                });
            }

            return new SearchRequestFilterTypeCompleter(_list);
        }
    }
}