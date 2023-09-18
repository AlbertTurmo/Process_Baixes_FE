using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reflection;
using System.ComponentModel.Design;

using Sql_Data;

// using ModernGui.Data;

namespace Baixes_Desktop
{
    public partial class ListForm : Form
    {
        private Form Active;
        public Panel ContainerPanel;
        List<GroupDto> ListGroupsDto;
        public DataTable GroupsDataTable;

        public ListForm()
        {
            InitializeComponent();
        }

        public ListForm(Panel ParentContainerPanel)
        {
            // Grups.ParentForm = ParentForm;
            ContainerPanel = ParentContainerPanel;
            InitializeComponent();
        }

        private void DataBind(StatusProcess StatusProcess)
        {

            List<LogPBajasA> ListLogPBajasA = SqlData_Bajas.GetTicketsByStatus(StatusProcess);

            DataGridViewGroups.DataSource = ListLogPBajasA;
            

        }


        public void Grups_Load(object sender, EventArgs e)
        {

            DataBind(StatusProcess.programmed);

            

            ListToDataTableConverter Converter = new ListToDataTableConverter();
            GroupsDataTable = Converter.ToDataTable(ListGroupsDto);

            //DataGridViewGroups.DataSource = GroupsDataTable;
            //SetColumns();

            //List<string> Result = ListGroupsDto.Select(o => o.Section).Distinct().ToList();

            //Result.Insert(0, "Tots");

            //SeccioCb.DataSource = Result;


        }

        private void GrupNameTb_KeyUp(object sender, KeyEventArgs e)
        {
            ReloadOrFilterGroups();

        }

        private void ReloadOrFilterGroups()
        {
            if (!String.IsNullOrWhiteSpace(GrupNameTb.Text.Trim()))
            {
                DataTable dtAfterSerach = SearchDataInDataGridViewOverSelectedFields(GrupNameTb.Text.Trim(), GroupsDataTable);
                DataGridViewGroups.DataSource = dtAfterSerach;
            }
            else
            {
                DataGridViewGroups.DataSource = GroupsDataTable;
            }
        }

        private DataTable SearchDataInDataGridViewOverSelectedFields(string SearchText, DataTable dt)
        {
            DataView DvForSearch = new DataView(dt)
            {
                // Apply search over selective fields.  
                // RowFilter = "Name Like '%" + searchText + "%' or Address Like '%" + searchText + "%' or Notes Like '%" + searchText + "%'"
                RowFilter = "Name Like '%" + SearchText + "%'"
            };

            DataTable NDt = DvForSearch.ToTable();

            return NDt;
        }

