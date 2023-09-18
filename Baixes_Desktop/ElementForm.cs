using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static Baixes_Desktop.WeekTools;
using static System.Windows.Forms.LinkLabel;

namespace Baixes_Desktop
{

    public partial class ElementForm : Form
    {
        public Groups GroupForm;
        public static string NavigatorUrl;

        public ElementForm()
        {
            InitializeComponent();
        }

        public ElementForm(Groups Groups)
        {
            InitializeComponent();
            GroupForm = Groups;
            PaintWindows(Groups);
        }

        private void Grup_Load(object sender, EventArgs e)
        {

            int a = GroupForm.GrupsId;

            var c = this.Controls;

            LoopControls(this);


            string NewUrl = "https://www.google.es/maps/place/Avinguda+de+Mossèn+Jacint+Verdaguer,+38,+08130+Santa+Perp%C3%A8tua+de+Mogoda,+Barcelona,+Spain";

            NewUrl = GetUrl();

            WebBrowser_Map.Navigate(NewUrl);

        }

        private string GetUrl()
        {

            string Url = @"https://www.google.es/maps/place/";
            Url = $"{Url}{TipusViaTb.Text}+";
            Url = $"{Url}{NomViaTb.Text.Replace(' ', '+')},+";
            Url = $"{Url}{NumTb.Text},+";
            Url = $"{Url}{CodiPostalTb.Text}+";
            Url = $"{Url}{PoblacioTb.Text.Replace(' ', '+')},+";
            Url = $"{Url}{ProvinciaTb.Text.Replace(' ', '+')},+";
            Url = $"{Url}Spain";

            return Url;


        }

        private void LoopControls(Control Parent_Control)
        {
            foreach (Control Control in Parent_Control.Controls)
            {
                if ((Control is TextBox) || (Control is ComboBox))
                {
                    Control.Enter += ControlReceivedFocus;
                    Control.Leave += ControlLoseFocus;
                    Control.TextChanged += ControlTextChanged;

                    // C.BackColor = Color.Black;
                }

                if (Control is Label)
                {
                    Control.BackColor = Color.FromArgb(180, 220, 220);
                }

                LoopControls(Control);
            }
        }


        private void ControlTextChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(sender + " Text Changed.");

            if (!Save_Btn.Enabled)
            {

                Save_Btn.Enabled = true;
            }
        }

        private void ControlReceivedFocus(object sender, EventArgs e)
        {

            Control Control = (Control)sender;
            Control.BackColor = Color.FromArgb(200, 190, 255);

            Debug.WriteLine(sender + " received focus.");
        }

        private void ControlLoseFocus(object sender, EventArgs e)
        {

            Control c = (Control)sender;
            c.BackColor = Color.White;

            Debug.WriteLine(sender + " lose focus.");
            Debug.WriteLine(c.Text + " lose focus.");
        }



        private void PaintWindows(Groups Group)
        {
            TP_Grup.Text = $"{Group.NomGrup} - Dades 1";
            TP_Grup_D2.Text = $"{Group.NomGrup} - Dades 2";
            TP__Grup_Map.Text = $"{Group.NomGrup} - Mapa";


            GrupIdTb.Text = $"{Group.GrupsId}";
            GrupNameTb.Text = $"{Group.NomGrup}";

            ObertesCb.Text = $"{Group.Obertes.Oberta}";
            ObservObertTb.Text = $"{Group.Obertes.Observacions}";

            SessionaFestiusCb.Text = $"{Group.Festius.SessionaFestius}";
            ObservFestTb.Text = $"{Group.Festius.Observacions}";

            SeccioTb.Text = $"{Group.Sections.Section}";

            TipusViaTb.Text = $"{Group.Adreces.tv}";
            NomViaTb.Text = $"{Group.Adreces.c}";
            NumTb.Text = $"{Group.Adreces.num}";
            AnumTb.Text = $"{Group.Adreces.anum}";

            PisTb.Text = $"{Group.Adreces.ps}";
            PortaTb.Text = $"{Group.Adreces.pt}";

            CodiPostalTb.Text = $"{Group.Adreces.cp:00000}";
            PoblacioTb.Text = $"{Group.Adreces.poblacio}";
            ProvinciaTb.Text = $"{Group.Adreces.provincia}";

            ObservacionsTb.Text = $"{Group.Adreces.observacions}";
            DisricteTb.Text = $"{Group.Adreces.districte}";
            ComarcaTb.Text = $"{Group.Adreces.Comarca}";
            LocalTb.Text = $"{Group.Locals.Local}";

            LatitudTb.Text = $"{Group.Adreces.LatLon.lat}";
            LongitudTb.Text = $"{Group.Adreces.LatLon.lon}";


            LinkLblAdress.Text = $"{Group.Adreces.Hyperlink}";

            MailTb.Text = $"{Group.Mails.EMail}";

            DataTable Contacts = GrupForm_Ext.LoadSubTable(Group, GrupForm_Ext.TableType.Contacts);
            DataGridViewContactes.DataSource = Contacts;

            DataTable Servers = GrupForm_Ext.LoadSubTable(Group, GrupForm_Ext.TableType.Servers);
            DataGridViewServers.DataSource = Servers;

            DataTable Transports = GrupForm_Ext.LoadSubTable(Group, GrupForm_Ext.TableType.Transports);
            DataGridViewTransports.DataSource = Transports;

            DataTable DataTableHorary = GrupForm_Ext.LoadSubTable(Group, GrupForm_Ext.TableType.Horary);
            DataGridViewHours.DataSource = DataTableHorary;

        }









