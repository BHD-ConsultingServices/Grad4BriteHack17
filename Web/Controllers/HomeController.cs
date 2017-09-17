
using BL.Providers;
using Web.Models;
using Web.Utilities;

namespace Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Initiatives()
        {
            var provider = new InitiativeProvider();
            var model = new InitiativesModel
            {
                Initiatives = provider.GetAllInitiatives()
            };

            return View(model);
        }
    }
}