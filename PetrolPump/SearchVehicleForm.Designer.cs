namespace PetrolPump
{
    partial class SearchVehicleForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.TBVehicle = new System.Windows.Forms.TextBox();
            this.TBCompany = new System.Windows.Forms.TextBox();
            this.DGVSearchVehicle = new System.Windows.Forms.DataGridView();
            this.DGVID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sitaraHilalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryManagementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.RBDesc = new System.Windows.Forms.RadioButton();
            this.RBAsc = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.CBOrderBy = new System.Windows.Forms.ComboBox();
            this.TBID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBDriver = new System.Windows.Forms.TextBox();
            this.BtnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSearchVehicle)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label4.Location = new System.Drawing.Point(153, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 29);
            this.label4.TabIndex = 94;
            this.label4.Text = "Vehicle No";
            // 
            // TBVehicle
            // 
            this.TBVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBVehicle.Location = new System.Drawing.Point(290, 162);
            this.TBVehicle.Name = "TBVehicle";
            this.TBVehicle.Size = new System.Drawing.Size(303, 35);
            this.TBVehicle.TabIndex = 2;
            this.TBVehicle.TextChanged += new System.EventHandler(this.TBVehicle_TextChanged);
            // 
            // TBCompany
            // 
            this.TBCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBCompany.Location = new System.Drawing.Point(844, 112);
            this.TBCompany.Name = "TBCompany";
            this.TBCompany.Size = new System.Drawing.Size(403, 35);
            this.TBCompany.TabIndex = 3;
            this.TBCompany.TextChanged += new System.EventHandler(this.TBName_TextChanged);
            // 
            // DGVSearchVehicle
            // 
            this.DGVSearchVehicle.AllowUserToAddRows = false;
            this.DGVSearchVehicle.AllowUserToDeleteRows = false;
            this.DGVSearchVehicle.AllowUserToResizeColumns = false;
            this.DGVSearchVehicle.AllowUserToResizeRows = false;
            this.DGVSearchVehicle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVSearchVehicle.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVSearchVehicle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVSearchVehicle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSearchVehicle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGVID,
            this.DGVName,
            this.DGVVehicle,
            this.DGVCName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVSearchVehicle.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVSearchVehicle.Location = new System.Drawing.Point(7, 264);
            this.DGVSearchVehicle.Name = "DGVSearchVehicle";
            this.DGVSearchVehicle.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVSearchVehicle.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVSearchVehicle.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 6, 0, 6);
            this.DGVSearchVehicle.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVSearchVehicle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVSearchVehicle.Size = new System.Drawing.Size(1381, 712);
            this.DGVSearchVehicle.TabIndex = 8;
            // 
            // DGVID
            // 
            this.DGVID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DGVID.HeaderText = "ID";
            this.DGVID.Name = "DGVID";
            this.DGVID.ReadOnly = true;
            this.DGVID.Width = 52;
            // 
            // DGVName
            // 
            this.DGVName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGVName.HeaderText = "Driver Name";
            this.DGVName.Name = "DGVName";
            this.DGVName.ReadOnly = true;
            // 
            // DGVVehicle
            // 
            this.DGVVehicle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGVVehicle.HeaderText = "Vehicle Number";
            this.DGVVehicle.Name = "DGVVehicle";
            this.DGVVehicle.ReadOnly = true;
            // 
            // DGVCName
            // 
            this.DGVCName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGVCName.HeaderText = "Company Name";
            this.DGVCName.Name = "DGVCName";
            this.DGVCName.ReadOnly = true;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.LblName.Location = new System.Drawing.Point(646, 115);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(186, 29);
            this.LblName.TabIndex = 93;
            this.LblName.Text = "Company Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.label3.Location = new System.Drawing.Point(579, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 39);
            this.label3.TabIndex = 141;
            this.label3.Text = "Search Vehicle";
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
            this.menuStrip1.Size = new System.Drawing.Size(1400, 46);
            this.menuStrip1.TabIndex = 140;
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
            this.inventoryManagementToolStripMenuItem1.Size = new System.Drawing.Size(136, 36);
            this.inventoryManagementToolStripMenuItem1.Text = "Search Vehicle";
            // 
            // RBDesc
            // 
            this.RBDesc.AutoSize = true;
            this.RBDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.RBDesc.Location = new System.Drawing.Point(915, 213);
            this.RBDesc.Name = "RBDesc";
            this.RBDesc.Size = new System.Drawing.Size(160, 33);
            this.RBDesc.TabIndex = 7;
            this.RBDesc.Text = "Descending";
            this.RBDesc.UseVisualStyleBackColor = true;
            // 
            // RBAsc
            // 
            this.RBAsc.AutoSize = true;
            this.RBAsc.Checked = true;
            this.RBAsc.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.RBAsc.Location = new System.Drawing.Point(765, 213);
            this.RBAsc.Name = "RBAsc";
            this.RBAsc.Size = new System.Drawing.Size(144, 33);
            this.RBAsc.TabIndex = 6;
            this.RBAsc.TabStop = true;
            this.RBAsc.Text = "Ascending";
            this.RBAsc.UseVisualStyleBackColor = true;
            this.RBAsc.CheckedChanged += new System.EventHandler(this.RBAsc_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label5.Location = new System.Drawing.Point(329, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 29);
            this.label5.TabIndex = 147;
            this.label5.Text = "Order By";
            // 
            // CBOrderBy
            // 
            this.CBOrderBy.DropDownHeight = 205;
            this.CBOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBOrderBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBOrderBy.FormattingEnabled = true;
            this.CBOrderBy.IntegralHeight = false;
            this.CBOrderBy.Items.AddRange(new object[] {
            "Company Name",
            "Driver Name",
            "ID",
            "Vehicle No"});
            this.CBOrderBy.Location = new System.Drawing.Point(444, 212);
            this.CBOrderBy.Name = "CBOrderBy";
            this.CBOrderBy.Size = new System.Drawing.Size(265, 37);
            this.CBOrderBy.Sorted = true;
            this.CBOrderBy.TabIndex = 5;
            this.CBOrderBy.SelectedIndexChanged += new System.EventHandler(this.CBOrderBy_SelectedIndexChanged);
            // 
            // TBID
            // 
            this.TBID.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBID.Location = new System.Drawing.Point(290, 112);
            this.TBID.Name = "TBID";
            this.TBID.Size = new System.Drawing.Size(303, 35);
            this.TBID.TabIndex = 1;
            this.TBID.TextChanged += new System.EventHandler(this.TBID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(153, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 29);
            this.label1.TabIndex = 146;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.Location = new System.Drawing.Point(646, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 29);
            this.label2.TabIndex = 149;
            this.label2.Text = "Driver Name";
            // 
            // TBDriver
            // 
            this.TBDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBDriver.Location = new System.Drawing.Point(844, 162);
            this.TBDriver.Name = "TBDriver";
            this.TBDriver.Size = new System.Drawing.Size(403, 35);
            this.TBDriver.TabIndex = 4;
            this.TBDriver.TextChanged += new System.EventHandler(this.TBDriver_TextChanged);
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(27)))), ((int)(((byte)(28)))));
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClose.FlatAppearance.BorderSize = 0;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.BtnClose.ForeColor = System.Drawing.Color.White;
            this.BtnClose.Image = global::PetrolPump.Properties.Resources.icon_close_circled_128__2_;
            this.BtnClose.Location = new System.Drawing.Point(1325, 59);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(50, 50);
            this.BtnClose.TabIndex = 150;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // SearchVehicleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(1400, 988);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBDriver);
            this.Controls.Add(this.RBDesc);
            this.Controls.Add(this.RBAsc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CBOrderBy);
            this.Controls.Add(this.TBID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TBVehicle);
            this.Controls.Add(this.TBCompany);
            this.Controls.Add(this.DGVSearchVehicle);
            this.Controls.Add(this.LblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SearchVehicleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Vehicle - Sitara Hilal Petroleum Service";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SearchVehicleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSearchVehicle)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBVehicle;
        private System.Windows.Forms.TextBox TBCompany;
        private System.Windows.Forms.DataGridView DGVSearchVehicle;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sitaraHilalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryManagementToolStripMenuItem1;
        private System.Windows.Forms.RadioButton RBDesc;
        private System.Windows.Forms.RadioButton RBAsc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBOrderBy;
        private System.Windows.Forms.TextBox TBID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBDriver;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVVehicle;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVCName;
        private System.Windows.Forms.Button BtnClose;
    }
}