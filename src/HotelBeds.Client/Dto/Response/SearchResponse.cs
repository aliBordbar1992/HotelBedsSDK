using System.Collections.Generic;
using HotelBeds.Shared.Activities.Response;

namespace HotelBeds.Client.Dto.Response
{
    public class SearchResponse
    {
        public List<SearchResponseItem> Items { get; set; }
        public PaginationResponse Pagination { get; set; }

        public SearchResponse()
        {
            Items = new List<SearchResponseItem>();
        }

        public void AddItem(SearchResponseItem searchResponseItem)
        {
            Items.Add(searchResponseItem);
        }

        public static SearchResponse ExtractFrom(ActivitySearchResponse response)
        {
            SearchResponse result = new SearchResponse();
            foreach (var activity in response.Activities)
            {
                result.AddItem(new SearchResponseItem
                {
                    Code = activity.Code,
                    Type = activity.Type.GetCode(),
                    Name = activity.Name,
                    Comments = activity.Content.Description
                });
            }

            result.Pagination = response.Pagination;

            return result;
        }
    }
}