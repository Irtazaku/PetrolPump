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
    public partial class EditCompanyForm : Form
    {
        public EditCompanyForm()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (CBName.Items.Count == 0)
            {
                MessageBox.Show("No company selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool Errors = false;

            if (TBName.Text.Trim().Length == 0)
            {
                TBName.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }
            else
            {
                TBName.BackColor = Color.White;
            }

            if (TBNumber.Text.Trim().Length == 0)
            {
                TBNumber.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }
            else
            {
                TBNumber.BackColor = Color.White;
            }

            if (TBEmail.Text.Trim().Length == 0)
            {
                TBEmail.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }
            else
            {
                TBEmail.BackColor = Color.White;
            }

            if (Errors)
                return;

            if (MessageBox.Show("Update Company:\n\nOld Name: " + CBName.Text + "\nNew Name: " +TBName.Text + "\nEmail: " + TBEmail.Text + "\nNumber: " + TBNumber.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MySqlFunctions Func = new MySqlFunctions();

            if (Func.NonReturnQuery("update companies set Name='" + TBName.Text + "', Number='" + TBNumber.Text + "', Email='" + TBEmail.Text + "' where name='" + CBName.Text + "'"))
            {
                Company.Name[CBName.SelectedIndex] = TBName.Text;
                Company.Name[CBName.SelectedIndex] = TBNumber.Text;
                Company.Name[CBName.SelectedIndex] = TBEmail.Text;

                MessageBox.Show("Company updated successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CBName.Items[CBName.SelectedIndex] = TBName.Text;
                CBName.SelectedIndex = CBName.SelectedIndex;
            }
            else
                MessageBox.Show("Company not updated. Company name not available", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Func.Dest();
        }

        private void EditCompanyForm_Load(object sender, EventArgs e)
        {
            foreach (string Name in Company.Name)
                CBName.Items.Add(Name);

            if (CBName.Items.Count > 0)
                CBName.SelectedIndex = 0;
        }

        private void CBID_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBName.Text = Company.Name[CBName.SelectedIndex];
            TBNumber.Text = Company.Number[CBName.SelectedIndex];
            TBEmail.Text = Company.Email[CBName.SelectedIndex];
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
