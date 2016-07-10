using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;

namespace PetrolPump
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void AdminUser()
        {
            BtnSearchCustomer.Visible = false;
            BtnAddCustomer.Visible = false;
            BtnSearchInventory.Visible = false;
            BtnBackup.Visible = false;
        }

        private void CashierUser()
        {
            BtnReports.Visible = false;
            BtnSummary.Visible = false;
            BtnLineCreditCustomers.Visible = false;
            BtnInventoryManagement.Visible = false;
            BtnAdminPanel.Visible = false;
            BtnCompanyManagement.Location = new Point(BtnCompanyManagement.Location.X + 158, 469);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (MySqlFunctions.CashierType == "Admin")
                AdminUser();
            else
                CashierUser();


            //this.Size = new Size(1406, 1016);
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            this.BringToFront();
        }

        private void BtnAddCast_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("AddCashForm"))
                new AddCashForm().Show();
        }

        private void BtnAddCredit_Click(object sender, EventArgs e)
        {
            this.Text = this.Size.Width+"";
            if (!Forms.IsOpened("AddCreditForm"))
            new AddCreditForm().Show();
        }

        private void BtnAddLineCredit_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("AddLineCreditForm"))
            new AddLineCreditForm().Show();
        }

        private void BtnAddVehicleCash_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("AddVehicleCashForm"))
            new AddVehicleCashForm().Show();
        }

        private void BtnReceiveCredit_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("ReceiveCreditForm"))
            new ReceiveCreditForm().Show();
        }

        private void BtnInventoryManagement_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("InventoryManagementForm"))
            new InventoryManagementForm().Show();
        }

        private void BtnLineCreditCustomers_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("LineCreditCustomersForm"))
            new LineCreditCustomersForm().Show();
        }

        private void BtnCompanyManagement_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("CompanyManagementForm"))
            new CompanyManagementForm().Show();
        }

        private void BtnReceiveLineCredit_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("ReceiveLineCreditForm"))
            new ReceiveLineCreditForm().Show();
        }

        private void BtnSearchCustomer_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("SearchLineCustomerForm"))
            new SearchLineCustomerForm().Show();
        }

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("AddLineCreditCustomerForm"))
            new AddLineCreditCustomerForm().Show();
        }

        private void BtnSearchInventory_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("SearchInventoryForm"))
            new SearchInventoryForm().Show();
        }

        private void BtnBackup_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "Database - " + DateTime.Now.ToString("dddd, MMMM dd, yyyy - hh;mm;ss tt");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MySqlFunctions Func2 = new MySqlFunctions();
                Func2.BackUp(saveFileDialog1.FileName);
                Func2.Dest();
                MessageBox.Show("Record backed up successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnReports_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("ReportsForm"))
            new ReportsForm().Show();
        }

        private void BtnAdminPanel_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("AdminPanelForm"))
            new AdminPanelForm().Show();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<Form> OpenFormsList = new List<Form>();
            Form LF = null; ;
            this.Hide();

            foreach (Form F in Application.OpenForms)
            {
                if (F.Name != "LoginForm" && F.Name != "MainForm")
                    OpenFormsList.Add(F);
                if (F.Name == "LoginForm")
                    LF = F;
            }

            foreach (Form F in OpenFormsList)
            {
                F.Close();
            }
            LF.BringToFront();
        }

        private void BtnMoneyManagement_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("AccountsManagementForm"))
                new AccountsManagementForm().Show();
        }

        private void BtnSummary_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("SummaryForm"))
                new SummaryForm().Show();
        }
    }
}
