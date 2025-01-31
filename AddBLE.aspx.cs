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
    public partial class AddBLE : System.Web.UI.Page
    {
        string BLEID = "";
        DataRow rowBLE = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GVWeb.IsAdmin)
                Response.Redirect("Login.aspx");

            if (!Page.IsPostBack)
            {
                BLEID = Request["ID"] + "";
                hdID.Value = BLEID;

                if (BLEID == "")
                {
                    Common.ShowMessage("Invalid BLE", ToastType.Error);
                    Response.Redirect("BLE.aspx");
                }
                if (BLEID == "-1") //new BLE
                {
                    lblHeading.Text = "Add New BLE";
                }
                else
                {
                    var rows = Tables.BLE.ToTable().Select("ID=" + BLEID);
                    if (rows.Length == 0)
                    {
                        Common.ShowMessage("Invalid BLE", ToastType.Error);
                        Response.Redirect("BLE.aspx");
                    }
                    else
                    {
                        rowBLE = rows[0];
                        DisplayBLE();
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

        void DisplayBLE()
        {
            lblHeading.Text = "Update BLE (ID: " + BLEID + ")";

            txtName.Text = rowBLE["DeviceID"] + "";

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                BLEID = hdID.Value;
                int floor;
                double lat, lon;

                if (string.IsNullOrEmpty(txtName.Text))
                {
                    Common.ShowMessage("Invalid Name", ToastType.Error);
                    return;
                }
                string SQL = "";



                if (BLEID == "-1")//new BLE
                {

                    SQL = $"INSERT INTO BLE (DeviceID,IsActive)Values('{txtName.Clean()}',{(chkActive.Checked?1:0)} );select scope_identity()";

                    BLEID = ModData.ExecuteSQLScaler(SQL).ToString();

                    var row = Tables.BLE.ToTable().Rows.Add(BLEID, txtName.Text,chkActive.Checked);

                }
                else
                {
                    SQL = string.Format("Update BLE SET DeviceID='{0}',IsActive={1} WHERE ID=" + BLEID,
                                      txtName.Clean(), (chkActive.Checked ? 1 : 0));

                    ModData.ExecuteSQLQuery(SQL);

                    var rows = Tables.BLE.ToTable().Select("ID=" + BLEID);
                    if (rows.Length > 0)
                    {
                        var rowBLE = rows[0];

                        rowBLE["DeviceID"] = txtName.Text;
                        rowBLE["IsActive"] = chkActive.Checked;
                    }
                }
                hdID.Value = BLEID;


                lblHeading.Text = "Update BLE (ID: " + BLEID + ")";
                Common.ShowMessage("BLE Updated.");
                Response.Redirect("AddBLE.aspx?ID=-1&msg=BLE Updated");
            }
            catch (Exception ex)
            {
                Common.ShowMessage(ex.Message, ToastType.Error);
            }
        }
    }
}