        private void LinkLblAdress_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string newurl = @"https://www.google.es/maps/place/Avinguda+de+Mossèn+Jacint+Verdaguer,+38,+08130+Santa+Perp%C3%A8tua+de+Mogoda,+Barcelona,+Spain";
            System.Diagnostics.Process.Start(newurl);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Horari NewStart = new Horari
            {
                GroupsId = this.GroupForm.GrupsId,
                WeekDay = WeekTools.DaysOfWeek.Tuesday.ToString(),
                Hour = new TimeSpan(20, 00, 00)
            };

            Horari NewEnd = new Horari
            {
                GroupsId = this.GroupForm.GrupsId,
                WeekDay = WeekTools.DaysOfWeek.Tuesday.ToString(),
                Hour = new TimeSpan(21, 40, 00)
            };

            Groups Group = GetData.GetGroup(this.GroupForm.GrupsId);

            GetData.SaveData(Group, NewStart, NewEnd);


        }

        private void DataGridViewHours_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            if (e.Exception.Message == "No se reconoce la cadena como un valor de TimeSpan válido.")
            {

                DataTable Dt_New = (DataTable)DataGridViewHours.DataSource;

                TimeSpan? NewTimeSpan = new TimeSpan();


                Dt_New.Rows[e.RowIndex][e.ColumnIndex] = NewTimeSpan;

                DataGridViewHours.DataSource = Dt_New;
                DataGridViewHours.Refresh();

                // MessageBox.Show(e.Exception.Message, "Data Error BB");


            }
            else
            {

                // -2146233033
                // -2146233033

                // Console.WriteLine(e.Exception.Message);

                MessageBox.Show(e.Exception.Message, "Data Error");

            }






        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            List<Horari> ListHorari = GetNewHorari(8);

            List<Contactes> ListConctactes = GetNewContactes(8);

            int GroupId = int.Parse(GrupIdTb.Text);

            Groups Group = null;


            if (true)
            {
                Group = new Groups()
                {
                    GrupsId = GroupId,
                    NomGrup = GrupNameTb.Text,

                    Adreces = new Adreces()
                    {
                        tv = TipusViaTb.Text.GetStringValue(),
                        c = NomViaTb.Text,
                        num = double.Parse(NumTb.Text),
                        anum = AnumTb.Text,
                        ps = PisTb.Text,
                        pt = PortaTb.Text,
                        cp = double.Parse(CodiPostalTb.Text),
                        poblacio = PoblacioTb.Text,
                        provincia = ProvinciaTb.Text,
                    },

                    Obertes = new Obertes()
                    {
                        ObertesId = GroupId,
                        Oberta = ObertesCb.Text,
                        Observacions = ObservObertTb.Text,
                    },

                    Festius = new Festius()
                    {
                        FestiusId = GroupId,
                        SessionaFestius = SessionaFestiusCb.Text,
                        Observacions = ObservFestTb.Text
                    },

                    Mails = new Mails()
                    {
                        MailsId = GroupId,
                        EMail = MailTb.Text,
                    },


                    Horari = GetNewHorari(GroupId),

                    Contactes = GetNewContactes(GroupId)

                };

                GetData.SaveData(Group);

            }


        }

        private List<Contactes> GetNewContactes(int GroupId)
        {
            DataTable Dt_New = (DataTable)DataGridViewContactes.DataSource;

            List<Contactes> ListContactes = ContactesTools.ConvertDataTableToListContactes(Dt_New, GroupId);
            return ListContactes;
        }

        private List<Horari> GetNewHorari(int GroupId)
        {
            DataTable Dt_New = (DataTable)DataGridViewHours.DataSource;

            List<Horari> ListHorari = WeekTools.ConvertDataTableToList(Dt_New, GroupId);
            return ListHorari;
        }








        private void GetDifferences()
        {
            DataTable Dt_New = (DataTable)DataGridViewHours.DataSource;
            DataTable Dt_Old = WeekTools.GetDataTable(GroupForm.Horari);

            foreach (DataRow DataRow_New in Dt_New.Rows)
            {
                int IndexRow = Dt_New.Rows.IndexOf(DataRow_New);
                int IndexColumn = 0;
                string WeekDay = Dt_Old.Columns[IndexColumn].ColumnName.Trim();

                object[] DataRow_New_ItemArray = DataRow_New.ItemArray;

                foreach (object Item_Array in DataRow_New_ItemArray)
                {
                    TimeSpan TimeSpan_New = new TimeSpan();
                    TimeSpan TimeSpan_Old = new TimeSpan();

                    if (!string.IsNullOrEmpty(Item_Array.ToString()))
                    {
                        TimeSpan_New = (TimeSpan)Item_Array;
                    }

                    if (!string.IsNullOrEmpty(Dt_Old.Rows[IndexRow][IndexColumn].ToString()))
                    {
                        TimeSpan_Old = (TimeSpan)Dt_Old.Rows[IndexRow][IndexColumn];
                    }

                    if (TimeSpan_New != TimeSpan_Old)
                    {
                        if (TimeSpan_Old.Ticks == 0)
                        {
                            GetData.Hours.Modify_Row_Hour(GroupForm.GrupsId, WeekDay, TimeSpan_New, TimeSpan_Old, GetData.Hours.RowAction.Add);
                        }

                        if (TimeSpan_New.Ticks == 0)
                        {
                            if (TimeSpan_Old.Ticks > 0)
                            {
                                GetData.Hours.Modify_Row_Hour(GroupForm.GrupsId, WeekDay, TimeSpan_New, TimeSpan_Old, GetData.Hours.RowAction.Delete);
                            }
                        }

                        if (TimeSpan_New.Ticks > 0)
                        {
                            if (TimeSpan_Old.Ticks > 0)
                            {
                                GetData.Hours.Modify_Row_Hour(GroupForm.GrupsId, WeekDay, TimeSpan_New, TimeSpan_Old, GetData.Hours.RowAction.Update);
                            }
                        }

                        Console.WriteLine(TimeSpan_New);
                    }

                    IndexColumn++;

                }

                Console.WriteLine(DataRow_New);
            }
        }


        private bool CheckModifications(bool Modified)
        {
            Modified = ChekModified(Modified, this.GroupForm.NomGrup, GrupNameTb.Text);

            Modified = ChekModified(Modified, TipusViaTb.Text, GroupForm.Adreces.tv);
            Modified = ChekModified(Modified, NomViaTb.Text, GroupForm.Adreces.c);
            Modified = ChekModified(Modified, NumTb.Text, GroupForm.Adreces.num.GetStringValue());
            Modified = ChekModified(Modified, AnumTb.Text, GroupForm.Adreces.anum.GetStringValue());
            Modified = ChekModified(Modified, PisTb.Text, GroupForm.Adreces.ps.GetStringValue());
            Modified = ChekModified(Modified, PortaTb.Text, GroupForm.Adreces.pt.GetStringValue());
            Modified = ChekModified(Modified, CodiPostalTb.Text, $"{GroupForm.Adreces.cp:00000}");
            Modified = ChekModified(Modified, PoblacioTb.Text, GroupForm.Adreces.poblacio.GetStringValue());
            Modified = ChekModified(Modified, ProvinciaTb.Text, GroupForm.Adreces.provincia.GetStringValue());
            Modified = ChekModified(Modified, ObservacionsTb.Text, GroupForm.Adreces.observacions.GetStringValue());
            Modified = ChekModified(Modified, DisricteTb.Text, GroupForm.Adreces.districte.GetStringValue());
            Modified = ChekModified(Modified, ComarcaTb.Text, GroupForm.Adreces.Comarca.GetStringValue());


            Modified = ChekModified(Modified, LocalTb.Text, GroupForm.Locals.Local.GetStringValue());
            Modified = ChekModified(Modified, MailTb.Text, GroupForm.Mails.EMail.GetStringValue());
            return Modified;
        }

        private static bool ChekModified(bool Modified, string Value1, string Value2)
        {
            if (Value1 != Value2)
            {
                Modified = true;
            }

            return Modified;
        }

        private void Close_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GrupForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ListForm GrupsList = new ListForm();
            GrupsList.Grups_Load(sender, e);


        }

        private void GrupNameTb_Enter(object sender, EventArgs e)
        {
            GrupNameTb.BackColor = Color.Beige;

            //  GrupNameTb.Focused;

        }



        private void TP_Map_Enter(object sender, EventArgs e)
        {
            //string NewUrl = GetUrl();

            //WebBrowser_Map.Navigate(NewUrl);

        }
    }
}
