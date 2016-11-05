namespace PetrolPump
{
    partial class AddLineCreditForm
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
            this.CBCustomer = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.CBType = new System.Windows.Forms.ComboBox();
            this.LblAmount = new System.Windows.Forms.Label();
            this.LblRate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TBLiter = new System.Windows.Forms.TextBox();
            this.CheckBoxPrint = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sitaraHilalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryManagementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TBDiscount = new System.Windows.Forms.TextBox();
            this.CBMachine = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CBCustomer
            // 
            this.CBCustomer.DropDownHeight = 205;
            this.CBCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBCustomer.FormattingEnabled = true;
            this.CBCustomer.IntegralHeight = false;
            this.CBCustomer.Location = new System.Drawing.Point(167, 153);
            this.CBCustomer.Name = "CBCustomer";
            this.CBCustomer.Size = new System.Drawing.Size(408, 37);
            this.CBCustomer.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.Location = new System.Drawing.Point(27, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 29);
            this.label2.TabIndex = 62;
            this.label2.Text = "Vehicle No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.label1.Location = new System.Drawing.Point(136, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 39);
            this.label1.TabIndex = 60;
            this.label1.Text = "Add Line Credit Sale";
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(143, 464);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(317, 56);
            this.BtnAdd.TabIndex = 6;
            this.BtnAdd.Text = "Add Line Credit Sale";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // CBType
            // 
            this.CBType.DropDownHeight = 205;
            this.CBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBType.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBType.FormattingEnabled = true;
            this.CBType.IntegralHeight = false;
            this.CBType.Location = new System.Drawing.Point(167, 203);
            this.CBType.Name = "CBType";
            this.CBType.Size = new System.Drawing.Size(408, 37);
            this.CBType.Sorted = true;
            this.CBType.TabIndex = 2;
            this.CBType.SelectedIndexChanged += new System.EventHandler(this.CBType_SelectedIndexChanged);
            // 
            // LblAmount
            // 
            this.LblAmount.AutoSize = true;
            this.LblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.LblAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(0)))));
            this.LblAmount.Location = new System.Drawing.Point(272, 364);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(118, 36);
            this.LblAmount.TabIndex = 74;
            this.LblAmount.Text = "Amount";
            // 
            // LblRate
            // 
            this.LblRate.AutoSize = true;
            this.LblRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.LblRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(0)))));
            this.LblRate.Location = new System.Drawing.Point(27, 364);
            this.LblRate.Name = "LblRate";
            this.LblRate.Size = new System.Drawing.Size(77, 36);
            this.LblRate.TabIndex = 73;
            this.LblRate.Text = "Rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label4.Location = new System.Drawing.Point(27, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 29);
            this.label4.TabIndex = 72;
            this.label4.Text = "Liter / Qty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label3.Location = new System.Drawing.Point(27, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 29);
            this.label3.TabIndex = 71;
            this.label3.Text = "Fuel Type";
            // 
            // TBLiter
            // 
            this.TBLiter.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBLiter.Location = new System.Drawing.Point(167, 255);
            this.TBLiter.Name = "TBLiter";
            this.TBLiter.Size = new System.Drawing.Size(146, 35);
            this.TBLiter.TabIndex = 3;
            this.TBLiter.TextChanged += new System.EventHandler(this.TBLiter_TextChanged);
            // 
            // CheckBoxPrint
            // 
            this.CheckBoxPrint.AutoSize = true;
            this.CheckBoxPrint.Checked = true;
            this.CheckBoxPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CheckBoxPrint.Location = new System.Drawing.Point(216, 414);
            this.CheckBoxPrint.Name = "CheckBoxPrint";
            this.CheckBoxPrint.Size = new System.Drawing.Size(170, 33);
            this.CheckBoxPrint.TabIndex = 5;
            this.CheckBoxPrint.Text = "Print Reciept";
            this.CheckBoxPrint.UseVisualStyleBackColor = true;
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
            this.inventoryManagementToolStripMenuItem1.Size = new System.Drawing.Size(183, 36);
            this.inventoryManagementToolStripMenuItem1.Text = "Add Line Credit Sale";
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
            this.BtnClose.Location = new System.Drawing.Point(522, 470);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(50, 50);
            this.BtnClose.TabIndex = 7;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label6.Location = new System.Drawing.Point(27, 308);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 29);
            this.label6.TabIndex = 79;
            this.label6.Text = "Discount %";
            // 
            // TBDiscount
            // 
            this.TBDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBDiscount.Location = new System.Drawing.Point(167, 305);
            this.TBDiscount.Name = "TBDiscount";
            this.TBDiscount.Size = new System.Drawing.Size(408, 35);
            this.TBDiscount.TabIndex = 4;
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
            this.CBMachine.Location = new System.Drawing.Point(422, 255);
            this.CBMachine.Name = "CBMachine";
            this.CBMachine.Size = new System.Drawing.Size(153, 37);
            this.CBMachine.Sorted = true;
            this.CBMachine.TabIndex = 81;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label7.Location = new System.Drawing.Point(318, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 29);
            this.label7.TabIndex = 80;
            this.label7.Text = "Machine";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(167, 118);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(408, 20);
            this.dateTimePicker1.TabIndex = 83;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label8.Location = new System.Drawing.Point(28, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 29);
            this.label8.TabIndex = 82;
            this.label8.Text = "DateTime";
            // 
            // AddLineCreditForm
            // 
            this.AcceptButton = this.BtnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(602, 540);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CBMachine);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TBDiscount);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.CBType);
            this.Controls.Add(this.LblAmount);
            this.Controls.Add(this.LblRate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBLiter);
            this.Controls.Add(this.CheckBoxPrint);
            this.Controls.Add(this.CBCustomer);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddLineCreditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Line Credit Sale - Sitara Hilal Petroleum Service";
            this.Load += new System.EventHandler(this.AddLineCreditForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.ComboBox CBType;
        private System.Windows.Forms.Label LblAmount;
        private System.Windows.Forms.Label LblRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBLiter;
        private System.Windows.Forms.CheckBox CheckBoxPrint;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sitaraHilalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryManagementToolStripMenuItem1;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBDiscount;
        private System.Windows.Forms.ComboBox CBMachine;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
    }
}