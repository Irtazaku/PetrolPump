namespace PetrolPump
{
    partial class AddInventoryForm
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
            this.CBType = new System.Windows.Forms.ComboBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.LblType = new System.Windows.Forms.Label();
            this.LblName = new System.Windows.Forms.Label();
            this.TBLiter = new System.Windows.Forms.TextBox();
            this.TBName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RBNewInventory = new System.Windows.Forms.RadioButton();
            this.RBOldInventory = new System.Windows.Forms.RadioButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sitaraHilalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryManagementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnClose = new System.Windows.Forms.Button();
            this.LblRate = new System.Windows.Forms.Label();
            this.TBRate = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CBType
            // 
            this.CBType.DropDownHeight = 205;
            this.CBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBType.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBType.FormattingEnabled = true;
            this.CBType.IntegralHeight = false;
            this.CBType.Location = new System.Drawing.Point(148, 210);
            this.CBType.Name = "CBType";
            this.CBType.Size = new System.Drawing.Size(408, 37);
            this.CBType.Sorted = true;
            this.CBType.TabIndex = 3;
            this.CBType.SelectedIndexChanged += new System.EventHandler(this.CBType_SelectedIndexChanged);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(168, 370);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(242, 56);
            this.BtnAdd.TabIndex = 6;
            this.BtnAdd.Text = "Add Inventory";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label4.Location = new System.Drawing.Point(27, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 29);
            this.label4.TabIndex = 67;
            this.label4.Text = "Liter / Qty";
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.LblType.Location = new System.Drawing.Point(27, 213);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(68, 29);
            this.LblType.TabIndex = 66;
            this.LblType.Text = "Type";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.LblName.Location = new System.Drawing.Point(27, 213);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(78, 29);
            this.LblName.TabIndex = 65;
            this.LblName.Text = "Name";
            // 
            // TBLiter
            // 
            this.TBLiter.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBLiter.Location = new System.Drawing.Point(148, 260);
            this.TBLiter.Name = "TBLiter";
            this.TBLiter.Size = new System.Drawing.Size(408, 35);
            this.TBLiter.TabIndex = 4;
            // 
            // TBName
            // 
            this.TBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBName.Location = new System.Drawing.Point(148, 210);
            this.TBName.Name = "TBName";
            this.TBName.Size = new System.Drawing.Size(408, 35);
            this.TBName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.label1.Location = new System.Drawing.Point(176, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 39);
            this.label1.TabIndex = 61;
            this.label1.Text = "Add Inventory";
            // 
            // RBNewInventory
            // 
            this.RBNewInventory.AutoSize = true;
            this.RBNewInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.RBNewInventory.Location = new System.Drawing.Point(27, 115);
            this.RBNewInventory.Name = "RBNewInventory";
            this.RBNewInventory.Size = new System.Drawing.Size(232, 33);
            this.RBNewInventory.TabIndex = 1;
            this.RBNewInventory.TabStop = true;
            this.RBNewInventory.Text = "Add New Inventory";
            this.RBNewInventory.UseVisualStyleBackColor = true;
            this.RBNewInventory.CheckedChanged += new System.EventHandler(this.RBNewInventory_CheckedChanged);
            // 
            // RBOldInventory
            // 
            this.RBOldInventory.AutoSize = true;
            this.RBOldInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.RBOldInventory.Location = new System.Drawing.Point(27, 154);
            this.RBOldInventory.Name = "RBOldInventory";
            this.RBOldInventory.Size = new System.Drawing.Size(167, 33);
            this.RBOldInventory.TabIndex = 2;
            this.RBOldInventory.TabStop = true;
            this.RBOldInventory.Text = "Add Quantity";
            this.RBOldInventory.UseVisualStyleBackColor = true;
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
            this.menuStrip1.Size = new System.Drawing.Size(583, 46);
            this.menuStrip1.TabIndex = 77;
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
            this.inventoryManagementToolStripMenuItem1.ShortcutKeyDisplayString = "";
            this.inventoryManagementToolStripMenuItem1.Size = new System.Drawing.Size(138, 36);
            this.inventoryManagementToolStripMenuItem1.Text = "Add Inventory";
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
            this.BtnClose.Location = new System.Drawing.Point(506, 376);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(50, 50);
            this.BtnClose.TabIndex = 7;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // LblRate
            // 
            this.LblRate.AutoSize = true;
            this.LblRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.LblRate.Location = new System.Drawing.Point(27, 313);
            this.LblRate.Name = "LblRate";
            this.LblRate.Size = new System.Drawing.Size(63, 29);
            this.LblRate.TabIndex = 68;
            this.LblRate.Text = "Rate";
            // 
            // TBRate
            // 
            this.TBRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBRate.Location = new System.Drawing.Point(148, 310);
            this.TBRate.Name = "TBRate";
            this.TBRate.Size = new System.Drawing.Size(408, 35);
            this.TBRate.TabIndex = 5;
            // 
            // AddInventoryForm
            // 
            this.AcceptButton = this.BtnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(583, 453);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.RBOldInventory);
            this.Controls.Add(this.RBNewInventory);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.LblRate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TBRate);
            this.Controls.Add(this.TBLiter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblType);
            this.Controls.Add(this.LblName);
            this.Controls.Add(this.CBType);
            this.Controls.Add(this.TBName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddInventoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Inventory - Sitara Hilal Petroleum Service";
            this.Load += new System.EventHandler(this.AddInventoryForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBType;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TBLiter;
        private System.Windows.Forms.TextBox TBName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RBNewInventory;
        private System.Windows.Forms.RadioButton RBOldInventory;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sitaraHilalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryManagementToolStripMenuItem1;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label LblRate;
        private System.Windows.Forms.TextBox TBRate;
    }
}