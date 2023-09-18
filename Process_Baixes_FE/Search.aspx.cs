using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using GridView = System.Web.UI.WebControls.GridView;
using CommonTools;
using GoogleServices;
using WebButton = System.Web.UI.WebControls.Button;
using Sql_Data;
using EncryptToolsProject;

using GoogleUser = Google.Apis.Admin.Directory.directory_v1.Data.User;
using System.Reflection;

namespace UnsubscribeR
{

    public partial class Search : System.Web.UI.Page
    {
        public static Empleado EmpleadoEditPanel;
        public static StatusProcess CurrentState;
        public static List<Empleado> ListEmpleado;
        public static string SessionUser;
        public static DataTable Permissions;
        public static DataTable DataTableLocated;
        public static DataTable DataTableScheduled;
        public static EditMode Editmode;
        public static LevelPermissions Level;
        public static int programmedSelectedIndex;
        public static List<string> ProgrammedList = new List<string>();

        #region CLASS HEADER


        public enum LevelPermissions
        {
            sadmin = 0,
            admin = 1,
            user = 2
        }

        public enum EditMode
        {
            ProgrammingNewUnsubscribe,
            ReprogrammingUnsubscribe
        }



        #endregion


        #region LOAD PAGE

        protected void Page_Load(object sender, EventArgs e)
        {
            _ = DateTime.Now;
            // Debug.WriteLine(myDate.ToString());

            if (!Page.IsPostBack)
            {

                /* Forçat momentaneament per hard code
                *************************************/
                // Session["user"] = "sruiz";
                // Session["username"] = "Servando Ruiz Beser";

                HtmlAnchor logout = (HtmlAnchor)Page.Master.FindControl("logout");
                logout.Visible = true;
                AdminLink.Visible = false;

                if (Session["user"] == null)
                {
                    // System.Environment.Exit(5);
                }

                // SessionUser = Session["user"].ToString();
                // Level = (LevelPermissions)ConnectSql.GetLevelUser(SessionUser);
                // Level = LevelPermissions.user;
                //permissions2 = ConnectSql.GetPermissionsDataTable(SessionUser);

                //if (Level == LevelPermissions.sadmin || Level == LevelPermissions.admin)
                //{
                //    SetAllPermissions();
                //    AdminLink.Visible = true;
                //}


                //Session["permissions"] = permissions2;
                //// EncryptionTools.PrintTable(permissions);

                //HtmlGenericControl UserName = (HtmlGenericControl)Page.Master.FindControl("username");
                //UserName.InnerHtml = Session["user"].ToString();
                //UserName.Visible = true;

                //ScheduledBtn.Enabled = false;

                //List<LogPBajasA> MList = SqlData_Bajas.GetTicketsInSql();

                //GridView1.DataSource = MList;


                //GetListScheduled();  // Colocar-ho a algun lloc per a refrescar....

                DataBind(StatusProcess.programmed);

                //Search.state = State.programmed;
                //Search.programmedSelectedIndex = -1;

                //DeleteButton.Visible = false;
                //ScheduledEditButton.Visible = false;

                // editButton.Enabled = false; // located Panel
                // scheduledGV.Sort("date", SortDirection.Ascending);
            }

            Page.MaintainScrollPositionOnPostBack = true;

        }

        //protected void Page_Init(object sender, EventArgs e)
        //{
        //    var onBlurScript = Page.ClientScript.GetPostBackEventReference(MailTb, "OnBlur");
        //    MailTb.Attributes.Add("onblur", onBlurScript);
        //}


        private void DataBind(StatusProcess StatusProcess)
        {

            List<LogPBajasA> ListLogPBajasA = SqlData_Bajas.GetTicketsByStatus(StatusProcess);

            ProgrammedGridView.DataSource = ListLogPBajasA;
            ProgrammedGridView.DataBind();

            if (ListLogPBajasA.Count > 0)
            {
                ProgrammedGridView.SelectedIndex = 0;
            }
            else
            {
                ProgrammedGridView.SelectedIndex = -1;
            }

            ViewState["DirStateScheduled"] = ListLogPBajasA;
            ViewState["sortDrScheduled"] = "Asc";

        }

