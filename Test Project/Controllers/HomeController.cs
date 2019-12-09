using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test_Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Our Core Values";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Our Contact Info";

            return View();
        }
    }
}