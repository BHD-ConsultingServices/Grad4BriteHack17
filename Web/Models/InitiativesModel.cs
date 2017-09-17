
namespace Web.Models
{
    using System.Collections.Generic;
    using Hackathon.Contracts.Initiatives;

    public class InitiativesModel
    {
        public IEnumerable<Initiative> Initiatives { get; set; }
    }
}