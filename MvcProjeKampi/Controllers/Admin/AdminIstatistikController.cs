using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjem.Controllers
{
    public class AdminIstatistikController : Controller
    {
        Context context = new Context();

        // GET: Istatistik
        public ActionResult Index()
        {
            var res1 = context.Categories.Count().ToString();
            ViewBag.result1 = res1;

            var res2 = context.Headings.Count(context => context.CategoryID == 15);
            ViewBag.result2 = res2;

            var res3 = context.Writers.Count(context => context.WriterName.ToLower().Contains("a"));
            ViewBag.result3 = res3;

            var res4 = context.Categories
                .Where(x => x.CategoryID == context.Headings
                    .GroupBy(c => c.CategoryID)
                        .OrderByDescending(c => c.Count())
                            .Select(c => c.Key)
                                .FirstOrDefault())
                                    .Select(x => x.CategoryName)
                                        .FirstOrDefault();
            ViewBag.result4 = res4;

            var trueStatus = context.Categories.Count(x => x.CategoryStatus == true);
            var falseStatus = context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.result5 = trueStatus - falseStatus;

            return View();

        }
    }
}