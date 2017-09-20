
namespace Web.Models
{
    using System.Collections.Generic;
    using Hackathon.Contracts.Challenge;
    using Hackathon.Contracts.Initiatives;

    public class InitiativeModel : Initiative
    {
        public IEnumerable<Challenge> Challenges { get; set; }
    }
}