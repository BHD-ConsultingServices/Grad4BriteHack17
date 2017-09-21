using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Adapters
{
    public static class AdapterExtensions
    {
        public static Contracts.RegistrationAttempt Map(this RegistrationAttempt entity)
        {
            if (entity == null)
                throw null;

            return new Contracts.RegistrationAttempt
            {
                Id = entity.Id,
                EmailAddress = entity.EmailAddress,
                FirstName = entity.FirstName,
                Surname = entity.Surname,
                HasSucceeded = entity.HasSucceeded,
                InitiativeId = entity.InitiativeId
            };
        }

        public static IEnumerable<Contracts.RegistrationAttempt> Map(this IEnumerable<RegistrationAttempt> entities) => (entities.Select(Map));

        public static Contracts.Initiatives.Initiative Map(this Initiative entity)
        {
            if (entity == null)
                return null;

            var item = new Contracts.Initiatives.Initiative
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                PassRate = entity.PassRate
            };
            return item;
        }

        public static IEnumerable<Contracts.Initiatives.Initiative> Map(this IEnumerable<Initiative> entities) => (entities.Select(Map));

        public static Contracts.Challenge.Challenge Map(this Challenge entity)
        {
            if (entity == null)
                return null;

            var item = new Contracts.Challenge.Challenge
            {
                Id = entity.Id,
                Question = entity.Question,
            };
            item.Type = (Contracts.Challenge.ChallengeType)entity.ChallengeType.CorrelationId;
            switch (item.Type)
            {
                case Contracts.Challenge.ChallengeType.YesNo:
                    var expectedYesNoAnswer = entity.ChallengeYesNo;
                    item.YesNoChallenge = new Contracts.Challenge.Types.YesNoChallenge
                    {
                        ExpectedAnswer = (Contracts.YesNoEnum)expectedYesNoAnswer.ExpectedAnswer
                    };
                    break;
                case Contracts.Challenge.ChallengeType.MultipleChoice:
                    var expectedMultiChoiceAnswer = entity.ChallengeMultipleChoice;
                    item.MultiChoiceChallenge = new Contracts.Challenge.Types.MultiChoiceChallenge
                    {
                        ExpectedAnswer = expectedMultiChoiceAnswer.ExpectedAnswer.First()
                    };
                    break;
            }

            return item;
        }

        public static IEnumerable<Contracts.Challenge.Challenge> Map(this IEnumerable<Challenge> entities) => (entities.Select(Map));

    }
}
