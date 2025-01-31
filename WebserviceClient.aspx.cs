using System;

namespace CampusNavigationWeb
{
    public partial class WebserviceClient : System.Web.UI.Page
    {
        string Key = "", cmd = "", para = "", para2 = "", para3 = "";
        Enum_Tasks enCmd = Enum_Tasks.None;

        protected void Page_Load(object sender, EventArgs e)
        {
            Key = (Request.QueryString["key"] + "").Trim();
            cmd = (Request.QueryString["cmd"] + "").Trim();
            para = (Request.QueryString["para"] + "").Trim();
            para2 = (Request.QueryString["para2"] + "").Trim();
            para3 = (Request.QueryString["para3"] + "").Trim();

            Response.Clear();

            if (cmd == "")
            { return; }

            try
            {
                enCmd = (Enum_Tasks)Enum.Parse(typeof(Enum_Tasks), cmd);
            }
            catch { return; }

            switch (enCmd)
            {
                case Enum_Tasks.UpdateLocation:
                    UpdateLocation();
                    break;
            }
            Response.End();

        }

        void UpdateLocation()
        {
            try
            {
                var deviceId = Request.QueryString["DeviceID"] + "";
                var bleId = Request.QueryString["BleID"] + "";

                var SQL = $"INSERT INTO Track(VisitorId, DeviceId)Values('{bleId}','{deviceId}');select scope_identity()";

                var Id = ModData.ExecuteSQLScaler(SQL).ToString();

                Response.Write("done");
            }catch(Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

    }
}