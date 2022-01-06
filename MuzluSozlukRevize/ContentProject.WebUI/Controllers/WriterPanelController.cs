using ContentProject.BusinessLayer.Concrete;
using ContentProject.BusinessLayer.ValidationRules;
using ContentProject.DataAccessLayer.Context;
using ContentProject.Entity.Concrete;
using ContentProject.WebUI.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using ContentProject.WebUI.Filters;

namespace ContentProject.WebUI.Controllers
{
    [WriterAuth]
    public class WriterPanelController : Controller
    {
        HeadingValidator hv = new HeadingValidator();
        HeadingManager hm = new HeadingManager();
        CategoryManager cm = new CategoryManager();
        WriterManager wm = new WriterManager();
        WriterValidator wv = new WriterValidator();
        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            if (CurrentSession.Writer != null)
            {
                return View(wm.List(x => x.WriterId == CurrentSession.Writer.WriterId));
            }
            else
            {
                return RedirectToAction("WriterLogin", "Login");
            }

        }
        [AllowAnonymous]
        public ActionResult WriterProfileById(int id)
        {
            var writerValues = wm.List(x => x.WriterId == id);
            return View(writerValues);
        }
        
        public ActionResult EditProfile(int? id)
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

        public ActionResult EditProfile(Writer writer, HttpPostedFileBase ProfileImage)
        {
            ValidationResult result = wv.Validate(writer);
            if (result.IsValid)
            {
                if (ProfileImage != null && (ProfileImage.ContentType == "image/jpg" || ProfileImage.ContentType == "image/jpeg" || ProfileImage.ContentType == "image/png"))
                {
                    string filename = $"user_{writer.WriterId}.{ProfileImage.ContentType.Split('/')[1]}";

                    ProfileImage.SaveAs(Server.MapPath($"~/AdminLTE-3.0.4/dist/img/{filename}"));
                    writer.WriterImage = filename;
                }

                Writer writerValue = wm.Get(x => x.WriterId == writer.WriterId);
                writerValue.WriterName = writer.WriterName;
                writerValue.WriterSurname = writer.WriterSurname;
                writerValue.WriterUsername = writer.WriterUsername;
                writerValue.WriterAbout = writer.WriterAbout;
                writerValue.WriterMail = writer.WriterMail;
                writerValue.WriterImage = writer.WriterImage;
                writerValue.isAdmin = writer.isAdmin;
                writerValue.isActive = writer.isActive;
                
                wm.Update(writerValue);
                return RedirectToAction("WriterProfile");
            }
            return View(writer);
            
        }


        public ActionResult MyHeading()
        {
            //DatabaseContext db = new DatabaseContext();
            //p = (string)Session["WriterUsername"];
            //var writerIdInfo = db.Writers.Where(x => x.WriterUsername == p).Select(y => y.WriterId).FirstOrDefault();
            if (CurrentSession.Writer != null)
            {
                var writerIdInfo = CurrentSession.Writer.WriterId;
                var values = hm.List(x => x.WriterId == writerIdInfo);
                return View(values);
            }
            else
            {
                return RedirectToAction("WriterLogin", "Login");
            }
        }

        

        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.List()
                                                  select new SelectListItem
                                                  { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();



            ViewBag.vlc = valueCategory;

            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            ValidationResult result = hv.Validate(heading);
            List<SelectListItem> valueCategory = (from x in cm.List()
                                                  select new SelectListItem
                                                  { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();
            ViewBag.vlc = valueCategory;
            if (result.IsValid)
            {
                heading.HeadingDate = DateTime.Now;
                heading.WriterId = CurrentSession.Writer.WriterId;
                heading.isActive = true;
                hm.Insert(heading);
                return RedirectToAction("MyHeading");
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

        public ActionResult EditHeading(int? id)
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
        public ActionResult EditHeading(Heading heading)
        {
            //ValidationResult result = hv.Validate(heading);
            //if (result.IsValid)
            //{
            var headingValues = hm.Get(x => x.HeadingId == heading.HeadingId);
            headingValues.HeadingName = heading.HeadingName;
            headingValues.isActive = heading.isActive;
            headingValues.HeadingDate = DateTime.Now;
            headingValues.Writer.WriterName = heading.Writer.WriterName;
            headingValues.CategoryId = heading.CategoryId;
            hm.Update(headingValues);
            return RedirectToAction("MyHeading");
            //}
            //return View();
        }

        public ActionResult DeleteHeading(int? id)
        {

            var headingValue = hm.Get(x => x.HeadingId == id);
            headingValue.isActive = false;
            hm.Delete(headingValue);
            return RedirectToAction("MyHeading");

        }

        public ActionResult AllHeading(int p = 1)  // sayfalamaya kaçıncı veriden başlayacak
        {
            if (CurrentSession.Writer != null)
            {
                return View(hm.List().Where(x=> x.isActive == true).ToPagedList(p, 10));  //indirdiğim package ile topagedlist metodunu çağırdım ve
                                                            //1'den başla her sayfada 5 veri tut dedim
            }
            else
            {
                return RedirectToAction("WriterLogin", "Login");
            }

        }
    }
}