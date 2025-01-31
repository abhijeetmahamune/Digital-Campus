using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace CampusNavigationWeb
{
    public partial class Home : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                string Today = DateTime.Now.Date.ToString("d-MMM-yyyy");
                string Month = DateTime.Now.Date.ToString("d-MMM-");

                int count = Tables.Devices.ToTable().Rows.Count;
                if (count > 0)
                {
                    btnOrders.Text = "My Devices : " + count;
                }
                else
                {
                    btnOrders.Text = "No Devices";
                    btnOrders.Enabled = false;
                    btnOrders.BackColor = System.Drawing.Color.Gray;
                    btnOrders.Style["cursor"] = "default";
                }

                

            }
        }
        protected void btnOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("Devices.aspx");
        }

    }
}