namespace PetrolPump
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sitaraHilalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryManagementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.BtnMoneyManagement = new System.Windows.Forms.Button();
            this.BtnBackup = new System.Windows.Forms.Button();
            this.BtnLogout = new System.Windows.Forms.Button();
            this.BtnLineCreditCustomers = new System.Windows.Forms.Button();
            this.BtnInventoryManagement = new System.Windows.Forms.Button();
            this.BtnReceiveLineCredit = new System.Windows.Forms.Button();
            this.BtnAdminPanel = new System.Windows.Forms.Button();
            this.BtnAddVehicleCash = new System.Windows.Forms.Button();
            this.BtnReceiveCredit = new System.Windows.Forms.Button();
            this.BtnAddLineCredit = new System.Windows.Forms.Button();
            this.BtnAddCredit = new System.Windows.Forms.Button();
            this.BtnAddCash = new System.Windows.Forms.Button();
            this.BtnCompanyManagement = new System.Windows.Forms.Button();
            this.BtnReports = new System.Windows.Forms.Button();
            this.BtnSearchCustomer = new System.Windows.Forms.Button();
            this.BtnBill = new System.Windows.Forms.Button();
            this.BtnAddCustomer = new System.Windows.Forms.Button();
            this.BtnSearchInventory = new System.Windows.Forms.Button();
            this.BtnCombinedReport = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sitaraHilalToolStripMenuItem,
            this.inventoryManagementToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.menuStrip1.Size = new System.Drawing.Size(1304, 46);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sitaraHilalToolStripMenuItem
            // 
            this.sitaraHilalToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.sitaraHilalToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.sitaraHilalToolStripMenuItem.Name = "sitaraHilalToolStripMenuItem";
            this.sitaraHilalToolStripMenuItem.Size = new System.Drawing.Size(140, 36);
            this.sitaraHilalToolStripMenuItem.Text = "Sitara Hilal";
            // 
            // inventoryManagementToolStripMenuItem1
            // 
            this.inventoryManagementToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.inventoryManagementToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.inventoryManagementToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.inventoryManagementToolStripMenuItem1.Name = "inventoryManagementToolStripMenuItem1";
            this.inventoryManagementToolStripMenuItem1.Size = new System.Drawing.Size(113, 36);
            this.inventoryManagementToolStripMenuItem1.Text = "Main Menu";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "SQL file|*.SQL";
            this.saveFileDialog1.Title = "Backup Records - Sitara Hilal Petroleum Service";
            // 
            // BtnMoneyManagement
            // 
            this.BtnMoneyManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(173)))));
            this.BtnMoneyManagement.FlatAppearance.BorderSize = 0;
            this.BtnMoneyManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMoneyManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.BtnMoneyManagement.ForeColor = System.Drawing.Color.White;
            this.BtnMoneyManagement.Image = ((System.Drawing.Image)(resources.GetObject("BtnMoneyManagement.Image")));
            this.BtnMoneyManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMoneyManagement.Location = new System.Drawing.Point(356, 900);
            this.BtnMoneyManagement.Name = "BtnMoneyManagement";
            this.BtnMoneyManagement.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.BtnMoneyManagement.Size = new System.Drawing.Size(421, 82);
            this.BtnMoneyManagement.TabIndex = 37;
            this.BtnMoneyManagement.Text = "Accounts Management";
            this.BtnMoneyManagement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnMoneyManagement.UseVisualStyleBackColor = false;
            this.BtnMoneyManagement.Click += new System.EventHandler(this.BtnMoneyManagement_Click);
            // 
            // BtnBackup
            // 
            this.BtnBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(59)))), ((int)(((byte)(185)))));
            this.BtnBackup.FlatAppearance.BorderSize = 0;
            this.BtnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.BtnBackup.ForeColor = System.Drawing.Color.White;
            this.BtnBackup.Image = global::PetrolPump.Properties.Resources._1454264367_cloud_arrow_up__1_;
            this.BtnBackup.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnBackup.Location = new System.Drawing.Point(887, 586);
            this.BtnBackup.Name = "BtnBackup";
            this.BtnBackup.Padding = new System.Windows.Forms.Padding(10);
            this.BtnBackup.Size = new System.Drawing.Size(417, 194);
            this.BtnBackup.TabIndex = 35;
            this.BtnBackup.Text = "Backup Records";
            this.BtnBackup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBackup.UseVisualStyleBackColor = false;
            this.BtnBackup.Click += new System.EventHandler(this.BtnBackup_Click);
            // 
            // BtnLogout
            // 
            this.BtnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(27)))), ((int)(((byte)(28)))));
            this.BtnLogout.FlatAppearance.BorderSize = 0;
            this.BtnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.BtnLogout.ForeColor = System.Drawing.Color.White;
            this.BtnLogout.Image = global::PetrolPump.Properties.Resources.logout;
            this.BtnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLogout.Location = new System.Drawing.Point(1094, 900);
            this.BtnLogout.Name = "BtnLogout";
            this.BtnLogout.Padding = new System.Windows.Forms.Padding(10);
            this.BtnLogout.Size = new System.Drawing.Size(210, 82);
            this.BtnLogout.TabIndex = 36;
            this.BtnLogout.Text = "Logout ";
            this.BtnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLogout.UseVisualStyleBackColor = false;
            this.BtnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // BtnLineCreditCustomers
            // 
            this.BtnLineCreditCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(83)))), ((int)(((byte)(44)))));
            this.BtnLineCreditCustomers.FlatAppearance.BorderSize = 0;
            this.BtnLineCreditCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLineCreditCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.BtnLineCreditCustomers.ForeColor = System.Drawing.Color.White;
            this.BtnLineCreditCustomers.Image = ((System.Drawing.Image)(resources.GetObject("BtnLineCreditCustomers.Image")));
            this.BtnLineCreditCustomers.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnLineCreditCustomers.Location = new System.Drawing.Point(887, 273);
            this.BtnLineCreditCustomers.Name = "BtnLineCreditCustomers";
            this.BtnLineCreditCustomers.Padding = new System.Windows.Forms.Padding(10);
            this.BtnLineCreditCustomers.Size = new System.Drawing.Size(417, 194);
            this.BtnLineCreditCustomers.TabIndex = 10;
            this.BtnLineCreditCustomers.Text = "Line Credit Customers";
            this.BtnLineCreditCustomers.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnLineCreditCustomers.UseVisualStyleBackColor = false;
            this.BtnLineCreditCustomers.Click += new System.EventHandler(this.BtnLineCreditCustomers_Click);
            // 
            // BtnInventoryManagement
            // 
            this.BtnInventoryManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(59)))), ((int)(((byte)(185)))));
            this.BtnInventoryManagement.FlatAppearance.BorderSize = 0;
            this.BtnInventoryManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnInventoryManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.BtnInventoryManagement.ForeColor = System.Drawing.Color.White;
            this.BtnInventoryManagement.Image = ((System.Drawing.Image)(resources.GetObject("BtnInventoryManagement.Image")));
            this.BtnInventoryManagement.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnInventoryManagement.Location = new System.Drawing.Point(887, 482);
            this.BtnInventoryManagement.Name = "BtnInventoryManagement";
            this.BtnInventoryManagement.Padding = new System.Windows.Forms.Padding(10);
            this.BtnInventoryManagement.Size = new System.Drawing.Size(417, 194);
            this.BtnInventoryManagement.TabIndex = 11;
            this.BtnInventoryManagement.Text = "Inventory Management";
            this.BtnInventoryManagement.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnInventoryManagement.UseVisualStyleBackColor = false;
            this.BtnInventoryManagement.Click += new System.EventHandler(this.BtnInventoryManagement_Click);
            // 
            // BtnReceiveLineCredit
            // 
            this.BtnReceiveLineCredit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.BtnReceiveLineCredit.FlatAppearance.BorderSize = 0;
            this.BtnReceiveLineCredit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReceiveLineCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.BtnReceiveLineCredit.ForeColor = System.Drawing.Color.White;
            this.BtnReceiveLineCredit.Image = ((System.Drawing.Image)(resources.GetObject("BtnReceiveLineCredit.Image")));
            this.BtnReceiveLineCredit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnReceiveLineCredit.Location = new System.Drawing.Point(455, 273);
            this.BtnReceiveLineCredit.Name = "BtnReceiveLineCredit";
            this.BtnReceiveLineCredit.Padding = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.BtnReceiveLineCredit.Size = new System.Drawing.Size(417, 194);
            this.BtnReceiveLineCredit.TabIndex = 6;
            this.BtnReceiveLineCredit.Text = "Receive Line Credit";
            this.BtnReceiveLineCredit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnReceiveLineCredit.UseVisualStyleBackColor = false;
            this.BtnReceiveLineCredit.Click += new System.EventHandler(this.BtnReceiveLineCredit_Click);
            // 
            // BtnAdminPanel
            // 
            this.BtnAdminPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.BtnAdminPanel.FlatAppearance.BorderSize = 0;
            this.BtnAdminPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdminPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.BtnAdminPanel.ForeColor = System.Drawing.Color.White;
            this.BtnAdminPanel.Image = ((System.Drawing.Image)(resources.GetObject("BtnAdminPanel.Image")));
            this.BtnAdminPanel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAdminPanel.Location = new System.Drawing.Point(792, 900);
            this.BtnAdminPanel.Name = "BtnAdminPanel";
            this.BtnAdminPanel.Padding = new System.Windows.Forms.Padding(10);
            this.BtnAdminPanel.Size = new System.Drawing.Size(287, 82);
            this.BtnAdminPanel.TabIndex = 12;
            this.BtnAdminPanel.Text = "Admin Panel ";
            this.BtnAdminPanel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAdminPanel.UseVisualStyleBackColor = false;
            this.BtnAdminPanel.Click += new System.EventHandler(this.BtnAdminPanel_Click);
            // 
            // BtnAddVehicleCash
            // 
            this.BtnAddVehicleCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(173)))));
            this.BtnAddVehicleCash.FlatAppearance.BorderSize = 0;
            this.BtnAddVehicleCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddVehicleCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.BtnAddVehicleCash.ForeColor = System.Drawing.Color.White;
            this.BtnAddVehicleCash.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddVehicleCash.Image")));
            this.BtnAddVehicleCash.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAddVehicleCash.Location = new System.Drawing.Point(23, 482);
            this.BtnAddVehicleCash.Name = "BtnAddVehicleCash";
            this.BtnAddVehicleCash.Padding = new System.Windows.Forms.Padding(10);
            this.BtnAddVehicleCash.Size = new System.Drawing.Size(417, 194);
            this.BtnAddVehicleCash.TabIndex = 3;
            this.BtnAddVehicleCash.Text = "Add Vehicle Cash";
            this.BtnAddVehicleCash.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAddVehicleCash.UseVisualStyleBackColor = false;
            this.BtnAddVehicleCash.Click += new System.EventHandler(this.BtnAddVehicleCash_Click);
            // 
            // BtnReceiveCredit
            // 
            this.BtnReceiveCredit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(167)))), ((int)(((byte)(96)))));
            this.BtnReceiveCredit.FlatAppearance.BorderSize = 0;
            this.BtnReceiveCredit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReceiveCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.BtnReceiveCredit.ForeColor = System.Drawing.Color.White;
            this.BtnReceiveCredit.Image = ((System.Drawing.Image)(resources.GetObject("BtnReceiveCredit.Image")));
            this.BtnReceiveCredit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnReceiveCredit.Location = new System.Drawing.Point(455, 64);
            this.BtnReceiveCredit.Name = "BtnReceiveCredit";
            this.BtnReceiveCredit.Padding = new System.Windows.Forms.Padding(10);
            this.BtnReceiveCredit.Size = new System.Drawing.Size(417, 194);
            this.BtnReceiveCredit.TabIndex = 5;
            this.BtnReceiveCredit.Text = "Receive Credit Sale";
            this.BtnReceiveCredit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnReceiveCredit.UseVisualStyleBackColor = false;
            this.BtnReceiveCredit.Click += new System.EventHandler(this.BtnReceiveCredit_Click);
            // 
            // BtnAddLineCredit
            // 
            this.BtnAddLineCredit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(59)))), ((int)(((byte)(185)))));
            this.BtnAddLineCredit.FlatAppearance.BorderSize = 0;
            this.BtnAddLineCredit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddLineCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.BtnAddLineCredit.ForeColor = System.Drawing.Color.White;
            this.BtnAddLineCredit.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddLineCredit.Image")));
            this.BtnAddLineCredit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAddLineCredit.Location = new System.Drawing.Point(23, 273);
            this.BtnAddLineCredit.Name = "BtnAddLineCredit";
            this.BtnAddLineCredit.Padding = new System.Windows.Forms.Padding(10);
            this.BtnAddLineCredit.Size = new System.Drawing.Size(417, 194);
            this.BtnAddLineCredit.TabIndex = 2;
            this.BtnAddLineCredit.Text = "Add Line Credit Sale";
            this.BtnAddLineCredit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAddLineCredit.UseVisualStyleBackColor = false;
            this.BtnAddLineCredit.Click += new System.EventHandler(this.BtnAddLineCredit_Click);
            // 
            // BtnAddCredit
            // 
            this.BtnAddCredit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(170)))));
            this.BtnAddCredit.FlatAppearance.BorderSize = 0;
            this.BtnAddCredit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.BtnAddCredit.ForeColor = System.Drawing.Color.White;
            this.BtnAddCredit.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddCredit.Image")));
            this.BtnAddCredit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAddCredit.Location = new System.Drawing.Point(23, 64);
            this.BtnAddCredit.Name = "BtnAddCredit";
            this.BtnAddCredit.Padding = new System.Windows.Forms.Padding(10);
            this.BtnAddCredit.Size = new System.Drawing.Size(417, 194);
            this.BtnAddCredit.TabIndex = 1;
            this.BtnAddCredit.Text = "Add Credit Sale";
            this.BtnAddCredit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAddCredit.UseVisualStyleBackColor = false;
            this.BtnAddCredit.Click += new System.EventHandler(this.BtnAddCredit_Click);
            // 
            // BtnAddCash
            // 
            this.BtnAddCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(83)))), ((int)(((byte)(44)))));
            this.BtnAddCash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnAddCash.FlatAppearance.BorderSize = 0;
            this.BtnAddCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.BtnAddCash.ForeColor = System.Drawing.Color.White;
            this.BtnAddCash.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddCash.Image")));
            this.BtnAddCash.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAddCash.Location = new System.Drawing.Point(23, 691);
            this.BtnAddCash.Name = "BtnAddCash";
            this.BtnAddCash.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.BtnAddCash.Size = new System.Drawing.Size(417, 194);
            this.BtnAddCash.TabIndex = 4;
            this.BtnAddCash.Text = "Add Cash Sale";
            this.BtnAddCash.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAddCash.UseVisualStyleBackColor = false;
            this.BtnAddCash.Click += new System.EventHandler(this.BtnAddCast_Click);
            // 
            // BtnCompanyManagement
            // 
            this.BtnCompanyManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(155)))), ((int)(((byte)(173)))));
            this.BtnCompanyManagement.FlatAppearance.BorderSize = 0;
            this.BtnCompanyManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCompanyManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.BtnCompanyManagement.ForeColor = System.Drawing.Color.White;
            this.BtnCompanyManagement.Image = ((System.Drawing.Image)(resources.GetObject("BtnCompanyManagement.Image")));
            this.BtnCompanyManagement.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnCompanyManagement.Location = new System.Drawing.Point(887, 64);
            this.BtnCompanyManagement.Name = "BtnCompanyManagement";
            this.BtnCompanyManagement.Padding = new System.Windows.Forms.Padding(10);
            this.BtnCompanyManagement.Size = new System.Drawing.Size(417, 194);
            this.BtnCompanyManagement.TabIndex = 9;
            this.BtnCompanyManagement.Text = "Company Management";
            this.BtnCompanyManagement.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCompanyManagement.UseVisualStyleBackColor = false;
            this.BtnCompanyManagement.Click += new System.EventHandler(this.BtnCompanyManagement_Click);
            // 
            // BtnReports
            // 
            this.BtnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(170)))));
            this.BtnReports.FlatAppearance.BorderSize = 0;
            this.BtnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.BtnReports.ForeColor = System.Drawing.Color.White;
            this.BtnReports.Image = ((System.Drawing.Image)(resources.GetObject("BtnReports.Image")));
            this.BtnReports.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnReports.Location = new System.Drawing.Point(455, 482);
            this.BtnReports.Name = "BtnReports";
            this.BtnReports.Padding = new System.Windows.Forms.Padding(10);
            this.BtnReports.Size = new System.Drawing.Size(417, 194);
            this.BtnReports.TabIndex = 7;
            this.BtnReports.Text = "Reports";
            this.BtnReports.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnReports.UseVisualStyleBackColor = false;
            this.BtnReports.Click += new System.EventHandler(this.BtnReports_Click);
            // 
            // BtnSearchCustomer
            // 
            this.BtnSearchCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(170)))));
            this.BtnSearchCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnSearchCustomer.FlatAppearance.BorderSize = 0;
            this.BtnSearchCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.BtnSearchCustomer.ForeColor = System.Drawing.Color.White;
            this.BtnSearchCustomer.Image = ((System.Drawing.Image)(resources.GetObject("BtnSearchCustomer.Image")));
            this.BtnSearchCustomer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSearchCustomer.Location = new System.Drawing.Point(455, 482);
            this.BtnSearchCustomer.Name = "BtnSearchCustomer";
            this.BtnSearchCustomer.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.BtnSearchCustomer.Size = new System.Drawing.Size(417, 194);
            this.BtnSearchCustomer.TabIndex = 32;
            this.BtnSearchCustomer.Text = "Search Customer";
            this.BtnSearchCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSearchCustomer.UseVisualStyleBackColor = false;
            this.BtnSearchCustomer.Click += new System.EventHandler(this.BtnSearchCustomer_Click);
            // 
            // BtnBill
            // 
            this.BtnBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(167)))), ((int)(((byte)(96)))));
            this.BtnBill.FlatAppearance.BorderSize = 0;
            this.BtnBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.BtnBill.ForeColor = System.Drawing.Color.White;
            this.BtnBill.Image = ((System.Drawing.Image)(resources.GetObject("BtnBill.Image")));
            this.BtnBill.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnBill.Location = new System.Drawing.Point(887, 691);
            this.BtnBill.Name = "BtnBill";
            this.BtnBill.Padding = new System.Windows.Forms.Padding(10);
            this.BtnBill.Size = new System.Drawing.Size(417, 194);
            this.BtnBill.TabIndex = 8;
            this.BtnBill.Text = "Company Bill";
            this.BtnBill.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnBill.UseVisualStyleBackColor = false;
            this.BtnBill.Click += new System.EventHandler(this.BtnSummary_Click);
            // 
            // BtnAddCustomer
            // 
            this.BtnAddCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(167)))), ((int)(((byte)(96)))));
            this.BtnAddCustomer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnAddCustomer.FlatAppearance.BorderSize = 0;
            this.BtnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.BtnAddCustomer.ForeColor = System.Drawing.Color.White;
            this.BtnAddCustomer.Image = ((System.Drawing.Image)(resources.GetObject("BtnAddCustomer.Image")));
            this.BtnAddCustomer.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnAddCustomer.Location = new System.Drawing.Point(455, 691);
            this.BtnAddCustomer.Name = "BtnAddCustomer";
            this.BtnAddCustomer.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.BtnAddCustomer.Size = new System.Drawing.Size(417, 194);
            this.BtnAddCustomer.TabIndex = 33;
            this.BtnAddCustomer.Text = "Add Customer";
            this.BtnAddCustomer.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnAddCustomer.UseVisualStyleBackColor = false;
            this.BtnAddCustomer.Click += new System.EventHandler(this.BtnAddCustomer_Click);
            // 
            // BtnSearchInventory
            // 
            this.BtnSearchInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(83)))), ((int)(((byte)(44)))));
            this.BtnSearchInventory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnSearchInventory.FlatAppearance.BorderSize = 0;
            this.BtnSearchInventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearchInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.BtnSearchInventory.ForeColor = System.Drawing.Color.White;
            this.BtnSearchInventory.Image = ((System.Drawing.Image)(resources.GetObject("BtnSearchInventory.Image")));
            this.BtnSearchInventory.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnSearchInventory.Location = new System.Drawing.Point(887, 377);
            this.BtnSearchInventory.Name = "BtnSearchInventory";
            this.BtnSearchInventory.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.BtnSearchInventory.Size = new System.Drawing.Size(417, 194);
            this.BtnSearchInventory.TabIndex = 21;
            this.BtnSearchInventory.Text = "Search Inventory";
            this.BtnSearchInventory.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnSearchInventory.UseVisualStyleBackColor = false;
            this.BtnSearchInventory.Click += new System.EventHandler(this.BtnSearchInventory_Click);
            // 
            // BtnCombinedReport
            // 
            this.BtnCombinedReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(134)))), ((int)(((byte)(180)))));
            this.BtnCombinedReport.FlatAppearance.BorderSize = 0;
            this.BtnCombinedReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCombinedReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F);
            this.BtnCombinedReport.ForeColor = System.Drawing.Color.White;
            this.BtnCombinedReport.Image = ((System.Drawing.Image)(resources.GetObject("BtnCombinedReport.Image")));
            this.BtnCombinedReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnCombinedReport.Location = new System.Drawing.Point(455, 691);
            this.BtnCombinedReport.Name = "BtnCombinedReport";
            this.BtnCombinedReport.Padding = new System.Windows.Forms.Padding(10);
            this.BtnCombinedReport.Size = new System.Drawing.Size(417, 194);
            this.BtnCombinedReport.TabIndex = 38;
            this.BtnCombinedReport.Text = "Combined Reports";
            this.BtnCombinedReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnCombinedReport.UseVisualStyleBackColor = false;
            this.BtnCombinedReport.Click += new System.EventHandler(this.BtnCombinedReport_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1290, 741);
            this.Controls.Add(this.BtnCombinedReport);
            this.Controls.Add(this.BtnMoneyManagement);
            this.Controls.Add(this.BtnBackup);
            this.Controls.Add(this.BtnLogout);
            this.Controls.Add(this.BtnLineCreditCustomers);
            this.Controls.Add(this.BtnInventoryManagement);
            this.Controls.Add(this.BtnReceiveLineCredit);
            this.Controls.Add(this.BtnAdminPanel);
            this.Controls.Add(this.BtnAddVehicleCash);
            this.Controls.Add(this.BtnReceiveCredit);
            this.Controls.Add(this.BtnAddLineCredit);
            this.Controls.Add(this.BtnAddCredit);
            this.Controls.Add(this.BtnAddCash);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.BtnCompanyManagement);
            this.Controls.Add(this.BtnReports);
            this.Controls.Add(this.BtnSearchCustomer);
            this.Controls.Add(this.BtnBill);
            this.Controls.Add(this.BtnAddCustomer);
            this.Controls.Add(this.BtnSearchInventory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu - Sitara Hilal Petroleum Service";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sitaraHilalToolStripMenuItem;
        private System.Windows.Forms.Button BtnAddCash;
        private System.Windows.Forms.Button BtnAddCredit;
        private System.Windows.Forms.Button BtnAddLineCredit;
        private System.Windows.Forms.Button BtnReceiveCredit;
        private System.Windows.Forms.Button BtnReceiveLineCredit;
        private System.Windows.Forms.Button BtnAddVehicleCash;
        private System.Windows.Forms.Button BtnInventoryManagement;
        private System.Windows.Forms.Button BtnCompanyManagement;
        private System.Windows.Forms.Button BtnLineCreditCustomers;
        private System.Windows.Forms.Button BtnReports;
        private System.Windows.Forms.Button BtnBill;
        private System.Windows.Forms.Button BtnAdminPanel;
        private System.Windows.Forms.Button BtnSearchCustomer;
        private System.Windows.Forms.Button BtnAddCustomer;
        private System.Windows.Forms.Button BtnBackup;
        private System.Windows.Forms.Button BtnSearchInventory;
        private System.Windows.Forms.ToolStripMenuItem inventoryManagementToolStripMenuItem1;
        private System.Windows.Forms.Button BtnLogout;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button BtnMoneyManagement;
        private System.Windows.Forms.Button BtnCombinedReport;
    }
}