using System.Collections.Generic;
using HotelBeds.Shared;
using HotelBeds.Shared.Activities.Domain;

namespace HotelBeds.Api.Activities.Helpers.PaxDistribution
{
    public class PaxDistributionBuilder
    {
        private readonly PaxBuildHolder _paxHolder;

        public PaxDistributionBuilder()
        {
            _paxHolder = new PaxBuildHolder();
        }


        public PaxDistributionBuilder(PaxBuildHolder paxHolder)
        {
            _paxHolder = paxHolder;
        }

        public PaxDistributionSelector AnAdult()
        {
            var t = new Shared.Activities.Dto.PaxDistribution {Type = PaxType.Adult};
            _paxHolder.AddPax(t);
            return new PaxDistributionSelector(_paxHolder);
        }

        public PaxDistributionSelector AnInfant()
        {
            var t = new Shared.Activities.Dto.PaxDistribution { Type = PaxType.Infant };
            _paxHolder.AddPax(t);
            return new PaxDistributionSelector(_paxHolder);
        }

        public PaxDistributionSelector AChild()
        {
            var t = new Shared.Activities.Dto.PaxDistribution { Type = PaxType.Child };
            _paxHolder.AddPax(t);
            return new PaxDistributionSelector(_paxHolder);
        }
        public PaxDistributionSelector APax()
        {
            var t = new Shared.Activities.Dto.PaxDistribution();
            _paxHolder.AddPax(t);
            return new PaxDistributionSelector(_paxHolder);
        }

        public PaxDistributionSelector A(string paxTypeCode)
        {
            var t = new Shared.Activities.Dto.PaxDistribution {Type = PaxType.FromCode(paxTypeCode)};
            _paxHolder.AddPax(t);
            return new PaxDistributionSelector(_paxHolder);
        }

        public PaxDistributionSelector An(string paxTypeCode)
        {
            return A(paxTypeCode);
        }

        public List<Shared.Activities.Dto.PaxDistribution> Build()
        {
            return _paxHolder.GetPaxList();
        }
    }
}