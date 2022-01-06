using ContentProject.BusinessLayer.Concrete;
using ContentProject.DataAccessLayer.Context;
using ContentProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContentProject.WebUI.Controllers
{
    public class ChartController : Controller
    {
        CategoryManager cm = new CategoryManager();
        
        // GET: Chart
        public ActionResult Index()
        {

            return View();
            //return Json(......... , JsonRequestBehavior.AllowGet);
        }
       
      

    }
}