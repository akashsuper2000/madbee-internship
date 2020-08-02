using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BikeandBarrel.Models;
using BikeandBarrel.Services;

namespace BikeandBarrel.Controllers
{
    public class QRController : Controller
    {
        UserService UserService = new UserService();

        public ActionResult VerifyMember(int Id)
        {
            User user= UserService.ValidateUserEntry(Id);
            if (user.Userid>0)
                ViewBag.Message = "VALID";
            else
                ViewBag.Message = "INVALID";
            return View();
        }

        public ActionResult Guest(int Id)
        {                     
            QRService QRService = new QRService();
            QRService.CreateGuestQR(Server.MapPath("~/Content/Image/Qrtest"+ Id + ".png"), Server.MapPath("~/Content/Image/BnBLogo.png"));
            return View();
        }
    }
}