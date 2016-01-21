using System.Web.Mvc;

namespace TemporaryWorkersHunter.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Charts()
        {
            return View();
        }

        public ActionResult Tables()
        {
            return View();
        }

        public ActionResult Forms()
        {
            return View();
        }

        public ActionResult BootstrapElements()
        {
            return View();
        }

        public ActionResult BootstrapGrid()
        {
            return View();
        }

        public ActionResult BlankPage()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}