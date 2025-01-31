using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampusNavigationWeb
{
    public partial class Visitors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GVWeb.IsAdmin)
                Response.Redirect("Login.aspx");
            if (!Page.IsPostBack)
            {
                FillGrid();
            }
            gvVisitors.RowEditing += new GridViewEditEventHandler(gvVisitors_RowEditing);
            gvVisitors.RowCancelingEdit += new GridViewCancelEditEventHandler(gvVisitors_RowCancelingEdit);
            gvVisitors.RowUpdating += new GridViewUpdateEventHandler(gvVisitors_RowUpdating);
            gvVisitors.RowDeleting += new GridViewDeleteEventHandler(gvVisitors_RowDeleting);
            gvVisitors.PageIndexChanging += new GridViewPageEventHandler(gvVisitors_PageIndexChanging);

            if (Request["__EVENTTARGET"] + "" == btnAdd.UniqueID)
            {
                btnAdd_Click();
            }
        }
        void gvVisitors_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVisitors.PageIndex = e.NewPageIndex;
            FillGrid();
        }

        void gvVisitors_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string ID = e.Keys["ID"] + "";
                if (ID == "")
                {
                    Common.ShowMessage("Visitors not available for delete", ToastType.Error);
                    return;
                }

                //delete from main table
                var SQL = "Delete From Visitors WHERE ID=" + ID;
                ModData.ExecuteSQLQuery(SQL);

                var rows = Tables.Visitors.ToTable().Select("ID=" + ID);
                rows.Remove();

                FillGrid();

                Common.ShowMessage("Records Deleted.");
            }
            catch (Exception ex)
            {
                Common.ShowMessage("Error: " + ex.Message, ToastType.Error);
            }
        }

        void gvVisitors_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Common.ShowMessage("Error: " + ex.Message, ToastType.Error);
            }
        }

        void gvVisitors_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
        }
        void gvVisitors_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("AddVisitor.aspx?ID=" + gvVisitors.Rows[e.NewEditIndex].Cells[2].Text);
        }

        void FillGrid()
        {
            var rows = Tables.Visitors.ToTable().Select("", "ID DESC");
            if (rows.Length > 0)
                gvVisitors.DataSource = rows.ToTable();
            else
                gvVisitors.DataSource = Tables.Visitors.ToTable().Clone();

            ViewState["CurrentTable"] = gvVisitors.DataSource;
            gvVisitors.DataBind();

            lblTotal.Text = "Total Records: " + ((DataTable)gvVisitors.DataSource).Rows.Count;
        }

        protected void btnAdd_Click()
        {
            Response.Redirect("AddVisitor.aspx?ID=-1");
        }


        protected void gvVisitors_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {

                    DataTable dt = (DataTable)ViewState["CurrentTable"];
                    DataRow rowCurrent = dt.Rows[((gvVisitors.PageIndex) * gvVisitors.PageSize) + e.Row.RowIndex];
                    //Find the DropDownList in the Row
                    if (gvVisitors.EditIndex == -1 || (gvVisitors.EditIndex > -1 && gvVisitors.EditIndex != e.Row.RowIndex))
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