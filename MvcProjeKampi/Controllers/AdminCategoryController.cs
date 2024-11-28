using BusinessLayer;
using BusinessLayer.ValiationRules;
using DataAccessLayer.EntitityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        [Authorize(Roles="B")]
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();

            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult AddCategory() 
        { 
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidatior categoryValidatior = new CategoryValidatior();
            ValidationResult result = categoryValidatior.Validate(p);
           
            if (result.IsValid) 
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var  category=cm.GetByID(id);
            cm.CategoryDelete(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCategory(int id) 
        { 
            var categoryvalue=cm.GetByID(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
}