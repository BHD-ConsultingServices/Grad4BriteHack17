
namespace Hackathon.Adapters
{
    using System;
    using Contracts.Initiatives;
    using Challenge = Contracts.Challenge;
    using System.Collections.Generic;

    public class InitiativeAdapter : IInitiativeAdapter
    {
        public Initiative Create(Initiative request)
        {
            throw new NotImplementedException();
        }

        public Initiative Update(Guid id, IInitiativeUpdatable initative)
        {
            throw new NotImplementedException();
        }

        public Initiative Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Challenge.Challenge> GetAllChallenges(Guid initiativeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Initiative> GetAllInitiatives()
        {
            throw new NotImplementedException();
        }
    }
}
