using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using System.Data;
using RestSharp;
using System.Net.Mail;

public static class Common
{
    public static Label Message_Bar;
    public static string AppPath = HttpContext.Current.Server.MapPath("");

    //Show message on screen
    public static void ShowMessage(string pMessageText, ToastType enType = ToastType.Information)
    {
        if (Message_Bar != null)
        {
            Message_Bar.Text = pMessageText;
            Message_Bar.CssClass = enType.ToString();
        }
    }
    public static string Clean(this TextBox pTxt)
    {
        return pTxt.Text.Replace("'", "''");
    }
}
