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
    public class SolutionsController : Controller
    {
        private Entities3 db = new Entities3();

        //
        // GET: /Solutions/

            public ActionResult Index(string keyWord)
        {
           var solutions = from s in db.Solutions
                        select s;

           if (!String.IsNullOrEmpty(keyWord))
           {
               var Result = (from q in db.Solutions
                                where (q.HardwareInfrastructure.Contains(keyWord) || q.SoftwareInfrastructure.Contains(keyWord) || q.Software_Applications.Contains(keyWord) || q.Networking.Contains(keyWord) || q.Storage.Contains(keyWord))
                    select q).ToArray();

               return View(Result);

           }

           else
           {
               return View(solutions);
           }
        }
        

        //
        // GET: /Solutions/Details/5

        public ActionResult Details(int id = 0)
        {
            Solutions solutions = db.Solutions.Find(id);
            if (solutions == null)
            {
                return HttpNotFound();
            }
            return View(solutions);
        }

        //
        // GET: /Solutions/Create
        [Authorize(Roles = "Administrator, Author")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Solutions/Create
        [Authorize(Roles = "Administrator, Author")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Solutions solutions)
        {
            if (ModelState.IsValid)
            {
                db.Solutions.Add(solutions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(solutions);
        }

        //
        // GET: /Solutions/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit(int id = 0)
        {
            Solutions solutions = db.Solutions.Find(id);
            if (solutions == null)
            {
                return HttpNotFound();
            }
            return View(solutions);
        }

        //
        // POST: /Solutions/Edit/5
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Solutions solutions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solutions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(solutions);
        }

        //
        // GET: /Solutions/Delete/5
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id = 0)
        {
            Solutions solutions = db.Solutions.Find(id);
            if (solutions == null)
            {
                return HttpNotFound();
            }
            return View(solutions);
        }

        //
        // POST: /Solutions/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Solutions solutions = db.Solutions.Find(id);
            db.Solutions.Remove(solutions);
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