using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampusNavigationWeb
{
    public partial class Track : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //find the latest location
            var id = Request["Id"] + "";
            if(id!="")
            {
                var dt = ModData.ExecuteSQL($"SELECT TOP 1 * FROM TRACK WHERE VisitorID='{id}'");
                if (dt.Rows.Count > 0)
                {
                    hfID.Value = dt.Rows[0]["DeviceID"] + "";
                    var rows = Tables.Devices.ToTable().Select("ID=" + hfID.Value);
                    if (rows.Length > 0)
                    {
                        lblDetails.Text = rows[0]["Name"] + "";
                        lblLocation.Text = rows[0]["Description"] + "";
                    }
                    imgMap.ImageUrl = "/loc/" + hfID.Value + ".jpg";
                }
            }
            if(ddDestination.Items.Count==0)
            {
                foreach (DataRow row in Tables.Devices.ToTable().Rows)
                    ddDestination.Items.Add(new ListItem(row["Description"] + "", row["ID"] + ""));
            }

        }

        protected void ddDestination_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}