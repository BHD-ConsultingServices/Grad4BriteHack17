
namespace Hackathon.Adapters
{
    using Hackathon.Contracts;
    using Hackathon.Contracts.Registration;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class RegistrationAttemptAdapter : IRegistrationAttemptAdapter
    {
        private bool withTransactionRollback = false;
        private DbContextTransaction transaction;

        public RegistrationAttemptAdapter()
        {
            if (transaction == null)
            {
                transaction = InitiativesEntities.Instance.Database.CurrentTransaction;
                if (transaction == null)
                {
                    transaction = InitiativesEntities.Instance.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                }
            }
        }

        public RegistrationAttemptAdapter(bool withTransactionRollback)
        {
            this.withTransactionRollback = withTransactionRollback;

            if (this.withTransactionRollback)
            {
                transaction = InitiativesEntities.Instance.Database.CurrentTransaction;
                if (transaction == null)
                {
                    transaction = InitiativesEntities.Instance.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
                }
            }
        }

        ~RegistrationAttemptAdapter()
        {
            if (withTransactionRollback)
            {
                if (transaction != null)
                {
                    if (transaction.UnderlyingTransaction.Connection != null)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        public void AnswerChallenge(Guid challengeId, Guid registrationId, Contracts.RegistrationAttemptAnswer answer)
        {


            var challenge = InitiativesEntities.Instance.Challenges.Single(c => c.Id == challengeId);

            var entity = new RegistrationAttemptAnswer
            {
                Id = Guid.NewGuid(),
                ChallengeId = challengeId,
                RegistrationAttemptId = registrationId
            };

            var challengeType = (Contracts.Challenge.ChallengeType)challenge.ChallengeType.CorrelationId;

            if (!Enum.IsDefined(typeof(Contracts.Challenge.ChallengeType), challenge.ChallengeType.CorrelationId))
                throw new Exception($"{challenge.ChallengeType.CorrelationId} is an invalid value for ChallengeType.");

            switch (challengeType)
            {
                case Contracts.Challenge.ChallengeType.Unknown:
                    throw new Exception($"Cannot create registration with Challenge Type of {challengeType.ToString()}.");
                case Contracts.Challenge.ChallengeType.YesNo:
                    if (!answer.AnswerYesNo.HasValue)
                    {
                        throw new Exception($"A Yes or No Answer was expected but nothing was received.");
                    }
                    entity.AnswerYesNo = answer.AnswerYesNo;
                    break;
                case Contracts.Challenge.ChallengeType.MultipleChoice:
                    if (string.IsNullOrEmpty(answer.AnswerMultipleChoice))
                    {
                        throw new Exception($"A MultipleChoice answer was expected but nothing was received..");
                    }
                    entity.AnswerMultipleChoice = answer.AnswerMultipleChoice.First().ToString();
                    break;
            }

            InitiativesEntities.Instance.RegistrationAttemptAnswers.Add(entity);
            InitiativesEntities.Instance.SaveChanges();

            Commit();
        }

        public Contracts.RegistrationAttempt CreateRegistration(Guid intiativeId, IUpdatableRegistration registration)
        {
            var entity = new RegistrationAttempt
            {
                Id = Guid.NewGuid(),
                EmailAddress = registration.EmailAddress,
                FirstName = registration.FirstName,
                Surname = registration.Surname,
                HasSucceeded = false,
                InitiativeId = intiativeId
            };

            entity = InitiativesEntities.Instance.RegistrationAttempts.Add(entity);
            var result = entity.Map();
            InitiativesEntities.Instance.SaveChanges();

            Commit();
            return result;
        }

        public IEnumerable<Contracts.RegistrationAttempt> GetAllRegistrations() => (InitiativesEntities.Instance.RegistrationAttempts.Map());

        public Contracts.RegistrationAttempt GetRegistrationByEmai(string emailAddress) => (InitiativesEntities.Instance.RegistrationAttempts.FirstOrDefault(r => r.EmailAddress == emailAddress).Map());

        public Contracts.RegistrationAttempt GetRegistrationById(Guid id) => (InitiativesEntities.Instance.RegistrationAttempts.FirstOrDefault(r => r.Id == id).Map());

        public Contracts.RegistrationAttempt UpdateRegistration(Guid id, IUpdatableRegistration registration)
        {
            var entity = InitiativesEntities.Instance.RegistrationAttempts.FirstOrDefault(r => r.Id == id);
            if (entity != null)
            {
                entity.EmailAddress = registration.EmailAddress;
                entity.FirstName = registration.FirstName;
                entity.Surname = registration.Surname;

                InitiativesEntities.Instance.SaveChanges();
                Commit();
                return entity.Map();
            }

            throw new InvalidOperationException($"Registration with Id [{id}] does not exist.");
        }

        private void Commit()
        {
            if (!withTransactionRollback)
            {
                if (transaction != null)
                {
                    transaction.Commit();
                }
            }
        }
    }
}
