using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BitirmeProjem.Controllers
{
    [AllowAnonymous]
    public class WriterPanelLoginController : Controller
    {
        // GET: WriterPanelLogin

        WriterLoginManager writerLoginManager = new WriterLoginManager(new EfWriterDal());

        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(Writer writer)
        {
            var writerUserInfo = writerLoginManager.GetWriter(writer.WriterMail,writer.WriterPassword);
            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.WriterMail, false);
                Session["WriterMail"] = writerUserInfo.WriterMail;
                return RedirectToAction("AllHeading", "WriterPanelHeading");
                
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings","Default");
        }
    }
}