using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Models.ActionFilter
{
    public class 計算程式運作時間Attribue : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.st = DateTime.Now;
        }
 
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.et = DateTime.Now;
            filterContext.Controller.ViewBag.RuntimCount = filterContext.Controller.ViewBag.et -
                 filterContext.Controller.ViewBag.st;
        }
    }
}