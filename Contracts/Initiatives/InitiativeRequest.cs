
namespace Hackathon.Contracts.Initiatives
{
    public class InitiativeRequest : IInitiativeUpdatable
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
