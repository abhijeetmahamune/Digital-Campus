using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampusNavigationWeb
{
    public partial class Devices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GVWeb.IsAdmin)
                Response.Redirect("Login.aspx");
            if (!Page.IsPostBack)
            {
                FillGrid();
            }
            gvDevices.RowEditing += new GridViewEditEventHandler(gvDevices_RowEditing);
            gvDevices.RowCancelingEdit += new GridViewCancelEditEventHandler(gvDevices_RowCancelingEdit);
            gvDevices.RowUpdating += new GridViewUpdateEventHandler(gvDevices_RowUpdating);
            gvDevices.RowDeleting += new GridViewDeleteEventHandler(gvDevices_RowDeleting);
            gvDevices.PageIndexChanging += new GridViewPageEventHandler(gvDevices_PageIndexChanging);

            if (Request["__EVENTTARGET"] + "" == btnAdd.UniqueID)
            {
                btnAdd_Click();
            }
        }
        void gvDevices_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDevices.PageIndex = e.NewPageIndex;
            FillGrid();
        }

        void gvDevices_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string ID = e.Keys["ID"] + "";
                if (ID == "")
                {
                    Common.ShowMessage("Devices not available for delete", ToastType.Error);
                    return;
                }

                //delete from main table
                var SQL = "Delete From Devices WHERE ID=" + ID;
                ModData.ExecuteSQLQuery(SQL);

                var rows = Tables.Devices.ToTable().Select("ID=" + ID);
                rows.Remove();

                FillGrid();

                Common.ShowMessage("Records Deleted.");
            }
            catch (Exception ex)
            {
                Common.ShowMessage("Error: " + ex.Message, ToastType.Error);
            }
        }

        void gvDevices_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Common.ShowMessage("Error: " + ex.Message, ToastType.Error);
            }
        }

        void gvDevices_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
        }
        void gvDevices_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("AddDevice.aspx?ID=" + gvDevices.Rows[e.NewEditIndex].Cells[2].Text);
        }

        void FillGrid()
        {

            gvDevices.DataSource = Tables.Devices.ToTable();
            ViewState["CurrentTable"] = gvDevices.DataSource;
            gvDevices.DataBind();

            lblTotal.Text = "Total Records: " + ((DataTable)gvDevices.DataSource).Rows.Count;
        }

        protected void btnAdd_Click()
        {
            Response.Redirect("AddDevice.aspx?ID=-1");
        }


        protected void gvDevices_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {

                    DataTable dt = (DataTable)ViewState["CurrentTable"];
                    DataRow rowCurrent = dt.Rows[((gvDevices.PageIndex) * gvDevices.PageSize) + e.Row.RowIndex];
                    //Find the DropDownList in the Row
                    if (gvDevices.EditIndex == -1 || (gvDevices.EditIndex > -1 && gvDevices.EditIndex != e.Row.RowIndex))
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