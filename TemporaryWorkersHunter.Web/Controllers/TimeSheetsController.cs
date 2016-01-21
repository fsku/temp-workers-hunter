using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TemporaryWorkersHunter.Entities;
using TemporaryWorkersHunter.Entities.DbContexts;
using TemporaryWorkersHunter.Web.ViewModels;

namespace TemporaryWorkersHunter.Web.Controllers
{
    //TODO Refactor using services
    public class TimeSheetsController : Controller
    {
        private TemporaryWorkersDb db = new TemporaryWorkersDb();

        // GET: TimeSheets
        public ActionResult Index()
        {
            var vm = new TimeSheetViewModel()
            {
                Date = DateTime.Now,
                TimeSheetRows = new List<TimeSheetRowViewModel>()
                {
                    new TimeSheetRowViewModel()
                    {
                        Worker = new WorkerViewModel()
                        {
                            FirstName = "Filip",
                            LastName = "Skurniak",
                        },
                        IsPresent = true,
                        IsLate = false,
                        NumberOfHours = 8,
                    },
                    new TimeSheetRowViewModel()
                    {
                        Worker = new WorkerViewModel()
                        {
                            FirstName = "Filip2",
                            LastName = "Skurniak2",
                        },
                        IsPresent = false,
                        IsLate = false,
                        NumberOfHours = 8,
                    },
                    new TimeSheetRowViewModel()
                    {
                        Worker = new WorkerViewModel()
                        {
                            FirstName = "Filip2",
                            LastName = "Skurniak3",
                        },
                        IsPresent = true,
                        IsLate = true,
                        NumberOfHours = 4,
                    }
                }
            };
            return View(vm);
        }

        // GET: TimeSheets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSheet timeSheet = db.TimeSheets.Find(id);
            if (timeSheet == null)
            {
                return HttpNotFound();
            }
            return View(timeSheet);
        }

        // GET: TimeSheets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeSheets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date")] TimeSheet timeSheet)
        {
            if (ModelState.IsValid)
            {
                db.TimeSheets.Add(timeSheet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeSheet);
        }

        // GET: TimeSheets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSheet timeSheet = db.TimeSheets.Find(id);
            if (timeSheet == null)
            {
                return HttpNotFound();
            }
            return View(timeSheet);
        }

        // POST: TimeSheets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date")] TimeSheet timeSheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeSheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeSheet);
        }

        // GET: TimeSheets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSheet timeSheet = db.TimeSheets.Find(id);
            if (timeSheet == null)
            {
                return HttpNotFound();
            }
            return View(timeSheet);
        }

        // POST: TimeSheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeSheet timeSheet = db.TimeSheets.Find(id);
            db.TimeSheets.Remove(timeSheet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
