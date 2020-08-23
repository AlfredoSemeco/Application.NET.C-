using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class HomeController : Controller
    {
        // equivalente a una clase servlet en Java

        // Home
        public ActionResult Index()
        {
            return View(); // call view con persistencia de variables
        }

        //Home/About
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();// call view con persistencia de variables
        }

        //Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();// call view con persistencia de variables
        }
    }
}