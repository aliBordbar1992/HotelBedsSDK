using System.Buffers.Text;
using System.Collections.Generic;

namespace HotelBeds.Activities.Api.Model.Search.Filters
{
    public class SegmentFilter : SearchFilterItems
    {
        public SegmentFilter(string segmentValue, string destinationValue)
        {
            var segment = new InnerSegmentFilter(segmentValue);
            var destination = new DestinationFilter(destinationValue);

            AddFilterItem(segment);
            AddFilterItem(destination);
        }

        private class InnerSegmentFilter : SearchFilterItem
        {
            public InnerSegmentFilter(string value)  : base(FilterType.Segment, value)
            {
            }
        }
    }
}