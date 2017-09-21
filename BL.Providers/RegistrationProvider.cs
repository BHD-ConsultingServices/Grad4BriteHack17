
namespace BL.Providers
{
    using Utilities;
    using Hackathon.Contracts;
    using Hackathon.Contracts.Registration;

    public class RegistrationProvider
    {
        private readonly IRegistrationAdapter _registrationAdapter;

        public RegistrationProvider(IRegistrationAdapter initiativeAdapter = null)
        {
            _registrationAdapter = initiativeAdapter ?? DependencyFactory.Resolve<IRegistrationAdapter>();
        }

        public Response Register(RegistrationRequest request)
        {
            /* The below is intentionally left out. This is the logic that must do the registration and calculate if it was a success  */

            //TODO: Check if Successfull

            //TODO: Persist to database using the adapter

            return new Response
            {
                IsSuccess = true
            };
        }

    }
}