        private void DataBindRows(string Mail)
        {

            List<LogPBajasA> ListLogPBajasA = SqlData_Bajas.GetTicketsByMail(Mail);

            ProgrammedGridView.DataSource = ListLogPBajasA;
            ProgrammedGridView.DataBind();

            if (ListLogPBajasA.Count > 0)
            {
                ProgrammedGridView.SelectedIndex = 0;
            }
            else
            {
                ProgrammedGridView.SelectedIndex = -1;
            }

            ViewState["DirStateScheduled"] = ListLogPBajasA;
            ViewState["sortDrScheduled"] = "Asc";

        }

        #endregion

        #region TEXTBOX DATA EVENTS

        protected void DataTb_TextChanged(object sender, EventArgs e)
        {
            SearchingUsers();
        }

        protected void SearchBtn_Click(object sender, ImageClickEventArgs e)
        {
            SearchingUsers();
        }


        protected void SearchRowsBtn_Click(object sender, ImageClickEventArgs e)
        {
            SearrchRows();
        }

        protected void SearchRows_TextChanged(object sender, EventArgs e)
        {
            SearrchRows();

        }

        private void SearrchRows()
        {
            ProgrammedBtn.Visible = true;
            CanceledBtn.Visible = true;
            ProessedBtn.Visible = true;
            ProcessingBtn.Visible = true;
            ErrorsBtn.Visible = true;


            GetColumnByName(ProgrammedGridView, "Procesar").Visible = false;
            GetColumnByName(ProgrammedGridView, "No Procesar").Visible = false;
            GetColumnByName(ProgrammedGridView, "Restaurar").Visible = false;
            GetColumnByName(ProgrammedGridView, "Estado").Visible = true;

            string DataText = SearchRows.Text;

            List<LogPBajasA> ListLogPBajasA = SqlData_Bajas.GetTicketsByMail(DataText);


            DataBindRows(DataText);
        }

        private void SearchingUsers()
        {
            string DataText = DataTb.Text;

            if (!String.IsNullOrEmpty(DataText))
            {
                if (DataText.Contains("@"))
                {
                    // cerca per mail.....

                    bool IsMailCorrect = CommonTools.Check.GetIfCorrectFormatMail(DataText);

                    if (IsMailCorrect)
                    {

                        bool Exists = CheckIfUserExistsInGoogle(DataText);

                        if (Exists)
                        {

                            GoogleUser GUser = SearchUserInGoogle(DataText);

                            if (GUser != null)
                            {

                                SetFoundsGrieViewFromGoogle(GUser);
                            }
                        }
                    }
                    else { }
                }
                else
                {
                    SearchUsers(DataText);
                }

                ModalPopupFoundPanel.Show();
            }
            // DataTb.Text = string.Empty;
        }


        private bool CheckIfUserExistsInGoogle(string DataText)
        {

            bool Exists = UsersManagement.CheckIfUserExists(DataText);

            return Exists;

        }


        private GoogleUser SearchUserInGoogle(string DataText)
        {
            GoogleUser GoogleUser = UsersManagement.GetUser(DataText);
            return GoogleUser;
        }

        private void SearchUsers(string DataText)
        {
            ListEmpleado = SqlGetData.SearchEmployees(DataText);

            FoundsGridView.DataSource = ListEmpleado; // Session["datatablead"];
            // LocatedGV.DataSource = DataTableLocated; // Session["datatablead"];
            FoundsGridView.AllowPaging = true;
            FoundsGridView.DataBind();

        }

        private void SetFoundsGrieViewFromGoogle(GoogleUser GoogleUser)
        {

            Empleado Empleado = new Empleado();

            if (GoogleUser.ExternalIds != null)
            {
                if (GoogleUser.ExternalIds.Count > 0)
                {
                    bool Success = int.TryParse(GoogleUser.ExternalIds[0].Value, out int EmployeeId);
                    if (Success)
                    {
                        Empleado.empleadoId = EmployeeId;
                        Empleado = SqlGetData.GetEmployeeByEmployeeId(EmployeeId);
                    }
                }
            }
            else
            {
                Empleado.nombreCompleto = GoogleUser.Name.FullName;
                Empleado.email = GoogleUser.PrimaryEmail;

                if (GoogleUser.Organizations != null)
                {
                    if (GoogleUser.Organizations.Count > 0)
                    {
                        Empleado.divisionPersonalDescripcion = GoogleUser.Organizations[0].Name;
                        Empleado.posicionDescripcion = GoogleUser.Organizations[0].Title;
                        Empleado.subDivisionPersonalDescripcion = GoogleUser.Organizations[0].Department;
                    }
                }

            }

            ListEmpleado = new List<Empleado>() { Empleado };
            FoundsGridView.DataSource = ListEmpleado; // Session["datatablead"];
            FoundsGridView.AllowPaging = true;
            FoundsGridView.DataBind();
        }
        #endregion




