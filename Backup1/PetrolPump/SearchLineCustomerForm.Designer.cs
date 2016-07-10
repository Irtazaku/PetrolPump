namespace PetrolPump
{
    partial class SearchLineCustomerForm
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
            this.TBName = new System.Windows.Forms.TextBox();
            this.DGVSearchCustomer = new System.Windows.Forms.DataGridView();
            this.DGVID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVVehicle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblName = new System.Windows.Forms.Label();
            this.RBDesc = new System.Windows.Forms.RadioButton();
            this.RBAsc = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.CBOrderBy = new System.Windows.Forms.ComboBox();
            this.TBID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sitaraHilalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryManagementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSearchCustomer)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label4.Location = new System.Drawing.Point(637, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 29);
            this.label4.TabIndex = 89;
            this.label4.Text = "Vehicle No";
            // 
            // TBVehicle
            // 
            this.TBVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBVehicle.Location = new System.Drawing.Point(774, 112);
            this.TBVehicle.Name = "TBVehicle";
            this.TBVehicle.Size = new System.Drawing.Size(408, 35);
            this.TBVehicle.TabIndex = 3;
            this.TBVehicle.TextChanged += new System.EventHandler(this.TBVehicle_TextChanged);
            // 
            // TBName
            // 
            this.TBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBName.Location = new System.Drawing.Point(183, 112);
            this.TBName.Name = "TBName";
            this.TBName.Size = new System.Drawing.Size(408, 35);
            this.TBName.TabIndex = 1;
            this.TBName.TextChanged += new System.EventHandler(this.TBName_TextChanged);
            // 
            // DGVSearchCustomer
            // 
            this.DGVSearchCustomer.AllowUserToAddRows = false;
            this.DGVSearchCustomer.AllowUserToDeleteRows = false;
            this.DGVSearchCustomer.AllowUserToResizeColumns = false;
            this.DGVSearchCustomer.AllowUserToResizeRows = false;
            this.DGVSearchCustomer.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVSearchCustomer.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVSearchCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVSearchCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSearchCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGVID,
            this.DGVName,
            this.DGVVehicle});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVSearchCustomer.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVSearchCustomer.Location = new System.Drawing.Point(12, 214);
            this.DGVSearchCustomer.Name = "DGVSearchCustomer";
            this.DGVSearchCustomer.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVSearchCustomer.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVSearchCustomer.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 6, 0, 6);
            this.DGVSearchCustomer.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVSearchCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVSearchCustomer.Size = new System.Drawing.Size(1256, 512);
            this.DGVSearchCustomer.TabIndex = 7;
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
            // DGVVehicle
            // 
            this.DGVVehicle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGVVehicle.HeaderText = "Vehicle Number";
            this.DGVVehicle.Name = "DGVVehicle";
            this.DGVVehicle.ReadOnly = true;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.LblName.Location = new System.Drawing.Point(99, 115);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(78, 29);
            this.LblName.TabIndex = 88;
            this.LblName.Text = "Name";
            // 
            // RBDesc
            // 
            this.RBDesc.AutoSize = true;
            this.RBDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.RBDesc.Location = new System.Drawing.Point(1022, 163);
            this.RBDesc.Name = "RBDesc";
            this.RBDesc.Size = new System.Drawing.Size(160, 33);
            this.RBDesc.TabIndex = 6;
            this.RBDesc.Text = "Descending";
            this.RBDesc.UseVisualStyleBackColor = true;
            // 
            // RBAsc
            // 
            this.RBAsc.AutoSize = true;
            this.RBAsc.Checked = true;
            this.RBAsc.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.RBAsc.Location = new System.Drawing.Point(872, 163);
            this.RBAsc.Name = "RBAsc";
            this.RBAsc.Size = new System.Drawing.Size(144, 33);
            this.RBAsc.TabIndex = 5;
            this.RBAsc.TabStop = true;
            this.RBAsc.Text = "Ascending";
            this.RBAsc.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label5.Location = new System.Drawing.Point(436, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 29);
            this.label5.TabIndex = 137;
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
            "ID",
            "Name",
            "Vehicle No"});
            this.CBOrderBy.Location = new System.Drawing.Point(551, 162);
            this.CBOrderBy.Name = "CBOrderBy";
            this.CBOrderBy.Size = new System.Drawing.Size(270, 37);
            this.CBOrderBy.Sorted = true;
            this.CBOrderBy.TabIndex = 4;
            // 
            // TBID
            // 
            this.TBID.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBID.Location = new System.Drawing.Point(183, 162);
            this.TBID.Name = "TBID";
            this.TBID.Size = new System.Drawing.Size(207, 35);
            this.TBID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(99, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 29);
            this.label1.TabIndex = 136;
            this.label1.Text = "ID";
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
            this.menuStrip1.TabIndex = 138;
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
            this.inventoryManagementToolStripMenuItem1.Size = new System.Drawing.Size(246, 36);
            this.inventoryManagementToolStripMenuItem1.Text = "Search Line Credit Customer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.label3.Location = new System.Drawing.Point(413, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(455, 39);
            this.label3.TabIndex = 139;
            this.label3.Text = "Search Line Credit Customer";
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
            this.BtnClose.TabIndex = 140;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // SearchLineCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(1280, 738);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.RBDesc);
            this.Controls.Add(this.RBAsc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CBOrderBy);
            this.Controls.Add(this.TBID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TBVehicle);
            this.Controls.Add(this.TBName);
            this.Controls.Add(this.DGVSearchCustomer);
            this.Controls.Add(this.LblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SearchLineCustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Line Credit Customer - Sitara Hilal Petroleum Service";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SearchLineCustomerForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchLineCustomerForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSearchCustomer)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBVehicle;
        private System.Windows.Forms.TextBox TBName;
        private System.Windows.Forms.DataGridView DGVSearchCustomer;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.RadioButton RBDesc;
        private System.Windows.Forms.RadioButton RBAsc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBOrderBy;
        private System.Windows.Forms.TextBox TBID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sitaraHilalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryManagementToolStripMenuItem1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVVehicle;
        private System.Windows.Forms.Button BtnClose;
    }
}