
namespace Hackathon.StubData.Initiative
{
    using Contracts.Initiatives;
    using System;
    using Rhino.Mocks;
    using Challenge = Contracts.Challenge;
    using System.Collections.Generic;
    using System.Linq;
    using Challenge;

    public class AdapterBuilder
    {
        private readonly IInitiativeAdapter _adapter;

        public AdapterBuilder()
        {
            _adapter = MockRepository.GenerateMock<IInitiativeAdapter>();
        }
        
        public AdapterBuilder AddCreateStub(Initiative response = null)
        {
            var stubResult = response ?? new InitiativeBuilder().SbcaVolenteering().Build();

            _adapter.Expect(e => e.Create(Arg<Initiative>.Is.Anything)).Return(stubResult);
            _adapter.Stub(e => e.Create(Arg<Initiative>.Is.Anything)).Return(stubResult);

            return this;
        }

        public AdapterBuilder AddUpdateStub(Initiative response = null)
        {
            var stubResult = response ?? new InitiativeBuilder().SbcaVolenteering().Build();

            _adapter.Expect(e => e.Update(Arg<Guid>.Is.Anything, Arg<Initiative>.Is.Anything)).Return(stubResult);
            _adapter.Stub(e => e.Update(Arg<Guid>.Is.Anything, Arg<Initiative>.Is.Anything)).Return(stubResult);

            return this;
        }

        public AdapterBuilder AddGetStub(Initiative response = null)
        {
            var stubResult = response ?? new InitiativeBuilder().SbcaVolenteering().Build();

            _adapter.Expect(e => e.Get(Arg<Guid>.Is.Anything)).Return(stubResult);
            _adapter.Stub(e => e.Get(Arg<Guid>.Is.Anything)).Return(stubResult);

            return this;
        }

        public AdapterBuilder AddGetAllChallengesStub(IEnumerable<Challenge.Challenge> response = null)
        {
            var stubResult = response ?? new List<Challenge.Challenge>
            {
                {
                    new ChallengeBuilder().DoYouLikeDogs().Build()
                },
                {
                    new ChallengeBuilder().FavoratePassTime().Build()
                }
            };

            var challenges = stubResult as Challenge.Challenge[] ?? stubResult.ToArray();

            _adapter.Expect(e => e.GetAllChallenges(Arg<Guid>.Is.Anything)).Return(challenges);
            _adapter.Stub(e => e.GetAllChallenges(Arg<Guid>.Is.Anything)).Return(challenges);

            return this;
        }

        public AdapterBuilder GetAllInitiatives(IEnumerable<Initiative> response = null)
        {
            var stubResult = response ?? new List<Initiative>
            {
                new InitiativeBuilder().SbcaVolenteering().Build(),
                new InitiativeBuilder().FeedAChild().Build()
            };

            var initiatives = stubResult as Initiative[] ?? stubResult.ToArray();

            _adapter.Expect(e => e.GetAllInitiatives()).Return(initiatives);
            _adapter.Stub(e => e.GetAllInitiatives()).Return(initiatives);

            return this;
        }

        public IInitiativeAdapter Build()
        {
            return _adapter;
        }
    }
}
