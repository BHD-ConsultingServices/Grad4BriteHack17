
namespace Hackathon.Contracts.Initiatives
{
    using System;
    using System.Collections.Generic;

    public interface IInitiativeAdapter
    {
        Initiative Create(Initiative request);

        Initiative Update(Guid id, IInitiativeUpdatable initative);

        Initiative Get(Guid id);

        IEnumerable<Challenge.Challenge> GetAllChallenges(Guid initiativeId);

        IEnumerable<Initiative> GetAllInitiatives();
    }
}
