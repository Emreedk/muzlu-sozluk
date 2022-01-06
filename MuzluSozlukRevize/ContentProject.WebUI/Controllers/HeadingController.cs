using ContentProject.BusinessLayer.Concrete;
using ContentProject.Entity.Concrete;
using ContentProject.BusinessLayer.ValidationRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;
using System.Net;
using PagedList;
using PagedList.Mvc;
using ContentProject.WebUI.Filters;

namespace ContentProject.WebUI.Controllers
{
    [AdminAuth]
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager();
        CategoryManager cm = new CategoryManager();
        WriterManager wm = new WriterManager();

        // GET: Heading
        public ActionResult Index(int p = 1)
        {
            var headingValues = hm.List().ToPagedList(p, 10);
            return View(headingValues);
        }

        public ActionResult HeadingReport()
        {
            var headingValues = hm.List();
            return View(headingValues);
        }

        public ActionResult HeadingByCategory(int id, int p = 1)
        {

            return View(hm.List(x => x.CategoryId == id).ToPagedList(p, 10));
        }

        public ActionResult HeadingAdd()
        {
            List<SelectListItem> valueCategory = (from x in cm.List()
                                                  select new SelectListItem
                                                  { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();
            List<SelectListItem> valueWriter = (from x in wm.List()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                    Value = x.WriterId.ToString()
                                                }).ToList();


            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;

            return View();
        }

        [HttpPost]
        public ActionResult HeadingAdd(Heading heading)
        {
            List<SelectListItem> valueCategory = (from x in cm.List()
                                                  select new SelectListItem
                                                  { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();
            List<SelectListItem> valueWriter = (from x in wm.List()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                    Value = x.WriterId.ToString()
                                                }).ToList();


            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;

            HeadingValidator headingValidator = new HeadingValidator();
            ValidationResult result = headingValidator.Validate(heading);
            if (ModelState.IsValid)
            {
                heading.HeadingDate = DateTime.Now;
                hm.Insert(heading);
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

        public ActionResult HeadingEdit(int? id)
        {
            List<SelectListItem> valueCategory = (from x in cm.List()
                                                  select new SelectListItem
                                                  { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();

            ViewBag.vlc = valueCategory;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heading headingValue = hm.Get(x => x.HeadingId == id);
            if (headingValue == null)
            {
                return HttpNotFound();
            }
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult HeadingEdit(Heading heading) //CategoryName alanına categoryId ataması yapılıyor?
        {
            List<SelectListItem> valueCategory = (from x in cm.List()
                                                  select new SelectListItem
                                                  { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();

            ViewBag.vlc = valueCategory;

            HeadingValidator hv = new HeadingValidator();
            ValidationResult result = hv.Validate(heading);
            if (result.IsValid)
            {
                var headingValues = hm.Get(x => x.HeadingId == heading.HeadingId);
                headingValues.HeadingName = heading.HeadingName;
                headingValues.isActive = heading.isActive;
                headingValues.HeadingDate = DateTime.Now;
                headingValues.Writer.WriterName = heading.Writer.WriterName;
                headingValues.CategoryId = heading.CategoryId;
                hm.Update(headingValues);
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

        public ActionResult HeadingDelete(int? id)
        {
            var headingValue = hm.Get(x => x.HeadingId == id);
            headingValue.isActive = false;
            hm.Delete(headingValue);
            return RedirectToAction("Index");
        }

    }
}