using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class CombinationController : Controller
    {
        private Entities3 db = new Entities3();

        //
        // GET: /Combination/

        public ActionResult Index()
        {
            var combination = db.Combination.Include(c => c.Solutions);
            return View(combination.ToList());
        }

        //
        // GET: /Combination/Details/5

        public ActionResult Details(int id = 0)
        {
            Combination combination = db.Combination.Find(id);
            if (combination == null)
            {
                return HttpNotFound();
            }
            return View(combination);
        }

        //
        // GET: /Combination/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewBag.SolutionId = new SelectList(db.Solutions, "SolutionId", "HardwareInfrastructure");
            return View();
        }

        //
        // POST: /Combination/Create
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Combination combination)
        {
            if (ModelState.IsValid)
            {
                db.Combination.Add(combination);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SolutionId = new SelectList(db.Solutions, "SolutionId", "HardwareInfrastructure", combination.SolutionId);
            return View(combination);
        }

        //
        // GET: /Combination/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id = 0)
        {
            Combination combination = db.Combination.Find(id);
            if (combination == null)
            {
                return HttpNotFound();
            }
            ViewBag.SolutionId = new SelectList(db.Solutions, "SolutionId", "HardwareInfrastructure", combination.SolutionId);
            return View(combination);
        }

        //
        // POST: /Combination/Edit/5
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Combination combination)
        {
            if (ModelState.IsValid)
            {
                db.Entry(combination).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SolutionId = new SelectList(db.Solutions, "SolutionId", "HardwareInfrastructure", combination.SolutionId);
            return View(combination);
        }

        //
        // GET: /Combination/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id = 0)
        {
            Combination combination = db.Combination.Find(id);
            if (combination == null)
            {
                return HttpNotFound();
            }
            return View(combination);
        }

        //
        // POST: /Combination/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Combination combination = db.Combination.Find(id);
            db.Combination.Remove(combination);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}