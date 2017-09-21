
namespace Hackathon.Adapters
{
    using System;
    using Contracts.Challenge;

    public class ChallengeAdapter: IChallengeAdapter
    {
        public Challenge Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Challenge Create(Challenge request)
        {
            throw new NotImplementedException();
        }

        public Challenge Update(Guid challengeId, IChallengeUpdatable request)
        {
            throw new NotImplementedException();
        }
    }
}
