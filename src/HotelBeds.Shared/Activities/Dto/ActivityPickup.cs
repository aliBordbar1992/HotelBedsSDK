using System;
using System.Collections.Generic;

namespace HotelBeds.Shared.Activities.Dto
{
    public class ActivityPickup
    {

        public string RateKey { get; set; }
        public string PickupName { get; set; }
        public string ZoneCode { get; set; }
        public string ZoneName { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public Coordinate Geolocation { get; set; }
        public string Time { get; set; }
        public string HotelName { get; set; }
        public List<PaxPrice> AmountsFrom { get; set; }
        public PickupOperationDate OperationDate { get; set; }
        public string ModalityCode { get; set; }
        public long OfficeCode { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public bool ValidMonday { get; set; }
        public bool ValidTuesday { get; set; }
        public bool ValidWednesday { get; set; }
        public bool ValidThursday { get; set; }
        public bool ValidFriday { get; set; }
        public bool ValidSaturday { get; set; }
        public bool ValidSunday { get; set; }
        public string PickupPointCode { get; set; }
        public bool Generic { get; set; }
        public long HotelCode { get; set; }
    }
}