        private void SeccioCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(SeccioCb.Text.Trim()) && (SeccioCb.Text!="Tots") )
            {
                DataTable dtAfterSerach = FilterigBySections(SeccioCb.Text.Trim(), GroupsDataTable);
                DataGridViewGroups.DataSource = dtAfterSerach;
            }
            else
            {
                DataGridViewGroups.DataSource = GroupsDataTable;
            }

        }


        private DataTable FilterigBySections(string SearchText, DataTable dt)
        {
            DataView DvForSearch = new DataView(dt)
            {
                // Apply search over selective fields.  
                // RowFilter = "Name Like '%" + searchText + "%' or Address Like '%" + searchText + "%' or Notes Like '%" + searchText + "%'"
                RowFilter = $"Section = '{SearchText}'"
            };

            DataTable NDt = DvForSearch.ToTable();

            return NDt;
        }




        private void SetColumns()
        {
            SetColumn("GroupNumber", "N.", 20);
            SetColumn("Section", "Seccio", 60);
            SetColumn("Name", "Nom", 120);
            SetColumn("Adress", "Adreça", 120);
            SetColumn("Town", "Població", 80);
            SetColumn("PostalCode", "CP", 60);

        }

        private void SetColumn(string ColumnName, string Title, int Width)
        {
            DataGridViewGroups.Columns[ColumnName].FillWeight = Width;
            DataGridViewGroups.Columns[ColumnName].HeaderText = Title;
        }

        private void DataGridViewGroups_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Groups Grup = GetGrup();
            ElementForm GrupForm = new ElementForm(Grup);
            OpenChildrenForm(GrupForm);
        }

        private Groups GetGrup()
        {
            DataGridViewRow D = DataGridViewGroups.SelectedRows[0];
            DataGridViewCell Cell = D.Cells["GroupNumber"];
            int GroupId = int.Parse(Cell.Value.ToString());
            Groups Grup = (from Element in GetData.ListGroups where Element.GrupsId == GroupId select Element).FirstOrDefault();
            return Grup;
        }

        private void OpenChildrenForm(ElementForm ChildForm)
        {
            if (Active != null)
            {
                Active.Close();
            }
            // ActivateButton(BtnSender);
            Active = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            ContainerPanel.Controls.Add(ChildForm);
            ChildForm.BringToFront();
            ChildForm.Show();
        }

        

        private void DataGridViewGroups_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {


            // High light and searching apply over selective fields of grid.  
            if (e.RowIndex > -1 && e.ColumnIndex > -1 && DataGridViewGroups.Columns[e.ColumnIndex].Name == "Name")
            {
                // Check data for search  
                if (!String.IsNullOrWhiteSpace(GrupNameTb.Text.Trim()))
                {
                    string GridCellValue = e.FormattedValue.ToString();

                    // check the index of search text into grid cell.  
                    int StartIndexInCellValue = GridCellValue.ToLower().IndexOf(GrupNameTb.Text.Trim().ToLower());

                    // IF search text is exists inside grid cell then startIndexInCellValue value will be greater then 0 or equal to 0  
                    if (StartIndexInCellValue >= 0)
                    {
                        e.Handled = true;
                        e.PaintBackground(e.CellBounds, true);

                        //the highlite rectangle  
                        Rectangle hl_rect = new Rectangle
                        {
                            Y = e.CellBounds.Y + 2,
                            Height = e.CellBounds.Height - 5
                        };

                        //find the size of the text before the search word in grid cell data.  
                        string sBeforeSearchword = GridCellValue.Substring(0, StartIndexInCellValue);

                        //size of the search word in the grid cell data  
                        string sSearchWord = GridCellValue.Substring(StartIndexInCellValue, GrupNameTb.Text.Trim().Length);
                        Size s1 = TextRenderer.MeasureText(e.Graphics, sBeforeSearchword, e.CellStyle.Font, e.CellBounds.Size);
                        Size s2 = TextRenderer.MeasureText(e.Graphics, sSearchWord, e.CellStyle.Font, e.CellBounds.Size);
                        if (s1.Width > 5)
                        {
                            hl_rect.X = e.CellBounds.X + s1.Width - 5;
                            hl_rect.Width = s2.Width - 6;
                        }
                        else
                        {
                            hl_rect.X = e.CellBounds.X + 2;
                            hl_rect.Width = s2.Width - 6;
                        }

                        //color for showing highlighted text in grid cell  
                        SolidBrush hl_brush = new SolidBrush(Color.BlueViolet);
                        //paint the background behind the search word  
                        e.Graphics.FillRectangle(hl_brush, hl_rect);
                        hl_brush.Dispose();
                        e.PaintContent(e.CellBounds);
                    }
                }
            }
        }

        private void NomGrupLbl_DoubleClick(object sender, EventArgs e)
        {
            GrupNameTb.Text = string.Empty;
            ReloadOrFilterGroups();
        }

        private void OpenedLbl_Click(object sender, EventArgs e)
        {
            if(OpenedLbl.Text=="Oberts")
            {
                GetData.SetGroups(GetData.EstatGroup.Tancat);
                OpenedLbl.Text = "Tancats";
                OpenedLbl.BackColor = Color.IndianRed;
                OpenedLbl.ForeColor = Color.Black;


            }
            else
            if (OpenedLbl.Text == "Tancats")
            {
                GetData.SetGroups(GetData.EstatGroup.Tots);
                OpenedLbl.Text = "Tots";
                OpenedLbl.BackColor = Color.MediumBlue;
                OpenedLbl.ForeColor = Color.White;


            }
            else
            if (OpenedLbl.Text == "Tots")
            {
                GetData.SetGroups(GetData.EstatGroup.Obert);
                OpenedLbl.Text = "Oberts";
                OpenedLbl.BackColor = Color.MediumSeaGreen;
                OpenedLbl.ForeColor = Color.White;
            }



            ListGroupsDto = GetData.ListGroupsDto;

            ListToDataTableConverter converter = new ListToDataTableConverter();
            GroupsDataTable = converter.ToDataTable(ListGroupsDto);

            DataGridViewGroups.DataSource = GroupsDataTable;

        }
    }
}
