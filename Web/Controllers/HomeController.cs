
namespace Web.Controllers
{
    using Hackathon.Contracts.Registration;
    using System.Web.Mvc;
    using System;
    using BL.Providers;
    using Models;
   
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InitiativeList()
        {
            var provider = new InitiativeProvider();
            var model = new InitiativesModel
            {
                Initiatives = provider.GetAllInitiatives()
            };

            return View(model);
        }

        public ActionResult Initiative(Guid initiativeId)
        {
            var provider = new InitiativeProvider();

            var intiative = provider.Get(initiativeId);
            var challenges = provider.GetAllChallenges(initiativeId);

            if (intiative == null)
            {
                return View(new InitiativeModel());
            }
            
            var model = new InitiativeModel
            {
                Id = intiative.Id,
                Title = intiative.Title,
                Description = intiative.Description,
                Challenges = challenges
            };

            return View(model);
        }

        public JsonResult Register(RegistrationRequest requests)
        {
            var provider = new RegistrationProvider();

            var response = provider.Register(requests);

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}