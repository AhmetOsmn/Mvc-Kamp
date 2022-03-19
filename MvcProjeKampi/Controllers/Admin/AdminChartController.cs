using BitirmeProjem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjem.Controllers
{
    public class AdminChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(),JsonRequestBehavior.AllowGet); 
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            list.Add(new CategoryClass()
            {
                CategoryName = "Seyehat",
                CategoryCount = 18
            });
            list.Add(new CategoryClass()
            {
                CategoryName = "Kitap",
                CategoryCount = 38
            });
            list.Add(new CategoryClass()
            {
                CategoryName = "Spor",
                CategoryCount = 22
            });

            return list;
        }
    }
}