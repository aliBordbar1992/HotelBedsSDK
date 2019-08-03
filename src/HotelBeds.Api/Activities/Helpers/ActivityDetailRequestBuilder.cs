using System;
using System.Collections.Generic;
using HotelBeds.Api.Activities.Helpers.PaxDistribution;
using HotelBeds.Shared.Activities.Request;

namespace HotelBeds.Api.Activities.Helpers
{
    public class ActivityDetailRequestBuilder
    {
        private readonly ActivityDetailRequest _detailRequest;

        public ActivityDetailRequestBuilder(string code, DateTime from, DateTime to, List<Shared.Activities.Dto.PaxDistribution> paxes)
        {
            _detailRequest = new ActivityDetailRequest(code, from, to, paxes);
        }

        public ActivityDetailRequestBuilder(string code, DateTime from, DateTime to, PaxDistributionBuilder paxBuilder)
        {
            _detailRequest = new ActivityDetailRequest(code, from, to, paxBuilder.Build());
        }

        public ActivityDetailRequestBuilder WithLanguage(string languageCode)
        {
            _detailRequest.Language = languageCode;
            return this;
        }

        public ActivityDetailRequest Build()
        {
            return _detailRequest;
        }
    }
}