namespace PetrolPump
{
    partial class SearchInventoryForm
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
            this.DGVSearchInventory = new System.Windows.Forms.DataGridView();
            this.DGVName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblRate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.TBRate = new System.Windows.Forms.TextBox();
            this.TBQuantity = new System.Windows.Forms.TextBox();
            this.CBOrderBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RBDesc = new System.Windows.Forms.RadioButton();
            this.RBAsc = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sitaraHilalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryManagementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.CBName = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSearchInventory)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVSearchInventory
            // 
            this.DGVSearchInventory.AllowUserToAddRows = false;
            this.DGVSearchInventory.AllowUserToDeleteRows = false;
            this.DGVSearchInventory.AllowUserToResizeColumns = false;
            this.DGVSearchInventory.AllowUserToResizeRows = false;
            this.DGVSearchInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVSearchInventory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVSearchInventory.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVSearchInventory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVSearchInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSearchInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGVName,
            this.DGVRate,
            this.DGVQuantity});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVSearchInventory.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVSearchInventory.Location = new System.Drawing.Point(12, 212);
            this.DGVSearchInventory.Name = "DGVSearchInventory";
            this.DGVSearchInventory.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVSearchInventory.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVSearchInventory.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 6, 0, 6);
            this.DGVSearchInventory.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVSearchInventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVSearchInventory.Size = new System.Drawing.Size(1334, 513);
            this.DGVSearchInventory.TabIndex = 7;
            // 
            // DGVName
            // 
            this.DGVName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGVName.HeaderText = "Name";
            this.DGVName.Name = "DGVName";
            this.DGVName.ReadOnly = true;
            // 
            // DGVRate
            // 
            this.DGVRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGVRate.HeaderText = "Rate";
            this.DGVRate.Name = "DGVRate";
            this.DGVRate.ReadOnly = true;
            // 
            // DGVQuantity
            // 
            this.DGVQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DGVQuantity.HeaderText = "Quantity";
            this.DGVQuantity.Name = "DGVQuantity";
            this.DGVQuantity.ReadOnly = true;
            // 
            // LblRate
            // 
            this.LblRate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblRate.AutoSize = true;
            this.LblRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.LblRate.Location = new System.Drawing.Point(550, 165);
            this.LblRate.Name = "LblRate";
            this.LblRate.Size = new System.Drawing.Size(63, 29);
            this.LblRate.TabIndex = 79;
            this.LblRate.Text = "Rate";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label4.Location = new System.Drawing.Point(173, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 29);
            this.label4.TabIndex = 78;
            this.label4.Text = "Liter / Qty";
            // 
            // LblName
            // 
            this.LblName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.LblName.Location = new System.Drawing.Point(173, 115);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(78, 29);
            this.LblName.TabIndex = 76;
            this.LblName.Text = "Name";
            // 
            // TBRate
            // 
            this.TBRate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TBRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBRate.Location = new System.Drawing.Point(619, 162);
            this.TBRate.Name = "TBRate";
            this.TBRate.Size = new System.Drawing.Size(200, 35);
            this.TBRate.TabIndex = 4;
            this.TBRate.TextChanged += new System.EventHandler(this.TBRate_TextChanged);
            // 
            // TBQuantity
            // 
            this.TBQuantity.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TBQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBQuantity.Location = new System.Drawing.Point(294, 162);
            this.TBQuantity.Name = "TBQuantity";
            this.TBQuantity.Size = new System.Drawing.Size(200, 35);
            this.TBQuantity.TabIndex = 3;
            this.TBQuantity.TextChanged += new System.EventHandler(this.TBQuantity_TextChanged);
            // 
            // CBOrderBy
            // 
            this.CBOrderBy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CBOrderBy.DropDownHeight = 205;
            this.CBOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBOrderBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBOrderBy.FormattingEnabled = true;
            this.CBOrderBy.IntegralHeight = false;
            this.CBOrderBy.Items.AddRange(new object[] {
            "Name",
            "Quantity",
            "Rate"});
            this.CBOrderBy.Location = new System.Drawing.Point(915, 112);
            this.CBOrderBy.Name = "CBOrderBy";
            this.CBOrderBy.Size = new System.Drawing.Size(270, 37);
            this.CBOrderBy.Sorted = true;
            this.CBOrderBy.TabIndex = 2;
            this.CBOrderBy.SelectedIndexChanged += new System.EventHandler(this.CBOrderBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.Location = new System.Drawing.Point(800, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 29);
            this.label1.TabIndex = 81;
            this.label1.Text = "Order By";
            // 
            // RBDesc
            // 
            this.RBDesc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RBDesc.AutoSize = true;
            this.RBDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.RBDesc.Location = new System.Drawing.Point(1025, 163);
            this.RBDesc.Name = "RBDesc";
            this.RBDesc.Size = new System.Drawing.Size(160, 33);
            this.RBDesc.TabIndex = 6;
            this.RBDesc.Text = "Descending";
            this.RBDesc.UseVisualStyleBackColor = true;
            // 
            // RBAsc
            // 
            this.RBAsc.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RBAsc.AutoSize = true;
            this.RBAsc.Checked = true;
            this.RBAsc.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.RBAsc.Location = new System.Drawing.Point(875, 163);
            this.RBAsc.Name = "RBAsc";
            this.RBAsc.Size = new System.Drawing.Size(144, 33);
            this.RBAsc.TabIndex = 5;
            this.RBAsc.TabStop = true;
            this.RBAsc.Text = "Ascending";
            this.RBAsc.UseVisualStyleBackColor = true;
            this.RBAsc.CheckedChanged += new System.EventHandler(this.RBAsc_CheckedChanged);
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
            this.menuStrip1.Size = new System.Drawing.Size(1358, 46);
            this.menuStrip1.TabIndex = 100;
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
            this.inventoryManagementToolStripMenuItem1.Size = new System.Drawing.Size(156, 36);
            this.inventoryManagementToolStripMenuItem1.Text = "Search Inventory";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.label3.Location = new System.Drawing.Point(542, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(274, 39);
            this.label3.TabIndex = 129;
            this.label3.Text = "Search Inventory";
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(27)))), ((int)(((byte)(28)))));
            this.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnClose.FlatAppearance.BorderSize = 0;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.BtnClose.ForeColor = System.Drawing.Color.White;
            this.BtnClose.Image = global::PetrolPump.Properties.Resources.icon_close_circled_128__2_;
            this.BtnClose.Location = new System.Drawing.Point(1296, 59);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(50, 50);
            this.BtnClose.TabIndex = 130;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // CBName
            // 
            this.CBName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBName.FormattingEnabled = true;
            this.CBName.Location = new System.Drawing.Point(294, 112);
            this.CBName.Name = "CBName";
            this.CBName.Size = new System.Drawing.Size(450, 32);
            this.CBName.TabIndex = 131;
            this.CBName.SelectedIndexChanged += new System.EventHandler(this.CBName_SelectedIndexChanged);
            // 
            // SearchInventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(1362, 741);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.RBDesc);
            this.Controls.Add(this.RBAsc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBOrderBy);
            this.Controls.Add(this.LblRate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TBRate);
            this.Controls.Add(this.TBQuantity);
            this.Controls.Add(this.DGVSearchInventory);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.CBName);
            this.Name = "SearchInventoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Inventory - Sitara Hilal Petroleum Service";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchInventoryForm_FormClosing);
            this.Load += new System.EventHandler(this.SearchInventoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSearchInventory)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVSearchInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVQuantity;
        private System.Windows.Forms.Label LblRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TBRate;
        private System.Windows.Forms.TextBox TBQuantity;
        private System.Windows.Forms.ComboBox CBOrderBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RBDesc;
        private System.Windows.Forms.RadioButton RBAsc;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sitaraHilalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryManagementToolStripMenuItem1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.ComboBox CBName;
    }
}