        #region PAGE STATE BUTTONS



        protected void StatusButtons_Click(object sender, EventArgs e)
        {

            WebButton WebButton = (WebButton)sender;

            ProgrammedBtn.Visible = true;
            CanceledBtn.Visible = true;
            ProessedBtn.Visible = true;
            ProcessingBtn.Visible = true;
            ErrorsBtn.Visible = true;

            if (WebButton.ID == "ProgrammedBtn")
            {
                CurrentState = StatusProcess.programmed;
                ProgrammedBtn.Visible = false;
                CaptionSh.InnerText = "Bajas Programadas";
            }

            if (WebButton.ID == "CanceledBtn")
            {
                CurrentState = StatusProcess.no_process;
                CanceledBtn.Visible = false;
                CaptionSh.InnerText = "Bajas Canceladas";
            }

            if (WebButton.ID == "ProessedBtn")
            {
                CurrentState = StatusProcess.processed;
                ProessedBtn.Visible = false;
                CaptionSh.InnerText = "Bajas Procesadas";
            }

            if (WebButton.ID == "ProcessingBtn")
            {
                CurrentState = StatusProcess.processing;
                ProcessingBtn.Visible = false;
                CaptionSh.InnerText = "Bajas Procesando";
            }

            if (WebButton.ID == "ErrorsBtn")
            {
                CurrentState = StatusProcess.error_process;
                ErrorsBtn.Visible = false;
                CaptionSh.InnerText = "Bajas con Error";
            }

            // CanceledBtn

            GetColumnByName(ProgrammedGridView, "Procesar").Visible = false;
            GetColumnByName(ProgrammedGridView, "No Procesar").Visible = false;
            GetColumnByName(ProgrammedGridView, "Restaurar").Visible = false;
            GetColumnByName(ProgrammedGridView, "Estado").Visible = false;

            ButtonsBox.Visible = false;

            if (CurrentState == StatusProcess.programmed)
            {

                GetColumnByName(ProgrammedGridView, "Procesar").Visible = true;
                GetColumnByName(ProgrammedGridView, "No Procesar").Visible = true;

                ButtonsBox.Visible = true;
            }
            else
            if (CurrentState == StatusProcess.no_process)
            {
                GetColumnByName(ProgrammedGridView, "Restaurar").Visible = true;
            }

            if ((CurrentState == StatusProcess.processing) || (CurrentState == StatusProcess.processed) || (CurrentState == StatusProcess.error_process))
            {
                GetColumnByName(ProgrammedGridView, "Estado").Visible = true;
            }


            DataBind(CurrentState);
        }


        private void SetEditPanelFromLogPBajasA(LogPBajasA LogPBajasA)
        {

            ResetEditPanel();

            H1.InnerText = "MODIFICACIÓN BAJA";

            TicketTb.Text = LogPBajasA.Ticket;
            NameTb.Text = LogPBajasA.Name;
            EmployeeIdTb.Text = LogPBajasA.EmployeeNumber.ToString();
            WindowsidTb.Text = LogPBajasA.WindowsId;
            MailTb.Text = LogPBajasA.Mail;
            ResponsableTicketTb.Text = LogPBajasA.ResponsableTicket;
            ResponsableADTb.Text = LogPBajasA.ResponsableAd;
            BackupMailCB.Checked = (LogPBajasA.BackupMail != null) ? LogPBajasA.BackupMail.Value : false;
            BackupDriveCB.Checked = (LogPBajasA.BackupMail != null) ? LogPBajasA.BackupDrive.Value : false;
            TranferCB.Checked = (LogPBajasA.Transfer != null) ? LogPBajasA.Transfer.Value : false;
            DeleteADCB.Checked = (LogPBajasA.DeleteAd != null) ? LogPBajasA.DeleteAd.Value : false;
            AliasCB.Checked = (LogPBajasA.CreateAlias != null) ? LogPBajasA.CreateAlias.Value : false;

        }


