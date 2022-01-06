using ContentProject.BusinessLayer.Concrete;
using ContentProject.BusinessLayer.ValidationRules;
using ContentProject.Entity.Concrete;
using ContentProject.WebUI.Filters;
using ContentProject.WebUI.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContentProject.WebUI.Controllers
{
    [WriterAuth]
    public class WriterPanelMessageController : Controller
    {
        MessageManager mm = new MessageManager();
        MessageValidator messageValidator = new MessageValidator();
        // GET: WriterPanelMessage
        public ActionResult WriterInbox()
        {
            if (CurrentSession.Writer != null)
            {
                var messageValues = mm.List(x => x.ReceiverMail == CurrentSession.Writer.WriterMail);
                return View(messageValues);
            }
            else
            {
                return RedirectToAction("WriterLogin", "Login");
            }

        }
        public ActionResult WriterSendbox()
        {
            if (CurrentSession.Writer != null)
            {
                var messageValues = mm.List(x => x.SenderMail == CurrentSession.Writer.WriterMail);
                return View(messageValues);
            }
            else
            {
                return RedirectToAction("WriterLogin", "Login");
            }


        }
        public PartialViewResult MessagePartial()
        {
            return PartialView();
        }
        public ActionResult GetInboxDetails(int id)
        {
            if (CurrentSession.Writer != null)
            {
                var messageValues = mm.Get(x => x.MessageId == id);
                return View(messageValues);
            }
            else
            {
                return RedirectToAction("WriterLogin", "Login");
            }


        }
        public ActionResult GetSendboxDetails(int id)
        {
            if (CurrentSession.Writer != null)
            {
                var messageValues = mm.Get(x => x.MessageId == id);
                return View(messageValues);
            }
            else
            {
                return RedirectToAction("WriterLogin", "Login");
            }


        }

        public ActionResult AddNew()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddNew(Message message)
        {
            ValidationResult result = messageValidator.Validate(message);
            if (result.IsValid)
            {
                message.MessageDate = DateTime.Now;
                message.SenderMail = CurrentSession.Writer.WriterMail;
                mm.Insert(message);
                return RedirectToAction("WriterSendbox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(message);
        }
    }
}