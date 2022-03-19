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
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory

        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        [Authorize(Roles = "B")]
        public ActionResult Index()
        {
            var categoryValues = categoryManager.GetCategoryList();
            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category )
        {
            CategoryValidator validationRules = new CategoryValidator();
            ValidationResult validationResult = validationRules.Validate(category);

            if (validationResult.IsValid)
            {
                categoryManager.AddCategory(category);
                @System.Threading.Thread.Sleep(3000);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = categoryManager.GetCategoryByID(id);

            categoryManager.DeleteCategory(categoryValue);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var categoryValue = categoryManager.GetCategoryByID(id);

            return View(categoryValue);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            categoryManager.UpdateCategory(category);
            return RedirectToAction("Index");
        }
    }
}