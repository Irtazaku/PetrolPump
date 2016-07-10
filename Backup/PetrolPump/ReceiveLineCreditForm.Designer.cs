﻿namespace PetrolPump
{
    partial class ReceiveLineCreditForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnSelect = new System.Windows.Forms.Button();
            this.CBNumber = new System.Windows.Forms.ComboBox();
            this.DGVReceiveLineCredit = new System.Windows.Forms.DataGridView();
            this.BtnReceive = new System.Windows.Forms.Button();
            this.CheckBoxPrint = new System.Windows.Forms.CheckBox();
            this.RBNumber = new System.Windows.Forms.RadioButton();
            this.RBID = new System.Windows.Forms.RadioButton();
            this.CBID = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sitaraHilalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryManagementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.LblAmount = new System.Windows.Forms.Label();
            this.DGVCBSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DGVTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVAmountReceived = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVAmountReceivable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVAmountReceiving = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVLiter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGVReceiveLineCredit)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSelect
            // 
            this.BtnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(179)))), ((int)(((byte)(63)))));
            this.BtnSelect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSelect.FlatAppearance.BorderSize = 0;
            this.BtnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSelect.ForeColor = System.Drawing.Color.White;
            this.BtnSelect.Location = new System.Drawing.Point(1048, 114);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(116, 37);
            this.BtnSelect.TabIndex = 5;
            this.BtnSelect.Text = "Select";
            this.BtnSelect.UseVisualStyleBackColor = false;
            this.BtnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // CBNumber
            // 
            this.CBNumber.DropDownHeight = 205;
            this.CBNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBNumber.FormattingEnabled = true;
            this.CBNumber.IntegralHeight = false;
            this.CBNumber.Location = new System.Drawing.Point(272, 114);
            this.CBNumber.Name = "CBNumber";
            this.CBNumber.Size = new System.Drawing.Size(257, 37);
            this.CBNumber.Sorted = true;
            this.CBNumber.TabIndex = 2;
            // 
            // DGVReceiveLineCredit
            // 
            this.DGVReceiveLineCredit.AllowUserToAddRows = false;
            this.DGVReceiveLineCredit.AllowUserToDeleteRows = false;
            this.DGVReceiveLineCredit.AllowUserToResizeColumns = false;
            this.DGVReceiveLineCredit.AllowUserToResizeRows = false;
            this.DGVReceiveLineCredit.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGVReceiveLineCredit.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVReceiveLineCredit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVReceiveLineCredit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVReceiveLineCredit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGVCBSelect,
            this.DGVTotalAmount,
            this.DGVAmountReceived,
            this.DGVAmountReceivable,
            this.DGVAmountReceiving,
            this.DGVDateTime,
            this.DGVType,
            this.DGVLiter,
            this.DGVRate,
            this.DGVID});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVReceiveLineCredit.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVReceiveLineCredit.Location = new System.Drawing.Point(12, 166);
            this.DGVReceiveLineCredit.Name = "DGVReceiveLineCredit";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(234)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVReceiveLineCredit.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DGVReceiveLineCredit.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5, 6, 10, 6);
            this.DGVReceiveLineCredit.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DGVReceiveLineCredit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVReceiveLineCredit.Size = new System.Drawing.Size(1256, 409);
            this.DGVReceiveLineCredit.TabIndex = 6;
            this.DGVReceiveLineCredit.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVReceiveLineCredit_CellValueChanged);
            this.DGVReceiveLineCredit.SelectionChanged += new System.EventHandler(this.DGVReceiveLineCredit_SelectionChanged);
            this.DGVReceiveLineCredit.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVReceiveLineCredit_CellContentClick);
            // 
            // BtnReceive
            // 
            this.BtnReceive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.BtnReceive.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnReceive.FlatAppearance.BorderSize = 0;
            this.BtnReceive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReceive.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.BtnReceive.ForeColor = System.Drawing.Color.White;
            this.BtnReceive.Location = new System.Drawing.Point(480, 655);
            this.BtnReceive.Name = "BtnReceive";
            this.BtnReceive.Size = new System.Drawing.Size(320, 56);
            this.BtnReceive.TabIndex = 8;
            this.BtnReceive.Text = "Receive Line Credit";
            this.BtnReceive.UseVisualStyleBackColor = false;
            this.BtnReceive.Click += new System.EventHandler(this.BtnReceive_Click);
            // 
            // CheckBoxPrint
            // 
            this.CheckBoxPrint.AutoSize = true;
            this.CheckBoxPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CheckBoxPrint.Location = new System.Drawing.Point(555, 595);
            this.CheckBoxPrint.Name = "CheckBoxPrint";
            this.CheckBoxPrint.Size = new System.Drawing.Size(170, 33);
            this.CheckBoxPrint.TabIndex = 7;
            this.CheckBoxPrint.Text = "Print Reciept";
            this.CheckBoxPrint.UseVisualStyleBackColor = true;
            // 
            // RBNumber
            // 
            this.RBNumber.AutoSize = true;
            this.RBNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.RBNumber.Location = new System.Drawing.Point(117, 115);
            this.RBNumber.Name = "RBNumber";
            this.RBNumber.Size = new System.Drawing.Size(149, 33);
            this.RBNumber.TabIndex = 1;
            this.RBNumber.TabStop = true;
            this.RBNumber.Text = "Vehicle No";
            this.RBNumber.UseVisualStyleBackColor = true;
            this.RBNumber.CheckedChanged += new System.EventHandler(this.RBNumber_CheckedChanged);
            // 
            // RBID
            // 
            this.RBID.AutoSize = true;
            this.RBID.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.RBID.Location = new System.Drawing.Point(575, 115);
            this.RBID.Name = "RBID";
            this.RBID.Size = new System.Drawing.Size(164, 33);
            this.RBID.TabIndex = 3;
            this.RBID.TabStop = true;
            this.RBID.Text = "Customer ID";
            this.RBID.UseVisualStyleBackColor = true;
            // 
            // CBID
            // 
            this.CBID.DropDownHeight = 205;
            this.CBID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBID.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBID.FormattingEnabled = true;
            this.CBID.IntegralHeight = false;
            this.CBID.Location = new System.Drawing.Point(745, 114);
            this.CBID.Name = "CBID";
            this.CBID.Size = new System.Drawing.Size(257, 37);
            this.CBID.Sorted = true;
            this.CBID.TabIndex = 4;
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
            this.menuStrip1.TabIndex = 113;
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
            this.inventoryManagementToolStripMenuItem1.Size = new System.Drawing.Size(171, 36);
            this.inventoryManagementToolStripMenuItem1.Text = "Receive Line Credit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.label2.Location = new System.Drawing.Point(483, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(315, 39);
            this.label2.TabIndex = 131;
            this.label2.Text = "Receive Line Credit";
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
            this.BtnClose.Location = new System.Drawing.Point(1218, 661);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(50, 50);
            this.BtnClose.TabIndex = 9;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // LblAmount
            // 
            this.LblAmount.AutoSize = true;
            this.LblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.LblAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(0)))));
            this.LblAmount.Location = new System.Drawing.Point(12, 592);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(118, 36);
            this.LblAmount.TabIndex = 133;
            this.LblAmount.Text = "Amount";
            // 
            // DGVCBSelect
            // 
            this.DGVCBSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DGVCBSelect.HeaderText = "Select";
            this.DGVCBSelect.Name = "DGVCBSelect";
            this.DGVCBSelect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCBSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DGVCBSelect.Width = 85;
            // 
            // DGVTotalAmount
            // 
            this.DGVTotalAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DGVTotalAmount.HeaderText = "Total Amount";
            this.DGVTotalAmount.Name = "DGVTotalAmount";
            this.DGVTotalAmount.ReadOnly = true;
            this.DGVTotalAmount.Width = 130;
            // 
            // DGVAmountReceived
            // 
            this.DGVAmountReceived.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DGVAmountReceived.HeaderText = "Amount Received";
            this.DGVAmountReceived.Name = "DGVAmountReceived";
            this.DGVAmountReceived.ReadOnly = true;
            this.DGVAmountReceived.Width = 160;
            // 
            // DGVAmountReceivable
            // 
            this.DGVAmountReceivable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DGVAmountReceivable.HeaderText = "Amount Receivable";
            this.DGVAmountReceivable.Name = "DGVAmountReceivable";
            this.DGVAmountReceivable.ReadOnly = true;
            this.DGVAmountReceivable.Width = 173;
            // 
            // DGVAmountReceiving
            // 
            this.DGVAmountReceiving.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(138)))), ((int)(((byte)(0)))));
            this.DGVAmountReceiving.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVAmountReceiving.HeaderText = "Amount Receiving";
            this.DGVAmountReceiving.Name = "DGVAmountReceiving";
            this.DGVAmountReceiving.Width = 164;
            // 
            // DGVDateTime
            // 
            this.DGVDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DGVDateTime.HeaderText = "Time";
            this.DGVDateTime.Name = "DGVDateTime";
            this.DGVDateTime.ReadOnly = true;
            this.DGVDateTime.Width = 75;
            // 
            // DGVType
            // 
            this.DGVType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DGVType.HeaderText = "Type";
            this.DGVType.Name = "DGVType";
            this.DGVType.ReadOnly = true;
            this.DGVType.Width = 76;
            // 
            // DGVLiter
            // 
            this.DGVLiter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DGVLiter.HeaderText = "Liter";
            this.DGVLiter.Name = "DGVLiter";
            this.DGVLiter.ReadOnly = true;
            this.DGVLiter.Width = 70;
            // 
            // DGVRate
            // 
            this.DGVRate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DGVRate.HeaderText = "Rate";
            this.DGVRate.Name = "DGVRate";
            this.DGVRate.ReadOnly = true;
            this.DGVRate.Width = 73;
            // 
            // DGVID
            // 
            this.DGVID.HeaderText = "ID";
            this.DGVID.Name = "DGVID";
            this.DGVID.Visible = false;
            // 
            // ReceiveLineCreditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(1280, 738);
            this.Controls.Add(this.LblAmount);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.RBID);
            this.Controls.Add(this.CBID);
            this.Controls.Add(this.RBNumber);
            this.Controls.Add(this.BtnSelect);
            this.Controls.Add(this.CBNumber);
            this.Controls.Add(this.DGVReceiveLineCredit);
            this.Controls.Add(this.BtnReceive);
            this.Controls.Add(this.CheckBoxPrint);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ReceiveLineCreditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receive Line Credit - Sitara Hilal Petroleum Service";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReceiveLineCreditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVReceiveLineCredit)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSelect;
        private System.Windows.Forms.ComboBox CBNumber;
        private System.Windows.Forms.DataGridView DGVReceiveLineCredit;
        private System.Windows.Forms.Button BtnReceive;
        private System.Windows.Forms.CheckBox CheckBoxPrint;
        private System.Windows.Forms.RadioButton RBNumber;
        private System.Windows.Forms.RadioButton RBID;
        private System.Windows.Forms.ComboBox CBID;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sitaraHilalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryManagementToolStripMenuItem1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label LblAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DGVCBSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVAmountReceived;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVAmountReceivable;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVAmountReceiving;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVLiter;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGVID;
    }
}