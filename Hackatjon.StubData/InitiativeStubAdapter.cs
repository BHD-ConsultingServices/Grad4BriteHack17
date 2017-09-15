
namespace Hackathon.StubData
{
    using System;
    using Contracts.Initiatives;
    using Initiative;
    using System.Collections.Generic;

    public class InitiativeStubAdapter : IInitiativeAdapter
    {
        private IInitiativeAdapter StubAdapter { get; }

        public InitiativeStubAdapter()
        {
            var builder = new AdapterBuilder();

            builder.AddCreateStub();
            builder.AddUpdateStub();
            builder.AddGetStub();
            builder.AddGetAllChallengesStub();

            StubAdapter = builder.Build();
        }

        public Contracts.Initiatives.Initiative Create(Contracts.Initiatives.Initiative request)
        {
            return StubAdapter.Create(request);
        }

        public Contracts.Initiatives.Initiative Update(Guid id, IInitiativeUpdatable initative)
        {
            return StubAdapter.Update(id, initative);
        }

        public Contracts.Initiatives.Initiative Get(Guid id)
        {
            return StubAdapter.Get(id);
        }

        public IEnumerable<Contracts.Challenge.Challenge> GetAllChallenges(Guid initiativeId)
        {
            return StubAdapter.GetAllChallenges(initiativeId);
        }

        public IEnumerable<Contracts.Initiatives.Initiative> GetAllInitiatives()
        {
            return StubAdapter.GetAllInitiatives();
        }
    }
}
