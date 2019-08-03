namespace HotelBeds.Api.Activities.Helpers.PaxDistribution
{
    public class PaxDistributionSelector
    {
        private readonly PaxBuildHolder _paxHolder;
        private readonly Shared.Activities.Dto.PaxDistribution _paxDistribution;

        public PaxDistributionSelector(Shared.Activities.Dto.PaxDistribution paxDistribution)
        {
            _paxDistribution = paxDistribution;
            _paxHolder = null;
        }

        public PaxDistributionSelector(PaxBuildHolder paxHolder)
        {
            _paxHolder = paxHolder;
            _paxDistribution = paxHolder.ActivePax;
        }

        public PaxDistributionBuilder WithAge(int age)
        {
            _paxDistribution.Age = age;
            return _paxHolder == null ? new PaxDistributionBuilder() : new PaxDistributionBuilder(_paxHolder);
        }
    }
}