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
    public partial class AddUser : System.Web.UI.Page
    {
        string UserID = "";
        DataRow rowUser = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GVWeb.IsAdmin)
                Response.Redirect("Login.aspx");

            if (Tables.BLE.ToTable().Rows.Count == 0)
                Response.Redirect("BLE.aspx");

            if (!Page.IsPostBack)
            {
                UserID = Request["ID"] + "";
                hdID.Value = UserID;

                if (UserID == "")
                {
                    Common.ShowMessage("Invalid User", ToastType.Error);
                    Response.Redirect("Users.aspx");
                }
                if (UserID == "-1") //new User
                {
                    lblHeading.Text = "Add New User";
                }
                else
                {
                    var rows = Tables.Users.ToTable().Select("ID=" + UserID);
                    if (rows.Length == 0)
                    {
                        Common.ShowMessage("Invalid User", ToastType.Error);
                        Response.Redirect("Users.aspx");
                    }
                    else
                    {
                        rowUser = rows[0];
                        DisplayUser();
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
        void DisplayUser()
        {

            lblHeading.Text = "Update User (ID: " + UserID + ")";

            txtName.Text = rowUser["Name"] + "";
            txtPhone.Text = rowUser["Phone"] + "";
            txtPassword.Text = rowUser["Password"] + "";
            txtDetails.Text = rowUser["Details"] + "";

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                UserID = hdID.Value;

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
                else if (txtPassword.Text =="")
                {
                    Common.ShowMessage("Invalid Password", ToastType.Error);
                    return;
                }

                string SQL = "";


                if (UserID == "-1")//new User
                {

                    SQL = $"INSERT INTO Users(Name,Phone, Password,Details,IsActive)Values('{txtName.Clean()}','{txtPhone.Clean()}','{txtPassword.Clean()}','{txtDetails.Clean()}',1);select scope_identity()";

                    UserID = ModData.ExecuteSQLScaler(SQL).ToString();

                    var row = Tables.Users.ToTable().Rows.Add(UserID, txtName.Text, txtPhone.Text, txtPassword.Text,txtDetails.Text,true);

                }
                else
                {
                    SQL = string.Format("Update Users SET Name='{0}',Phone='{1}',Password='{2}',Details='{3}' WHERE ID=" + UserID,
                                      txtName.Clean(), txtPhone.Clean(), txtPassword.Clean(), txtDetails.Clean());

                    ModData.ExecuteSQLQuery(SQL);

                    var rows = Tables.Users.ToTable().Select("ID=" + UserID);
                    if (rows.Length > 0)
                    {
                        var rowUser = rows[0];

                        rowUser["Name"] = txtName.Text;
                        rowUser["Phone"] = txtPhone.Text;
                        rowUser["Password"] = txtPassword.Text;
                        rowUser["Details"] = txtDetails.Text;
                    }
                }
                hdID.Value = UserID;


                lblHeading.Text = "Update User (ID: " + UserID + ")";
                Common.ShowMessage("User Updated.");
                Response.Redirect("AddUser.aspx?ID=-1&msg=User Updated");
            }
            catch (Exception ex)
            {
                Common.ShowMessage(ex.Message, ToastType.Error);
            }
        }
    }
}