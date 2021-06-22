using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact

        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        
        public ActionResult Index()
        {
            var contactValues = contactManager.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = contactManager.GetById(id);    
            return View(contactValues);
        }

        public PartialViewResult ContactPartial()
        {
            var messageListInbox = messageManager.GetListInbox();

            var length1 = messageListInbox.Count().ToString();
            ViewBag.result1 = length1;

            var contactValues = contactManager.GetList();
            var length2 = contactValues.Count().ToString();
            ViewBag.result2 = length2;

            return PartialView();
        }
    }
}