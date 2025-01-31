using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampusNavigationWeb
{
    public partial class n2 : System.Web.UI.MasterPage
    {

        protected override void OnInit(EventArgs e)
        {
            if (!GVWeb.IsAdmin && GVWeb.rowUser == null)
                Response.Redirect("Login.aspx");

            Common.Message_Bar = lblMessage;
            
            divAdmin.Visible = GVWeb.IsAdmin;
            divHR.Visible = !GVWeb.IsAdmin;
            lblWelcome.Text = "Welcome " + (GVWeb.IsAdmin ? "Admin" : GVWeb.rowUser["Name"]);

            lblDateTime.Text = "Date : " + DateTime.Now.ToString("dd-MMM-yy hh:mm tt");
            base.OnInit(e);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void imgLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

    }
}