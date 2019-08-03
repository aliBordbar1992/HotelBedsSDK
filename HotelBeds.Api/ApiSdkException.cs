using System;
using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Api.Activities
{
    public class ApiSdkException : Exception
    {
        public const long SerialVersionUid = 1L;
        private readonly Error _error;

        ApiSdkException(Error error) : base()
        {
            this._error = error;
        }

        ApiSdkException(Error error, String message, Exception innerEx) : base(message, innerEx)
        {
            _error = error;
        }
    }
}