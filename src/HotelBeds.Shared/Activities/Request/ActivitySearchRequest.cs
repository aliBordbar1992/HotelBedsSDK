using System;
using System.Collections.Generic;
using System.Text;
using HotelBeds.Shared.Activities.Domain;
using HotelBeds.Shared.Activities.Dto;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HotelBeds.Shared.Activities.Request
{
    public class ActivitySearchRequest : IWithPaginationRequest
    {
        public List<ActivitySearchFilterItemList> Filters { get; }
        public DateTime From { get; }
        public DateTime To { get; }
        public PaginationRequest Pagination { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ActivityOrderType Order { get; set; }
        public string Language { get; set; }

        public ActivitySearchRequest(List<ActivitySearchFilterItemList> filters,
            DateTime from, DateTime to)
        {
            Filters = filters;
            From = from;
            To = to;
        }

        public ActivitySearchRequest(List<ActivitySearchFilterItemList> filters,
                DateTime from, DateTime to, PaginationRequest pagination,
                ActivityOrderType order, string language)
        {
            Filters = filters;
            From = from;
            To = to;
            Pagination = pagination;
            Order = order;
            Language = language;
        }

        public override string ToString()
        {
            //TODO: The fields shown are still to be determined. First proposal
            StringBuilder sb = new StringBuilder();

            string sdf = "yyyy-MM-dd";
            if (From != null) sb.Append("From=").Append(From.ToString(sdf)).Append(",");
            if (To != null) sb.Append("To=").Append(To.ToString(sdf)).Append(",");

            if (Filters != null)
            {
                foreach (var filter in Filters)
                {
                    if (filter != null)
                    {
                        foreach (var filterItem in filter.SearchFilterItems)
                        {
                            sb.Append("FilterItemType=").Append(filterItem.Type.ToString()).Append(",");
                            sb.Append("FilterItemValue=").Append(filterItem.Type).Append(",");
                        }
                    }
                }
            }

            sb.Append("class=ActivitySearchRequest");
            return sb.ToString();
        }

        public PaginationRequest GetPagination()
        {
            return Pagination;
        }

        public override int GetHashCode()
        {
            int hash = 5;
            hash = 37 * hash + Filters.GetHashCode();
            hash = 37 * hash + From.GetHashCode();
            hash = 37 * hash + To.GetHashCode();
            hash = 37 * hash + Pagination.GetHashCode();
            hash = 37 * hash + Order.GetHashCode();
            hash = 37 * hash + Language.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            ActivitySearchRequest other = (ActivitySearchRequest)obj;
            if (!Filters.Equals(other.Filters)) return false;
            if (!From.Equals(other.From)) return false;
            if (!To.Equals(other.To)) return false;
            if (!Pagination.Equals(other.Pagination)) return false;
            if (!Language.Equals(other.Language)) return false;
            if (Order != other.Order) return false;
            return true;
        }
    }
}