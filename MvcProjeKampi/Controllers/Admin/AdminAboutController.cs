using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjem.Controllers
{
    public class AdminAboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());

        public ActionResult Index()
        {
            var aboutValues = aboutManager.GetAboutList();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            aboutManager.AddAbout(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {

            return PartialView();
        }

        public ActionResult ToDoList()
        {
            return View();
        }

    }
}