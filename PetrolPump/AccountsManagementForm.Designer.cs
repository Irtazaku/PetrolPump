namespace PetrolPump
{
    partial class AccountsManagementForm
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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.MIExpense = new System.Windows.Forms.ToolStripMenuItem();
            this.MIWithdraw = new System.Windows.Forms.ToolStripMenuItem();
            this.MIDeposit = new System.Windows.Forms.ToolStripMenuItem();
            this.MIAddAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryManagementToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelExpense = new System.Windows.Forms.Panel();
            this.TBExpenseAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CBExpenseBankName = new System.Windows.Forms.ComboBox();
            this.CBExpenseAccountNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RBExpenseChequePayment = new System.Windows.Forms.RadioButton();
            this.RBExpenseCashPayment = new System.Windows.Forms.RadioButton();
            this.BtnClose = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnAddExpense = new System.Windows.Forms.Button();
            this.TBExpenseDescription = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.PanelWithdraw = new System.Windows.Forms.Panel();
            this.CBWithdrawBankName = new System.Windows.Forms.ComboBox();
            this.CBWithdrawAccountNo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnWithdraw = new System.Windows.Forms.Button();
            this.TBWithdrawAmount = new System.Windows.Forms.TextBox();
            this.PanelDeposit = new System.Windows.Forms.Panel();
            this.CBDepositBankName = new System.Windows.Forms.ComboBox();
            this.CBDepositAccountNo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.BtnDeposit = new System.Windows.Forms.Button();
            this.TBDepositAmount = new System.Windows.Forms.TextBox();
            this.PanelAccount = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.TBInitialBalance = new System.Windows.Forms.TextBox();
            this.RBNewBank = new System.Windows.Forms.RadioButton();
            this.RBOldBank = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.TBAddAccount = new System.Windows.Forms.Button();
            this.TBAccountNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.CBBankName = new System.Windows.Forms.ComboBox();
            this.TBBankName = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.PanelExpense.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PanelWithdraw.SuspendLayout();
            this.PanelDeposit.SuspendLayout();
            this.PanelAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.menuStrip2.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIExpense,
            this.MIWithdraw,
            this.MIDeposit,
            this.MIAddAccount});
            this.menuStrip2.Location = new System.Drawing.Point(0, 46);
            this.menuStrip2.Margin = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(756, 33);
            this.menuStrip2.TabIndex = 8;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // MIExpense
            // 
            this.MIExpense.ForeColor = System.Drawing.Color.White;
            this.MIExpense.Name = "MIExpense";
            this.MIExpense.Size = new System.Drawing.Size(88, 29);
            this.MIExpense.Text = "Expense";
            this.MIExpense.Click += new System.EventHandler(this.MIExpense_Click);
            // 
            // MIWithdraw
            // 
            this.MIWithdraw.ForeColor = System.Drawing.Color.White;
            this.MIWithdraw.Name = "MIWithdraw";
            this.MIWithdraw.Size = new System.Drawing.Size(100, 29);
            this.MIWithdraw.Text = "Withdraw";
            this.MIWithdraw.Click += new System.EventHandler(this.MIWithdraw_Click);
            // 
            // MIDeposit
            // 
            this.MIDeposit.ForeColor = System.Drawing.Color.White;
            this.MIDeposit.Name = "MIDeposit";
            this.MIDeposit.Size = new System.Drawing.Size(86, 29);
            this.MIDeposit.Text = "Deposit";
            this.MIDeposit.Click += new System.EventHandler(this.MIDeposit_Click);
            // 
            // MIAddAccount
            // 
            this.MIAddAccount.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.MIAddAccount.ForeColor = System.Drawing.Color.White;
            this.MIAddAccount.Name = "MIAddAccount";
            this.MIAddAccount.Size = new System.Drawing.Size(128, 29);
            this.MIAddAccount.Text = "Add Account";
            this.MIAddAccount.Click += new System.EventHandler(this.MIAddAccount_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.inventoryManagementToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.menuStrip1.Size = new System.Drawing.Size(756, 46);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.toolStripMenuItem3.ForeColor = System.Drawing.Color.White;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(140, 36);
            this.toolStripMenuItem3.Text = "Sitara Hilal";
            // 
            // inventoryManagementToolStripMenuItem1
            // 
            this.inventoryManagementToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.inventoryManagementToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.inventoryManagementToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.inventoryManagementToolStripMenuItem1.Name = "inventoryManagementToolStripMenuItem1";
            this.inventoryManagementToolStripMenuItem1.Size = new System.Drawing.Size(207, 36);
            this.inventoryManagementToolStripMenuItem1.Text = "Accounts Management";
            // 
            // PanelExpense
            // 
            this.PanelExpense.Controls.Add(this.TBExpenseAmount);
            this.PanelExpense.Controls.Add(this.label3);
            this.PanelExpense.Controls.Add(this.panel1);
            this.PanelExpense.Controls.Add(this.RBExpenseChequePayment);
            this.PanelExpense.Controls.Add(this.RBExpenseCashPayment);
            this.PanelExpense.Controls.Add(this.BtnClose);
            this.PanelExpense.Controls.Add(this.label5);
            this.PanelExpense.Controls.Add(this.BtnAddExpense);
            this.PanelExpense.Controls.Add(this.TBExpenseDescription);
            this.PanelExpense.Controls.Add(this.LblName);
            this.PanelExpense.Location = new System.Drawing.Point(12, 82);
            this.PanelExpense.Name = "PanelExpense";
            this.PanelExpense.Size = new System.Drawing.Size(730, 365);
            this.PanelExpense.TabIndex = 9;
            // 
            // TBExpenseAmount
            // 
            this.TBExpenseAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBExpenseAmount.Location = new System.Drawing.Point(238, 112);
            this.TBExpenseAmount.Name = "TBExpenseAmount";
            this.TBExpenseAmount.Size = new System.Drawing.Size(396, 35);
            this.TBExpenseAmount.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label3.Location = new System.Drawing.Point(97, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 29);
            this.label3.TabIndex = 143;
            this.label3.Text = "Amount";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CBExpenseBankName);
            this.panel1.Controls.Add(this.CBExpenseAccountNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(88, 201);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 93);
            this.panel1.TabIndex = 141;
            // 
            // CBExpenseBankName
            // 
            this.CBExpenseBankName.DropDownHeight = 205;
            this.CBExpenseBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBExpenseBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBExpenseBankName.FormattingEnabled = true;
            this.CBExpenseBankName.IntegralHeight = false;
            this.CBExpenseBankName.Location = new System.Drawing.Point(152, 3);
            this.CBExpenseBankName.Name = "CBExpenseBankName";
            this.CBExpenseBankName.Size = new System.Drawing.Size(385, 37);
            this.CBExpenseBankName.Sorted = true;
            this.CBExpenseBankName.TabIndex = 5;
            this.CBExpenseBankName.SelectedIndexChanged += new System.EventHandler(this.CBBankName_SelectedIndexChanged);
            // 
            // CBExpenseAccountNo
            // 
            this.CBExpenseAccountNo.DropDownHeight = 205;
            this.CBExpenseAccountNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBExpenseAccountNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBExpenseAccountNo.FormattingEnabled = true;
            this.CBExpenseAccountNo.IntegralHeight = false;
            this.CBExpenseAccountNo.Location = new System.Drawing.Point(152, 53);
            this.CBExpenseAccountNo.Name = "CBExpenseAccountNo";
            this.CBExpenseAccountNo.Size = new System.Drawing.Size(385, 37);
            this.CBExpenseAccountNo.Sorted = true;
            this.CBExpenseAccountNo.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.Location = new System.Drawing.Point(9, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 29);
            this.label1.TabIndex = 102;
            this.label1.Text = "Bank Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.Location = new System.Drawing.Point(9, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 29);
            this.label2.TabIndex = 98;
            this.label2.Text = "Account No";
            // 
            // RBExpenseChequePayment
            // 
            this.RBExpenseChequePayment.AutoSize = true;
            this.RBExpenseChequePayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.RBExpenseChequePayment.Location = new System.Drawing.Point(303, 160);
            this.RBExpenseChequePayment.Name = "RBExpenseChequePayment";
            this.RBExpenseChequePayment.Size = new System.Drawing.Size(215, 33);
            this.RBExpenseChequePayment.TabIndex = 4;
            this.RBExpenseChequePayment.TabStop = true;
            this.RBExpenseChequePayment.Text = "Cheque Payment";
            this.RBExpenseChequePayment.UseVisualStyleBackColor = true;
            // 
            // RBExpenseCashPayment
            // 
            this.RBExpenseCashPayment.AutoSize = true;
            this.RBExpenseCashPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.RBExpenseCashPayment.Location = new System.Drawing.Point(103, 160);
            this.RBExpenseCashPayment.Name = "RBExpenseCashPayment";
            this.RBExpenseCashPayment.Size = new System.Drawing.Size(185, 33);
            this.RBExpenseCashPayment.TabIndex = 3;
            this.RBExpenseCashPayment.TabStop = true;
            this.RBExpenseCashPayment.Text = "Cash Payment";
            this.RBExpenseCashPayment.UseVisualStyleBackColor = true;
            this.RBExpenseCashPayment.CheckedChanged += new System.EventHandler(this.RBCashPayment_CheckedChanged);
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
            this.BtnClose.Location = new System.Drawing.Point(584, 310);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(50, 50);
            this.BtnClose.TabIndex = 8;
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.label5.Location = new System.Drawing.Point(255, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 39);
            this.label5.TabIndex = 106;
            this.label5.Text = "Add Expense";
            // 
            // BtnAddExpense
            // 
            this.BtnAddExpense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.BtnAddExpense.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnAddExpense.FlatAppearance.BorderSize = 0;
            this.BtnAddExpense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.BtnAddExpense.ForeColor = System.Drawing.Color.White;
            this.BtnAddExpense.Location = new System.Drawing.Point(226, 304);
            this.BtnAddExpense.Name = "BtnAddExpense";
            this.BtnAddExpense.Size = new System.Drawing.Size(278, 56);
            this.BtnAddExpense.TabIndex = 7;
            this.BtnAddExpense.Text = "Add Expense";
            this.BtnAddExpense.UseVisualStyleBackColor = false;
            this.BtnAddExpense.Click += new System.EventHandler(this.BtnAddExpense_Click);
            // 
            // TBExpenseDescription
            // 
            this.TBExpenseDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBExpenseDescription.Location = new System.Drawing.Point(238, 66);
            this.TBExpenseDescription.Name = "TBExpenseDescription";
            this.TBExpenseDescription.Size = new System.Drawing.Size(396, 35);
            this.TBExpenseDescription.TabIndex = 1;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.LblName.Location = new System.Drawing.Point(97, 69);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(135, 29);
            this.LblName.TabIndex = 100;
            this.LblName.Text = "Description";
            // 
            // PanelWithdraw
            // 
            this.PanelWithdraw.Controls.Add(this.CBWithdrawBankName);
            this.PanelWithdraw.Controls.Add(this.CBWithdrawAccountNo);
            this.PanelWithdraw.Controls.Add(this.label6);
            this.PanelWithdraw.Controls.Add(this.label7);
            this.PanelWithdraw.Controls.Add(this.label4);
            this.PanelWithdraw.Controls.Add(this.button1);
            this.PanelWithdraw.Controls.Add(this.label8);
            this.PanelWithdraw.Controls.Add(this.BtnWithdraw);
            this.PanelWithdraw.Controls.Add(this.TBWithdrawAmount);
            this.PanelWithdraw.Location = new System.Drawing.Point(12, 82);
            this.PanelWithdraw.Name = "PanelWithdraw";
            this.PanelWithdraw.Size = new System.Drawing.Size(730, 365);
            this.PanelWithdraw.TabIndex = 144;
            // 
            // CBWithdrawBankName
            // 
            this.CBWithdrawBankName.DropDownHeight = 205;
            this.CBWithdrawBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBWithdrawBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBWithdrawBankName.FormattingEnabled = true;
            this.CBWithdrawBankName.IntegralHeight = false;
            this.CBWithdrawBankName.Location = new System.Drawing.Point(239, 133);
            this.CBWithdrawBankName.Name = "CBWithdrawBankName";
            this.CBWithdrawBankName.Size = new System.Drawing.Size(396, 37);
            this.CBWithdrawBankName.Sorted = true;
            this.CBWithdrawBankName.TabIndex = 10;
            this.CBWithdrawBankName.SelectedIndexChanged += new System.EventHandler(this.CBWithdrawBankName_SelectedIndexChanged);
            // 
            // CBWithdrawAccountNo
            // 
            this.CBWithdrawAccountNo.DropDownHeight = 205;
            this.CBWithdrawAccountNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBWithdrawAccountNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBWithdrawAccountNo.FormattingEnabled = true;
            this.CBWithdrawAccountNo.IntegralHeight = false;
            this.CBWithdrawAccountNo.Location = new System.Drawing.Point(239, 183);
            this.CBWithdrawAccountNo.Name = "CBWithdrawAccountNo";
            this.CBWithdrawAccountNo.Size = new System.Drawing.Size(396, 37);
            this.CBWithdrawAccountNo.Sorted = true;
            this.CBWithdrawAccountNo.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label6.Location = new System.Drawing.Point(96, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 29);
            this.label6.TabIndex = 147;
            this.label6.Text = "Bank Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label7.Location = new System.Drawing.Point(96, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 29);
            this.label7.TabIndex = 146;
            this.label7.Text = "Account No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label4.Location = new System.Drawing.Point(98, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 29);
            this.label4.TabIndex = 143;
            this.label4.Text = "Amount";
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
            this.button1.Location = new System.Drawing.Point(584, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 50);
            this.button1.TabIndex = 13;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.label8.Location = new System.Drawing.Point(286, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 39);
            this.label8.TabIndex = 106;
            this.label8.Text = "Withdraw";
            // 
            // BtnWithdraw
            // 
            this.BtnWithdraw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.BtnWithdraw.FlatAppearance.BorderSize = 0;
            this.BtnWithdraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnWithdraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.BtnWithdraw.ForeColor = System.Drawing.Color.White;
            this.BtnWithdraw.Location = new System.Drawing.Point(226, 247);
            this.BtnWithdraw.Name = "BtnWithdraw";
            this.BtnWithdraw.Size = new System.Drawing.Size(278, 56);
            this.BtnWithdraw.TabIndex = 12;
            this.BtnWithdraw.Text = "Withdraw";
            this.BtnWithdraw.UseVisualStyleBackColor = false;
            this.BtnWithdraw.Click += new System.EventHandler(this.BtnWithdraw_Click);
            // 
            // TBWithdrawAmount
            // 
            this.TBWithdrawAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBWithdrawAmount.Location = new System.Drawing.Point(239, 87);
            this.TBWithdrawAmount.Name = "TBWithdrawAmount";
            this.TBWithdrawAmount.Size = new System.Drawing.Size(396, 35);
            this.TBWithdrawAmount.TabIndex = 9;
            // 
            // PanelDeposit
            // 
            this.PanelDeposit.Controls.Add(this.CBDepositBankName);
            this.PanelDeposit.Controls.Add(this.CBDepositAccountNo);
            this.PanelDeposit.Controls.Add(this.label9);
            this.PanelDeposit.Controls.Add(this.label10);
            this.PanelDeposit.Controls.Add(this.label11);
            this.PanelDeposit.Controls.Add(this.button2);
            this.PanelDeposit.Controls.Add(this.label12);
            this.PanelDeposit.Controls.Add(this.BtnDeposit);
            this.PanelDeposit.Controls.Add(this.TBDepositAmount);
            this.PanelDeposit.Location = new System.Drawing.Point(12, 82);
            this.PanelDeposit.Name = "PanelDeposit";
            this.PanelDeposit.Size = new System.Drawing.Size(730, 365);
            this.PanelDeposit.TabIndex = 145;
            // 
            // CBDepositBankName
            // 
            this.CBDepositBankName.DropDownHeight = 205;
            this.CBDepositBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBDepositBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBDepositBankName.FormattingEnabled = true;
            this.CBDepositBankName.IntegralHeight = false;
            this.CBDepositBankName.Location = new System.Drawing.Point(239, 133);
            this.CBDepositBankName.Name = "CBDepositBankName";
            this.CBDepositBankName.Size = new System.Drawing.Size(396, 37);
            this.CBDepositBankName.Sorted = true;
            this.CBDepositBankName.TabIndex = 15;
            this.CBDepositBankName.SelectedIndexChanged += new System.EventHandler(this.CBDepositBankName_SelectedIndexChanged);
            // 
            // CBDepositAccountNo
            // 
            this.CBDepositAccountNo.DropDownHeight = 205;
            this.CBDepositAccountNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBDepositAccountNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBDepositAccountNo.FormattingEnabled = true;
            this.CBDepositAccountNo.IntegralHeight = false;
            this.CBDepositAccountNo.Location = new System.Drawing.Point(239, 183);
            this.CBDepositAccountNo.Name = "CBDepositAccountNo";
            this.CBDepositAccountNo.Size = new System.Drawing.Size(396, 37);
            this.CBDepositAccountNo.Sorted = true;
            this.CBDepositAccountNo.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label9.Location = new System.Drawing.Point(96, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 29);
            this.label9.TabIndex = 147;
            this.label9.Text = "Bank Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label10.Location = new System.Drawing.Point(96, 186);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 29);
            this.label10.TabIndex = 146;
            this.label10.Text = "Account No";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label11.Location = new System.Drawing.Point(98, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 29);
            this.label11.TabIndex = 143;
            this.label11.Text = "Amount";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(27)))), ((int)(((byte)(28)))));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::PetrolPump.Properties.Resources.icon_close_circled_128__2_;
            this.button2.Location = new System.Drawing.Point(584, 253);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 18;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.label12.Location = new System.Drawing.Point(299, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(133, 39);
            this.label12.TabIndex = 106;
            this.label12.Text = "Deposit";
            // 
            // BtnDeposit
            // 
            this.BtnDeposit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.BtnDeposit.FlatAppearance.BorderSize = 0;
            this.BtnDeposit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDeposit.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.BtnDeposit.ForeColor = System.Drawing.Color.White;
            this.BtnDeposit.Location = new System.Drawing.Point(226, 247);
            this.BtnDeposit.Name = "BtnDeposit";
            this.BtnDeposit.Size = new System.Drawing.Size(278, 56);
            this.BtnDeposit.TabIndex = 17;
            this.BtnDeposit.Text = "Deposit";
            this.BtnDeposit.UseVisualStyleBackColor = false;
            this.BtnDeposit.Click += new System.EventHandler(this.BtnDeposit_Click);
            // 
            // TBDepositAmount
            // 
            this.TBDepositAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBDepositAmount.Location = new System.Drawing.Point(239, 87);
            this.TBDepositAmount.Name = "TBDepositAmount";
            this.TBDepositAmount.Size = new System.Drawing.Size(396, 35);
            this.TBDepositAmount.TabIndex = 14;
            // 
            // PanelAccount
            // 
            this.PanelAccount.Controls.Add(this.label15);
            this.PanelAccount.Controls.Add(this.TBInitialBalance);
            this.PanelAccount.Controls.Add(this.RBNewBank);
            this.PanelAccount.Controls.Add(this.RBOldBank);
            this.PanelAccount.Controls.Add(this.label14);
            this.PanelAccount.Controls.Add(this.button3);
            this.PanelAccount.Controls.Add(this.label16);
            this.PanelAccount.Controls.Add(this.TBAddAccount);
            this.PanelAccount.Controls.Add(this.TBAccountNo);
            this.PanelAccount.Controls.Add(this.label13);
            this.PanelAccount.Controls.Add(this.CBBankName);
            this.PanelAccount.Controls.Add(this.TBBankName);
            this.PanelAccount.Location = new System.Drawing.Point(12, 82);
            this.PanelAccount.Name = "PanelAccount";
            this.PanelAccount.Size = new System.Drawing.Size(730, 365);
            this.PanelAccount.TabIndex = 148;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label15.Location = new System.Drawing.Point(94, 227);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 29);
            this.label15.TabIndex = 152;
            this.label15.Text = "Balance";
            // 
            // TBInitialBalance
            // 
            this.TBInitialBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBInitialBalance.Location = new System.Drawing.Point(238, 224);
            this.TBInitialBalance.Name = "TBInitialBalance";
            this.TBInitialBalance.Size = new System.Drawing.Size(396, 35);
            this.TBInitialBalance.TabIndex = 45;
            // 
            // RBNewBank
            // 
            this.RBNewBank.AutoSize = true;
            this.RBNewBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.RBNewBank.Location = new System.Drawing.Point(292, 86);
            this.RBNewBank.Name = "RBNewBank";
            this.RBNewBank.Size = new System.Drawing.Size(141, 33);
            this.RBNewBank.TabIndex = 41;
            this.RBNewBank.TabStop = true;
            this.RBNewBank.Text = "New Bank";
            this.RBNewBank.UseVisualStyleBackColor = true;
            // 
            // RBOldBank
            // 
            this.RBOldBank.AutoSize = true;
            this.RBOldBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.RBOldBank.Location = new System.Drawing.Point(102, 86);
            this.RBOldBank.Name = "RBOldBank";
            this.RBOldBank.Size = new System.Drawing.Size(175, 33);
            this.RBOldBank.TabIndex = 40;
            this.RBOldBank.TabStop = true;
            this.RBOldBank.Text = "Existing Bank";
            this.RBOldBank.UseVisualStyleBackColor = true;
            this.RBOldBank.CheckedChanged += new System.EventHandler(this.RBOldBank_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label14.Location = new System.Drawing.Point(95, 181);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(136, 29);
            this.label14.TabIndex = 146;
            this.label14.Text = "Account No";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(27)))), ((int)(((byte)(28)))));
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::PetrolPump.Properties.Resources.icon_close_circled_128__2_;
            this.button3.Location = new System.Drawing.Point(584, 287);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 50);
            this.button3.TabIndex = 47;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.label16.Location = new System.Drawing.Point(260, 23);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(210, 39);
            this.label16.TabIndex = 106;
            this.label16.Text = "Add Account";
            // 
            // TBAddAccount
            // 
            this.TBAddAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(135)))));
            this.TBAddAccount.FlatAppearance.BorderSize = 0;
            this.TBAddAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TBAddAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.TBAddAccount.ForeColor = System.Drawing.Color.White;
            this.TBAddAccount.Location = new System.Drawing.Point(226, 281);
            this.TBAddAccount.Name = "TBAddAccount";
            this.TBAddAccount.Size = new System.Drawing.Size(278, 56);
            this.TBAddAccount.TabIndex = 46;
            this.TBAddAccount.Text = "Add Account";
            this.TBAddAccount.UseVisualStyleBackColor = false;
            this.TBAddAccount.Click += new System.EventHandler(this.TBAddAccount_Click);
            // 
            // TBAccountNo
            // 
            this.TBAccountNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBAccountNo.Location = new System.Drawing.Point(239, 178);
            this.TBAccountNo.Name = "TBAccountNo";
            this.TBAccountNo.Size = new System.Drawing.Size(396, 35);
            this.TBAccountNo.TabIndex = 44;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label13.Location = new System.Drawing.Point(95, 135);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(138, 29);
            this.label13.TabIndex = 147;
            this.label13.Text = "Bank Name";
            // 
            // CBBankName
            // 
            this.CBBankName.DropDownHeight = 205;
            this.CBBankName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.CBBankName.FormattingEnabled = true;
            this.CBBankName.IntegralHeight = false;
            this.CBBankName.Location = new System.Drawing.Point(238, 132);
            this.CBBankName.Name = "CBBankName";
            this.CBBankName.Size = new System.Drawing.Size(396, 37);
            this.CBBankName.Sorted = true;
            this.CBBankName.TabIndex = 42;
            // 
            // TBBankName
            // 
            this.TBBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.TBBankName.Location = new System.Drawing.Point(238, 132);
            this.TBBankName.Name = "TBBankName";
            this.TBBankName.Size = new System.Drawing.Size(396, 35);
            this.TBBankName.TabIndex = 43;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(27)))), ((int)(((byte)(28)))));
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = global::PetrolPump.Properties.Resources.icon_close_circled_128__2_;
            this.button4.Location = new System.Drawing.Point(0, 82);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(1, 1);
            this.button4.TabIndex = 149;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // AccountsManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button4;
            this.ClientSize = new System.Drawing.Size(756, 459);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.PanelAccount);
            this.Controls.Add(this.PanelDeposit);
            this.Controls.Add(this.PanelWithdraw);
            this.Controls.Add(this.PanelExpense);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountsManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accounts Management - Sitara Hilal Petroleum Service";
            this.Load += new System.EventHandler(this.AccountsManagementForm_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.PanelExpense.ResumeLayout(false);
            this.PanelExpense.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PanelWithdraw.ResumeLayout(false);
            this.PanelWithdraw.PerformLayout();
            this.PanelDeposit.ResumeLayout(false);
            this.PanelDeposit.PerformLayout();
            this.PanelAccount.ResumeLayout(false);
            this.PanelAccount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem MIAddAccount;
        private System.Windows.Forms.ToolStripMenuItem MIWithdraw;
        private System.Windows.Forms.ToolStripMenuItem MIDeposit;
        private System.Windows.Forms.ToolStripMenuItem MIExpense;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem inventoryManagementToolStripMenuItem1;
        private System.Windows.Forms.Panel PanelExpense;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnAddExpense;
        private System.Windows.Forms.TextBox TBExpenseDescription;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CBExpenseAccountNo;
        private System.Windows.Forms.ComboBox CBExpenseBankName;
        private System.Windows.Forms.RadioButton RBExpenseChequePayment;
        private System.Windows.Forms.RadioButton RBExpenseCashPayment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBExpenseAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel PanelWithdraw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnWithdraw;
        private System.Windows.Forms.TextBox TBWithdrawAmount;
        private System.Windows.Forms.ComboBox CBWithdrawBankName;
        private System.Windows.Forms.ComboBox CBWithdrawAccountNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel PanelDeposit;
        private System.Windows.Forms.ComboBox CBDepositBankName;
        private System.Windows.Forms.ComboBox CBDepositAccountNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button BtnDeposit;
        private System.Windows.Forms.TextBox TBDepositAmount;
        private System.Windows.Forms.Panel PanelAccount;
        private System.Windows.Forms.ComboBox CBBankName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button TBAddAccount;
        private System.Windows.Forms.TextBox TBAccountNo;
        private System.Windows.Forms.TextBox TBBankName;
        private System.Windows.Forms.RadioButton RBNewBank;
        private System.Windows.Forms.RadioButton RBOldBank;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TBInitialBalance;
        private System.Windows.Forms.Button button4;
    }
}