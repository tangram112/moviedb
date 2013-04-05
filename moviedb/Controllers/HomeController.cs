using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace moviedb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "porządek w domowej wideotece, z nami to łatwe.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Dane o aplikacji.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Dane kontaktowe.";

            return View();
        }
    }
}
