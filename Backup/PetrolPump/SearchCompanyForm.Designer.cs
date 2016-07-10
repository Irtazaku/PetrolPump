namespace PetrolPump
{
    partial class SearchCompanyForm
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
            this.TBNumber = new System.Windows.Forms.TextBox();
            this.TBName = new System.Windows.Forms.TextBox();
            this.DGVSearchCompany = new System.Windows.Forms.DataGridView();
            this.DGVID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TBEmail = new System.Windows.Forms.TextBox();
            this.TBID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sitaraHilalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryManagementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.RBDesc = new System.Windows.Forms.RadioButton();
            this.RBAsc = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.CBOrderBy = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSearchCompany)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(652, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 29);
            this.label4.TabIndex = 94;
            this.label4.Text = "Number";
            // 
            // TBNumber
            // 
            this.TBNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBNumber.Location = new System.Drawing.Point(758, 112);
            this.TBNumber.Name = "TBNumber";
            this.TBNumber.Size = new System.Drawing.Size(408, 35);
            this.TBNumber.TabIndex = 3;
            this.TBNumber.TextChanged += new System.EventHandler(this.TBNumber_TextChanged);
            // 
            // TBName
            // 
            this.TBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBName.Location = new System.Drawing.Point(198, 162);
            this.TBName.Name = "TBName";
            this.TBName.Size = new System.Drawing.Size(408, 35);
            this.TBName.TabIndex = 2;
            this.TBName.TextChanged += new System.EventHandler(this.TBName_TextChanged);
            // 
            // DGVSearchCompany
            // 
            this.DGVSearchCompany.AllowUserToAddRows = false;
            this.DGVSearchCompany.AllowUserToDeleteRows = false;
            this.DGVSearchCompany.AllowUserToResizeColumns = false;
            this.DGVSearchCompany.AllowUserToResizeRows = false;
            this.DGVSearchCompany.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVSearchCompany.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVSearchCompany.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVSearchCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSearchCompany.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGVID,
            this.DGVName,
            this.DGVNumber,
            this.DGVEmail});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVSearchCompany.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVSearchCompany.Location = new System.Drawing.Point(12, 266);
            this.DGVSearchCompany.Name = "DGVSearchCompany";
            this.DGVSearchCompany.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVSearchCompany.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVSearchCompany.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 6, 0, 6);
            this.DGVSearchCompany.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVSearchCompany.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVSearchCompany.Size = new System.Drawing.Size(1256, 460);
            this.DGVSearchCompany.TabIndex = 8;
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
            this.DGVName.HeaderText = "Name";
            this.DGVName.Name = "DGVName";
            this.DGVName.ReadOnly = true;
            // 
            // DGVNumber
            // 
            this.DGVNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGVNumber.HeaderText = "Number";
            this.DGVNumber.Name = "DGVNumber";
            this.DGVNumber.ReadOnly = true;
            // 
            // DGVEmail
            // 
            this.DGVEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGVEmail.HeaderText = "Email";
            this.DGVEmail.Name = "DGVEmail";
            this.DGVEmail.ReadOnly = true;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblName.Location = new System.Drawing.Point(114, 115);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(36, 29);
            this.LblName.TabIndex = 93;
            this.LblName.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(652, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 29);
            this.label1.TabIndex = 96;
            this.label1.Text = "Email";
            // 
            // TBEmail
            // 
            this.TBEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBEmail.Location = new System.Drawing.Point(758, 162);
            this.TBEmail.Name = "TBEmail";
            this.TBEmail.Size = new System.Drawing.Size(408, 35);
            this.TBEmail.TabIndex = 4;
            this.TBEmail.TextChanged += new System.EventHandler(this.TBEmail_TextChanged);
            // 
            // TBID
            // 
            this.TBID.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBID.Location = new System.Drawing.Point(198, 112);
            this.TBID.Name = "TBID";
            this.TBID.Size = new System.Drawing.Size(408, 35);
            this.TBID.TabIndex = 1;
            this.TBID.TextChanged += new System.EventHandler(this.TBID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(114, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 29);
            this.label2.TabIndex = 98;
            this.label2.Text = "Name";
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
            this.menuStrip1.Size = new System.Drawing.Size(1280, 46);
            this.menuStrip1.TabIndex = 99;
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
            this.inventoryManagementToolStripMenuItem1.Size = new System.Drawing.Size(158, 36);
            this.inventoryManagementToolStripMenuItem1.Text = "Search Company";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.label3.Location = new System.Drawing.Point(500, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 39);
            this.label3.TabIndex = 128;
            this.label3.Text = "Search Company";
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
            this.BtnClose.Location = new System.Drawing.Point(1218, 59);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(50, 50);
            this.BtnClose.TabIndex = 9;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // RBDesc
            // 
            this.RBDesc.AutoSize = true;
            this.RBDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.RBDesc.Location = new System.Drawing.Point(853, 213);
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
            this.RBAsc.Location = new System.Drawing.Point(703, 213);
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
            this.label5.Location = new System.Drawing.Point(267, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 29);
            this.label5.TabIndex = 131;
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
            "Email",
            "ID",
            "Name",
            "Number"});
            this.CBOrderBy.Location = new System.Drawing.Point(382, 212);
            this.CBOrderBy.Name = "CBOrderBy";
            this.CBOrderBy.Size = new System.Drawing.Size(270, 37);
            this.CBOrderBy.Sorted = true;
            this.CBOrderBy.TabIndex = 5;
            // 
            // SearchCompanyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(1280, 738);
            this.Controls.Add(this.RBDesc);
            this.Controls.Add(this.RBAsc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CBOrderBy);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.TBID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TBNumber);
            this.Controls.Add(this.TBName);
            this.Controls.Add(this.DGVSearchCompany);
            this.Controls.Add(this.LblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SearchCompanyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Company - Sitara Hilal Petroleum Service";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchCompanyForm_FormClosing);
            this.Load += new System.EventHandler(this.SearchCompanyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSearchCompany)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBNumber;
        private System.Windows.Forms.TextBox TBName;
        private System.Windows.Forms.DataGridView DGVSearchCompany;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBEmail;
        private System.Windows.Forms.TextBox TBID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sitaraHilalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryManagementToolStripMenuItem1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVEmail;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.RadioButton RBDesc;
        private System.Windows.Forms.RadioButton RBAsc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBOrderBy;
    }
}