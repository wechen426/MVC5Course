﻿using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult H_Test()
        {
            return View();
        }
        public ActionResult Login(string ReturnUrl ="")
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM login, string ReturnUrl ="")
        {
            if (ModelState.IsValid)
            {//return Content(login.username + "--" + login.password);
                FormsAuthentication.RedirectFromLoginPage(login.username, false);
                TempData["loginVM"] = login;
                if (ReturnUrl.StartsWith("/"))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
           
            return View();
        }


        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}