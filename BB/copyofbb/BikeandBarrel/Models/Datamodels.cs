using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeandBarrel.Models
{
    public class User
    {
        public int Userid { set; get; }
        public string Membershipid { set; get; }
        public string Username { set; get; }
        public string Mobile { set; get; }
        public string Email { set; get; }
        public DateTime Activatedon { set; get; }
        public DateTime Expiryon { set; get; }
        public string Regid { set; get; }
        public int Otp { set; get; }
        public string DP { set; get; }
    }

    public class Bills
    {
        public int Userid { set; get; }
        public int Billno { set; get; }
        public DateTime Billdate { set; get; }
        public float Amount { set; get; }
        public int Voucherused { set; get; }
    }

    public class Rewardpoints
    {
        public int Userid { set; get; }
        public int Totalpts { set; get; }
        public int Redeemablepts { set; get; }
        public int Vouchers { set; get; }
    }

    public class RewardpointsHistory
    {
        public int Id { set; get; }
        public int Userid { set; get; }
        public int Pts { set; get; }
        public DateTime Transdate { set; get; }
        public string Type { set; get; } // CR/DR
        public string Remarks { set; get; }
    }

    public class Menu
    {
        public int Menuid { set; get; }
        public string Menuiteam { set; get; }
    }

    public class Guest
    {
        public int Inviteid { set; get; }
        public int Userid { set; get; }
        //public string Guestname { set; get; }
        public string Guestmobile { set; get; }
        public DateTime Allowon { set; get; }
        public string Status { set; get; } // INVITED/ATTENDED/EXPIRED
    }

    public class RequestforSong
    {
        public int ReqId { set; get; }
        public int Userid { set; get; }
        public DateTime Reqdate { set; get; }
        public string Songdetails { set; get; }
        public string Status { set; get; } // DONE/PENDING/REJECTED
    }

    public class TableReservation
    {
        public int ReqId { set; get; }
        public int Userid { set; get; }
        public DateTime Reqdate { set; get; }
        public string Details { set; get; }
        public string Status { set; get; } // DONE/PENDING/REJECTED
    }

    public class CakeRequest
    {
        public int ReqId { set; get; }
        public int Userid { set; get; }
        public DateTime Reqdate { set; get; }
        public string Cakeflavor { set; get; }
        public string Weight { set; get; }
        public string Wishtext { set; get; }
        public string Status { set; get; } // DONE/PENDING/REJECTED
    }

    public class ReferaFriend
    {
        public int RefId { set; get; }
        public int Userid { set; get; }
        public string Inviteename { set; get; }
        public string Mobile { set; get; }
        public string Status { set; get; } // OPEN/FOLLOWUP/DONE/REJECTED
    }

    public class Notifications
    {
        public int MessageId { set; get; }
        public string Messagetext { set; get; }
        public string Messagemedia { set; get; }
        public DateTime Messagedate { set; get; }
        public string Messagetype { set; get; }
        public string Status { set; get; } // SUCCESS/FAILURE
    }

    public class Webusers
    {
        public int Userid { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public DateTime Expiryon { set; get; }
    }

    public class posts
    {
        public int Postid { set; get; }
        public string Posttext { set; get; }
        public string Postmedia { set; get; }
        public int Postedby { set; get; }
        public DateTime Postedon { set; get; }
        public string Posttype { set; get; } // Interactive gallery /wall post
    }

    public class Postcomments
    {
        public int Commid { set; get; }
        public int Postid { set; get; }
        public string Commenttext { set; get; }
        public int Commentby { set; get; }
        public DateTime Commenton { set; get; }
    }
    
    public class Postlikes
    {
        public int Postid { set; get; }
        public int Userid { set; get; }
        public DateTime Likedon { set; get; }
    }

    public class Temppass
    {
        public int Passid { set; get; }
        public string Roomno { set; get; }
        public string Guestname { set; get; }
        public string Mobile { set; get; }
        public DateTime Expiryon { set; get; }
        public string Status { set; get; } // INVITED/COMPLETED/EXPIRED
    }

    public class MessageResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}