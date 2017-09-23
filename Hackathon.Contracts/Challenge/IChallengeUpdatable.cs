
namespace Hackathon.Contracts.Challenge
{
    using Types;

    public interface IChallengeUpdatable
    {
        string Question { get; set; }

        ChallengeType Type { get; set; }

        bool Success { get; set; }

        YesNoChallenge YesNoChallenge { get; set; }

        MultiChoiceChallenge MultiChoiceChallenge { get; set; }
    }
}
