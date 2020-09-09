using CURDWithEntityFrameworkCodeFirstWebAPI_Demo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Mvc;

namespace CURDWithEntityFrameworkCodeFirstWebAPI_Demo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

