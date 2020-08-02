using BikeandBarrel.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BikeandBarrel.Services
{
    public class UserService
    {
        DbService DbService = new DbService();
        SmsService SmsService = new SmsService();

        public string ValidateMobileLogin(string Membershipid, string Mobile)
        {
            User user = new User
            {
                Membershipid = Membershipid,
                Mobile = Mobile
            };
            string sql = "SELECT * FROM user WHERE Membershipid='" + user.Membershipid + "' AND Mobile='"+ user.Mobile + "'";

            DataTable DT = DbService.SelectData(sql); //get data from db

            if(DT.Rows.Count==1)
            {
                //valid - send otp and return valid user as json string
                user.Userid = Convert.ToInt32(DT.Rows[0]["Userid"]);
                user.Username = DT.Rows[0]["Username"].ToString();
                user.Email = DT.Rows[0]["Email"].ToString();
                user.Activatedon = Convert.ToDateTime(DT.Rows[0]["Activatedon"]);
                user.Expiryon = Convert.ToDateTime(DT.Rows[0]["Expiryon"]);
                user.Otp= generateOTP();

                SendLoginOTP(user);
                return JsonConvert.SerializeObject(user);
            }
            else
            {
                //invalid - send invalid string
                user.Userid = 0;
                return JsonConvert.SerializeObject(user);
            }
        }

        public User ValidateUserEntry(int Userid)
        {
            //validates userid and date time and send valid user on conditions met
            //return user with null id on conditions failure
            return GetUserById(Userid);
        }

        private void SendLoginOTP(User user)
        {
            string msg = "Your login otp is" + user.Otp;
            SmsService.SendsmsMsg91(user.Mobile, msg, Constants.MSG91_SENDERID);
            string sql = "update user set Otp="+ user.Otp +" where Userid=" + user.Userid;
            bool status = DbService.Executequery(sql);
        }

        private int generateOTP()
        {
            Random R = new Random();
            return R.Next(100000, 999999);
        }

        public string ValidateMobileLoginOTP(int Userid, int Otp,string Reg)
        {
            string sql = "SELECT * FROM user WHERE Userid="+ Userid;
            DataTable DT = DbService.SelectData(sql); //get data from db
            User user = new User();
            user.Userid = Userid;
            user.Regid = Reg;

            MessageResponse StatusResponse = new MessageResponse();

            if (DT.Rows.Count == 1)
            {
                if (Convert.ToInt32(DT.Rows[0]["Otp"])==Otp)
                {
                    StatusResponse.Status = "SUCCESS";
                    StatusResponse.Message = "VALID";
                    UpdateReg(user);
                }
                else
                {
                    StatusResponse.Status = "FAILURE";
                    StatusResponse.Message = "INVALID OTP";
                }
                return JsonConvert.SerializeObject(StatusResponse);
            }
            else
            {
                //invalid - send invalid string
                StatusResponse.Status = "FAILURE";
                StatusResponse.Message = "INVALID USERID";
                return JsonConvert.SerializeObject(StatusResponse);
            }
        }

        private void UpdateReg(User user)
        {
            string sql = "update user set Regid='" + user.Regid + "', Otp=0 where Userid=" + user.Userid;
            bool status = DbService.Executequery(sql);
        }

        public bool ValidateUserid(int Userid)
        {
            string sql = "SELECT * FROM user WHERE Userid=" + Userid;

            DataTable DT = DbService.SelectData(sql); //get data from db

            if (DT.Rows.Count == 1)
                return true;
            else
                return false;

        }

        public User GetUserById(int Userid)
        {
            User user = new User();
            string sql = "SELECT * FROM user WHERE Userid=" + Userid;

            DataTable DT = DbService.SelectData(sql); //get data from db

            if (DT.Rows.Count == 1)
            {
                user.Userid = Convert.ToInt32(DT.Rows[0]["Userid"]);
                user.Membershipid = DT.Rows[0]["Membershipid"].ToString();
                user.Username = DT.Rows[0]["Username"].ToString();
                user.Mobile = DT.Rows[0]["Mobile"].ToString();
                user.Email = DT.Rows[0]["Email"].ToString();
                user.Activatedon = Convert.ToDateTime(DT.Rows[0]["Activatedon"]);
                user.Expiryon = Convert.ToDateTime(DT.Rows[0]["Expiryon"]);
                user.Otp = Convert.ToInt32(DT.Rows[0]["Otp"]);
                user.DP = DT.Rows[0]["DP"].ToString();
                return user;
            }
            user.Userid = 0;
            return user;
        }

        public User GetUsernameById(int Userid)
        {
            User user = new User();
            string sql = "SELECT Username FROM user WHERE Userid=" + Userid;

            DataTable DT = DbService.SelectData(sql); //get data from db

            if (DT.Rows.Count == 1)
            {
                user.Userid = Userid;
                user.Username = DT.Rows[0]["Username"].ToString();
                return user;
            }
            user.Userid = 0;
            return user;
        }
        }
}