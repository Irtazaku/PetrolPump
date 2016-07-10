using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PetrolPump
{
    public partial class AccountsManagementForm : Form
    {
        public AccountsManagementForm()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AccountsManagementForm_Load(object sender, EventArgs e)
        {
            PanelExpense.Visible = true;
            PanelAccount.Visible = false;
            PanelDeposit.Visible = false;
            PanelWithdraw.Visible = false;

            RBExpenseCashPayment.Checked = true;
            RBOldBank.Checked = true;

            foreach (string Name in Accounts.BankName)
            {
                if (CBExpenseBankName.Items.Contains(Name))
                    continue;

                CBExpenseBankName.Items.Add(Name + "");
                CBWithdrawBankName.Items.Add(Name + "");
                CBDepositBankName.Items.Add(Name + "");
                CBBankName.Items.Add(Name + "");
            }

            if (CBExpenseBankName.Items.Count > 0)
                CBExpenseBankName.SelectedIndex = 0;
            if (CBWithdrawBankName.Items.Count > 0)
                CBWithdrawBankName.SelectedIndex = 0;
            if (CBDepositBankName.Items.Count > 0)
                CBDepositBankName.SelectedIndex = 0;
            if (CBBankName.Items.Count > 0)
                CBBankName.SelectedIndex = 0;
        }

        private void RBCashPayment_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = !RBExpenseCashPayment.Checked;
        }

        private void CBBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBExpenseAccountNo.Items.Clear();
            List<string> AccountNumbers = Accounts.GetAccountNumbers(CBExpenseBankName.Text);
            foreach (string Number in AccountNumbers)
            {
                CBExpenseAccountNo.Items.Add(Number);
            }
            if (CBExpenseBankName.Items.Count > 0)
                CBExpenseAccountNo.SelectedIndex = 0;
        }

        private void BtnAddExpense_Click(object sender, EventArgs e)
        {
            if (RBExpenseChequePayment.Checked)
            {
                if (CBExpenseBankName.Items.Count == 0)
                {
                    MessageBox.Show("No bank selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (CBWithdrawAccountNo.Items.Count == 0)
                {
                    MessageBox.Show("No account selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            bool Errors = false;

            if (TBExpenseDescription.Text.Trim().Length == 0)
            {
                TBExpenseDescription.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }

            else
            {
                TBExpenseDescription.BackColor = Color.White;
            }

            if (!Regex.IsMatch(TBExpenseAmount.Text, "^[0-9]*[.]{0,1}[0-9]{1,2}$"))
            {
                TBExpenseAmount.BackColor = Color.FromArgb(255, 207, 207);
                return;
            }
            else
            {
                TBExpenseAmount.BackColor = Color.White;
            }

            if (Errors)
                return;

            if (MessageBox.Show("Add Expense:\n\nDescription: " + TBExpenseDescription.Text + "\nAmount: " + TBExpenseAmount.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MySqlFunctions Func2 = new MySqlFunctions();

            if (RBExpenseCashPayment.Checked)
                Func2.NonReturnQuery("insert into expense set description='" + TBExpenseDescription.Text + "', amount='" + TBExpenseAmount.Text + "', datetime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', Type='Cash'");
            else
            {
                Func2.NonReturnQuery("insert into expense set description='" + TBExpenseDescription.Text + "', amount='" + TBExpenseAmount.Text + "', datetime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "', Type='Cheque',AccountID='" + Accounts.GetAccountID(CBExpenseBankName.Text, CBExpenseAccountNo.Text) + "'");
            }

            Func2.Dest();

            MessageBox.Show("Expense recorded successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TBExpenseDescription.Text = TBExpenseAmount.Text = "";
        }

        private void BtnWithdraw_Click(object sender, EventArgs e)
        {
            if (CBWithdrawBankName.Items.Count == 0)
            {
                MessageBox.Show("No bank selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CBWithdrawAccountNo.Items.Count == 0)
            {
                MessageBox.Show("No account selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(TBWithdrawAmount.Text, "^[0-9]*[.]{0,1}[0-9]{1,2}$"))
            {
                TBWithdrawAmount.BackColor = Color.FromArgb(255, 207, 207);
                return;
            }
            else
            {
                TBWithdrawAmount.BackColor = Color.White;
            }

            if (MessageBox.Show("Withdraw amount: " + TBWithdrawAmount.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MySqlFunctions Func2 = new MySqlFunctions();

            Func2.NonReturnQuery("insert into withdraw set amount='" + TBWithdrawAmount.Text + "', datetime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',AccountID='" + Accounts.GetAccountID(CBExpenseBankName.Text, CBExpenseAccountNo.Text) + "'");
            Func2.Dest();

            MessageBox.Show("Amount withdrawn successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TBWithdrawAmount.Text = "";
        }

        private void CBWithdrawBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBWithdrawAccountNo.Items.Clear();
            List<string> AccountNumbers = Accounts.GetAccountNumbers(CBWithdrawBankName.Text);
            foreach (string Number in AccountNumbers)
            {
                CBWithdrawAccountNo.Items.Add(Number);
            }
            if (CBWithdrawAccountNo.Items.Count > 0)
                CBWithdrawAccountNo.SelectedIndex = 0;
        }

        private void MIExpense_Click(object sender, EventArgs e)
        {
            PanelExpense.Visible = true;
            PanelAccount.Visible = false;
            PanelDeposit.Visible = false;
            PanelWithdraw.Visible = false;
            PanelExpense.BringToFront();
        }

        private void MIWithdraw_Click(object sender, EventArgs e)
        {
            PanelExpense.Visible = false;
            PanelAccount.Visible = false;
            PanelDeposit.Visible = false;
            PanelWithdraw.Visible = true;
            PanelWithdraw.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnDeposit_Click(object sender, EventArgs e)
        {
            if (CBDepositBankName.Items.Count == 0)
            {
                MessageBox.Show("No bank selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CBDepositAccountNo.Items.Count == 0)
            {
                MessageBox.Show("No account selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(TBDepositAmount.Text, "^[0-9]*[.]{0,1}[0-9]{1,2}$"))
            {
                TBDepositAmount.BackColor = Color.FromArgb(255, 207, 207);
                return;
            }
            else
            {
                TBDepositAmount.BackColor = Color.White;
            }

            if (MessageBox.Show("Deposit amount: " + TBDepositAmount.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MySqlFunctions Func2 = new MySqlFunctions();

            Func2.NonReturnQuery("insert into deposit set amount='" + TBDepositAmount.Text + "', datetime='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',AccountID='" + Accounts.GetAccountID(CBExpenseBankName.Text, CBExpenseAccountNo.Text) + "'");
            Func2.Dest();

            MessageBox.Show("Amount deposited successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TBDepositAmount.Text = "";
        }

        private void CBDepositBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBDepositAccountNo.Items.Clear();
            List<string> AccountNumbers = Accounts.GetAccountNumbers(CBDepositBankName.Text);
            foreach (string Number in AccountNumbers)
            {
                CBDepositAccountNo.Items.Add(Number);
            }
            if (CBDepositAccountNo.Items.Count > 0)
                CBDepositAccountNo.SelectedIndex = 0;
        }

        private void MIDeposit_Click(object sender, EventArgs e)
        {
            PanelExpense.Visible = false;
            PanelAccount.Visible = false;
            PanelDeposit.Visible = true;
            PanelWithdraw.Visible = false;
            PanelDeposit.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RBOldBank_CheckedChanged(object sender, EventArgs e)
        {
            TBBankName.Visible = RBNewBank.Checked;
            CBBankName.Visible = !RBNewBank.Checked;
        }

        private void TBAddAccount_Click(object sender, EventArgs e)
        {
            if (RBOldBank.Checked)
            {
                if (CBBankName.Items.Count == 0)
                {
                    MessageBox.Show("No bank selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            bool Error = false;

            if (!Regex.IsMatch(TBInitialBalance.Text, "^[0-9]*[.]{0,1}[0-9]{1,2}$"))
            {
                TBInitialBalance.BackColor = Color.FromArgb(255, 207, 207);
                Error = true;
            }
            else
            {
                TBInitialBalance.BackColor = Color.White;
            }

            if (TBAccountNo.Text.Trim().Length == 0)
            {
                TBAccountNo.BackColor = Color.FromArgb(255, 207, 207);
                Error = true;
            }
            else
            {
                TBAccountNo.BackColor = Color.White;
            }

            if (RBNewBank.Checked)
            {
                if (TBBankName.Text.Trim().Length == 0)
                {
                    TBBankName.BackColor = Color.FromArgb(255, 207, 207);
                    Error = true;
                }
                else
                {
                    TBBankName.BackColor = Color.White;
                }
            }

            if (Error)
                return;

            if (MessageBox.Show("Add new account\n\nBank Name: " + (RBNewBank.Checked ? TBBankName.Text : CBBankName.Text) + "\nAccount No: " + TBAccountNo.Text + "\nBalance: " + TBInitialBalance.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MySqlFunctions Func2 = new MySqlFunctions();

            if (RBNewBank.Checked)
                Func2.NonReturnQuery("insert into accounts set bankname='" + TBBankName.Text + "', accountnumber='" + TBAccountNo.Text + "', initialbalance='" + TBInitialBalance.Text + "'");
            else
                Func2.NonReturnQuery("insert into accounts set bankname='" + CBBankName.Text + "', accountnumber='" + TBAccountNo.Text + "', initialbalance='" + TBInitialBalance.Text + "'");

            Accounts.Add(Func2.ScalarInt("SELECT LAST_INSERT_ID();"), TBBankName.Text, TBAccountNo.Text);

            Func2.Dest();

            MessageBox.Show("Account added successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TBBankName.Text = TBAccountNo.Text = TBInitialBalance.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MIAddAccount_Click(object sender, EventArgs e)
        {
            PanelExpense.Visible = false;
            PanelAccount.Visible = true;
            PanelDeposit.Visible = false;
            PanelWithdraw.Visible = false;
            PanelAccount.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
