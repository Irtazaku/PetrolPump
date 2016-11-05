namespace PetrolPump
{
    partial class ReceiveCreditForm
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
            this.CBName = new System.Windows.Forms.ComboBox();
            this.BtnReceive = new System.Windows.Forms.Button();
            this.CheckBoxPrint = new System.Windows.Forms.CheckBox();
            this.RBChequePayment = new System.Windows.Forms.RadioButton();
            this.RBCashPayment = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TBChequeNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sitaraHilalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryManagementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblAmount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TBAmount = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CBAccountNo = new System.Windows.Forms.ComboBox();
            this.CBBankName = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CBName
            // 
            this.CBName.DropDownHeight = 205;
            this.CBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBName.FormattingEnabled = true;
            this.CBName.IntegralHeight = false;
            this.CBName.Location = new System.Drawing.Point(148, 137);
            this.CBName.Name = "CBName";
            this.CBName.Size = new System.Drawing.Size(408, 37);
            this.CBName.Sorted = true;
            this.CBName.TabIndex = 1;
            this.CBName.SelectedIndexChanged += new System.EventHandler(this.CBName_SelectedIndexChanged);
            // 
            // BtnReceive
            // 
            this.BtnReceive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.BtnReceive.FlatAppearance.BorderSize = 0;
            this.BtnReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReceive.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.BtnReceive.ForeColor = System.Drawing.Color.White;
            this.BtnReceive.Location = new System.Drawing.Point(161, 53);
            this.BtnReceive.Name = "BtnReceive";
            this.BtnReceive.Size = new System.Drawing.Size(232, 56);
            this.BtnReceive.TabIndex = 9;
            this.BtnReceive.Text = "Receive Credit";
            this.BtnReceive.UseVisualStyleBackColor = false;
            this.BtnReceive.Click += new System.EventHandler(this.BtnReceive_Click);
            // 
            // CheckBoxPrint
            // 
            this.CheckBoxPrint.AutoSize = true;
            this.CheckBoxPrint.Checked = true;
            this.CheckBoxPrint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CheckBoxPrint.Location = new System.Drawing.Point(192, 3);
            this.CheckBoxPrint.Name = "CheckBoxPrint";
            this.CheckBoxPrint.Size = new System.Drawing.Size(170, 33);
            this.CheckBoxPrint.TabIndex = 8;
            this.CheckBoxPrint.Text = "Print Reciept";
            this.CheckBoxPrint.UseVisualStyleBackColor = true;
            // 
            // RBChequePayment
            // 
            this.RBChequePayment.AutoSize = true;
            this.RBChequePayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.RBChequePayment.Location = new System.Drawing.Point(232, 299);
            this.RBChequePayment.Name = "RBChequePayment";
            this.RBChequePayment.Size = new System.Drawing.Size(215, 33);
            this.RBChequePayment.TabIndex = 4;
            this.RBChequePayment.TabStop = true;
            this.RBChequePayment.Text = "Cheque Payment";
            this.RBChequePayment.UseVisualStyleBackColor = true;
            // 
            // RBCashPayment
            // 
            this.RBCashPayment.AutoSize = true;
            this.RBCashPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.RBCashPayment.Location = new System.Drawing.Point(32, 299);
            this.RBCashPayment.Name = "RBCashPayment";
            this.RBCashPayment.Size = new System.Drawing.Size(185, 33);
            this.RBCashPayment.TabIndex = 3;
            this.RBCashPayment.TabStop = true;
            this.RBCashPayment.Text = "Cash Payment";
            this.RBCashPayment.UseVisualStyleBackColor = true;
            this.RBCashPayment.CheckedChanged += new System.EventHandler(this.RBCashPayment_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.Location = new System.Drawing.Point(10, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 29);
            this.label2.TabIndex = 98;
            this.label2.Text = "Account No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label5.Location = new System.Drawing.Point(8, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 29);
            this.label5.TabIndex = 102;
            this.label5.Text = "Bank Name";
            // 
            // TBChequeNo
            // 
            this.TBChequeNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBChequeNo.Location = new System.Drawing.Point(154, 3);
            this.TBChequeNo.Name = "TBChequeNo";
            this.TBChequeNo.Size = new System.Drawing.Size(385, 35);
            this.TBChequeNo.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label3.Location = new System.Drawing.Point(10, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 29);
            this.label3.TabIndex = 100;
            this.label3.Text = "Cheque No";
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
            this.BtnClose.Location = new System.Drawing.Point(489, 59);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(50, 50);
            this.BtnClose.TabIndex = 10;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
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
            this.menuStrip1.TabIndex = 112;
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
            this.inventoryManagementToolStripMenuItem1.Size = new System.Drawing.Size(135, 36);
            this.inventoryManagementToolStripMenuItem1.Text = "Receive Credit";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.label1.Location = new System.Drawing.Point(171, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 39);
            this.label1.TabIndex = 130;
            this.label1.Text = "Receive Credit";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label4.Location = new System.Drawing.Point(27, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 29);
            this.label4.TabIndex = 135;
            this.label4.Text = "Company";
            // 
            // LblAmount
            // 
            this.LblAmount.AutoSize = true;
            this.LblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.LblAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(0)))));
            this.LblAmount.Location = new System.Drawing.Point(26, 190);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(351, 36);
            this.LblAmount.TabIndex = 137;
            this.LblAmount.Text = "Amount Receivable: 0 Rs";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(26, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(258, 36);
            this.label7.TabIndex = 136;
            this.label7.Text = "Amount Receiving";
            // 
            // TBAmount
            // 
            this.TBAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.TBAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(0)))));
            this.TBAmount.Location = new System.Drawing.Point(290, 239);
            this.TBAmount.Name = "TBAmount";
            this.TBAmount.Size = new System.Drawing.Size(266, 41);
            this.TBAmount.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TBChequeNo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CBAccountNo);
            this.panel1.Controls.Add(this.CBBankName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(17, 340);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 141);
            this.panel1.TabIndex = 138;
            // 
            // CBAccountNo
            // 
            this.CBAccountNo.DropDownHeight = 205;
            this.CBAccountNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBAccountNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBAccountNo.FormattingEnabled = true;
            this.CBAccountNo.IntegralHeight = false;
            this.CBAccountNo.Location = new System.Drawing.Point(152, 103);
            this.CBAccountNo.Name = "CBAccountNo";
            this.CBAccountNo.Size = new System.Drawing.Size(385, 37);
            this.CBAccountNo.Sorted = true;
            this.CBAccountNo.TabIndex = 103;
            // 
            // CBBankName
            // 
            this.CBBankName.DropDownHeight = 205;
            this.CBBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBBankName.FormattingEnabled = true;
            this.CBBankName.IntegralHeight = false;
            this.CBBankName.Location = new System.Drawing.Point(152, 53);
            this.CBBankName.Name = "CBBankName";
            this.CBBankName.Size = new System.Drawing.Size(385, 37);
            this.CBBankName.Sorted = true;
            this.CBBankName.TabIndex = 104;
            this.CBBankName.SelectedIndexChanged += new System.EventHandler(this.CBBankName_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnReceive);
            this.panel2.Controls.Add(this.CheckBoxPrint);
            this.panel2.Controls.Add(this.BtnClose);
            this.panel2.Location = new System.Drawing.Point(17, 490);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(554, 116);
            this.panel2.TabIndex = 139;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(148, 105);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(408, 20);
            this.dateTimePicker1.TabIndex = 141;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label8.Location = new System.Drawing.Point(27, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 29);
            this.label8.TabIndex = 140;
            this.label8.Text = "DateTime";
            // 
            // ReceiveCreditForm
            // 
            this.AcceptButton = this.BtnReceive;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(583, 615);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TBAmount);
            this.Controls.Add(this.LblAmount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.RBChequePayment);
            this.Controls.Add(this.RBCashPayment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.CBName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReceiveCreditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receive Credit - Sitara Hilal Petroleum Service";
            this.Load += new System.EventHandler(this.ReceiveCreditForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBName;
        private System.Windows.Forms.Button BtnReceive;
        private System.Windows.Forms.CheckBox CheckBoxPrint;
        private System.Windows.Forms.RadioButton RBChequePayment;
        private System.Windows.Forms.RadioButton RBCashPayment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBChequeNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sitaraHilalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryManagementToolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TBAmount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox CBAccountNo;
        private System.Windows.Forms.ComboBox CBBankName;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label8;
    }
}