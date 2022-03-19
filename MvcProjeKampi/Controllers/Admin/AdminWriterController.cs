using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitirmeProjem.Controllers
{
    public class AdminWriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator validationRules = new WriterValidator();

        public ActionResult Index()
        {
            var writerValues = writerManager.GetWriterList();
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            ValidationResult results = validationRules.Validate(writer);

            if (results.IsValid)
            {
                writerManager.AddWriter(writer);
                return RedirectToAction("Index");
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

        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var writerValue = writerManager.GetWriterByID(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult UpdateWriter(Writer writer)
        {
            ValidationResult results = validationRules.Validate(writer);

            if (results.IsValid)
            {
                writerManager.UpdateWriter(writer);
                return RedirectToAction("Index");
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
    }
}