
namespace Hackathon.Contracts.Challenge
{
    using System;

    public interface IChallengeAdapter
    {
        Challenge Get(Guid id);

        Challenge Create(Guid initiativeId, Challenge request);

        Challenge Update(Guid challengeId, IChallengeUpdatable request);
    }
}
