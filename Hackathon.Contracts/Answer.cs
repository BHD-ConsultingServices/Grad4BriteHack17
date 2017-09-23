
namespace Hackathon.Contracts
{
    using System;
    using Challenge;

    public class Answer
	{
        public Guid ChallengeId { get; set; }

        public ChallengeType ChallengeType { get; set; }

        public YesNoEnum YesNoAnswer { get; set; }

        public char MultiAnswer { get; set; }
	}
}