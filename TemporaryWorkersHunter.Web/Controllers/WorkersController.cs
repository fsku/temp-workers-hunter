using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TemporaryWorkersHunter.Entities;
using TemporaryWorkersHunter.Service;

namespace TemporaryWorkersHunter.Web.Controllers
{
    //TODO use view models !
    [Authorize]
    public class WorkersController : Controller
    {
        private readonly IWorkerService _workerService;

        public WorkersController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        public ActionResult Index()
        {
            return View(_workerService.GetAll().ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = _workerService.GetById(id.Value);

            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Image,Pesel,RelianceRating")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                _workerService.Add(worker);
                return RedirectToAction("Index");
            }

            return View(worker);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worker worker = _workerService.GetById(id.Value);

            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Image,Pesel,RelianceRating")] Worker worker)
        {
            if (ModelState.IsValid)
            {
                _workerService.Update(worker);
                return RedirectToAction("Index");
            }
            return View(worker);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Worker worker = _workerService.GetById(id.Value);

            if (worker == null)
            {
                return HttpNotFound();
            }
            return View(worker);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Worker worker = _workerService.GetById(id);
            _workerService.Delete(worker);

            return RedirectToAction("Index");
        }
    }
}
