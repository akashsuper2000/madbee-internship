using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeandBarrel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Front()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Table()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string pwd) {

            if (name == "admin" && pwd == "password")
            {
                ViewBag.Message = null;
                return RedirectToAction("Front","Home");
            }

            else {
                ViewBag.Message = "Invalid Credentials";
                return View();
            }

            
        }
    }

}