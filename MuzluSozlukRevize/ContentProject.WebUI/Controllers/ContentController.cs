using ContentProject.BusinessLayer.Concrete;
using ContentProject.WebUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContentProject.WebUI.Controllers
{
    [AdminAuth]
    public class ContentController : Controller
    {
        ContentManager com = new ContentManager();
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string p)
        {
            
            var Values = from x in com.List() select x;
            if (!string.IsNullOrEmpty(p))
            {
                Values = Values.Where(y => y.ContentValue.Contains(p));
            }

            return View(Values.ToList());
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentValues = com.List(x => x.HeadingId == id);
            return View(contentValues);
        }
    }
}