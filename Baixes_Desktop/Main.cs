using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baixes_Desktop
{
    public partial class Main : Form
    {
        private Form Active;

        public Main()
        {
            InitializeComponent();
            ListForm ListForm = new ListForm(ContainerPanel);
            OpenChildrenForm(ListForm);

        }

        private void GrupsBtn_Click(object sender, EventArgs e)
        {
            ListForm G = new ListForm(ContainerPanel);
            OpenChildrenForm(G);
        }


        public void OpenChildrenForm(Form ChildForm)
        {
            if (Active != null)
            {
                Active.Close();
            }
            Active = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            ContainerPanel.Controls.Add(ChildForm);
            ChildForm.BringToFront();
            ChildForm.Show();

        }


        public void OpenGrup(Groups Group)
        {
            ElementForm GrupForm = new ElementForm
            {
                GroupForm = Group,
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            ContainerPanel.Controls.Add(GrupForm);
            GrupForm.BringToFront();
            GrupForm.Show();

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void ObrirGrupBtn_Click(object sender, EventArgs e)
        {
            Groups Group = new Groups();

            OpenGrup(Group);

            


        }
    }
}
