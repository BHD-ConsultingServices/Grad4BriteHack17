
namespace Hackathon.Contracts.Challenge
{
    using Types;

    public class ChallengeRequest : IChallengeUpdatable
    {
        public string Question { get; set; }

        public ChallengeType Type { get; set; }

        public bool Success { get; set; }

        public YesNoChallenge YesNoChallenge { get; set; }

        public MultiChoiceChallenge MultiChoiceChallenge { get; set; }
    }
}
