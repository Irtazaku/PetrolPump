﻿namespace PetrolPump
{
    partial class EditCompanyForm
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
            this.BtnAdd = new System.Windows.Forms.Button();
            this.LblRate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TBNumber = new System.Windows.Forms.TextBox();
            this.TBName = new System.Windows.Forms.TextBox();
            this.CBName = new System.Windows.Forms.ComboBox();
            this.LblType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBEmail = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sitaraHilalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryManagementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.BtnClose = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(185, 322);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(232, 56);
            this.BtnAdd.TabIndex = 5;
            this.BtnAdd.Text = "Edit Company";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // LblRate
            // 
            this.LblRate.AutoSize = true;
            this.LblRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.LblRate.Location = new System.Drawing.Point(27, 215);
            this.LblRate.Name = "LblRate";
            this.LblRate.Size = new System.Drawing.Size(121, 29);
            this.LblRate.TabIndex = 102;
            this.LblRate.Text = "Phone No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label4.Location = new System.Drawing.Point(27, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 29);
            this.label4.TabIndex = 101;
            this.label4.Text = "New Name";
            // 
            // TBNumber
            // 
            this.TBNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBNumber.Location = new System.Drawing.Point(167, 212);
            this.TBNumber.Name = "TBNumber";
            this.TBNumber.Size = new System.Drawing.Size(408, 35);
            this.TBNumber.TabIndex = 3;
            // 
            // TBName
            // 
            this.TBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBName.Location = new System.Drawing.Point(167, 162);
            this.TBName.Name = "TBName";
            this.TBName.Size = new System.Drawing.Size(408, 35);
            this.TBName.TabIndex = 2;
            // 
            // CBName
            // 
            this.CBName.DropDownHeight = 205;
            this.CBName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBName.FormattingEnabled = true;
            this.CBName.IntegralHeight = false;
            this.CBName.Location = new System.Drawing.Point(167, 112);
            this.CBName.Name = "CBName";
            this.CBName.Size = new System.Drawing.Size(408, 37);
            this.CBName.TabIndex = 1;
            this.CBName.SelectedIndexChanged += new System.EventHandler(this.CBID_SelectedIndexChanged);
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.LblType.Location = new System.Drawing.Point(27, 115);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(123, 29);
            this.LblType.TabIndex = 100;
            this.LblType.Text = "Old Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.Location = new System.Drawing.Point(27, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 29);
            this.label2.TabIndex = 107;
            this.label2.Text = "Email";
            // 
            // TBEmail
            // 
            this.TBEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBEmail.Location = new System.Drawing.Point(167, 262);
            this.TBEmail.Name = "TBEmail";
            this.TBEmail.Size = new System.Drawing.Size(408, 35);
            this.TBEmail.TabIndex = 4;
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
            this.menuStrip1.TabIndex = 108;
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
            this.inventoryManagementToolStripMenuItem1.Size = new System.Drawing.Size(136, 36);
            this.inventoryManagementToolStripMenuItem1.Text = "Edit Company";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.label3.Location = new System.Drawing.Point(186, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 39);
            this.label3.TabIndex = 109;
            this.label3.Text = "Edit Company";
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
            this.BtnClose.Location = new System.Drawing.Point(525, 328);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(50, 50);
            this.BtnClose.TabIndex = 6;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // EditCompanyForm
            // 
            this.AcceptButton = this.BtnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(602, 405);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBEmail);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.LblRate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TBNumber);
            this.Controls.Add(this.TBName);
            this.Controls.Add(this.CBName);
            this.Controls.Add(this.LblType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCompanyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Company - Sitara Hilal Petroleum Service";
            this.Load += new System.EventHandler(this.EditCompanyForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Label LblRate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TBNumber;
        private System.Windows.Forms.TextBox TBName;
        private System.Windows.Forms.ComboBox CBName;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBEmail;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sitaraHilalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryManagementToolStripMenuItem1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtnClose;
    }
}