﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FileResult1()
        {
            //把檔案丟出去
            return File(Server.MapPath("~/Content/mmm.jpg"), "image/jepg");
        }
        public ActionResult FR1()
        {
            //下載含檔名
            return View(File(Server.MapPath("~/Content/mmm.jpg"), "image/jepg", "1_1_50"));
            
        }
        public ActionResult showimg()
        {
            return View();
        }
    }
}