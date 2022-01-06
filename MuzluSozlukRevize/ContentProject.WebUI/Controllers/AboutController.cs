using ContentProject.BusinessLayer.Concrete;
using ContentProject.Entity.Concrete;
using ContentProject.WebUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContentProject.WebUI.Controllers
{
    [AdminAuth]
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager();
        // GET: About
        public ActionResult Index()
        {
            var aboutValues = abm.List();
            return View(aboutValues);
        }
        public ActionResult AboutAdd()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AboutAdd(About about)
        {
            abm.Insert(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {

            return PartialView();
        }
    }
}