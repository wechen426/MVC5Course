using MVC5Course.Models;
using MVC5Course.Models.ActionFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    [Authorize]
    [計算程式運作時間Attribue] //帶入actionfilter
    public abstract class BaseController : Controller
    {
       //建立共用的資源方法，避免重複輸入
       public ProductRepository repo = RepositoryHelper.GetProductRepository();
    }
}