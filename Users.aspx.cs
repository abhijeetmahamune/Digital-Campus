using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampusNavigationWeb
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GVWeb.IsAdmin)
                Response.Redirect("Login.aspx");
            if (!Page.IsPostBack)
            {
                FillGrid();
            }
            gvUsers.RowEditing += new GridViewEditEventHandler(gvUsers_RowEditing);
            gvUsers.RowCancelingEdit += new GridViewCancelEditEventHandler(gvUsers_RowCancelingEdit);
            gvUsers.RowUpdating += new GridViewUpdateEventHandler(gvUsers_RowUpdating);
            gvUsers.RowDeleting += new GridViewDeleteEventHandler(gvUsers_RowDeleting);
            gvUsers.PageIndexChanging += new GridViewPageEventHandler(gvUsers_PageIndexChanging);

            if (Request["__EVENTTARGET"] + "" == btnAdd.UniqueID)
            {
                btnAdd_Click();
            }
        }
        void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsers.PageIndex = e.NewPageIndex;
            FillGrid();
        }

        void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string ID = e.Keys["ID"] + "";
                if (ID == "")
                {
                    Common.ShowMessage("Users not available for delete", ToastType.Error);
                    return;
                }

                //delete from main table
                var SQL = "Delete From Users WHERE ID=" + ID;
                ModData.ExecuteSQLQuery(SQL);

                var rows = Tables.Users.ToTable().Select("ID=" + ID);
                rows.Remove();

                FillGrid();

                Common.ShowMessage("Records Deleted.");
            }
            catch (Exception ex)
            {
                Common.ShowMessage("Error: " + ex.Message, ToastType.Error);
            }
        }

        void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Common.ShowMessage("Error: " + ex.Message, ToastType.Error);
            }
        }

        void gvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
        }
        void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("AddUser.aspx?ID=" + gvUsers.Rows[e.NewEditIndex].Cells[2].Text);
        }

        void FillGrid()
        {
            var rows = Tables.Users.ToTable().Select("", "ID DESC");
            if (rows.Length > 0)
                gvUsers.DataSource = rows.ToTable();
            else
                gvUsers.DataSource = Tables.Users.ToTable().Clone();

            ViewState["CurrentTable"] = gvUsers.DataSource;
            gvUsers.DataBind();

            lblTotal.Text = "Total Records: " + ((DataTable)gvUsers.DataSource).Rows.Count;
        }

        protected void btnAdd_Click()
        {
            Response.Redirect("AddUser.aspx?ID=-1");
        }


        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {

                    DataTable dt = (DataTable)ViewState["CurrentTable"];
                    DataRow rowCurrent = dt.Rows[((gvUsers.PageIndex) * gvUsers.PageSize) + e.Row.RowIndex];
                    //Find the DropDownList in the Row
                    if (gvUsers.EditIndex == -1 || (gvUsers.EditIndex > -1 && gvUsers.EditIndex != e.Row.RowIndex))
                    {
                    }
                    else
                    {
                    }

                }
                catch { }
            }
        }

        protected void ddCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            FillGrid();
        }


    }
}