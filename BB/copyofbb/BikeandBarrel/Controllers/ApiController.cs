using BikeandBarrel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikeandBarrel.Controllers
{
    public class ApiController : Controller
    {
        UserService UserService = new UserService();

        [HttpPost]
        public string ValidateMobileLogin(string Membershipid, string Mobile)
        {
            return UserService.ValidateMobileLogin(Membershipid, Mobile);
        }

        [HttpPost]
        public string ValidateMobileLoginOTP(int Userid, int Otp, string Reg)
        {
            return UserService.ValidateMobileLoginOTP(Userid, Otp, Reg);
        }

        [HttpPost]
        public string InviteGuest(int Userid, string Mobile, string Date,string Time, string Message)
        {
            InviteService InviteService = new InviteService();
            return InviteService.InviteGuest(Userid, Mobile, Date, Time, Message);
        }

        [HttpPost]
        public string InviteGuestHistory(int Userid)
        {
            InviteService InviteService = new InviteService();
            return InviteService.InviteGuestHistory(Userid);
        }
    }
}