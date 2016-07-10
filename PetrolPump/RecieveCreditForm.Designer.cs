namespace PetrolPump
{
    partial class RecieveCreditForm
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
            this.BtnClose = new System.Windows.Forms.Button();
            this.CBCompany = new System.Windows.Forms.ComboBox();
            this.BtnRecieve = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckBoxPrint = new System.Windows.Forms.CheckBox();
            this.BtnSelect = new System.Windows.Forms.Button();
            this.DGVReceiveCredit = new System.Windows.Forms.DataGridView();
            this.DGVCBSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGVVehicleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVAmountRecieved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVAmountRecievable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVLiter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVCreditID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReceiveCredit)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.BtnClose.FlatAppearance.BorderSize = 0;
            this.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClose.ForeColor = System.Drawing.Color.White;
            this.BtnClose.Location = new System.Drawing.Point(477, 374);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(103, 41);
            this.BtnClose.TabIndex = 66;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = false;
            // 
            // CBCompany
            // 
            this.CBCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBCompany.FormattingEnabled = true;
            this.CBCompany.Location = new System.Drawing.Point(138, 68);
            this.CBCompany.Name = "CBCompany";
            this.CBCompany.Size = new System.Drawing.Size(284, 28);
            this.CBCompany.TabIndex = 65;
            // 
            // BtnRecieve
            // 
            this.BtnRecieve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(179)))), ((int)(((byte)(63)))));
            this.BtnRecieve.FlatAppearance.BorderSize = 0;
            this.BtnRecieve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRecieve.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRecieve.ForeColor = System.Drawing.Color.White;
            this.BtnRecieve.Location = new System.Drawing.Point(299, 374);
            this.BtnRecieve.Name = "BtnRecieve";
            this.BtnRecieve.Size = new System.Drawing.Size(160, 41);
            this.BtnRecieve.TabIndex = 63;
            this.BtnRecieve.Text = "Recieve Credit";
            this.BtnRecieve.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(58, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 62;
            this.label2.Text = "Company";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(179)))), ((int)(((byte)(63)))));
            this.label1.Location = new System.Drawing.Point(250, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 36);
            this.label1.TabIndex = 61;
            this.label1.Text = "Recieve Credit";
            // 
            // CheckBoxPrint
            // 
            this.CheckBoxPrint.AutoSize = true;
            this.CheckBoxPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxPrint.Location = new System.Drawing.Point(150, 384);
            this.CheckBoxPrint.Name = "CheckBoxPrint";
            this.CheckBoxPrint.Size = new System.Drawing.Size(119, 24);
            this.CheckBoxPrint.TabIndex = 64;
            this.CheckBoxPrint.Text = "Print Reciept";
            this.CheckBoxPrint.UseVisualStyleBackColor = true;
            // 
            // BtnSelect
            // 
            this.BtnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(179)))), ((int)(((byte)(63)))));
            this.BtnSelect.FlatAppearance.BorderSize = 0;
            this.BtnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSelect.ForeColor = System.Drawing.Color.White;
            this.BtnSelect.Location = new System.Drawing.Point(428, 60);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(116, 41);
            this.BtnSelect.TabIndex = 67;
            this.BtnSelect.Text = "Select";
            this.BtnSelect.UseVisualStyleBackColor = false;
            this.BtnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // DGVReceiveCredit
            // 
            this.DGVReceiveCredit.AllowUserToAddRows = false;
            this.DGVReceiveCredit.AllowUserToDeleteRows = false;
            this.DGVReceiveCredit.AllowUserToResizeColumns = false;
            this.DGVReceiveCredit.AllowUserToResizeRows = false;
            this.DGVReceiveCredit.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVReceiveCredit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVReceiveCredit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVReceiveCredit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGVCBSelect,
            this.DGVVehicleID,
            this.DGVTotalAmount,
            this.DGVAmountRecieved,
            this.DGVAmountRecievable,
            this.DGVDateTime,
            this.DGVType,
            this.DGVLiter,
            this.DGVRate,
            this.DGVCreditID});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVReceiveCredit.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVReceiveCredit.Location = new System.Drawing.Point(12, 111);
            this.DGVReceiveCredit.Name = "DGVReceiveCredit";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVReceiveCredit.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVReceiveCredit.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5, 6, 0, 6);
            this.DGVReceiveCredit.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVReceiveCredit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVReceiveCredit.Size = new System.Drawing.Size(727, 248);
            this.DGVReceiveCredit.TabIndex = 68;
            // 
            // DGVCBSelect
            // 
            this.DGVCBSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DGVCBSelect.Frozen = true;
            this.DGVCBSelect.HeaderText = "Select";
            this.DGVCBSelect.Name = "DGVCBSelect";
            this.DGVCBSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCBSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DGVCBSelect.Width = 79;
            // 
            // DGVVehicleID
            // 
            this.DGVVehicleID.HeaderText = "Vehicle Number";
            this.DGVVehicleID.Name = "DGVVehicleID";
            this.DGVVehicleID.ReadOnly = true;
            // 
            // DGVTotalAmount
            // 
            this.DGVTotalAmount.HeaderText = "Total Amount";
            this.DGVTotalAmount.Name = "DGVTotalAmount";
            this.DGVTotalAmount.ReadOnly = true;
            // 
            // DGVAmountRecieved
            // 
            this.DGVAmountRecieved.HeaderText = "Amount Recieved";
            this.DGVAmountRecieved.Name = "DGVAmountRecieved";
            this.DGVAmountRecieved.ReadOnly = true;
            // 
            // DGVAmountRecievable
            // 
            this.DGVAmountRecievable.HeaderText = "Amount Recievable";
            this.DGVAmountRecievable.Name = "DGVAmountRecievable";
            this.DGVAmountRecievable.ReadOnly = true;
            // 
            // DGVDateTime
            // 
            this.DGVDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DGVDateTime.HeaderText = "Time";
            this.DGVDateTime.Name = "DGVDateTime";
            this.DGVDateTime.ReadOnly = true;
            this.DGVDateTime.Width = 68;
            // 
            // DGVType
            // 
            this.DGVType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DGVType.HeaderText = "Type";
            this.DGVType.Name = "DGVType";
            this.DGVType.ReadOnly = true;
            this.DGVType.Width = 68;
            // 
            // DGVLiter
            // 
            this.DGVLiter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DGVLiter.HeaderText = "Liter";
            this.DGVLiter.Name = "DGVLiter";
            this.DGVLiter.ReadOnly = true;
            this.DGVLiter.Width = 65;
            // 
            // DGVRate
            // 
            this.DGVRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DGVRate.HeaderText = "Rate";
            this.DGVRate.Name = "DGVRate";
            this.DGVRate.ReadOnly = true;
            this.DGVRate.Width = 69;
            // 
            // DGVCreditID
            // 
            this.DGVCreditID.HeaderText = "Credit ID";
            this.DGVCreditID.Name = "DGVCreditID";
            this.DGVCreditID.ReadOnly = true;
            this.DGVCreditID.Visible = false;
            // 
            // RecieveCreditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 438);
            this.Controls.Add(this.DGVReceiveCredit);
            this.Controls.Add(this.BtnSelect);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.CBCompany);
            this.Controls.Add(this.BtnRecieve);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CheckBoxPrint);
            this.Name = "RecieveCreditForm";
            this.Text = "RecieveCreditForm";
            this.Load += new System.EventHandler(this.RecieveCreditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVReceiveCredit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.ComboBox CBCompany;
        private System.Windows.Forms.Button BtnRecieve;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckBoxPrint;
        private System.Windows.Forms.Button BtnSelect;
        private System.Windows.Forms.DataGridView DGVReceiveCredit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGVCBSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVVehicleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVAmountRecieved;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVAmountRecievable;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVLiter;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVCreditID;
    }
}