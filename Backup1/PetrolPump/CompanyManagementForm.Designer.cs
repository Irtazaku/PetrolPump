namespace PetrolPump
{
    partial class CompanyManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyManagementForm));
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inventoryManagementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnEditVehicle = new System.Windows.Forms.Button();
            this.BtnDeleteVehicle = new System.Windows.Forms.Button();
            this.BtnSearchVehicle = new System.Windows.Forms.Button();
            this.BtnAddVehicle = new System.Windows.Forms.Button();
            this.BtnSearchCompany = new System.Windows.Forms.Button();
            this.BtnEditCompany = new System.Windows.Forms.Button();
            this.BtnDeleteCompany = new System.Windows.Forms.Button();
            this.BtnAddCompany = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.toolStripMenuItem3.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(140, 36);
            this.toolStripMenuItem3.Text = "Sitara Hilal";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.inventoryManagementToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.menuStrip1.Size = new System.Drawing.Size(937, 46);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inventoryManagementToolStripMenuItem1
            // 
            this.inventoryManagementToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.inventoryManagementToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.inventoryManagementToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.inventoryManagementToolStripMenuItem1.Name = "inventoryManagementToolStripMenuItem1";
            this.inventoryManagementToolStripMenuItem1.Size = new System.Drawing.Size(211, 36);
            this.inventoryManagementToolStripMenuItem1.Text = "Company Management";
            // 
            // BtnEditVehicle
            // 
            this.BtnEditVehicle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.BtnEditVehicle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnEditVehicle.FlatAppearance.BorderSize = 0;
            this.BtnEditVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.BtnEditVehicle.ForeColor = System.Drawing.Color.White;
            this.BtnEditVehicle.Image = ((System.Drawing.Image)(resources.GetObject("BtnEditVehicle.Image")));
            this.BtnEditVehicle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnEditVehicle.Location = new System.Drawing.Point(625, 234);
            this.BtnEditVehicle.Name = "BtnEditVehicle";
            this.BtnEditVehicle.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.BtnEditVehicle.Size = new System.Drawing.Size(300, 170);
            this.BtnEditVehicle.TabIndex = 6;
            this.BtnEditVehicle.Text = "Edit Vehicle";
            this.BtnEditVehicle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnEditVehicle.UseVisualStyleBackColor = false;
            this.BtnEditVehicle.Click += new System.EventHandler(this.BtnEditVehicle_Click);
            // 
            // BtnDeleteVehicle
            // 
            this.BtnDeleteVehicle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(83)))), ((int)(((byte)(44)))));
            this.BtnDeleteVehicle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnDeleteVehicle.FlatAppearance.BorderSize = 0;
            this.BtnDeleteVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDeleteVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.BtnDeleteVehicle.ForeColor = System.Drawing.Color.White;
            this.BtnDeleteVehicle.Image = ((System.Drawing.Image)(resources.GetObject("BtnDeleteVehicle.Image")));
            this.BtnDeleteVehicle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnDeleteVehicle.Location = new System.Drawing.Point(473, 410);
            this.BtnDeleteVehicle.Name = "BtnDeleteVehicle";
            this.BtnDeleteVehicle.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.BtnDeleteVehicle.Size = new System.Drawing.Size(300, 170);
            this.BtnDeleteVehicle.TabIndex = 8;
            this.BtnDeleteVehicle.Text = "Delete Vehicle";
            this.BtnDeleteVehicle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnDeleteVehicle.UseVisualStyleBackColor = false;
            this.BtnDeleteVehicle.Click += new System.EventHandler(this.BtnDeleteVehicle_Click);
            // 
            // BtnSearchVehicle
            // 
            this.BtnSearchVehicle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(173)))));
            this.BtnSearchVehicle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnSearchVehicle.FlatAppearance.BorderSize = 0;
            this.BtnSearchVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.BtnSearchVehicle.ForeColor = System.Drawing.Color.White;
            this.BtnSearchVehicle.Image = ((System.Drawing.Image)(resources.GetObject("BtnSearchVehicle.Image")));
            this.BtnSearchVehicle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSearchVehicle.Location = new System.Drawing.Point(318, 234);
            this.BtnSearchVehicle.Name = "BtnSearchVehicle";
            this.BtnSearchVehicle.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.BtnSearchVehicle.Size = new System.Drawing.Size(300, 170);
            this.BtnSearchVehicle.TabIndex = 5;
            this.BtnSearchVehicle.Text = "Search Vehicle";
            this.BtnSearchVehicle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSearchVehicle.UseVisualStyleBackColor = false;
            this.BtnSearchVehicle.Click += new System.EventHandler(this.BtnSearchVehicle_Click);
            // 
            // BtnAddVehicle
            // 
            this.BtnAddVehicle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(167)))), ((int)(((byte)(96)))));
            this.BtnAddVehicle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnAddVehicle.FlatAppearance.BorderSize = 0;
            this.BtnAddVehicle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.BtnAddVehicle.ForeColor = System.Drawing.Color.White;
            this.BtnAddVehicle.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddVehicle.Image")));
            this.BtnAddVehicle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAddVehicle.Location = new System.Drawing.Point(12, 234);
            this.BtnAddVehicle.Name = "BtnAddVehicle";
            this.BtnAddVehicle.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.BtnAddVehicle.Size = new System.Drawing.Size(300, 170);
            this.BtnAddVehicle.TabIndex = 4;
            this.BtnAddVehicle.Text = "Add Vehicle";
            this.BtnAddVehicle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAddVehicle.UseVisualStyleBackColor = false;
            this.BtnAddVehicle.Click += new System.EventHandler(this.BtnAddVehicle_Click);
            // 
            // BtnSearchCompany
            // 
            this.BtnSearchCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(173)))));
            this.BtnSearchCompany.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnSearchCompany.FlatAppearance.BorderSize = 0;
            this.BtnSearchCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.BtnSearchCompany.ForeColor = System.Drawing.Color.White;
            this.BtnSearchCompany.Image = ((System.Drawing.Image)(resources.GetObject("BtnSearchCompany.Image")));
            this.BtnSearchCompany.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSearchCompany.Location = new System.Drawing.Point(318, 58);
            this.BtnSearchCompany.Name = "BtnSearchCompany";
            this.BtnSearchCompany.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.BtnSearchCompany.Size = new System.Drawing.Size(300, 170);
            this.BtnSearchCompany.TabIndex = 2;
            this.BtnSearchCompany.Text = "Search Company";
            this.BtnSearchCompany.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSearchCompany.UseVisualStyleBackColor = false;
            this.BtnSearchCompany.Click += new System.EventHandler(this.BtnSearchCompany_Click);
            // 
            // BtnEditCompany
            // 
            this.BtnEditCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.BtnEditCompany.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnEditCompany.FlatAppearance.BorderSize = 0;
            this.BtnEditCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.BtnEditCompany.ForeColor = System.Drawing.Color.White;
            this.BtnEditCompany.Image = ((System.Drawing.Image)(resources.GetObject("BtnEditCompany.Image")));
            this.BtnEditCompany.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnEditCompany.Location = new System.Drawing.Point(624, 58);
            this.BtnEditCompany.Name = "BtnEditCompany";
            this.BtnEditCompany.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.BtnEditCompany.Size = new System.Drawing.Size(300, 170);
            this.BtnEditCompany.TabIndex = 3;
            this.BtnEditCompany.Text = "Edit Company";
            this.BtnEditCompany.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnEditCompany.UseVisualStyleBackColor = false;
            this.BtnEditCompany.Click += new System.EventHandler(this.BtnEditCompany_Click);
            // 
            // BtnDeleteCompany
            // 
            this.BtnDeleteCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(83)))), ((int)(((byte)(44)))));
            this.BtnDeleteCompany.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnDeleteCompany.FlatAppearance.BorderSize = 0;
            this.BtnDeleteCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDeleteCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.BtnDeleteCompany.ForeColor = System.Drawing.Color.White;
            this.BtnDeleteCompany.Image = ((System.Drawing.Image)(resources.GetObject("BtnDeleteCompany.Image")));
            this.BtnDeleteCompany.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnDeleteCompany.Location = new System.Drawing.Point(167, 410);
            this.BtnDeleteCompany.Name = "BtnDeleteCompany";
            this.BtnDeleteCompany.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.BtnDeleteCompany.Size = new System.Drawing.Size(300, 170);
            this.BtnDeleteCompany.TabIndex = 7;
            this.BtnDeleteCompany.Text = "Delete Company";
            this.BtnDeleteCompany.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnDeleteCompany.UseVisualStyleBackColor = false;
            this.BtnDeleteCompany.Click += new System.EventHandler(this.BtnDeleteCompany_Click);
            // 
            // BtnAddCompany
            // 
            this.BtnAddCompany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(167)))), ((int)(((byte)(96)))));
            this.BtnAddCompany.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnAddCompany.FlatAppearance.BorderSize = 0;
            this.BtnAddCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.BtnAddCompany.ForeColor = System.Drawing.Color.White;
            this.BtnAddCompany.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddCompany.Image")));
            this.BtnAddCompany.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAddCompany.Location = new System.Drawing.Point(12, 58);
            this.BtnAddCompany.Name = "BtnAddCompany";
            this.BtnAddCompany.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.BtnAddCompany.Size = new System.Drawing.Size(300, 170);
            this.BtnAddCompany.TabIndex = 1;
            this.BtnAddCompany.Text = "Add Company";
            this.BtnAddCompany.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAddCompany.UseVisualStyleBackColor = false;
            this.BtnAddCompany.Click += new System.EventHandler(this.BtnAddCompany_Click);
            // 
            // CompanyManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 594);
            this.Controls.Add(this.BtnEditVehicle);
            this.Controls.Add(this.BtnDeleteVehicle);
            this.Controls.Add(this.BtnSearchVehicle);
            this.Controls.Add(this.BtnAddVehicle);
            this.Controls.Add(this.BtnSearchCompany);
            this.Controls.Add(this.BtnEditCompany);
            this.Controls.Add(this.BtnDeleteCompany);
            this.Controls.Add(this.BtnAddCompany);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompanyManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Management - Sitara Hilal Petroleum Service";
            this.Load += new System.EventHandler(this.CompanyManagementForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSearchCompany;
        private System.Windows.Forms.Button BtnEditCompany;
        private System.Windows.Forms.Button BtnDeleteCompany;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Button BtnAddCompany;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inventoryManagementToolStripMenuItem1;
        private System.Windows.Forms.Button BtnAddVehicle;
        private System.Windows.Forms.Button BtnSearchVehicle;
        private System.Windows.Forms.Button BtnEditVehicle;
        private System.Windows.Forms.Button BtnDeleteVehicle;
    }
}