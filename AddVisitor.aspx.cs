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
    public partial class AddVisitor : System.Web.UI.Page
    {
        string VisitorID = "";
        DataRow rowVisitor = null;
        DateTime? assignTime = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GVWeb.IsAdmin)
                Response.Redirect("Login.aspx");

            if (Tables.BLE.ToTable().Rows.Count == 0)
                Response.Redirect("BLE.aspx");

            if (ddBleID.Items.Count == 0)
            {
                foreach (DataRow row in Tables.BLE.ToTable().Select("IsActive=1"))
                    ddBleID.Items.Add(new ListItem(row["DeviceID"] + "", row["ID"] + ""));
                ddBleID.SelectedIndex = 0;

            }
            if (!Page.IsPostBack)
            {
                VisitorID = Request["ID"] + "";
                hdID.Value = VisitorID;

                if (VisitorID == "")
                {
                    Common.ShowMessage("Invalid Visitor", ToastType.Error);
                    Response.Redirect("Visitors.aspx");
                }
                if (VisitorID == "-1") //new Visitor
                {
                    lblHeading.Text = "Add New Visitor";
                }
                else
                {
                    var rows = Tables.Visitors.ToTable().Select("ID=" + VisitorID);
                    if (rows.Length == 0)
                    {
                        Common.ShowMessage("Invalid Visitor", ToastType.Error);
                        Response.Redirect("Visitors.aspx");
                    }
                    else
                    {
                        rowVisitor = rows[0];
                        DisplayVisitor();
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
        void DisplayVisitor()
        {

            lblHeading.Text = "Update Visitor (ID: " + VisitorID + ")";

            txtName.Text = rowVisitor["Name"] + "";
            txtPhone.Text = rowVisitor["Phone"] + "";
            ddBleID.SelectedValue = rowVisitor["BleID"] + "";

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                VisitorID = hdID.Value;

                if (string.IsNullOrEmpty(txtName.Text))
                {
                    Common.ShowMessage("Invalid Name", ToastType.Error);
                    return;
                }
                else if (txtPhone.Text.Length != 10)
                {
                    Common.ShowMessage("Invalid Phone", ToastType.Error);
                    return;
                }
                else if (ddBleID.SelectedIndex==-1)
                {
                    Common.ShowMessage("Invalid BLE ID", ToastType.Error);
                    return;
                }

                string SQL = "";
                var bleId = Convert.ToInt32(ddBleID.SelectedItem.Value);


                if (VisitorID == "-1")//new Visitor
                {

                    SQL = $"INSERT INTO Visitors(Name,Phone, BleID)Values('{txtName.Clean()}','{txtPhone.Clean()}',{bleId});select scope_identity()";

                    VisitorID = ModData.ExecuteSQLScaler(SQL).ToString();

                    var row = Tables.Visitors.ToTable().Rows.Add(VisitorID, txtName.Text, txtPhone.Text, bleId, DateTime.Now, null);

                }
                else
                {
                    SQL = string.Format("Update Visitors SET Name='{0}',Phone='{1}',BleID='{2}',ReturnTime=getdate() WHERE ID=" + VisitorID,
                                      txtName.Clean(), txtPhone.Clean(), bleId);

                    ModData.ExecuteSQLQuery(SQL);

                    var rows = Tables.Visitors.ToTable().Select("ID=" + VisitorID);
                    if (rows.Length > 0)
                    {
                        var rowVisitor = rows[0];

                        rowVisitor["Name"] = txtName.Text;
                        rowVisitor["Phone"] = txtPhone.Text;
                        rowVisitor["BleID"] = bleId;
                        rowVisitor["ReturnTime"] = DateTime.Now;
                    }
                }
                hdID.Value = VisitorID;


                lblHeading.Text = "Update Visitor (ID: " + VisitorID + ")";
                Common.ShowMessage("Visitor Updated.");
                Response.Redirect("AddVisitor.aspx?ID=-1&msg=Visitor Updated");
            }
            catch (Exception ex)
            {
                Common.ShowMessage(ex.Message, ToastType.Error);
            }
        }
    }
}