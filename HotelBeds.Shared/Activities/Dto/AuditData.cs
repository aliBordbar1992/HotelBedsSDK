using System;
using System.Collections.Generic;

namespace HotelBeds.Shared.Activities.Dto
{
    public class AuditData
    {
        public double ProcessTime { get; set; }
        public DateTime Time { get; set; }
        public string ServerId { get; set; }
        public string Environment { get; set; }
        public List<string> AceRequests { get; set; }
        public List<string> AceResponses { get; set; }


        public override int GetHashCode()
        {
            int hash = 7;
            hash = 59 * hash + ProcessTime.GetHashCode();
            hash = 59 * hash + Time.GetHashCode();
            hash = 59 * hash + ServerId.GetHashCode();
            hash = 59 * hash + Environment.GetHashCode();
            hash = 59 * hash + AceRequests.GetHashCode();
            hash = 59 * hash + AceResponses.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            AuditData other = (AuditData)obj;
            if (!ProcessTime.Equals(other.ProcessTime)) return false;
            if (!Time.Equals(other.Time)) return false;
            if (!ServerId.Equals(other.ServerId)) return false;
            if (!Environment.Equals(other.Environment)) return false;
            if (!AceRequests.Equals(other.AceRequests)) return false;
            if (!AceResponses.Equals(other.AceResponses)) return false;

            return true;
        }
    }
}