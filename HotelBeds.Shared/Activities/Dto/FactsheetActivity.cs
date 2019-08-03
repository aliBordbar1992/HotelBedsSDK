using System;
using System.Collections.Generic;
using HotelBeds.Shared.Activities.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HotelBeds.Shared.Activities.Dto
{
    public class FactsheetActivity
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public ActivityFactsheetType ActivityFactsheetType { get; set; }
        public string ActivityCode { get; set; }
        public string ModalityCode { get; set; }
        public string ContentId { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Summary { get; set; }
        public List<string> AdvancedTips { get; set; }
        public List<Country> Countries { get; set; }
        public List<string> Highligths { get; set; }
        public string Name { get; set; }
        public List<string> DetailedInfo { get; set; }
        public List<FeatureGroup> FeatureGroups { get; set; }
        public GuidingOptions GuidingOptions { get; set; }
        public List<string> ImportantInfo { get; set; } //suma
        public Location Location { get; set; }
        public Media Media { get; set; } //suma
        public List<Note> Notes { get; set; }
        public Redeem RedeemInfo { get; set; }
        public List<Route> Routes { get; set; }
        public Schedule Scheduling { get; set; }
        public List<SegmentGroup> SegmentationGroups { get; set; }
        public Coordinate Geolocation { get; set; }
        public List<Venue> VenueIds { get; set; }

        public FactsheetActivity()
        {
        }


        public override int GetHashCode()
        {
            int hash = 5;
            hash = 17 * hash + ActivityFactsheetType.GetHashCode();
            hash = 17 * hash + ActivityCode.GetHashCode();
            hash = 17 * hash + ModalityCode.GetHashCode();
            hash = 17 * hash + ContentId.GetHashCode();
            hash = 17 * hash + Description.GetHashCode();
            hash = 17 * hash + LastUpdate.GetHashCode();
            hash = 17 * hash + Summary.GetHashCode();
            hash = 17 * hash + AdvancedTips.GetHashCode();
            hash = 17 * hash + Countries.GetHashCode();
            hash = 17 * hash + Highligths.GetHashCode();
            hash = 17 * hash + Name.GetHashCode();
            hash = 17 * hash + DetailedInfo.GetHashCode();
            hash = 17 * hash + FeatureGroups.GetHashCode();
            hash = 17 * hash + GuidingOptions.GetHashCode();
            hash = 17 * hash + ImportantInfo.GetHashCode();
            hash = 17 * hash + Location.GetHashCode();
            hash = 17 * hash + Media.GetHashCode();
            hash = 17 * hash + Notes.GetHashCode();
            hash = 17 * hash + RedeemInfo.GetHashCode();
            hash = 17 * hash + Routes.GetHashCode();
            hash = 17 * hash + Scheduling.GetHashCode();
            hash = 17 * hash + SegmentationGroups.GetHashCode();
            hash = 17 * hash + Geolocation.GetHashCode();
            hash = 17 * hash + VenueIds.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;


            FactsheetActivity other = (FactsheetActivity)obj;
            if (ActivityFactsheetType != other.ActivityFactsheetType)
                return false;
            if (!ActivityCode.Equals(other.ActivityCode)) return false;
            if (!ModalityCode.Equals(other.ModalityCode)) return false;
            if (!ContentId.Equals(other.ContentId)) return false;
            if (!Description.Equals(other.Description)) return false;
            if (!LastUpdate.Equals(other.LastUpdate)) return false;
            if (!Summary.Equals(other.Summary)) return false;
            if (!AdvancedTips.Equals(other.AdvancedTips)) return false;
            if (!Countries.Equals(other.Countries)) return false;
            if (!Highligths.Equals(other.Highligths)) return false;
            if (!Name.Equals(other.Name)) return false;
            if (!DetailedInfo.Equals(other.DetailedInfo)) return false;
            if (!FeatureGroups.Equals(other.FeatureGroups)) return false;
            if (!GuidingOptions.Equals(other.GuidingOptions)) return false;
            if (!ImportantInfo.Equals(other.ImportantInfo)) return false;
            if (!Location.Equals(other.Location)) return false;
            if (!Media.Equals(other.Media)) return false;
            if (!Notes.Equals(other.Notes)) return false;
            if (!RedeemInfo.Equals(other.RedeemInfo)) return false;
            if (!Routes.Equals(other.Routes)) return false;
            if (!Scheduling.Equals(other.Scheduling)) return false;
            if (!SegmentationGroups.Equals(other.SegmentationGroups)) return false;
            if (!Geolocation.Equals(other.Geolocation)) return false;
            if (!VenueIds.Equals(other.VenueIds)) return false;

            return true;
        }
    }
}