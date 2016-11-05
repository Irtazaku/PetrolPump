namespace PetrolPump
{
    partial class AddCreditForm
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
            this.CheckBoxPrint = new System.Windows.Forms.CheckBox();
            this.CBType = new System.Windows.Forms.ComboBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.LblAmount = new System.Windows.Forms.Label();
            this.LblRate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBLiter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CBVehicle = new System.Windows.Forms.ComboBox();
            this.CBCompany = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sitaraHilalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryManagementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TBDiscount = new System.Windows.Forms.TextBox();
            this.CBMachine = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckBoxPrint
            // 
            this.CheckBoxPrint.AutoSize = true;
            this.CheckBoxPrint.Checked = true;
            this.CheckBoxPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CheckBoxPrint.Location = new System.Drawing.Point(216, 467);
            this.CheckBoxPrint.Name = "CheckBoxPrint";
            this.CheckBoxPrint.Size = new System.Drawing.Size(170, 33);
            this.CheckBoxPrint.TabIndex = 6;
            this.CheckBoxPrint.Text = "Print Reciept";
            this.CheckBoxPrint.UseVisualStyleBackColor = true;
            // 
            // CBType
            // 
            this.CBType.DropDownHeight = 205;
            this.CBType.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBType.FormattingEnabled = true;
            this.CBType.IntegralHeight = false;
            this.CBType.Location = new System.Drawing.Point(166, 253);
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
            this.BtnAdd.Location = new System.Drawing.Point(176, 519);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(250, 56);
            this.BtnAdd.TabIndex = 7;
            this.BtnAdd.Text = "Add Credit Sale";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // LblAmount
            // 
            this.LblAmount.AutoSize = true;
            this.LblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.LblAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(0)))));
            this.LblAmount.Location = new System.Drawing.Point(263, 417);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(118, 36);
            this.LblAmount.TabIndex = 37;
            this.LblAmount.Text = "Amount";
            // 
            // LblRate
            // 
            this.LblRate.AutoSize = true;
            this.LblRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.LblRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(0)))));
            this.LblRate.Location = new System.Drawing.Point(26, 417);
            this.LblRate.Name = "LblRate";
            this.LblRate.Size = new System.Drawing.Size(77, 36);
            this.LblRate.TabIndex = 36;
            this.LblRate.Text = "Rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label4.Location = new System.Drawing.Point(27, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 29);
            this.label4.TabIndex = 35;
            this.label4.Text = "Liter / Qty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label3.Location = new System.Drawing.Point(27, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 29);
            this.label3.TabIndex = 34;
            this.label3.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.Location = new System.Drawing.Point(27, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 29);
            this.label2.TabIndex = 33;
            this.label2.Text = "Company";
            // 
            // TBLiter
            // 
            this.TBLiter.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBLiter.Location = new System.Drawing.Point(166, 308);
            this.TBLiter.Name = "TBLiter";
            this.TBLiter.Size = new System.Drawing.Size(146, 35);
            this.TBLiter.TabIndex = 4;
            this.TBLiter.TextChanged += new System.EventHandler(this.TBLiter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.label1.Location = new System.Drawing.Point(173, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 39);
            this.label1.TabIndex = 29;
            this.label1.Text = "Add Credit Sale";
            // 
            // CBVehicle
            // 
            this.CBVehicle.DropDownHeight = 205;
            this.CBVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBVehicle.FormattingEnabled = true;
            this.CBVehicle.IntegralHeight = false;
            this.CBVehicle.Location = new System.Drawing.Point(166, 201);
            this.CBVehicle.Name = "CBVehicle";
            this.CBVehicle.Size = new System.Drawing.Size(408, 37);
            this.CBVehicle.TabIndex = 2;
            // 
            // CBCompany
            // 
            this.CBCompany.DropDownHeight = 205;
            this.CBCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBCompany.FormattingEnabled = true;
            this.CBCompany.IntegralHeight = false;
            this.CBCompany.Location = new System.Drawing.Point(166, 149);
            this.CBCompany.Name = "CBCompany";
            this.CBCompany.Size = new System.Drawing.Size(408, 37);
            this.CBCompany.TabIndex = 1;
            this.CBCompany.SelectedIndexChanged += new System.EventHandler(this.CBCompany_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label5.Location = new System.Drawing.Point(27, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 29);
            this.label5.TabIndex = 44;
            this.label5.Text = "Vehicle";
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
            this.menuStrip1.Size = new System.Drawing.Size(602, 46);
            this.menuStrip1.TabIndex = 62;
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
            this.inventoryManagementToolStripMenuItem1.Text = "Add Cash Sale";
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
            this.BtnClose.Location = new System.Drawing.Point(525, 525);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(50, 50);
            this.BtnClose.TabIndex = 8;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label6.Location = new System.Drawing.Point(27, 361);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 29);
            this.label6.TabIndex = 64;
            this.label6.Text = "Discount %";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // TBDiscount
            // 
            this.TBDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBDiscount.Location = new System.Drawing.Point(167, 358);
            this.TBDiscount.Name = "TBDiscount";
            this.TBDiscount.Size = new System.Drawing.Size(408, 35);
            this.TBDiscount.TabIndex = 5;
            this.TBDiscount.TextChanged += new System.EventHandler(this.TBDiscount_TextChanged);
            // 
            // CBMachine
            // 
            this.CBMachine.BackColor = System.Drawing.Color.White;
            this.CBMachine.DropDownHeight = 205;
            this.CBMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBMachine.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBMachine.ForeColor = System.Drawing.Color.Black;
            this.CBMachine.FormattingEnabled = true;
            this.CBMachine.IntegralHeight = false;
            this.CBMachine.Location = new System.Drawing.Point(422, 308);
            this.CBMachine.Name = "CBMachine";
            this.CBMachine.Size = new System.Drawing.Size(153, 37);
            this.CBMachine.Sorted = true;
            this.CBMachine.TabIndex = 66;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label7.Location = new System.Drawing.Point(318, 311);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 29);
            this.label7.TabIndex = 65;
            this.label7.Text = "Machine";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label8.Location = new System.Drawing.Point(27, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 29);
            this.label8.TabIndex = 68;
            this.label8.Text = "DateTime";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(167, 115);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(407, 20);
            this.dateTimePicker1.TabIndex = 69;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // AddCreditForm
            // 
            this.AcceptButton = this.BtnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(602, 585);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CBMachine);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TBDiscount);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CBCompany);
            this.Controls.Add(this.CBVehicle);
            this.Controls.Add(this.CBType);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.LblAmount);
            this.Controls.Add(this.LblRate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBLiter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckBoxPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCreditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Credit Sale - Sitara Hilal Petroleum Service";
            this.Load += new System.EventHandler(this.AddCreditForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckBoxPrint;
        private System.Windows.Forms.ComboBox CBType;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Label LblAmount;
        private System.Windows.Forms.Label LblRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBLiter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CBVehicle;
        private System.Windows.Forms.ComboBox CBCompany;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sitaraHilalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryManagementToolStripMenuItem1;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBDiscount;
        private System.Windows.Forms.ComboBox CBMachine;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}