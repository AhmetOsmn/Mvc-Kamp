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
    public class AdminHeadingController : Controller
    {
        // GET: Heading
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var headingValues = headingManager.GetHeadingList();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            List<SelectListItem> valueWriter = (from x in writerManager.GetWriterList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName + " " +x.WriterSurname,
                                                      Value = x.WriterID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.AddHeading(heading);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetHeadingByID(id);
            headingValue.HeadingStatus = false;
            headingManager.DeleteHeading(headingValue);
            return RedirectToAction("Index");
        } 

        public ActionResult ActiveHeading(int id)
        {
            var headingValue = headingManager.GetHeadingByID(id);
            headingValue.HeadingStatus=true;
            headingManager.ActiveHeading(headingValue);
            return RedirectToAction("Index");
        }

        public ActionResult HeadingReport()
        {
            var headingValues = headingManager.GetHeadingList();
            return View(headingValues);
        }
    }
}