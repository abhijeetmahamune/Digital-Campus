using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CampusNavigationWeb
{
    public partial class BLE : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!GVWeb.IsAdmin)
                Response.Redirect("Login.aspx");

            if (!Page.IsPostBack)
            {
                FillGrid();
            }
            gvBLEDevices.RowEditing += new GridViewEditEventHandler(gvBLEDevices_RowEditing);
            gvBLEDevices.RowCancelingEdit += new GridViewCancelEditEventHandler(gvBLEDevices_RowCancelingEdit);
            gvBLEDevices.RowUpdating += new GridViewUpdateEventHandler(gvBLEDevices_RowUpdating);
            gvBLEDevices.RowDeleting += new GridViewDeleteEventHandler(gvBLEDevices_RowDeleting);
            gvBLEDevices.PageIndexChanging += new GridViewPageEventHandler(gvBLEDevices_PageIndexChanging);

            if (Request["__EVENTTARGET"] + "" == btnAdd.UniqueID)
            {
                btnAdd_Click();
            }
        }
        void gvBLEDevices_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBLEDevices.PageIndex = e.NewPageIndex;
            FillGrid();
        }

        void gvBLEDevices_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string ID = e.Keys["ID"] + "";
                if (ID == "")
                {
                    Common.ShowMessage("BLE not available for delete", ToastType.Error);
                    return;
                }

                //delete from main table
                var SQL = "Delete From BLE WHERE ID=" + ID;
                ModData.ExecuteSQLQuery(SQL);

                var rows = Tables.BLE.ToTable().Select("ID=" + ID);
                rows.Remove();

                FillGrid();

                Common.ShowMessage("Records Deleted.");
            }
            catch (Exception ex)
            {
                Common.ShowMessage("Error: " + ex.Message, ToastType.Error);
            }
        }

        void gvBLEDevices_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Common.ShowMessage("Error: " + ex.Message, ToastType.Error);
            }
        }

        void gvBLEDevices_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
        }
        void gvBLEDevices_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Response.Redirect("AddBLE.aspx?ID=" + gvBLEDevices.Rows[e.NewEditIndex].Cells[2].Text);
        }

        void FillGrid()
        {

            gvBLEDevices.DataSource = Tables.BLE.ToTable();
            ViewState["CurrentTable"] = gvBLEDevices.DataSource;
            gvBLEDevices.DataBind();

            lblTotal.Text = "Total Records: " + ((DataTable)gvBLEDevices.DataSource).Rows.Count;
        }

        protected void btnAdd_Click()
        {
            Response.Redirect("AddBLE.aspx?ID=-1");
        }


        protected void gvBLEDevices_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {

                    DataTable dt = (DataTable)ViewState["CurrentTable"];
                    DataRow rowCurrent = dt.Rows[((gvBLEDevices.PageIndex) * gvBLEDevices.PageSize) + e.Row.RowIndex];
                    //Find the DropDownList in the Row
                    if (gvBLEDevices.EditIndex == -1 || (gvBLEDevices.EditIndex > -1 && gvBLEDevices.EditIndex != e.Row.RowIndex))
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
        protected void trackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Track.aspx?id=FFFF1001D8C3");
        }
    }
}