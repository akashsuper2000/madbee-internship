using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace BikeandBarrel.Services
{
    public class SmsService
    {
        public void SendsmsMsg91(string mobile, string message, string smssender)
        {
            string authenticationKey = "170406AuV5zJ6EFhH59967987";
            string route = "4";
            string countryCode = "0";// "Country code";
            //string domain = "https://control.msg91.com/api/sendhttp.php?";
            string domain = "http://sms.madbee.in/api/sendhttp.php?";
            try
            {
                var URL = domain
                    + "authkey=" + authenticationKey
                    + "&mobiles=" + mobile
                    + "&message=" + message
                    + "&sender=" + smssender
                    + "&route=" + route
                    + "&country=" + countryCode;
                WebRequest wrequest = WebRequest.Create(URL);
                WebResponse wresponse = wrequest.GetResponse();
            }
            catch
            {

            }
        }
    }
}