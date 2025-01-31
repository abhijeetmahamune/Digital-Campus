using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Net.Mail;

namespace CampusNavigationWeb
{
    public static class GVWeb
    {
        public static Boolean __Debug = false;//true;
        public static string WebUrl = __Debug ? "http://192.168.1.20/" : "http://test.CampusNavigation.in/";
        public static string ADMIN = "Admin";
        public static string gvarUserID
        {
            get
            {
                
                if (Session["gvarUserID"] + "" == "")
                    Session["gvarUserID"] = "";
                return Session["gvarUserID"] + "";
            }
            set
            {
                Session["gvarUserID"] = value;
            }
        }
        public static bool IsNumber(string val)
        {
            foreach (var ch in val.ToCharArray())
                if (ch > '9' || ch < '0')
                    return false;

            return true;
        }
        
        public static Boolean IsAdmin
        {
            get
            {
                if (Session["IsAdmin"] + "" == "")
                    Session["IsAdmin"] = false;
                return Convert.ToBoolean(Session["IsAdmin"] + "");
            }
            set
            {
                Session["IsAdmin"] = value;
            }
        }

        public static int UserID
        {
            get
            {
                if (Session["UserID"] + "" == "")
                    Session["UserID"] = -1;
                return Convert.ToInt32(Session["UserID"] + "");
            }
            set
            {
                Session["UserID"] = value;
            }
        }

        public static DataRow rowUser
        {
            get
            {
                if (Session["rowUser"] + "" == "")
                {
                    var rows = Tables.Users.ToTable().Select("ID=" + UserID);
                    if (rows.Length > 0)
                        Session["rowUser"] = rows[0];
                    else
                    {
                        HttpContext.Current.Response.Redirect("Login.aspx");
                    }
                }
                return (DataRow)Session["rowUser"];
            }
            set
            {
                Session["rowUser"] = value;
            }
        }
        

        
        private static HttpSessionState Session
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }
       
        
    }
}