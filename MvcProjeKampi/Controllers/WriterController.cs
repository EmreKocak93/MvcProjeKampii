using BusinessLayer.Concrete;
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
    public class WriterController : Controller
    {
        // GET: Writer
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidatior writervalidatior = new WriterValidatior();
        public ActionResult Index()
        {
            var WriterValues = wm.GetList();
            return View(WriterValues);
        }
        [HttpGet]
        public ActionResult AddWriter() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
           
            ValidationResult results = writervalidatior.Validate(p);
            if (results.IsValid) 
            {
                wm.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else 
            {
                foreach (var x in results.Errors) 
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }

            return View();
        }
        [HttpGet]
        public ActionResult EditWriter(int id) 
        { 
            var writerValue=wm.GetByID(id);
            return View(writerValue); 
        }
        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
           
            ValidationResult results = writervalidatior.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var x in results.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
                
            }
            return View();
            
        }
    
    }
}