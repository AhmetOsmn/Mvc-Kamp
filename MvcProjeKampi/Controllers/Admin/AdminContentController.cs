using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjem.Controllers
{
    public class AdminContentController : Controller
    {
        // GET: Content

        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string filter)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                var values2 = contentManager.GetContentList(filter);
                return View(values2);
            }
            var values = contentManager.GetContentList();
            return View(values);

        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.GetContentListByHeadingID(id);
            return View(contentValues);
        }
    }
}