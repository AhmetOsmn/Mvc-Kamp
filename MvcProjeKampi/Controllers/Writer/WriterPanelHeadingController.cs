using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules.FluentValidation;

namespace BitirmeProjem.Controllers
{
    public class WriterPanelHeadingController : Controller
    {
        // GET: WriterPanel

        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        Context context = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string p = (string)Session["WriterMail"];
            id = context.Writers.Where(x => x.WriterMail == p).Select(x => x.WriterID).FirstOrDefault();
            var writerInfo = writerManager.GetWriterByID(id);
            return View(writerInfo);
        }


        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator validationRules = new WriterValidator();
            ValidationResult results = validationRules.Validate(writer);

            if (results.IsValid)
            {
                writerManager.UpdateWriter(writer);
                return RedirectToAction("AllHeading","WriterPanelHeading");
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

        public ActionResult MyHeading(string p) {

          
            p = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == p).Select(x => x.WriterID).FirstOrDefault();
            var values = headingManager.GetHeadingListByWriter(writerIdInfo);
            return View(values); 
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string mail = (string)Session["WriterMail"];
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == mail).Select(x => x.WriterID).FirstOrDefault();

            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = writerIdInfo;
            heading.HeadingStatus = true;
            headingManager.AddHeading(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            var headingValue = headingManager.GetHeadingByID(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult UpdateHeading(Heading heading)
        {
            headingManager.UpdateHeading(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetHeadingByID(id);
            headingValue.HeadingStatus = false;
            headingManager.DeleteHeading(headingValue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int startPage = 1)
        {
            var headings = headingManager.GetHeadingList().ToPagedList(startPage,10);
            return View(headings);
        }
    }
}