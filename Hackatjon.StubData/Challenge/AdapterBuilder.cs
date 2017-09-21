
namespace Hackathon.StubData.Challenge
{
    using System;
    using Rhino.Mocks;
    using Contracts.Challenge;

    public class AdapterBuilder
    {
        private readonly IChallengeAdapter _adapter;

        public AdapterBuilder()
        {
            _adapter = MockRepository.GenerateMock<IChallengeAdapter>();
        }
        
        public AdapterBuilder AddCreateStub(Challenge response = null)
        {
            var stubResult = response ?? new ChallengeBuilder().DoYouLikeDogs().Build();

            _adapter.Expect(e => e.Create(Arg<Guid>.Is.Anything, Arg<Challenge>.Is.Anything)).Return(stubResult);
            _adapter.Stub(e => e.Create(Arg<Guid>.Is.Anything, Arg<Challenge>.Is.Anything)).Return(stubResult);

            return this;
        }

        public AdapterBuilder AddUpdateStub(Challenge response = null)
        {
            var stubResult = response ?? new ChallengeBuilder().FavoratePassTime().Build();

            _adapter.Expect(e => e.Update(Arg<Guid>.Is.Anything, Arg<Challenge>.Is.Anything)).Return(stubResult);
            _adapter.Stub(e => e.Update(Arg<Guid>.Is.Anything, Arg<Challenge>.Is.Anything)).Return(stubResult);

            return this;
        }

        public AdapterBuilder AddGetStub(Challenge response = null)
        {
            var stubResult = response ?? new ChallengeBuilder().DoYouLikeDogs().Build();

            _adapter.Expect(e => e.Get(Arg<Guid>.Is.Anything)).Return(stubResult);
            _adapter.Stub(e => e.Get(Arg<Guid>.Is.Anything)).Return(stubResult);

            return this;
        }

        public IChallengeAdapter Build()
        {
            return _adapter;
        }
    }
}
