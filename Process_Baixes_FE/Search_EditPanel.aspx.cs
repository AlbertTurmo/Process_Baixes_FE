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

        protected void EditPanelValidateButton_Click(object sender, EventArgs e)
        {
            ValidateEditPanel();

        }

        private bool ValidateEditPanel()
        {
            bool Errors = false;
            bool Exists1 = false;
            bool Exists2 = false;
            string Mail = MailTb.Text;
            string ResponsibleMail = ResponsableTicketTb.Text;
            bool ItsEmpty1 = string.IsNullOrEmpty(Mail);
            bool ItsEmpty2 = string.IsNullOrEmpty(ResponsibleMail);

            string Error = string.Empty;

            if (!ItsEmpty1)
            {

                bool ItsCorrect = Check.GetIfCorrectFormatMail(Mail);

                if (!ItsCorrect)
                {
                    Error = "Error: el formato del correo es incorrecto.";
                    MailTb.BorderColor = Color.Red;
                    MailTb.ForeColor = Color.Red;
                    SetErrorInLabel(Error);
                }
                else
                {
                    Exists1 = CheckIfUserExistsInGoogle(Mail);

                    if (!Exists1)
                    {
                        MailTb.ForeColor = Color.Red;
                        Error = "Error: el correo del usuario no existe.";
                        SetErrorInLabel(Error);
                    }
                    else
                    {
                        MailTb.ForeColor = Color.Green;
                    }
                }

            }

            if (!ItsEmpty2)
            {
                bool ItsCorrect = Check.GetIfCorrectFormatMail(ResponsibleMail);

                if (!ItsCorrect)
                {
                    Error = $"{Error}<br />Error: el formato del correo del responsable no es incorrecto.";

                    ResponsableTicketTb.ForeColor = Color.Red;
                    SetErrorInLabel(Error);
                }
                else
                {
                    Exists2 = CheckIfUserExistsInGoogle(ResponsibleMail);

                    if (!Exists2)
                    {
                        Error = $"{Error}<br />Error: el correo del responsable no existe.";
                        ResponsableTicketTb.ForeColor = Color.Red;
                        SetErrorInLabel(Error);
                    }
                    else
                    {
                        ResponsableTicketTb.ForeColor = Color.Green;
                    }
                }

            }

            if ((Exists1 && Exists2) || (Exists1 && ItsEmpty2) || (Exists2 || ItsEmpty1))
            {
                // release error
                ErrorLabel.Visible = false;
                ResponsableTicketTb.ForeColor = Color.Green;
                MailTb.ForeColor = Color.Green;
                EditPanelAcceptButton.Visible = true;
                EditPanelValidateButton.Visible = false;
            }
            else
            {
                EditPanelAcceptButton.Visible = false;
                EditPanelValidateButton.Visible = true;
                Errors = true;

            }

            return Errors;


        }

        private void SetErrorInLabel(string Error)
        {
            ErrorLabel.Text = Error;
            ErrorLabel.ForeColor = Color.Red;
            ErrorLabel.Visible = true;
        }

        protected void EditPanelCloseButton_Click(object sender, ImageClickEventArgs e)
        {
            ResetEditPanel();
            LeavePanel();
        }

        protected void EditPanelCancelButton_Click(object sender, EventArgs e)
        {
            ResetEditPanel();
            LeavePanel();
        }

        private void ResetEditPanel()
        {

            TicketTb.Text = string.Empty;
            NameTb.Text = string.Empty;
            EmployeeIdTb.Text = string.Empty;
            WindowsidTb.Text = string.Empty;
            MailTb.Text = string.Empty;
            ResponsableTicketTb.Text = string.Empty;
            ResponsableADTb.Text = string.Empty;
            BackupMailCB.Checked = false;
            TranferCB.Checked = false;
            DeleteADCB.Checked = false;
            BackupDriveCB.Checked = false;
            AliasCB.Checked = false;

            MailTb.ForeColor = Color.Black;
            ResponsableTicketTb.ForeColor = Color.Black;

            EditPanelAcceptButton.Visible = false;
            EditPanelValidateButton.Visible = true;

        }

        private void LeavePanel()
        {
            if (Search.Editmode == EditMode.ProgrammingNewUnsubscribe)
            {
                ModalPopupEditPanel.Hide();
                ModalPopupFoundPanel.Show();
            }
            else
            if (Search.Editmode == EditMode.ReprogrammingUnsubscribe)
            {
                ModalPopupEditPanel.Hide();
            }
        }


        /* EDIT PANEL  (EVENTS DE EDIT PANEL) */
        #region *** EDIT PANEL ***

        protected void DateTb_TextChanged(object sender, EventArgs e)
        {
            // string date = DateTb.Text;
            // DateTime NewDateTime = DateTime.Parse(date);


            // DayOfWeek day = NewDateTime.DayOfWeek;

            // Per forçar que sigui diumenge
            //day = DayOfWeek.Sunday;

            // Debug.WriteLine(day);
            // Debug.WriteLine((int)day);
            // int nday = (int)day;
            // int DefaultHour = 18;
            //if (nday > 4 || nday == 0)
            //{
            //    DefaultHour = 15;
            //}

            // hourTb.Text = TimeSpan.FromHours(DefaultHour).ToString();

        }

        protected void EditPanelAcceptButton_Click(object sender, EventArgs e)
        {

            bool WithErrors = ValidateEditPanel();

            if(!WithErrors)
            {
                //DateTime date = DateTime.Parse(DateTb.Text);
                //TimeSpan hour = TimeSpan.Parse(hourTb.Text);

                if (Editmode == EditMode.ProgrammingNewUnsubscribe)
                {
                    Literal1.Text = "PROGRAMACIÓN NUEVA BAJA";
                }
                else
                if (Editmode == EditMode.ReprogrammingUnsubscribe)
                {
                    Literal1.Text = "REPROGRAMACIÓN DE BAJA";
                }
                Literal2.Text = "Programando la baja de:";
                Literal3.Text = NameTb.Text;

                bool DeleteGUBool = false;

                if (!string.IsNullOrEmpty(MailTb.Text))
                {
                    DeleteGUBool = true;
                }

                string DeleteGU = $"Eliminar Usuario Google = {GetBooleanSiNo(DeleteGUBool)}";
                string BackupMail = $"Backup Mail = {GetBooleanSiNo(BackupMailCB.Checked)}";
                string BackupDrive = $"Backup Drive = {GetBooleanSiNo(BackupDriveCB.Checked)}";
                string Tranfer = $"Transferir = {GetBooleanSiNo(TranferCB.Checked)}";
                string Alias = $"Crear Alias = {GetBooleanSiNo(AliasCB.Checked)}";
                string Delete = $"Eliminar Usuario AD = {GetBooleanSiNo(DeleteADCB.Checked)}";
                string Result = $"<br /> {DeleteGU} <br /> {BackupMail} <br /> {BackupDrive} <br /> {Tranfer} <br /> {Delete} <br /> {Alias} ";

                LableResult.Text = Result;


                //Literal4.Text = $"Para el {date.ToLongDateString()}";
                //Literal5.Text = $"A las: {hour:hh\\:mm} hs.";

                ModalPopupEditPanel.Hide();
                ModalPopupConfirmPanel.Show();

            }



        }

        private string GetBooleanSiNo(bool Checked)
        {
            string Result = (Checked) ? "Si" : "No";
            return Result;
        }


        #endregion



    }
}