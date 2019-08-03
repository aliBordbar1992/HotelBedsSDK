using System.Collections.Generic;

namespace HotelBeds.Api.Activities.Helpers.PaxDistribution
{
    public class PaxBuildHolder
    {
        private List<Shared.Activities.Dto.PaxDistribution> _paxes;
        private Shared.Activities.Dto.PaxDistribution _pax;
        public Shared.Activities.Dto.PaxDistribution ActivePax { get; set; }

        public PaxBuildHolder()
        {
            _pax = new Shared.Activities.Dto.PaxDistribution();
            _paxes = new List<Shared.Activities.Dto.PaxDistribution>();
        }

        public void AddPax(Shared.Activities.Dto.PaxDistribution pax)
        {
            ActivePax = pax;
            _paxes.Add(pax);
        }

        public List<Shared.Activities.Dto.PaxDistribution> GetPaxList()
        {
            return _paxes;
        }
    }
}