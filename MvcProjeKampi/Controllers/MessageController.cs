using BusinessLayer.Concrete;
using BusinessLayer.ValiationRules;
using DataAccessLayer.Concrete;
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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidatior mv = new MessageValidatior();
        WriterManager wm = new WriterManager(new EfWriterDal());
        Context c= new Context();
        [Authorize]
        public ActionResult Inbox(string p)
        {

            var messageList = mm.GetListInbox(p);
            //var adminMailCount = messageList.Where(m => m.ReceiverMail.Contains("admin")).Count();
            //ViewBag.AdminCount = adminMailCount;
         
            return View(messageList);
        }
        public ActionResult SendBox(string p)
        {
            var messageList = mm.GetListSendBox(p);
            return View(messageList);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {

            ValidationResult results = mv.Validate(p);
            //Girilen veriler şartlara uygunsa if çalışır
            if (results.IsValid)
            {
                p.MessageDate=DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("SendBox");
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