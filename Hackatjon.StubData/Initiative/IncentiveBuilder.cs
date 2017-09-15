
namespace Hackathon.StubData.Initiative
{
    using System;
    using Contracts.Initiatives;

    public class InitiativeBuilder : Initiative
    {
        public InitiativeBuilder()
        {
            Id = Guid.NewGuid();
        }

        public InitiativeBuilder UpdateId(Guid id)
        {
            Id = id;

            return this;
        }

        public InitiativeBuilder UpdateDescription(string description)
        {
            Description = description;

            return this;
        }

        public InitiativeBuilder SbcaVolenteering()
        {
            Title = "SBCA Volenteering";
            Description = "Spend a day feeding, cleaning and caring for the animals at the SBCA";

            return this;
        }

        public InitiativeBuilder FeedAChild()
        {
            Title = "Feed a Child";
            Description = "Get involved with Matlanda orphanage and make a difference";

            return this;
        }

        public InitiativeRequest BuildRequest()
        {
            return this;
        }

        public Initiative Build()
        {
            return this;
        }
    }
}