        private void SetEditPanelFromEmpleado(Empleado Empleado)
        {
            ResetEditPanel();

            H1.InnerText = "Programación Baja";

            string Mail = string.Empty;
            string MailResposible = string.Empty;

            if (!string.IsNullOrEmpty(Empleado.usuarioWindows))
            {
                Mail = ConnectAd.LookForMail(Empleado.usuarioWindows);
                MailResposible = ConnectAd.LookForManager(Empleado.usuarioWindows);
            }

            TicketTb.Text = GetNextIMTicket();

            NameTb.Text = CommonTools.Text.ToTitleCase(Empleado.nombreCompleto);
            EmployeeIdTb.Text = Empleado.empleadoId.ToString();
            WindowsidTb.Text = Empleado.usuarioWindows.ToLower();

            SetChecks(Empleado.email, string.Empty, Empleado.usuarioWindows);

            if (string.IsNullOrEmpty(Empleado.email))
            {
                BackupMailCB.Enabled = false;
                BackupDriveCB.Enabled = false;
                TranferCB.Enabled = false;
                AliasCB.Enabled = false;
            }

            MailTb.Text = Mail;
            ResponsableADTb.Text = MailResposible;
            ResponsableTicketTb.Text = string.Empty;

        }

        public static string GetNextIMTicket()
        {
            LogPBajasA LastIMLogPBajasA = SqlData_Bajas.GetLastTicketsIMInSql();

            string NewTicket = "IM-0001";

            if (LastIMLogPBajasA!=null)
            {
                NewTicket = $"IM-{int.Parse(LastIMLogPBajasA.Ticket.Substring(3)) + 1:0000}";
            }

            return NewTicket;
        }

        #endregion

        /* Scheduled GV Events */
        #region PROGRAMMED GRIDVIEW EVENTS

        protected void ScheduledGV_Sorting(object sender, GridViewSortEventArgs e)
        {
            List<LogPBajasA> ListLogPBajasA = (List<LogPBajasA>)ViewState["DirStateScheduled"];
            List<LogPBajasA> NewListLogPBajasA = ListLogPBajasA;

            if (e.SortExpression=="Name")
            {
                if(e.SortDirection== SortDirection.Ascending)
                {
                    NewListLogPBajasA = ListLogPBajasA.OrderBy(x => x.Name).ToList();
                }
                else
                if(e.SortDirection == System.Web.UI.WebControls.SortDirection.Descending)
                {
                    NewListLogPBajasA = ListLogPBajasA.OrderByDescending(x => x.Name).ToList();
                }

                ProgrammedGridView.DataSource = NewListLogPBajasA;

                // ProgrammedGridView.sorte

            }




            ProgrammedGridView.DataBind();
        }

