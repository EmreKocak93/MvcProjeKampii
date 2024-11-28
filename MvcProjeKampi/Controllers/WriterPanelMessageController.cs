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
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        //Inbox ve Sendbox da Session kullanarak giren kişinin maili ile ona ait mesajları getirme işlem yaptık
        MessageManager mm=new MessageManager(new EfMessageDal());
        MessageValidatior mv=new MessageValidatior();
        
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = mm.GetListInbox(p);
            int gelenmesaj=messageList.Where(m=>m.ReceiverMail==p).Count();
            TempData["Inbox"] = gelenmesaj;

            //var adminMailCount = messageList.Where(m => m.ReceiverMail.Contains("admin")).Count();
            //ViewBag.AdminCount = adminMailCount;

            return View(messageList);
        }
        public ActionResult SendBox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = mm.GetListSendBox(p);
            int gönderilenmesaj = messageList.Where(m => m.SenderMail == p).Count();
            TempData["Sendbox"] = gönderilenmesaj;
            return View(messageList);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
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
            string sender = (string)Session["WriterMail"];
            ValidationResult results = mv.Validate(p);
            //Girilen veriler şartlara uygunsa if çalışır
            if (results.IsValid)
            {
                p.SenderMail = sender;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
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