using System.Collections.Generic;
using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Shared.Activities.Response
{
    public abstract class BaseResponse
    {
        public AuditData AuditData { get; set; }
        public string OperationId { get; set; }
        public List<Error> Errors { get; set; }


        public override int GetHashCode()
        {
            int hash = 7;
            hash = 97 * hash + AuditData.GetHashCode();
            hash = 97 * hash + OperationId.GetHashCode();
            hash = 97 * hash + Errors.GetHashCode();
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;

            BaseResponse other = (BaseResponse)obj;
            if (!AuditData.Equals(other.AuditData)) return false;
            if (!OperationId.Equals(other.OperationId)) return false;
            if (!Errors.Equals(other.Errors)) return false;

            return true;
        }
    }
}