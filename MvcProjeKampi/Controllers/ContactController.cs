using BusinessLayer.Concrete;
using BusinessLayer.ValiationRules;
using DataAccessLayer.EntitityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm=new ContactManager(new EfContactDal());
        ContactValidatior cv=new ContactValidatior();
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
            
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetByID(id);
            return View(contactValues);
        }
        public PartialViewResult ContactPartial()
        {

            return PartialView();
        }
    }
}