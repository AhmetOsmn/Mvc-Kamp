using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        Context context = new Context();
         
        // GET: Istatistik

        public ActionResult Index()
        {
            var res1 = context.Categories.Count().ToString();
            ViewBag.result1 = res1;

            ViewBag.result2 = context.Headings.Count(context => context.CategoryId == 10);

            var res3 = context.Writers.Count(w => w.WriterName.ToLower().Contains("a"));
            ViewBag.result3 = res3;

            var res4 = context.Categories
                .Where(x => x.CategoryId == context.Headings
                    .GroupBy(c => c.CategoryId)
                        .OrderByDescending(c => c.Count())
                            .Select(c => c.Key)
                                .FirstOrDefault())
                                    .Select(x => x.CategoryName)
                                        .FirstOrDefault();

            ViewBag.result4 = res4;

            //var result5 = context.Categories.Count(x => x.CategoryStatus == true) - context.Categories.Count(x => x.CategoryStatus == false);
            //ViewBag.result5 = result5;

            var trueStatus = context.Categories.Count(x => x.CategoryStatus == true);
            var falseStatus = context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.result5 = trueStatus - falseStatus;


            return View();
        }


        
    }
}