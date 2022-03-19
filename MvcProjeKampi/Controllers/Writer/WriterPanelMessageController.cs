using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjem.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();


        public ActionResult Inbox()
        {
            string mail = (string)Session["WriterMail"];
            var messageList = messageManager.GetMessageListInbox(mail);
            return View(messageList);
        }

        public ActionResult SendBox()
        {
            string mail = (string)Session["WriterMail"];
            var messageList = messageManager.GetMessageListSendbox(mail);
            return View(messageList);
        }

        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = messageManager.GetMessageByID(id);
            return View(values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = messageManager.GetMessageByID(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult results = validationRules.Validate(message);

            if (results.IsValid)
            {
                message.SenderMail = (string)Session["WriterMail"];
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.AddMessage(message);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}