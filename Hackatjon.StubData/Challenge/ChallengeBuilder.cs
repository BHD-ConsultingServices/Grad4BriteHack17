
namespace Hackathon.StubData.Challenge
{
    using Contracts.Challenge;
    using Contracts;
    using Contracts.Challenge.Types;
    using System;

    public class ChallengeBuilder : Challenge
    {
        public ChallengeBuilder()
        {
            Id = Guid.NewGuid();
        }

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
            this.Type = ChallengeType.MultipleChoice;

            Question = "What passtime activity do you like most?";
            MultiChoiceChallenge = new MultiChoiceChallenge
            {
                ExpectedAnswer = 'b',
                OptionA = "Take a walk in the park",
                OptionB = "Visit a petshop",
                OptionC = "Watch a movie",
                OptionD = "Going out clubbing"
            };

            return this;
        }

        public ChallengeBuilder HowDoYouStopAnAngryDog()
        {
            this.Type = ChallengeType.MultipleChoice;

            Question = "How do you calm down an aggressive dog?";
            MultiChoiceChallenge = new MultiChoiceChallenge
            {
                ExpectedAnswer = 'b',
                OptionA = "Talk to it in soothing voice",
                OptionB = "Spray the dog with water",
                OptionC = "Bite it on the ear to show dominance",
                OptionD = "Address the dog in a stern deep voice"
            };

            return this;
        }

        public ChallengeRequest BuildRequest() => this;

        public Challenge Build() => this;
    }
}
