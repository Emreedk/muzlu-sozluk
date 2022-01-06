using ContentProject.BusinessLayer.Concrete;
using ContentProject.BusinessLayer.ValidationRules;
using ContentProject.Entity.Concrete;
using ContentProject.WebUI.Filters;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using PagedList;
using PagedList.Mvc;
using System.Web.Mvc;

namespace ContentProject.WebUI.Controllers
{
    [AdminAuth]
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager();
        ContentManager ctm = new ContentManager();
        // GET: Writer
        public ActionResult Index(int p = 1)
        {
            var writerValues = wm.List().ToPagedList(p,12);
            return View(writerValues);
        }

        public ActionResult ContentByWriter(int id, int p=1)
        {
            var writerValues = ctm.List(x => x.WriterId == id).ToPagedList(p,10);
            return View(writerValues);
        }
        public ActionResult WriterReport()
        {
            var writerValues = wm.List();
            return View(writerValues);
        }

        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult result = writerValidator.Validate(writer);
            if (ModelState.IsValid)
            {
                wm.Insert(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult EditWriter(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Writer writerValue = wm.Get(x => x.WriterId == id);
            if (writerValue == null)
            {
                return HttpNotFound();
            }
            return View(writerValue);
        }

        [HttpPost]

        public ActionResult EditWriter(Writer writer)
        {
            if (ModelState.IsValid)
            {
                Writer writerValue = wm.Get(x => x.WriterId == writer.WriterId);
                writerValue.WriterName = writer.WriterName;
                writerValue.WriterSurname = writer.WriterSurname;
                writerValue.WriterUsername = writer.WriterUsername;
                writerValue.WriterAbout = writer.WriterAbout;
                writerValue.WriterMail = writer.WriterMail;
                writerValue.WriterImage = writer.WriterImage;
                writerValue.isAdmin = writer.isAdmin;
                wm.Update(writerValue);
                return RedirectToAction("Index");
            }
            return View(writer);
        }
    }
}