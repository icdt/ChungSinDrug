﻿using icdtFramework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChungSinDrug.Controllers.admin
{
    public class DashboardController : MvcBaseController
    {
        public ActionResult Index()
        {
            return View("~/Views/Admin/Dashboard/Index.cshtml");
        }
    }
}