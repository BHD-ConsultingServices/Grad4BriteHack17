
namespace Hackathon.Contracts
{
    using System;
    using System.Collections.Generic;

    public class RegistrationRequest
	{
        public Guid InitiativeId { get; set; }

	    public string Email { get; set; }

        public IEnumerable<Answer> Answers { get; set; }
	}
}