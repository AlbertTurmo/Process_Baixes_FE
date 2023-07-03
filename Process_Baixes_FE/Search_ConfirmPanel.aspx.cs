using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows.Controls;
using CommonTools;
using GoogleServices;
using Sql_Data;

using GoogleUser = Google.Apis.Admin.Directory.directory_v1.Data.User;

namespace UnsubscribeR
{
    public partial class Search
    {


        #region ** CONFIRM PANEL BUTTONS ***

        protected void ConfirmPanelAcceptButton_Click(object sender, EventArgs e)
        {

            if (Editmode == EditMode.ProgrammingNewUnsubscribe)
            {
                InsertUnsubscribe();
                ResetPanels();
            }
            else
            if (Editmode == EditMode.ReprogrammingUnsubscribe)
            {
                UpdateUnsubscribe();
                ResetPanels();
            }

        }

        private void InsertUnsubscribe()
        {

            bool HasMail = (!string.IsNullOrEmpty(MailTb.Text.Trim()));
            bool itsCorrect = int.TryParse(EmployeeIdTb.Text, out int EmployeeNumber);
            int EmployeeIdInt = (itsCorrect) ? EmployeeNumber : 0;

            LogPBajasA NewLogPBajasA = new LogPBajasA
            {
                Ticket = TicketTb.Text,
                Name = NameTb.Text,
                EmployeeNumber = EmployeeIdInt,
                WindowsId = WindowsidTb.Text,
                Mail = MailTb.Text,
                ResponsableTicket = ResponsableTicketTb.Text,
                ResponsableAd = ResponsableADTb.Text,
                BackupMail = BackupMailCB.Checked,
                BackupDrive = BackupDriveCB.Checked,
                Transfer = TranferCB.Checked,
                DeleteAd = DeleteADCB.Checked,
                CreateAlias = AliasCB.Checked,
                Nif = EmpleadoEditPanel.dni, // UUser.Dni,
                StartProcess = DateTime.Now,
                ChangeStatusP = DateTime.Now,
                StatusTicket = "Abierto",
                StatusProcess = StatusProcess.programmed.ToString()
            };


            LogPBajasA NewLogPBajasAResult = SqlData_Bajas.Create(NewLogPBajasA);

            Exports NewExport = new Exports()
            {
                InicioProceso = DateTime.Now,
                IssueKey = TicketTb.Text,
                StatusKey = "Abierto",
                EmpleadoId = EmployeeIdInt,
                Nombre = NameTb.Text,
                Nif = EmpleadoEditPanel.dni, // UUser.Dni,
                Mail = MailTb.Text,
                WindowsId = WindowsidTb.Text,
                MailResponsible = ResponsableTicketTb.Text,
                StatusExport = Sql_Data_Utils.GetStatusByBoolean(BackupMailCB.Checked).ToString().ToLower(),
                UpdateProcess = DateTime.Now,
                StatusDrive = Sql_Data_Utils.GetStatusByBoolean(BackupDriveCB.Checked).ToString().ToLower(),
                StatusTransfer = Sql_Data_Utils.GetStatusByBoolean(TranferCB.Checked).ToString().ToLower(),
                StatusProcess = StatusProcess.programmed.ToString().ToLower(),
                StatusAd = Sql_Data_Utils.GetStatusByBoolean(DeleteADCB.Checked).ToString().ToLower(),
                StatusAlias = Sql_Data_Utils.GetStatusByBoolean(AliasCB.Checked).ToString().ToLower(),
                StatusGoogleUser = Sql_Data_Utils.GetStatusByBoolean(HasMail).ToString().ToLower(),
            };


            Exports NewExportResult = SqlData_Exports.Create(NewExport);
         

        }

