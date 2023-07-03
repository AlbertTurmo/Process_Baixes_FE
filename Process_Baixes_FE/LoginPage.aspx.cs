using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using Sql_Data;

namespace UnsubscribeR
{
    public partial class LoginPage : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // EventLogClass.CreateEventLogSource();
            // EventLogClass.WriteLogStarting();

            HtmlGenericControl UserName = (HtmlGenericControl)Page.Master.FindControl("username");
            UserName.Visible = false;

            HtmlAnchor logout = (HtmlAnchor)Page.Master.FindControl("logout");
            logout.Visible = false;

#if false
        DataTable d = ConnectSql.GetUsersDataTable();
        EncryptionTools.PrintTable(d);
#endif
        }


        protected void Login1_Authenticate(object sender, AuthenticateEventArgs AuthenticateEventArgs)
        {
            Session["user"] = OcaLogin.UserName.Trim();
            Session["pass"] = OcaLogin.Password.Trim();

            // ConnectSql.InsertLog(new Log(OcaLogin.UserName, "Login", "Intentando inciar sesión", "Log-in 1", string.Empty, Log.Encrypted.True));

            // DataTable DataTableUsers = ConnectSql.GetUsersDataTable();


            // only for encrypt tables
            //List<string> NoDecryptColumns = new List<string>
            //{
            //    "UsuariosId"
            //};

            //DataTableUsers = EncryptionTools.GetDecryptedDataTable(DataTableUsers, NoDecryptColumns);
            //DataTableUsers = EncryptionTools.GetConvertedTypeDataTable(DataTableUsers);


            // List<string> Users = DataTableUsers.AsEnumerable().Select(r => r.Field<string>("windowsId")).ToList();


            // bool correct1 = ldapAuthenticator.validate((string)Session["user"], (string)Session["pass"]);
            bool correct1 = LdapAuthenticator.Validate(OcaLogin.UserName, OcaLogin.Password);
            // bool correct2 = Users.Contains(OcaLogin.UserName, EqualityComparer<string>.Default);

            bool correct2 = SqlData_Users.CheckUser(OcaLogin.UserName.Trim());


            if (correct1 && correct2)
            {
                // ConnectSql.InsertLog(new Log(OcaLogin.UserName, "Log-in", "Incio correcto", string.Empty, string.Empty, Log.Encrypted.True));
                // EventLogClass.WriteLog($"Se ha iniciado sesión: {OcaLogin.UserName}", System.Diagnostics.EventLogEntryType.Information);

                Response.Redirect("Search.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                // Fuente: https://www.iteramos.com/pregunta/5345/por-que-responseredirect-causas-systemthreadingthreadabortexception
            }

            //if (correct2)
            //{
            //    string Name = (from DataRow dr in DataTableUsers.Rows where (string)dr["windowsid"] == OcaLogin.UserName select (string)dr["nombre"]).FirstOrDefault();
            //    Session["user"] = Name;
            //}

            //if (correct1 && correct2)
            //{
            //    // ConnectSql.InsertLog(new Log(OcaLogin.UserName, "Log-in", "Incio correcto", string.Empty, string.Empty, Log.Encrypted.True));
            //    // EventLogClass.WriteLog($"Se ha iniciado sesión: {OcaLogin.UserName}", System.Diagnostics.EventLogEntryType.Information);

            //    Response.Redirect("Search.aspx", false);
            //    Context.ApplicationInstance.CompleteRequest();
            //    // Fuente: https://www.iteramos.com/pregunta/5345/por-que-responseredirect-causas-systemthreadingthreadabortexception


            //}
            //else
            //{

            //    // ConnectSql.InsertLog(new Log(OcaLogin.UserName, "Log-in", "Incio fallido", string.Empty, string.Empty, Log.Encrypted.True));
            //    // EventLogClass.WriteLog($"Inicio de sesión fallido: {OcaLogin.UserName}", System.Diagnostics.EventLogEntryType.Warning);

            //    AuthenticateEventArgs.Authenticated = false;
            //}

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

        }
    }
}