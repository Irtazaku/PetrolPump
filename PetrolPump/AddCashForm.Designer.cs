namespace PetrolPump
{
    partial class AddCashForm
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
            this.label7 = new System.Windows.Forms.Label();
            this.LblAmount = new System.Windows.Forms.Label();
            this.LblRate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBVehicleNumber = new System.Windows.Forms.TextBox();
            this.TBLiter = new System.Windows.Forms.TextBox();
            this.TBName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sitaraHilalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryManagementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CBMachine = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckBoxPrint
            // 
            this.CheckBoxPrint.AutoSize = true;
            this.CheckBoxPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CheckBoxPrint.Location = new System.Drawing.Point(222, 363);
            this.CheckBoxPrint.Name = "CheckBoxPrint";
            this.CheckBoxPrint.Size = new System.Drawing.Size(170, 33);
            this.CheckBoxPrint.TabIndex = 5;
            this.CheckBoxPrint.Text = "Print Reciept";
            this.CheckBoxPrint.UseVisualStyleBackColor = true;
            // 
            // CBType
            // 
            this.CBType.BackColor = System.Drawing.Color.White;
            this.CBType.DropDownHeight = 205;
            this.CBType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBType.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBType.ForeColor = System.Drawing.Color.Black;
            this.CBType.FormattingEnabled = true;
            this.CBType.IntegralHeight = false;
            this.CBType.Location = new System.Drawing.Point(180, 162);
            this.CBType.Name = "CBType";
            this.CBType.Size = new System.Drawing.Size(408, 37);
            this.CBType.Sorted = true;
            this.CBType.TabIndex = 2;
            this.CBType.SelectedIndexChanged += new System.EventHandler(this.CBType_SelectedIndexChanged);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(182, 413);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(250, 56);
            this.BtnAdd.TabIndex = 6;
            this.BtnAdd.Text = "Add Cash Sale";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label7.Location = new System.Drawing.Point(27, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 29);
            this.label7.TabIndex = 25;
            this.label7.Text = "Vehicle No";
            // 
            // LblAmount
            // 
            this.LblAmount.AutoSize = true;
            this.LblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.LblAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(0)))));
            this.LblAmount.Location = new System.Drawing.Point(263, 313);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(118, 36);
            this.LblAmount.TabIndex = 24;
            this.LblAmount.Text = "Amount";
            // 
            // LblRate
            // 
            this.LblRate.AutoSize = true;
            this.LblRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.LblRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(0)))));
            this.LblRate.Location = new System.Drawing.Point(26, 313);
            this.LblRate.Name = "LblRate";
            this.LblRate.Size = new System.Drawing.Size(77, 36);
            this.LblRate.TabIndex = 23;
            this.LblRate.Text = "Rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label4.Location = new System.Drawing.Point(27, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 29);
            this.label4.TabIndex = 22;
            this.label4.Text = "Liter / Qty";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label3.Location = new System.Drawing.Point(27, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 29);
            this.label3.TabIndex = 21;
            this.label3.Text = "Fuel Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.Location = new System.Drawing.Point(27, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 29);
            this.label2.TabIndex = 20;
            this.label2.Text = "Driver Name";
            // 
            // TBVehicleNumber
            // 
            this.TBVehicleNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBVehicleNumber.Location = new System.Drawing.Point(180, 264);
            this.TBVehicleNumber.Name = "TBVehicleNumber";
            this.TBVehicleNumber.Size = new System.Drawing.Size(408, 35);
            this.TBVehicleNumber.TabIndex = 4;
            // 
            // TBLiter
            // 
            this.TBLiter.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBLiter.Location = new System.Drawing.Point(180, 214);
            this.TBLiter.Name = "TBLiter";
            this.TBLiter.Size = new System.Drawing.Size(146, 35);
            this.TBLiter.TabIndex = 3;
            this.TBLiter.TextChanged += new System.EventHandler(this.TBLiter_TextChanged);
            // 
            // TBName
            // 
            this.TBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBName.Location = new System.Drawing.Point(180, 112);
            this.TBName.Name = "TBName";
            this.TBName.Size = new System.Drawing.Size(408, 35);
            this.TBName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.label1.Location = new System.Drawing.Point(185, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 39);
            this.label1.TabIndex = 16;
            this.label1.Text = "Add Cash Sale";
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
            this.menuStrip1.Size = new System.Drawing.Size(615, 46);
            this.menuStrip1.TabIndex = 61;
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
            this.BtnClose.Location = new System.Drawing.Point(538, 419);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(50, 50);
            this.BtnClose.TabIndex = 7;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label5.Location = new System.Drawing.Point(328, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 29);
            this.label5.TabIndex = 62;
            this.label5.Text = "Machine";
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
            this.CBMachine.Location = new System.Drawing.Point(431, 214);
            this.CBMachine.Name = "CBMachine";
            this.CBMachine.Size = new System.Drawing.Size(157, 37);
            this.CBMachine.Sorted = true;
            this.CBMachine.TabIndex = 63;
            // 
            // AddCashForm
            // 
            this.AcceptButton = this.BtnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(615, 496);
            this.Controls.Add(this.CBMachine);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.CheckBoxPrint);
            this.Controls.Add(this.CBType);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LblAmount);
            this.Controls.Add(this.LblRate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBVehicleNumber);
            this.Controls.Add(this.TBLiter);
            this.Controls.Add(this.TBName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCashForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Cash Sale - Sitara Hilal Petroleum Service";
            this.Load += new System.EventHandler(this.AddCashForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckBoxPrint;
        private System.Windows.Forms.ComboBox CBType;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblAmount;
        private System.Windows.Forms.Label LblRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBVehicleNumber;
        private System.Windows.Forms.TextBox TBLiter;
        private System.Windows.Forms.TextBox TBName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sitaraHilalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryManagementToolStripMenuItem1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CBMachine;

    }
}