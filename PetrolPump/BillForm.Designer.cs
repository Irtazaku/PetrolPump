namespace PetrolPump
{
    partial class BillForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sitaraHilalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryManagementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.BillLabel = new System.Windows.Forms.Label();
            this.CBCompany = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.LblType = new System.Windows.Forms.Label();
            this.DPFrom = new System.Windows.Forms.DateTimePicker();
            this.BtnClose = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DPTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
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
            this.menuStrip1.Size = new System.Drawing.Size(599, 46);
            this.menuStrip1.TabIndex = 109;
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
            this.inventoryManagementToolStripMenuItem1.Size = new System.Drawing.Size(128, 36);
            this.inventoryManagementToolStripMenuItem1.Text = "Company Bill";
            // 
            // BillLabel
            // 
            this.BillLabel.AutoSize = true;
            this.BillLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.BillLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.BillLabel.Location = new System.Drawing.Point(188, 60);
            this.BillLabel.Name = "BillLabel";
            this.BillLabel.Size = new System.Drawing.Size(219, 39);
            this.BillLabel.TabIndex = 115;
            this.BillLabel.Text = "Company Bill";
            // 
            // CBCompany
            // 
            this.CBCompany.DropDownHeight = 205;
            this.CBCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBCompany.FormattingEnabled = true;
            this.CBCompany.IntegralHeight = false;
            this.CBCompany.Location = new System.Drawing.Point(162, 109);
            this.CBCompany.Name = "CBCompany";
            this.CBCompany.Size = new System.Drawing.Size(408, 37);
            this.CBCompany.TabIndex = 116;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.Location = new System.Drawing.Point(25, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 29);
            this.label1.TabIndex = 121;
            this.label1.Text = "Company";
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.BtnAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(181, 255);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(237, 56);
            this.BtnAdd.TabIndex = 118;
            this.BtnAdd.Text = "Save Bill";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.LblType.Location = new System.Drawing.Point(25, 162);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(126, 29);
            this.LblType.TabIndex = 120;
            this.LblType.Text = "From Date";
            // 
            // DPFrom
            // 
            this.DPFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.DPFrom.Location = new System.Drawing.Point(162, 162);
            this.DPFrom.Name = "DPFrom";
            this.DPFrom.Size = new System.Drawing.Size(408, 29);
            this.DPFrom.TabIndex = 122;
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
            this.BtnClose.Location = new System.Drawing.Point(1325, 96);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(50, 50);
            this.BtnClose.TabIndex = 98;
            this.BtnClose.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(27)))), ((int)(((byte)(28)))));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::PetrolPump.Properties.Resources.icon_close_circled_128__2_;
            this.button1.Location = new System.Drawing.Point(520, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 119;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DPTo
            // 
            this.DPTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.DPTo.Location = new System.Drawing.Point(162, 203);
            this.DPTo.Name = "DPTo";
            this.DPTo.Size = new System.Drawing.Size(408, 29);
            this.DPTo.TabIndex = 124;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.Location = new System.Drawing.Point(25, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 29);
            this.label2.TabIndex = 123;
            this.label2.Text = "To Date";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // BillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(599, 333);
            this.Controls.Add(this.DPFrom);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CBCompany);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.LblType);
            this.Controls.Add(this.BillLabel);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.DPTo);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BillForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Bill - Sitara Hilal Petroleum Service";
            this.Load += new System.EventHandler(this.BillForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sitaraHilalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryManagementToolStripMenuItem1;
        private System.Windows.Forms.Label BillLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CBCompany;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.DateTimePicker DPFrom;
        private System.Windows.Forms.DateTimePicker DPTo;
        private System.Windows.Forms.Label label2;
    }
}