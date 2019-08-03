using System;
using System.Collections.Generic;
using System.Linq;
using HotelBeds.Shared.Activities.Domain;

namespace HotelBeds.Shared.Activities.Dto
{
    public class VoucherActivity
    {
        public VoucherActivity(PurchasedService activity)
        {
            PaxDistribution = new List<PaxResponse>();
            ChildrenAges = new List<int>();
            Remarks = new List<string>();

            TicketFullName = activity.Name;
            From = activity.DateFrom;
            To = activity.DateTo;
            ModalityName = activity.Modality.Name;
            PaxDistribution = activity.Paxes;
            Destination = string.Join(',', activity.ContactInfo.Country.Destinations.Select(x => x.Name));

            Remarks = activity.Comments
                .Where(x => x.Type == CommentType.ContractRemarks).ToList()
                .Select(x => x.Text).ToList();

            SupplierInfo = activity.ProviderInformation;
            SessionSelected = activity.Modality.Rates?.First().RateDetails?.First().Sessions?.First().Name;
            LanguageSelected = activity.Modality.Rates?.First().RateDetails?.First().Languages?.First().Code;
            PickupPoint = null;

            foreach (var activityPax in activity.Paxes)
            {
                if (activityPax.Age < 18) ChildrenAges.Add(activityPax.Age);
            }
        }

        public string TicketFullName { get; }
        public DateTime From { get; }
        public DateTime To { get; }
        public string ModalityName { get; }
        public List<PaxResponse> PaxDistribution { get; }
        public List<int> ChildrenAges { get; }
        public string Destination { get; }
        public List<string> Remarks { get; }
        public ProviderInformation SupplierInfo { get; }
        public string SessionSelected { get; }
        public string LanguageSelected { get; }
        public ActivityPickup PickupPoint { get; }
    }
}