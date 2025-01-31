using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace CampusNavigationWeb
{
    public partial class AddDevice : System.Web.UI.Page
    {
        string DeviceID = "";
        DataRow rowDevice = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GVWeb.IsAdmin)
                Response.Redirect("Login.aspx");

            if (!Page.IsPostBack)
            {
                DeviceID = Request["ID"] + "";
                hdID.Value = DeviceID;

                if (DeviceID == "")
                {
                    Common.ShowMessage("Invalid Device", ToastType.Error);
                    Response.Redirect("Devices.aspx");
                }
                if (DeviceID == "-1") //new Device
                {
                    lblHeading.Text = "Add New Device";
                    txtFloor.Text = "0";
                }
                else
                {
                    var rows = Tables.Devices.ToTable().Select("ID=" + DeviceID);
                    if (rows.Length == 0)
                    {
                        Common.ShowMessage("Invalid Device", ToastType.Error);
                        Response.Redirect("Devices.aspx");
                    }
                    else
                    {
                        rowDevice = rows[0];
                        DisplayDevice();
                    }
                }
                if (Request["MSG"] + "" != "")
                    Common.ShowMessage(Request["MSG"] + "");

            }
            if (!Page.IsPostBack)
            {
            }
            if (Request["__EVENTTARGET"] + "" == btnSave.CommandName)
            {
                btnSave_Click(null, null);
            }

        }

        void DisplayDevice()
        {
            lblHeading.Text = "Update Device (ID: " + DeviceID + ")";

            txtName.Text = rowDevice["Name"] + "";
            txtDesc.Text = rowDevice["Description"] + "";
            txtLat.Text = rowDevice["Lat"] + "";
            txtLong.Text = rowDevice["Lon"] + "";
            txtFloor.Text = rowDevice["FloorNo"] + "";

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                DeviceID = hdID.Value;
                int floor;
                double lat, lon;

                if (string.IsNullOrEmpty(txtName.Text))
                {
                    Common.ShowMessage("Invalid Name", ToastType.Error);
                    return;
                }
                else if (!double.TryParse(txtLat.Text, out lat))
                {
                    Common.ShowMessage("Invalid latitude", ToastType.Error);
                    return;
                }
                else if (!double.TryParse(txtLong.Text, out lon))
                {
                    Common.ShowMessage("Invalid Lognitude", ToastType.Error);
                    return;
                }
                else if (!int.TryParse(txtFloor.Text, out floor))
                {
                    Common.ShowMessage("Invalid Points", ToastType.Error);
                    return;
                }
                string SQL = "";



                if (DeviceID == "-1")//new Device
                {

                    SQL = $"INSERT INTO Devices(Name,Description, Lat,Lon,FloorNo)Values('{txtName.Clean()}','{txtDesc.Clean()}',{lat},{lon},{floor});select scope_identity()";

                    DeviceID = ModData.ExecuteSQLScaler(SQL).ToString();

                    var row = Tables.Devices.ToTable().Rows.Add(DeviceID, txtName.Text, txtDesc.Text, lat, lon, floor);

                }
                else
                {
                    SQL = string.Format("Update Devices SET Name='{0}',Description='{1}',Lat='{2}',Lon='{3}',FloorNo='{4}' WHERE ID=" + DeviceID,
                                      txtName.Clean(), txtDesc.Clean(), lat, lon, floor);

                    ModData.ExecuteSQLQuery(SQL);

                    var rows = Tables.Devices.ToTable().Select("ID=" + DeviceID);
                    if (rows.Length > 0)
                    {
                        var rowDevice = rows[0];

                        rowDevice["Name"] = txtName.Text;
                        rowDevice["Description"] = txtDesc.Text;
                        rowDevice["Lat"] = lat;
                        rowDevice["Lon"] = lon;
                        rowDevice["FloorNo"] = floor;
                    }
                }
                hdID.Value = DeviceID;


                lblHeading.Text = "Update Device (ID: " + DeviceID + ")";
                Common.ShowMessage("Device Updated.");
                Response.Redirect("AddDevice.aspx?ID=-1&msg=Device Updated");
            }
            catch (Exception ex)
            {
                Common.ShowMessage(ex.Message, ToastType.Error);
            }
        }
    }
}