
namespace Hackathon.Adapters
{
    using System;
    using Contracts.Initiatives;
    using Challenge = Contracts.Challenge;
    using System.Collections.Generic;
    using System.Linq;

    public class InitiativeAdapter : IInitiativeAdapter
    {
        private InitiativesEntities context = new InitiativesEntities();

        public Contracts.Initiatives.Initiative Create(Contracts.Initiatives.Initiative request)
        {
            var entity = new Initiative
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                PassRate = request.Passrate
            };

            context.Initiatives.Add(entity);
            context.SaveChanges();
            var initiative = entity.Map();
            return initiative;
        }

        public Contracts.Initiatives.Initiative Get(Guid id)
        {
            var entity = context.Initiatives.Single(x => x.Id == id);
            var initiative = entity.Map();
            return initiative;
        }

        public IEnumerable<Contracts.Challenge.Challenge> GetAllChallenges(Guid initiativeId)
        {
            var entities = context.Challenges;
            var challenges = entities.Map();
            return challenges;
        }

        public IEnumerable<Contracts.Initiatives.Initiative> GetAllInitiatives()
        {
            var entities = context.Initiatives;
            var initiatives = entities.Map();
            return initiatives;
        }

        public Contracts.Initiatives.Initiative Update(Guid id, IInitiativeUpdatable initative)
        {
            var entity = context.Initiatives.Single(x => x.Id == id);
            entity.Title = initative.Description;
            context.SaveChanges();
            var initiative = entity.Map();
            return initiative;
        }
    }
}
