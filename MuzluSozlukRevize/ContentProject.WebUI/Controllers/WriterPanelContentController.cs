using ContentProject.BusinessLayer.Concrete;
using ContentProject.BusinessLayer.ValidationRules;
using ContentProject.DataAccessLayer.Context;
using ContentProject.Entity.Concrete;
using ContentProject.WebUI.Filters;
using ContentProject.WebUI.Models;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ContentProject.WebUI.Controllers
{
    //[AllowAnonymous]
    [WriterAuth]
    public class WriterPanelContentController : Controller
    {
        ContentManager com = new ContentManager();
        ContentValidator cov = new ContentValidator();

        // GET: WriterPanelContent
        public ActionResult MyContent()
        {
            //DatabaseContext db = new DatabaseContext();

            //p = (string)Session["WriterUsername"];

            //var writeridInfo = db.Writers.Where(x => x.WriterUsername == p).Select(y=> y.WriterId).FirstOrDefault();


            if (CurrentSession.Writer != null)
            {
                var writerIdInfo = CurrentSession.Writer.WriterId;                  //yukarıda açıklama satırı olan session üzerinden id alma                                                                            işlemini
                var contentValues = com.List(x => x.WriterId == writerIdInfo);      //CurrentSession Class'ı sayesinde tek satırda gerçekleştirdim.
                return View(contentValues);
            }

            return View();
        }
        
        public ActionResult ContentByWriter(int id, int p = 1)
        {
            var writerValues = com.List(x => x.WriterId == id).ToPagedList(p, 10);
            return View(writerValues);
        }
        public ActionResult ContentByHeading(int? id,int p =1)
        {
            var contentValues = com.List(x => x.HeadingId == id).ToPagedList(p,10);
            return View(contentValues);
        }
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]

        public ActionResult AddContent(Content content)
        {
            ValidationResult result = cov.Validate(content);

            if (CurrentSession.Writer != null)
            {
                if (result.IsValid)
                {
                    content.ContentDate = DateTime.Now;
                    content.WriterId = CurrentSession.Writer.WriterId;
                    content.isActive = true;
                    com.Insert(content);
                    return RedirectToAction("MyContent");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else
            {
                return RedirectToAction("WriterLogin", "Login");
            }
            return View();
        }

        public ActionResult MyContentEdit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content contentValue = com.Get(x => x.ContentId == id);
            if (contentValue == null)
            {
                return HttpNotFound();
            }
            return View(contentValue);
        }

        [HttpPost]

        public ActionResult MyContentEdit(Content content) //pop-up ile yapalım? 
        {
           var contentValues = com.Get(x=> x.ContentId == content.ContentId);
            contentValues.ContentDate = DateTime.Now;
            contentValues.ContentValue = content.ContentValue;
            contentValues.isActive = content.isActive;
            contentValues.WriterId = content.WriterId;
            contentValues.HeadingId = content.HeadingId;
            com.Update(contentValues);

            return RedirectToAction("MyContent");
        }

        public ActionResult MyContentDelete(int? id)
        {
            var contentValue = com.Get(x => x.ContentId == id);
            contentValue.isActive = false;
            com.Delete(contentValue);
            return RedirectToAction("MyContent");
        }
    }
}