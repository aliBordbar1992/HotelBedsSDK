using System.Collections.Generic;
using HotelBeds.Shared.Activities.Domain;

namespace HotelBeds.Shared.Activities.Dto
{
    public class BundledService
    {
        public int Order { get; set; }
        public BundleActivity Activity { get; set; }
        public ActivityType Type { get; set; }
        public string PayableName { get; set; }
        public List<Comment> Comments { get; set; }
        public ProviderInformation ProviderInformation { get; set; }
    }
}