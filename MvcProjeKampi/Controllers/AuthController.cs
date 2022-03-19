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
    public class AuthController : Controller
    {
        // GET: Auth
        AdminManager adminManager = new AdminManager(new EfAdminDal());

        public ActionResult Index()
        {
            var values = adminManager.GetAdminList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            adminManager.AddAdmin(admin);
            @System.Threading.Thread.Sleep(3000);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var adminValue = adminManager.GetadminByID(id);

            return View(adminValue);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            adminManager.UpdateAdmin(admin);
            return RedirectToAction("Index");
        }

    }
}