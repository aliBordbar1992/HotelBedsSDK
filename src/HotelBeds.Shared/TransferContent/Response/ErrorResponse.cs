using System.Collections.Generic;
using HotelBeds.Shared.Transfer.Domain;

namespace HotelBeds.Shared.TransferContent.Response
{
    public class ErrorResponse
    {
        public string Code { get; set; }
        public string DateTime { get; set; }
        public string Description { get; set; }
        public List<FieldError> FieldErrors { get; set; }
        public bool IsBadRequest { get; set; }
        public string Message { get; set; }
        public string ServiceName { get; set; }
        public string TraceId { get; set; }
    }
}