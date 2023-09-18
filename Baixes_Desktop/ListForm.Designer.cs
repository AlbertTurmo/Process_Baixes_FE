
namespace Baixes_Desktop
{
    partial class ListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.SeccioCb = new System.Windows.Forms.ComboBox();
            this.SeccioLbl = new System.Windows.Forms.Label();
            this.NomGrupLbl = new System.Windows.Forms.Label();
            this.GrupNameTb = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.DataGridViewGroups = new System.Windows.Forms.DataGridView();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ToolTip_GL = new System.Windows.Forms.ToolTip(this.components);
            this.OpenedLbl = new System.Windows.Forms.Label();
            this.HeaderPanel.SuspendLayout();
            this.CenterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.HeaderPanel.Controls.Add(this.SeccioCb);
            this.HeaderPanel.Controls.Add(this.SeccioLbl);
            this.HeaderPanel.Controls.Add(this.OpenedLbl);
            this.HeaderPanel.Controls.Add(this.NomGrupLbl);
            this.HeaderPanel.Controls.Add(this.GrupNameTb);
            this.HeaderPanel.Controls.Add(this.panel1);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(1228, 57);
            this.HeaderPanel.TabIndex = 0;
            // 
            // SeccioCb
            // 
            this.SeccioCb.FormattingEnabled = true;
            this.SeccioCb.Location = new System.Drawing.Point(471, 13);
            this.SeccioCb.Name = "SeccioCb";
            this.SeccioCb.Size = new System.Drawing.Size(175, 21);
            this.SeccioCb.TabIndex = 18;
            this.SeccioCb.SelectedIndexChanged += new System.EventHandler(this.SeccioCb_SelectedIndexChanged);
            // 
            // SeccioLbl
            // 
            this.SeccioLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(220)))));
            this.SeccioLbl.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeccioLbl.Location = new System.Drawing.Point(381, 14);
            this.SeccioLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SeccioLbl.Name = "SeccioLbl";
            this.SeccioLbl.Size = new System.Drawing.Size(85, 20);
            this.SeccioLbl.TabIndex = 17;
            this.SeccioLbl.Text = "Secció :";
            this.SeccioLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NomGrupLbl
            // 
            this.NomGrupLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(220)))));
            this.NomGrupLbl.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomGrupLbl.Location = new System.Drawing.Point(31, 12);
            this.NomGrupLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NomGrupLbl.Name = "NomGrupLbl";
            this.NomGrupLbl.Size = new System.Drawing.Size(97, 20);
            this.NomGrupLbl.TabIndex = 5;
            this.NomGrupLbl.Text = "Nom Grup :";
            this.NomGrupLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTip_GL.SetToolTip(this.NomGrupLbl, "Doble Click per esborrar el contingut.");
            this.NomGrupLbl.DoubleClick += new System.EventHandler(this.NomGrupLbl_DoubleClick);
            // 
            // GrupNameTb
            // 
            this.GrupNameTb.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrupNameTb.Location = new System.Drawing.Point(132, 12);
            this.GrupNameTb.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.GrupNameTb.Name = "GrupNameTb";
            this.GrupNameTb.Size = new System.Drawing.Size(237, 22);
            this.GrupNameTb.TabIndex = 4;
            this.GrupNameTb.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GrupNameTb_KeyUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.panel1.Location = new System.Drawing.Point(1188, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(40, 633);
            this.panel1.TabIndex = 3;
            // 
            // CenterPanel
            // 
            this.CenterPanel.Controls.Add(this.DataGridViewGroups);
            this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterPanel.Location = new System.Drawing.Point(34, 57);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(1160, 624);
            this.CenterPanel.TabIndex = 1;
            // 
            // DataGridViewGroups
            // 
            this.DataGridViewGroups.AllowUserToAddRows = false;
            this.DataGridViewGroups.AllowUserToDeleteRows = false;
            this.DataGridViewGroups.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(250)))));
            this.DataGridViewGroups.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.DataGridViewGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewGroups.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.DataGridViewGroups.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridViewGroups.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewGroups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DataGridViewGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewGroups.DefaultCellStyle = dataGridViewCellStyle11;
            this.DataGridViewGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewGroups.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DataGridViewGroups.Location = new System.Drawing.Point(0, 0);
            this.DataGridViewGroups.Name = "DataGridViewGroups";
            this.DataGridViewGroups.RowHeadersVisible = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(215)))), ((int)(((byte)(245)))));
            this.DataGridViewGroups.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DataGridViewGroups.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataGridViewGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewGroups.Size = new System.Drawing.Size(1160, 624);
            this.DataGridViewGroups.TabIndex = 0;
            this.DataGridViewGroups.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewGroups_CellDoubleClick);
            this.DataGridViewGroups.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DataGridViewGroups_CellPainting);
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 57);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(34, 656);
            this.LeftPanel.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1194, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(34, 656);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(34, 681);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1160, 32);
            this.panel3.TabIndex = 4;
            // 
            // ToolTip_GL
            // 
            this.ToolTip_GL.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ToolTip_GL.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ToolTip_GL.ToolTipTitle = "Help";
            // 
            // OpenedLbl
            // 
            this.OpenedLbl.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.OpenedLbl.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenedLbl.ForeColor = System.Drawing.Color.White;
            this.OpenedLbl.Location = new System.Drawing.Point(680, 14);
            this.OpenedLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.OpenedLbl.Name = "OpenedLbl";
            this.OpenedLbl.Size = new System.Drawing.Size(97, 20);
            this.OpenedLbl.TabIndex = 5;
            this.OpenedLbl.Text = "Oberts";
            this.OpenedLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OpenedLbl.Click += new System.EventHandler(this.OpenedLbl_Click);
            this.OpenedLbl.DoubleClick += new System.EventHandler(this.NomGrupLbl_DoubleClick);
            // 
            // GrupsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(1228, 713);
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.HeaderPanel);
            this.Name = "GrupsList";
            this.Text = "Grups";
            this.Load += new System.EventHandler(this.Grups_Load);
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.CenterPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewGroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel CenterPanel;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView DataGridViewGroups;
        private System.Windows.Forms.Label NomGrupLbl;
        private System.Windows.Forms.TextBox GrupNameTb;
        private System.Windows.Forms.ComboBox SeccioCb;
        private System.Windows.Forms.Label SeccioLbl;
        private System.Windows.Forms.ToolTip ToolTip_GL;
        private System.Windows.Forms.Label OpenedLbl;
    }
}