using EntitiyLayer.Concrete;
using System;
using DataAccessLayer.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using BusinessLayer.Concrete;
using DataAccessLayer.EntitityFramework;
using Newtonsoft.Json.Linq;
using System.Net;




namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        WriterLoginManager wm = new WriterLoginManager(new EfWriterDal());
        
        private const string SecretKey = "6LeygE4qAAAAAI-pAmoFLPZS6j9d2zOHCM136O_7";
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c= new Context();
            var adminInfo = c.Admins.FirstOrDefault(x=>x.AdminUserName==p.AdminUserName &&
            x.AdminPassword==p.AdminPassword);
            if (adminInfo != null) 
            {
                FormsAuthentication.SetAuthCookie(adminInfo.AdminUserName, false);
                Session["AdminUserName"]=adminInfo.AdminUserName;
                return RedirectToAction("Index","AdminCategory");
            }
            else 
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı Lütfen tekrar deneyiniz","Giriş Başarısız",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return RedirectToAction("Index");
            }

            
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult WriterLogin(Writer p)
        {
            var recaptchaResponse = Request["g-recaptcha-response"];

            // Eğer reCAPTCHA yanıtı boşsa doğrulama başarısız demektir
            if (string.IsNullOrEmpty(recaptchaResponse))
            {
                ViewBag.Message = "Lütfen reCAPTCHA'yı tamamlayın.";
                return View("WriterLogin"); // Hata varsa aynı sayfaya geri dön
            }

            // reCAPTCHA'yı Google sunucusunda doğrula
            var client = new WebClient();
            var result = client.DownloadString($"https://www.google.com/recaptcha/api/siteverify?secret={SecretKey}&response={recaptchaResponse}");

            if (result.Contains("\"success\": true"))
            {
                // Doğrulama başarılı
                ViewBag.Message = "Doğrulama başarılı!";
            }
            else
            {
                // Doğrulama başarısız
                ViewBag.Message = "Doğrulama başarısız!";
            }
            var writeruserinfo = wm.GetWriter(p.WriterMail, p.WriterPassword);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı Lütfen tekrar deneyiniz", "Giriş Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return RedirectToAction("WriterLogin");
            }
        
            //return View("Index"); // Doğrulama sonucuna göre aynı sayfaya geri dön
        }
        //Context c = new Context();
        //var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail &&
        //x.WriterPassword == p.WriterPassword);
       

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings","Default");
        }
    }
}