        protected void UpdateUnsubscribe()
        {

            if(!string.IsNullOrEmpty(TicketTb.Text))
            {

                LogPBajasA LogPBajasA = SqlData_Bajas.GetLogPBajasAByTicket(TicketTb.Text);

                LogPBajasA.Mail = MailTb.Text;
                LogPBajasA.WindowsId = WindowsidTb.Text;
                LogPBajasA.ResponsableTicket = ResponsableTicketTb.Text;
                LogPBajasA.BackupMail = BackupMailCB.Checked;
                LogPBajasA.BackupDrive = BackupDriveCB.Checked;
                LogPBajasA.Transfer = TranferCB.Checked;
                LogPBajasA.CreateAlias = AliasCB.Checked;
                LogPBajasA.DeleteAd = DeleteADCB.Checked;

                LogPBajasA NewLogPBajasA = SqlData_Bajas.UpdateLogPBajas(LogPBajasA);


                bool HasMail = (!string.IsNullOrEmpty(MailTb.Text.Trim()));

                Exports Export = SqlData_Exports.GetExportsAByTicket(TicketTb.Text);

                Export.Mail = MailTb.Text;
                Export.WindowsId = WindowsidTb.Text;
                Export.MailResponsible = ResponsableTicketTb.Text;
                Export.StatusExport = Sql_Data_Utils.GetStatusByBoolean(BackupMailCB.Checked).ToString().ToLower();
                Export.UpdateProcess = DateTime.Now;
                Export.StatusDrive = Sql_Data_Utils.GetStatusByBoolean(BackupDriveCB.Checked).ToString().ToLower();
                Export.StatusTransfer = Sql_Data_Utils.GetStatusByBoolean(TranferCB.Checked).ToString().ToLower();
                Export.StatusProcess = StatusProcess.programmed.ToString().ToLower();
                Export.StatusAd = Sql_Data_Utils.GetStatusByBoolean(DeleteADCB.Checked).ToString().ToLower();
                Export.StatusAlias = Sql_Data_Utils.GetStatusByBoolean(AliasCB.Checked).ToString().ToLower();
                Export.StatusGoogleUser = Sql_Data_Utils.GetStatusByBoolean(HasMail).ToString().ToLower();

                SqlData_Exports.UpdateExports(Export);

            }

           







            //int index = ProgrammedGridView.SelectedIndex;
            //if (index != -1)
            //{
            //    DataRow row = DataTableScheduled.Rows[index];
            //    int id = (int)row["id"];
            //    // UUser.Observations = observationsTb.Text;
            //    // string date = DateTb.Text;
            //    // UnsubscribeR.UUser.Date = DateTime.Parse(date);

            //    // string hour = hourTb.Text;
            //    // UnsubscribeR.UUser.Hour = TimeSpan.Parse(hour);

            //    DateTime newDT = UUser.Date.Add(UUser.Hour);
            //    UUser.DateHour = newDT.ToString();
            //    UUser.Condition.Now = DateTime.Now.ToString();

            //    // UnsubscribeR.UUser.EntrevistaSalida = EntrevistaSCB.Checked;

            //    // ConnectSql.InsertLog(new Log(SessionUser, "Programación", "Baja reprogramada.", UUser.Name, UUser.WindowsId, Log.Encrypted.True));

            //    // connectSql.canceledUser(id);
            //    // UUser.EncryptUser();

            //    // ConnectSql.UpdatedUser(id);

            //    DataBind(StatusProcess.programmed);
            //}

        }

        private void ResetPanels()
        {
            ModalPopupStatePanel.Hide();
            ModalPopupConfirmPanel.Hide();
            ModalPopupEditPanel.Hide();
            ModalPopupFoundPanel.Hide();
            // DateTb.Text = string.Empty;

            ProgrammedGridView.SelectedIndex = -1;
            // GetListScheduled();

            DataBind(StatusProcess.programmed);
        }


        protected void ConfirmPanelCancelButton_Click(object sender, EventArgs e)
        {

            ModalPopupConfirmPanel.Hide();
            ModalPopupEditPanel.Show();

        }







        #endregion ** CONFIRM PANEL BUTTONS ***






    }
}