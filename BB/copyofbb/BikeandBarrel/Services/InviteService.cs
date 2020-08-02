using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BikeandBarrel.Models;
using Newtonsoft.Json;

namespace BikeandBarrel.Services
{
    public class InviteService
    {
        DbService DbService = new DbService();

        public string InviteGuest(int Userid, string Mobile, string Date, string Time, string Message)
        {
            //validate params, validate user
            //if valid, send invite sms and store it in db
            //if not valid, send respective errors
            UserService UserService = new UserService();

            MessageResponse MessageResponse = new MessageResponse();
            string sql="";
            if(Userid!=0 && Mobile!="" && Date!="" && Time!="" && Message!="") //VALIDATING PARAM
            {
                if (UserService.ValidateUserid(Userid)) //VALIDATE USER
                {
                    string[] Mobiles = Mobile.Split(',');
                    foreach (string mobileno in Mobiles)
                    {
                        sql = "INSERT INTO guest(Userid,Guestmobile,Allowon,Status) VALUES (" + Userid + ",'" + mobileno + "','" + Date + " " + Time + "','" + "INVITED" + ");";
                        try
                        {
                            DbService.Executequery(sql);
                            int InviteId = DbService.GetLastInsertId();
                            InviteGuestbySMS(Userid, mobileno, Date, Time, Message, InviteId);
                        }
                        catch(Exception e)
                        {
                            MessageResponse.Status = "FAILURE";
                            MessageResponse.Message = "SERVER ERROR,TRY AGAIN";
                            return JsonConvert.SerializeObject(MessageResponse);

                        }
                    }
                    MessageResponse.Status = "SUCCESS";
                    MessageResponse.Message = "INVITED SUCCESSFULLY";
                    return JsonConvert.SerializeObject(MessageResponse);
                }
                else
                {
                    MessageResponse.Status = "FAILURE";
                    MessageResponse.Message = "INVALID USERID";
                }
            }
            else
            {
                MessageResponse.Status = "FAILURE";
                MessageResponse.Message = "INVALID PARAMETERS";
            }
            return JsonConvert.SerializeObject(MessageResponse);
        }

        private void InviteGuestbySMS(int Userid, string Mobile, string Date, string Time, string Message,int InviteId)
        {
            SmsService SmsService = new SmsService();
            string STAT_URL = "";
            string msg = Message+ STAT_URL+ InviteId;
            SmsService.SendsmsMsg91(Mobile, msg, Constants.MSG91_SENDERID);
        }

        public string InviteGuestHistory(int Userid)
        {
            //validates user
            //if valid, send invitedguest list from db and return as json string
            //if invalid, send repective error json
            List<Guest> Guests = new List<Guest>();

            string sql = "SELECT * FROM guest WHERE userid=" + Userid + " ORDER BY Inviteid DESC LIMIT "+Constants.INVITEGUESTHISTORY_COUNT; // selecting last 10 entries

            DataTable DT = DbService.SelectData(sql); //get data from db

            foreach (DataRow row in DT.Rows)
            {
                Guest Guest = new Guest
                {
                    Inviteid = Convert.ToInt32(row["Inviteid"]),
                    Guestmobile = row["Guestmobile"].ToString(),
                    Allowon = Convert.ToDateTime(row["Allowon"]),
                    Userid = Userid,
                    Status= row["Status"].ToString()
                };
                Guests.Add(Guest);
            }
            return JsonConvert.SerializeObject(Guests);
        }
    }
}