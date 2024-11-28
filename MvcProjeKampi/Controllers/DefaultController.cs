using BusinessLayer.Concrete;
using DataAccessLayer.EntitityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Headings() 
        {
            var headingList = hm.GetList();
            return View(headingList);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentlist=contentManager.GetListByHeadingID(id);
            return PartialView(contentlist);
        }
    }
}