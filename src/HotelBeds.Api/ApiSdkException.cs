using System;
using System.Collections.Generic;
using HotelBeds.Shared.Activities.Dto;

namespace HotelBeds.Api.Activities
{
    public class ApiSdkException : Exception
    {
        public const long SerialVersionUid = 1L;
        private readonly Error _error;

        public ApiSdkException(Error error) : base()
        {
            this._error = error;
        }

        public ApiSdkException(Error error, String message, Exception innerEx) : base(message, innerEx)
        {
            _error = error;
        }
    }

    public static class ExceptionExtensions
    {
        public static IEnumerable<Exception> GetInnerExceptions(this Exception ex)
        {
            if (ex == null)
            {
                throw new ArgumentNullException("ex");
            }

            var innerException = ex;
            do
            {
                yield return innerException;
                innerException = innerException.InnerException;
            }
            while (innerException != null);
        }
    }
}