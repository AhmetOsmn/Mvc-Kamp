using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
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
    public class AdminMessageController : Controller
    {
        // GET: Message
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator validationRules = new MessageValidator();

        public ActionResult Inbox()
        {
            var messageList =  messageManager.GetMessageListInbox("admin@gmail.com");
            return View(messageList);
        }

        public ActionResult SendBox()
        {
            var messageList = messageManager.GetMessageListSendbox("admin@gmail.com");
            return View(messageList);
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
    }
}