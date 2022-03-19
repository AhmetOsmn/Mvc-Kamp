using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjem.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default

        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult Headings()
        {
            var headingList = headingManager.GetHeadingList();
            return View(headingList);
        }

        public PartialViewResult Index(int id=2)
        {
            var contentList = contentManager.GetContentListByHeadingID(id);
            return PartialView(contentList);
        }

    }
}