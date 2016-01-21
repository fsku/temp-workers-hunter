using System.Web.Mvc;

namespace TemporaryWorkersHunter.Web.Controllers
{
    public class NavbarController : Controller
    {
        // GET: Navbar
        public ActionResult Navbar(string controller, string action)
        {
            //var data = new Data();
            
            //var navbar = data.itemsPerUser(controller, action, User.Identity.Name);

            return PartialView("_navbar");
        }
    }
}