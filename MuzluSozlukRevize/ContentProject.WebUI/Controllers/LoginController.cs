using ContentProject.BusinessLayer.Concrete;
using ContentProject.BusinessLayer.ValidationRules;
using ContentProject.DataAccessLayer.Context;
using ContentProject.Entity.Concrete;
using ContentProject.WebUI.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ContentProject.WebUI.Controllers
{
    //[AllowAnonymous]
    public class LoginController : Controller
    {

        WriterManager wm = new WriterManager();
        LoginValidator lv = new LoginValidator();
        RegisterValidator rv = new RegisterValidator();
        // GET: Login

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Writer writer)
        {


            ValidationResult result = rv.Validate(writer);
            ModelState.Remove("isAdmin");
            ModelState.Remove("isActive");
            bool user = wm.UsernameMatchs(writer.WriterUsername, writer.WriterMail);

            if (result.IsValid && user==false)
            {
                writer.WriterImage = "avatar.png";

                wm.Insert(writer);
                return RedirectToAction("WriterLogin", "Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                if (user)
                {
                    ModelState.AddModelError("AlreadyUsername", "Kullanıcı adı kayıtlı. Başka bir kullanıcı adı giriniz");
                    if (writer.WriterMail != null)
                    {
                        ModelState.AddModelError("AlreadyMail", "Mail adresi kayıtlı. Geçerli bir mail adresi giriniz.");
                    }
                    
                }
                
            }


            return View(writer);
        }

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Index(Admin admin)
        //{
        //    ValidationResult result = alv.Validate(admin);
        //    if (result.IsValid)
        //    {
        //        DatabaseContext db = new DatabaseContext();
        //        var adminuserinfo = db.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
        //        //FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
        //        //Session["AdminUserName"] = adminuserinfo.AdminUserName;
        //        CurrentSession.Set<Admin>("AdminUserName", adminuserinfo);
        //        return RedirectToAction("Index", "AdminCategory");
        //    }

        //    else
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //    return View();

        //}

        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            ValidationResult result = lv.Validate(writer);
            if (result.IsValid)
            {
                DatabaseContext db = new DatabaseContext();
                var writeruserinfo = db.Writers.FirstOrDefault(x => x.WriterUsername == writer.WriterUsername && x.WriterPassword == writer.WriterPassword);

                //FormsAuthentication.SetAuthCookie(writeruserinfo.WriterUsername, false);
                //Session["WriterUsername"] = writeruserinfo.WriterUsername;
                CurrentSession.Set<Writer>("Username", writeruserinfo);
                return RedirectToAction("Headings", "Home");
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

        public ActionResult LogOut()
        {
            CurrentSession.Clear("Username");
            return RedirectToAction("HomePage", "Home");
        }
    }
}


//ValidationResult result = cv.Validate(p);
//if (result.IsValid)
//{
//    cm.Insert(p);
//    return RedirectToAction("Index");
//}
//else
//{
//    foreach (var item in result.Errors)
//    {
//        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
//    }
//}