        protected void ScheduledGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Search.CurrentState == StatusProcess.programmed)
            {
                EditButton.Visible = true;
            }
        }

        protected void ScheduledGV_PageIndexChanging(object sender, GridViewPageEventArgs GridViewPageEventArgs)
        {
            DataBind(CurrentState);
            ProgrammedGridView.PageIndex = GridViewPageEventArgs.NewPageIndex;
            ProgrammedGridView.DataBind();
        }


        protected void ScheduledGV_RowCreated(object sender, GridViewRowEventArgs e)
        {
            int n = e.Row.RowIndex;
            int nn = ProgrammedGridView.SelectedIndex;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Attributes["onmouseover"] = "this.originalstyle=this.style.backgroundColor; this.style.backgroundColor='Gray'";

                // when mouse is over the row, save original color to new attribute, and change it to highlight color
                // e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor; this.style.backgroundColor='Gray'");

                e.Row.Attributes["onmouseout"] = "this.style.backgroundColor=this.originalstyle;";

                // when mouse leaves the row, change the bg color to its original value   
                // e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");

                e.Row.Attributes.Add("ondblclick", "this.originalstyle=this.style.backgroundColor; this.style.backgroundColor='Gray'");
                // e.Row.Attributes.Add("onClick", "this.originalstyle=this.style.backgroundColor; this.style.backgroundColor='Gray'");

                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(ProgrammedGridView, "Select$" + e.Row.RowIndex);
                // e.Row.Attributes["onClick"] = Page.ClientScript.GetPostBackClientHyperlink(ScheduledGV, "Select$" + e.Row.RowIndex);
                // e.Row.ToolTip = "Doble Clic para seleccionar este registro....";

                // e.Row.Attributes.Add("onclick", "this.style.backgroundColor='#27DE8B'");

                // e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(usersFoundGV, "Select$" + e.Row.RowIndex);
                // e.Row.ToolTip = "Click to select this row";

            }


        }

        #endregion


        protected void EditButton_Click(object sender, EventArgs e)
        {
            Editmode = EditMode.ReprogrammingUnsubscribe;

            if (ProgrammedGridView.SelectedIndex != -1)
            {

                GridViewRow GridViewRow = ProgrammedGridView.SelectedRow;
                string Ticket = ((HyperLink)GetCellByName(GridViewRow, "Ticket").Controls[0]).Text;

                LogPBajasA LogPBajasA = SqlData_Bajas.GetLogPBajasAByTicket(Ticket);


                ResetEditPanel();
                SetEditPanelFromLogPBajasA(LogPBajasA);
                ModalPopupFoundPanel.Hide();
                ModalPopupEditPanel.Show();
            }
        }



        protected void ProgrammedGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // If multiple buttons are used in a GridView control, use the
            // CommandName property to determine which button was clicked.
            // Response.Write("<script>alert('Hello');</script>");
           


            if ((e.CommandName == "ToProcess") || (e.CommandName == "No_Process") || (e.CommandName == "Restore") || (e.CommandName == "State"))
            {
                bool Success = int.TryParse(e.CommandArgument.ToString(), out int RowIndex);

                if (Success)
                {
                    GridViewRow GridViewRow = ProgrammedGridView.Rows[RowIndex];
                    string Ticket = ((HyperLink)GetCellByName(GridViewRow, "Ticket").Controls[0]).Text;
                    LogPBajasA LogPBajasA = SqlData_Bajas.GetLogPBajasAByTicket(Ticket);
                    Exports Export = SqlData_Exports.GetExportsAByTicket(Ticket);

                    if (Export != null)
                    {
                        if (e.CommandName == "ToProcess")
                        {
                            int NumberProcessing = SqlData_Exports.CountExportsByStatus(StatusProcess.processing);

                            /* only test */
                            // NumberProcessing = 18;

                            if (NumberProcessing < 18)
                            {
                                LogPBajasA = SqlData_Bajas.UpdateStatus(LogPBajasA, StatusProcess.to_process);
                                Export = SqlData_Exports.UpdateStatus(Export, StatusProcess.to_process);
                                
                                DataBind(StatusProcess.programmed);
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('DEMASIADOS PROCESOS CONCURRENTES');", true);
                            }
                        }
                        else
                        if (e.CommandName == "No_Process")
                        {
                            LogPBajasA = SqlData_Bajas.UpdateStatus(LogPBajasA, StatusProcess.no_process);
                            Export = SqlData_Exports.UpdateStatus(Export, StatusProcess.no_process);

                            DataBind(StatusProcess.programmed);
                        }
                        else
                        if (e.CommandName == "Restore")
                        {
                            LogPBajasA = SqlData_Bajas.UpdateStatus(LogPBajasA, StatusProcess.programmed);
                            Export = SqlData_Exports.UpdateStatus(Export, StatusProcess.programmed);
                            DataBind(StatusProcess.no_process);
                        }
                        else
                        if (e.CommandName == "State")
                        {

                            Export.Password = EncryptTools.Decrypt(Export.Password);

                            SetStatePanelFromExport(Export);
                        }

                    }

                }
            }
        }


        private void SetStatePanelFromExport(Exports Export)
        {
            // H3.InnerText = "ESTADO BAJA";

            string StatusProcess = (Export.StatusProcess != null) ? Export.StatusProcess.ToLower() : string.Empty;
            string ExportsId = (Export.ExportsId != 0) ? $"{Export.ExportsId}" : string.Empty;
            string InicioProceso = (Export.InicioProceso != null) ? $"{Export.InicioProceso}" : string.Empty;
            string UpdateProcess = (Export.UpdateProcess != null) ? $"{Export.UpdateProcess}" : string.Empty;
            string IssueKey = (Export.IssueKey != null) ? $"{Export.IssueKey}" : string.Empty;
            string WindowsId = (Export.WindowsId != null) ? $"{Export.WindowsId}" : string.Empty;
            string StatusKey = (Export.StatusKey != null) ? $"{Export.StatusKey}" : string.Empty;
            string EmpleadoId = (Export.EmpleadoId != null) ? $"{Export.EmpleadoId}" : string.Empty;
            string ExportName = (Export.ExportName != null) ? $"{Export.ExportName}" : string.Empty;
            string ErrorExport = (Export.ErrorExport != null) ? $"{Export.ErrorExport}" : string.Empty;
            string SizeInBytes = (Export.SizeInBytes != null) ? $"{Export.SizeInBytes}" : string.Empty;
            string StatusExport = (Export.StatusExport != null) ? Export.StatusExport.ToLower() : string.Empty;
            string StatusDrive = (Export.StatusDrive != null) ? Export.StatusDrive.ToLower() : string.Empty;
            string StatusTransfer = (Export.StatusTransfer != null) ? Export.StatusTransfer.ToLower() : string.Empty;
            string StatusAd = (Export.StatusAd != null) ? Export.StatusAd.ToLower() : string.Empty;
            string StatusAlias = (Export.StatusAlias != null) ? Export.StatusAlias.ToLower() : string.Empty;
            string StatusGoogleUser = (Export.StatusGoogleUser != null) ? Export.StatusGoogleUser.ToLower() : string.Empty;
            string Password = (Export.Password != null) ? Export.Password : string.Empty;


            TableCell1.Text = $"{GetTranslateExports.ExportsTranslate[StatusProcess]}";
            TableCell17.Text = $"{ExportsId}";
            TableCell2.Text = $"{InicioProceso}";
            TableCell3.Text = $"{UpdateProcess}";
            // TableCell4.Text = $"{IssueKey}";
            TableCell5.Text = $"{WindowsId}";
            TableCell6.Text = $"{StatusKey}";
            TableCell7.Text = $"{EmpleadoId}";
            TableCell8.Text = $"{ExportName}";
            TableCell9.Text = (ErrorExport == "0") ? "Sin Errores" : $"Error: {ErrorExport}";
            TableCell10.Text = $"{SizeInBytes}";
            TableCell11.Text = $"{GetTranslateExports.ExportsTranslate[StatusExport]}";
            TableCell12.Text = $"{GetTranslateExports.ExportsTranslate[StatusDrive]}";
            TableCell13.Text = $"{GetTranslateExports.ExportsTranslate[StatusTransfer]}";
            TableCell14.Text = $"{GetTranslateExports.ExportsTranslate[StatusAd]}";
            TableCell15.Text = $"{GetTranslateExports.ExportsTranslate[StatusAlias]}";
            TableCell16.Text = $"{GetTranslateExports.ExportsTranslate[StatusGoogleUser]}";
            TableCell18.Text = $"{Password}";

            ModalPopupStatePanel.Show();



        }

        protected void StatePanelAcceptButton_Click(object sender, EventArgs e)
        {
            ModalPopupStatePanel.Hide();

        }


        public static DataControlFieldCell GetCellByName(GridViewRow GridViewRow, string CellName)
        {
            DataControlFieldCell RetunedCell = null;

            foreach (DataControlFieldCell Cell in GridViewRow.Cells)
            {
                if (Cell.ContainingField.ToString() == CellName)
                {
                    RetunedCell = Cell;
                }
            }
            return RetunedCell;
        }


        public static DataControlField GetColumnByName(GridView GridView, string ColumnName)
        {
            DataControlField ReturnedColumn = null;

            foreach (DataControlField Column in GridView.Columns)
            {
                if (Column.HeaderText.ToString() == ColumnName)
                {
                    ReturnedColumn = Column;
                }
            }
            return ReturnedColumn;
        }

        protected void WindowsidTb_TextChanged(object sender, EventArgs e)
        {
            SetChecksFromWindow();
        }

        private void SetChecksFromWindow()
        {
            string Mail = MailTb.Text;
            string MailResponsibleTicket = ResponsableTicketTb.Text;
            string WindowsId = WindowsidTb.Text;

            SetChecks(Mail, MailResponsibleTicket, WindowsId);

        }



        private void SetChecks(string Mail, string MailResponsible, string WindowsId)
        {
            if (!string.IsNullOrEmpty(Mail))
            {
                BackupMailCB.Enabled = true;
                BackupDriveCB.Enabled = true;
            }
            else
            {
                BackupMailCB.Enabled = false;
                BackupDriveCB.Enabled = false;
            }

            if (!string.IsNullOrEmpty(Mail) && !string.IsNullOrEmpty(MailResponsible))
            {
                TranferCB.Enabled = true;
                AliasCB.Enabled = true;
            }
            else
            {
                TranferCB.Enabled = false;
                AliasCB.Enabled = false;
            }


            if (!string.IsNullOrEmpty(WindowsId))
            {
                DeleteADCB.Enabled = true;
            }
            else
            {
                DeleteADCB.Enabled = true;
            }

        }

       
    }
}
