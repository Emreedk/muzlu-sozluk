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
    [WriterAuth]
    public class GalleryController : Controller
    {
        GalleryManager gm = new GalleryManager();
        // GET: Gallery
        public ActionResult Index()
        {

            return View(gm.List());
        }
    }
}