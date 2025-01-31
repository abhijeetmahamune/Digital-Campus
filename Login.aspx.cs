using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Web.Script.Serialization;

namespace CampusNavigationWeb
{
    public partial class Log : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Common.Message_Bar = lblStatusMsg;
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {

            var sPass = txtPassword.Text.Trim();
            if (txtLoginID.Text == "admin" && sPass == "123")
            {
                GVWeb.UserID = -1;

                GVWeb.IsAdmin = true;
                Response.Redirect("Home.aspx");
            }
            else
            {
                var rows = Tables.Users.ToTable().Select("Phone='" + txtLoginID.Text + "' AND Password='" + sPass + "'");
                if (rows.Length > 0 )
                {
                    var row = rows[0];
                    if (Convert.ToInt32(row["Active"]) == 0)
                    {
                        Common.ShowMessage("Account Deatctivated.");
                        return;
                    }
                    GVWeb.rowUser = row;
                    GVWeb.UserID = Convert.ToInt32(row["ID"]);
                    GVWeb.IsAdmin = false;
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Common.ShowMessage("Invalid user");
                }
            }
        }
    }
}