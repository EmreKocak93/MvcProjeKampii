﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntitityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        ImageFileManager ifm=new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var files=ifm.GetList();
            return View(files);
        }
    }
}