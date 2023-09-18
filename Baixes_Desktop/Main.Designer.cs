
namespace Baixes_Desktop
{
    partial class Main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ObrirGrupBtn = new System.Windows.Forms.Button();
            this.GrupsBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ContainerPanel = new System.Windows.Forms.Panel();
            this.MenuPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(180)))), ((int)(((byte)(220)))));
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(1624, 56);
            this.TitlePanel.TabIndex = 0;
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(80)))), ((int)(((byte)(140)))));
            this.MenuPanel.Controls.Add(this.panel1);
            this.MenuPanel.Controls.Add(this.pictureBox1);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuPanel.Location = new System.Drawing.Point(0, 56);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(217, 905);
            this.MenuPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ObrirGrupBtn);
            this.panel1.Controls.Add(this.GrupsBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 821);
            this.panel1.TabIndex = 1;
            // 
            // ObrirGrupBtn
            // 
            this.ObrirGrupBtn.FlatAppearance.BorderSize = 0;
            this.ObrirGrupBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ObrirGrupBtn.Font = new System.Drawing.Font("Leelawadee UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ObrirGrupBtn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.ObrirGrupBtn.Location = new System.Drawing.Point(0, 69);
            this.ObrirGrupBtn.Name = "ObrirGrupBtn";
            this.ObrirGrupBtn.Size = new System.Drawing.Size(217, 61);
            this.ObrirGrupBtn.TabIndex = 0;
            this.ObrirGrupBtn.Text = "Nou";
            this.ObrirGrupBtn.UseVisualStyleBackColor = true;
            this.ObrirGrupBtn.Click += new System.EventHandler(this.ObrirGrupBtn_Click);
            // 
            // GrupsBtn
            // 
            this.GrupsBtn.FlatAppearance.BorderSize = 0;
            this.GrupsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GrupsBtn.Font = new System.Drawing.Font("Leelawadee UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrupsBtn.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.GrupsBtn.Location = new System.Drawing.Point(0, 3);
            this.GrupsBtn.Name = "GrupsBtn";
            this.GrupsBtn.Size = new System.Drawing.Size(217, 61);
            this.GrupsBtn.TabIndex = 0;
            this.GrupsBtn.Text = "Listat";
            this.GrupsBtn.UseVisualStyleBackColor = true;
            this.GrupsBtn.Click += new System.EventHandler(this.GrupsBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.ErrorImage = global::Baixes_Desktop.Properties.Resources.atj;
            this.pictureBox1.Image = global::Baixes_Desktop.Properties.Resources.atj;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(217, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ContainerPanel
            // 
            this.ContainerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(150)))), ((int)(((byte)(180)))));
            this.ContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerPanel.Location = new System.Drawing.Point(217, 56);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(1407, 905);
            this.ContainerPanel.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1624, 961);
            this.Controls.Add(this.ContainerPanel);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.TitlePanel);
            this.Name = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.MenuPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button GrupsBtn;
        public System.Windows.Forms.Panel ContainerPanel;
        private System.Windows.Forms.Button ObrirGrupBtn;
    }
}

