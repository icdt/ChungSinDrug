using icdtFramework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChungSinDrug.Controllers
{
    public class HomeController : MvcBaseController
    {
        public ActionResult Index()
        {
            return View("~/Views/Website/Index.cshtml");
        }

        public ActionResult Register()
        {
            return View("~/Views/Website/Account/Register.cshtml");
        }
    }
}