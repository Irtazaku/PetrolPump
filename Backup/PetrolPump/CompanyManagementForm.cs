using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PetrolPump
{
    public partial class CompanyManagementForm : Form
    {
        public CompanyManagementForm()
        {
            InitializeComponent();
        }

        private void BtnAddCompany_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("AddCompanyForm"))
                new AddCompanyForm().Show();
        }

        private void BtnEditCompany_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("EditCompanyForm"))
            new EditCompanyForm().Show();
        }

        private void BtnSearchCompany_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("SearchCompanyForm"))
            new SearchCompanyForm().Show();
        }

        private void BtnDeleteCompany_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("DeleteCompanyForm"))
            new DeleteCompanyForm().Show();
        }

        private void BtnAddVehicle_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("AddVehicleForm"))
            new AddVehicleForm().Show();
        }

        private void BtnEditVehicle_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("EditVehicleForm"))
            new EditVehicleForm().Show();
        }

        private void BtnSearchVehicle_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("SearchVehicleForm"))
            new SearchVehicleForm().Show();
        }

        private void BtnDeleteVehicle_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("DeleteVehicleForm"))
            new DeleteVehicleForm().Show();
        }

        private void CashierUser()
        {
            this.Size = new Size(646, 454);
            BtnEditCompany.Visible = false;
            BtnDeleteCompany.Visible = false;
            BtnEditVehicle.Visible = false;
            BtnDeleteVehicle.Visible = false;
        }

        private void CompanyManagementForm_Load(object sender, EventArgs e)
        {
            if (MySqlFunctions.CashierType == "Cashier")
                CashierUser();
        }
    }
}
