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
    public class DropSolController : Controller
    {

        private Entities3 db = new Entities3();
        //
        // GET: /DropSol/

        public ActionResult Index()
        {
            var DropSol = new DropSol();
            DropSol.DropComb = db.Combination.ToList();


            return View(DropSol);
        }

        /*[HttpPost]
        public ActionResult SolGet()
        {
            ViewBag.Selected = Request.Form["CombId"];
            return View();
        }*/

        [HttpPost]
        public ActionResult ShowSol()
        {
            var reqf = Convert.ToInt32(Request.Form["CombId"]);

            var sol = (from u in db.Combination
                            from w in db.Solutions
                            where u.SolutionId == reqf && w.SolutionId == u.SolutionId
                            select w).Distinct();

            /* var userqry = (from u in db.UserProfiles
                           from w in u.webpages_Roles
                           where w.RoleId == reqf
                           select u).ToList(); */

            return View(sol);
            //return new RazorPDF.PdfResult(userqry2, "ShowSol");

        }

        


    }
}
