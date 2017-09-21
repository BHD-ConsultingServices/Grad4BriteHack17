
namespace Hackathon.Adapters
{
    using System;
    using Contracts.Challenge;
    using System.Linq;

    public class ChallengeAdapter : IChallengeAdapter
    {
        private InitiativesEntities context = new InitiativesEntities();

        public Contracts.Challenge.Challenge Create(Guid initiativeId, Contracts.Challenge.Challenge request)
        {

            var entity = new Challenge
            {
                Id = Guid.NewGuid(),
                InitiativeId = initiativeId,
                Question = request.Question
            };

            var challengeType = context.ChallengeTypes.FirstOrDefault(x => x.CorrelationId == (int)request.Type);
            entity.ChallengeTypeId = challengeType.Id;

            switch (request.Type)
            {
                case Contracts.Challenge.ChallengeType.YesNo:
                    var challengeYesNo = new ChallengeYesNo
                    {
                        Id = Guid.NewGuid(),
                        ExpectedAnswer = (int)request.YesNoChallenge.ExpectedAnswer
                    };
                    context.ChallengeYesNoes.Add(challengeYesNo);
                    entity.ChallengeYesNoId = challengeYesNo.Id;
                    break;
                case Contracts.Challenge.ChallengeType.MultipleChoice:
                    var challengeMulti = new ChallengeMultipleChoice
                    {
                        Id = Guid.NewGuid(),
                        ExpectedAnswer = request.MultiChoiceChallenge.ExpectedAnswer.ToString()
                    };
                    context.ChallengeMultipleChoices.Add(challengeMulti);
                    entity.ChallengeMultipleChoiceId = challengeMulti.Id;
                    break;
            }

            context.Challenges.Add(entity);
            context.SaveChanges();
            return entity.Map();
        }

        public Contracts.Challenge.Challenge Get(Guid id)
        {
            var entity = context.Challenges.Single(x => x.Id == id);
            var challenge = entity.Map();
            return challenge;
        }

        public Contracts.Challenge.Challenge Update(Guid challengeId, IChallengeUpdatable request)
        {
            var entity = context.Challenges.Single(x => x.Id == challengeId);
            entity.Question = request.Question;
            var challenge = entity.Map();
            return challenge;
        }
    }
}
