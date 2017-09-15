
using System;

namespace Hackathon.StubData.Challenge
{
    using Contracts.Challenge;
    using Contracts;
    using Contracts.Challenge.Types;

    public class ChallengeBuilder : Challenge
    {
        public ChallengeBuilder UpdateId(Guid id)
        {
            Id = id;

            return this;
        }

        public ChallengeBuilder DoYouLikeDogs()
        {
            this.Type = ChallengeType.YesNo;

            Question = "Do you like dogs?";
            YesNoChallenge = new YesNoChallenge
            {
                ExpectedAnswer = YesNoEnum.Yes
            };

            return this;
        }

        public ChallengeBuilder UpdateQuestion(string question)
        {
            Question = question;

            return this;
        }

        public ChallengeBuilder FavoratePassTime()
        {
            this.Type = ChallengeType.YesNo;

            Question = "What passtime activity do you like most?";
            MultiChoiceChallenge = new MultiChoiceChallenge
            {
                ExpectedAnswer = 'b',
                OptionA = "Talk a walk in the park",
                OptionB = "Visit a petshop",
                OptionC = "Watch a movie",
                OptionD = "Going out clubbing"
            };

            return this;
        }

        public ChallengeRequest BuildRequest()
        {
            return this;
        }

        public Challenge Build()
        {
            return this;
        }
    }
}
