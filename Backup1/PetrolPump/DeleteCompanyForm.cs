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
    public partial class DeleteCompanyForm : Form
    {
        public DeleteCompanyForm()
        {
            InitializeComponent();
        }

        private void DeleteCompanyForm_Load(object sender, EventArgs e)
        {
            foreach (string Name in Company.Name)
                CBCompany.Items.Add(Name);

            CBCompany.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete Company:\n\nCompany Name: " + CBCompany.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return; 
            
            MySqlFunctions Func = new MySqlFunctions();

            Func.NonReturnQuery("delete from companies where name='" + CBCompany.Text + "'");

            Func.Dest();

            Company.ID.RemoveAt(CBCompany.SelectedIndex);
            Company.Name.RemoveAt(CBCompany.SelectedIndex);
            Company.Number.RemoveAt(CBCompany.SelectedIndex);
            Company.Email.RemoveAt(CBCompany.SelectedIndex);
            Company.Vehicles.RemoveAt(CBCompany.SelectedIndex);

            MessageBox.Show("Company deleted successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CBCompany.Items.RemoveAt(CBCompany.SelectedIndex);
            CBCompany.SelectedIndex = 0;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
