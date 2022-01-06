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
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager();
        CategoryValidator cv = new CategoryValidator();
        // GET: AdminCategory
        
        public ActionResult Index(int p = 1)
        {
            var categoryValues = cm.List().ToPagedList(p, 10);
            return View(categoryValues);
        }

        public ActionResult CategoryReport()
        {
            var categoryValues = cm.List();
            return View(categoryValues);
        }
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            
            ValidationResult result = cv.Validate(p);
            if (result.IsValid)
            {
                cm.Insert(p);
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

        public ActionResult DeleteCategory(int? id)
        {
            
            Category categoryValue = cm.Get(x => x.CategoryId == id);
            categoryValue.CategoryStatus = false;
            cm.Delete(categoryValue);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category categoryValue = cm.Get(x => x.CategoryId == id);
            
            if (categoryValue == null)
            {
                return HttpNotFound();
            }
            return View(categoryValue);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            ValidationResult result = cv.Validate(category);
            
            if (result.IsValid)
            {
                Category categoryValue = cm.Get(x => x.CategoryId == category.CategoryId);
                categoryValue.CategoryName = category.CategoryName;
                categoryValue.CategoryDescription = category.CategoryDescription;
                cm.Update(categoryValue);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(category);
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}