
namespace Hackathon.StubData
{
    using System;
    using Contracts.Challenge;
    using Challenge;

    public class ChallengeStubAdapter : IChallengeAdapter
    {
        private IChallengeAdapter StubAdapter { get; }

        public ChallengeStubAdapter()
        {
            var builder = new AdapterBuilder();

            builder.AddCreateStub();
            builder.AddUpdateStub();
            builder.AddGetStub();

            StubAdapter = builder.Build();
        }

        public Contracts.Challenge.Challenge Get(Guid id)
        {
            return StubAdapter.Get(id);
        }

        public Contracts.Challenge.Challenge Create(Contracts.Challenge.Challenge request)
        {
            return StubAdapter.Create(request);
        }

        public Contracts.Challenge.Challenge Update(Guid challengeId, IChallengeUpdatable request)
        {
            return StubAdapter.Update(challengeId, request);
        }
    }
}
