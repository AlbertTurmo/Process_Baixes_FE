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
using WebButton = System.Web.UI.WebControls.Button;
using Sql_Data;

using GoogleUser = Google.Apis.Admin.Directory.directory_v1.Data.User;

namespace UnsubscribeR
{
    public partial class Search
    {


        protected void FoundsPanelCancelButton_Click(object sender, EventArgs e)
        {
            ModalPopupFoundPanel.Hide();
            FoundsGridView.SelectedIndex = -1;
        }

        #region *** FOUNDS PANEL BUTTONS ***

        protected void FoundsPanelCloseButton_Click(object sender, ImageClickEventArgs e)
        {
            ModalPopupFoundPanel.Hide();
            FoundsGridView.SelectedIndex = -1;
        }

        protected void FoundsGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = FoundsGridView.SelectedIndex;

            if (index != -1)
            {
                CreateEditPanelWithEmployee();
            }
        }

        private void CreateEditPanelWithEmployee()
        {
            Editmode = EditMode.ProgrammingNewUnsubscribe;

            GridViewRow GridViewRow = FoundsGridView.SelectedRow;

            string EmployeeNumberSt = GetCellByName(GridViewRow, "EMPLEADO").Text;

            bool SuccesNumber = int.TryParse(EmployeeNumberSt, out int EmployeeNumber);

            if(SuccesNumber)
            {
                // string NombreCompleto = GridViewRow.Cells[1].Text; // buscador que ja tinc per nom columna.
                EmpleadoEditPanel = (from Element in ListEmpleado where (Element.empleadoId == EmployeeNumber) select Element).FirstOrDefault();
                SetEditPanelFromEmpleado(EmpleadoEditPanel);
                ModalPopupFoundPanel.Hide();
                ModalPopupEditPanel.Show();
            }

        }

        #endregion *** FOUNDS PANEL BUTTONS ***




        #region *** FOUNDS GV EVENTS ****
        protected void FoundsGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor; this.style.backgroundColor='Gray'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");

                e.Row.Attributes.Add("ondblclick", "this.originalstyle=this.style.backgroundColor; this.style.backgroundColor='red'");
                e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(FoundsGridView, "Select$" + e.Row.RowIndex);

                //  e.Row.Attributes.Add("ondClick", "this.originalstyle=this.style.backgroundColor; this.style.backgroundColor='red'");
                // e.Row.Attributes["onClick"] = Page.ClientScript.GetPostBackClientHyperlink(LocatedGV, "Select$" + e.Row.RowIndex);


                e.Row.ToolTip = "Doble Clic para seleccionar este registro....";
            }
        }

        protected void FoundsGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dtrslt = (DataTable)ViewState["dirStateLocated"];
            if (dtrslt.Rows.Count > 0)
            {
                if (Convert.ToString(ViewState["sortdrLocated"]) == "Asc")
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Desc";
                    ViewState["sortdrLocated"] = "Desc";
                }
                else
                {
                    dtrslt.DefaultView.Sort = e.SortExpression + " Asc";
                    ViewState["sortdrLocated"] = "Asc";
                }

                FoundsGridView.DataSource = dtrslt;
                FoundsGridView.DataBind();

            }
        }


        protected void FoundsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            FoundsGridView.PageIndex = e.NewPageIndex;
            BindData();

            ModalPopupFoundPanel.Show();
        }

        private void BindData()
        {
            // LocatedGV.DataSource = DataTableLocated;
            FoundsGridView.DataSource = ListEmpleado;
            FoundsGridView.DataBind();
        }

        #endregion *** FOUNDS GV EVENTS ****

    }
}