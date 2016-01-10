using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugTrackerApp.Models;

namespace BugTrackerApp.Controllers
{
    [Authorize]
    public class BugsController : Controller
    {
        private BugTrackerAppContext db = new BugTrackerAppContext();

        //
        // GET: /Bugs/

        public ActionResult Index()
        {
            return View(db.Bugs.ToList());
        }

        //
        // GET: /Bugs/Details/5

        public ActionResult Details(int id = 0)
        {
            Bug bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return HttpNotFound();
            }
            return View(bug);
        }

        //
        // GET: /Bugs/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Bugs/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bug bug)
        {
                db.Bugs.Add(bug);
                db.SaveChanges();
                var isAjax = Request.IsAjaxRequest();
            return PartialView("BugRow", bug);
        }

        //
        // GET: /Bugs/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Bug bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return HttpNotFound();
            }
            return View(bug);
        }

        //
        // POST: /Bugs/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bug bug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bug);
        }

        //
        // GET: /Bugs/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Bug bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return HttpNotFound();
            }
            return View(bug);
        }

        //
        // POST: /Bugs/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bug bug = db.Bugs.Find(id);
            db.Bugs.Remove(bug);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult List()
        {
            return View(db.Bugs.ToList());
        }
    }
}