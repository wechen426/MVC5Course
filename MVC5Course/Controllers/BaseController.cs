using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
       //建立共用的資源方法，避免重複輸入
       public ProductRepository repo = RepositoryHelper.GetProductRepository();
    }
}