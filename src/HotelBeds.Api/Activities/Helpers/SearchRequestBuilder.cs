using System;
using System.Collections.Generic;
using HotelBeds.Api.Activities.Helpers.RequestFilter;
using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Activities.Dto;
using HotelBeds.Shared.Activities.Request;

namespace HotelBeds.Api.Activities.Helpers
{
    public class SearchRequestBuilder
    {
        private readonly ActivitySearchRequest _request;

        public SearchRequestBuilder(List<ActivitySearchFilterItemList> filter, DateTime from, DateTime to)
        {
            _request = new ActivitySearchRequest(filter, from, to);
        }

        public SearchRequestBuilder(ISearchRequestFilterTypeCompleter filterBuilder, DateTime from, DateTime to)
        {
            _request = new ActivitySearchRequest(filterBuilder.Build(), from, to);
        }


        /// <summary>
        /// Returns a <see cref="SearchRequestBuilder"/> that contains <see cref="ActivitySearchRequest"/> with a <see cref="PaginationRequest"/>
        /// </summary>
        /// <param name="page">Page index - one based</param>
        /// <param name="itemsPerPage">Items per page</param>
        /// <returns></returns>
        public SearchRequestBuilder Paginated(int page, int itemsPerPage)
        {
            _request.Pagination = new PaginationRequest
            {
                ItemsPerPage = itemsPerPage,
                Page = page
            };

            return this;
        }


        /// <summary>
        /// Returns a <see cref="SearchRequestBuilder"/> that contains <see cref="ActivitySearchRequest"/> with a filled language property
        /// </summary>
        /// <param name="lang">Desired language</param>
        /// <returns></returns>
        public SearchRequestBuilder WithLanguage(string lang)
        {
            _request.Language = lang;

            return this;
        }


        /// <summary>
        /// Returns a <see cref="SearchRequestBuilder"/> that contains <see cref="ActivitySearchRequest"/> with an <see cref="ActivityOrderType"/>
        /// </summary>
        /// <param name="type">Type of Order for response</param>
        /// <returns></returns>
        public SearchRequestBuilder WithOrder(ActivityOrderType type)
        {
            _request.Order = type;

            return this;
        }

        /// <summary>
        /// Builds the request
        /// </summary>
        /// <returns></returns>
        public ActivitySearchRequest Build()
        {
            return _request;
        }
    }
}