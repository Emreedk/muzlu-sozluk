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
    [AdminAuth]
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager();
        MessageValidator messageValidator = new MessageValidator();
        // GET: Message

        public ActionResult Inbox()
        {
            //var writerIdInfo = CurrentSession.Writer.WriterId;

            var messageValues = mm.List(x => x.ReceiverMail == CurrentSession.Writer.WriterMail);
            return View(messageValues);
        }
        
        public ActionResult Sendbox()
        {
            var messageValues = mm.List(x => x.SenderMail == CurrentSession.Writer.WriterMail);
            return View(messageValues);

        }

        public ActionResult GetInboxDetails(int id)
        {
            var messageValues = mm.Get(x => x.MessageId == id);
            return View(messageValues);

        }
        public ActionResult GetSendboxDetails(int id)
        {
            var messageValues = mm.Get(x => x.MessageId == id);
            return View(messageValues);

        }

        public PartialViewResult MessagePartial()
        {
            return PartialView();
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
                mm.Insert(message);
                return RedirectToAction("Sendbox");
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

        public ActionResult Draft()
        {
            return View();
        }
    }
}