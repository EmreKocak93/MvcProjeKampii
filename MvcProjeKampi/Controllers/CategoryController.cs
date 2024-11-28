using BusinessLayer;
using BusinessLayer.ValiationRules;
using DataAccessLayer.EntitityFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using FluentValidation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;

namespace MvcProjeKampi.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        CategoryManager cm=new CategoryManager(new EfCategoryDal());
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList() 
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
        public ActionResult AddCategory(Category cat)
        {
           // cm.CategoryAddBL(cat);
            CategoryValidatior categoryValidatior= new CategoryValidatior();
            ValidationResult results=categoryValidatior.Validate(cat);
            if (results.IsValid) 
            {
                cm.CategoryAdd(cat);
                return RedirectToAction("GetCategoryList");
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