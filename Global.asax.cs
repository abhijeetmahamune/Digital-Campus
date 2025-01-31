using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CampusNavigationWeb
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            string CONST_CONN_STRING = "";
            if (GVWeb.__Debug)
            {
                CONST_CONN_STRING = @"Password=sa;Persist Security Info=True;User ID=sa;;Initial Catalog=Campus;Data Source=.;Pooling=true;Connect Timeout=50;Min Pool Size=5; Max Pool Size=50;";
            }
            else
            {
                //CONST_CONN_STRING = @"Password=Pwd@12!@#;Persist Security Info=True;User ID=testCampusNavigation;Initial Catalog=testCampusNavigation;Data Source=MyServer;Pooling=true;Connect Timeout=50;Min Pool Size=5; Max Pool Size=50;";
                CONST_CONN_STRING = @"Password=CaLL@d@#$%^!@1;Persist Security Info=True;User ID=calldriverdb;Initial Catalog=calldriverdb;Data Source=115.124.127.210;Pooling=true;Connect Timeout=50;Min Pool Size=5; Max Pool Size=50;";

            }
            var con = new SqlConnection(CONST_CONN_STRING);
            ModData.Init(con);
            
            ModData.LoadEntireDatabase();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

            ModData.DeInit();
        }
    }
}