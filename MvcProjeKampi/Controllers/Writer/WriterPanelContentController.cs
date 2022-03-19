using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjem.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager contentManager = new ContentManager(new EfContentDal());
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        Context context = new Context();

        public ActionResult MyContent(string p)
        {
             
            p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(x => x.WriterID).FirstOrDefault();
            var contentValues = contentManager.GetContentListByWriter(writerIdInfo);

            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            var headingInfo = headingManager.GetHeadingByID(id);
            ViewBag.Id = id;
            ViewBag.Name = headingInfo.HeadingName;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == mail).Select(x => x.WriterID).FirstOrDefault();

            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterID = writerIdInfo;
            content.ContentStatus = true;
            contentManager.AddContent(content);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }

    }
}