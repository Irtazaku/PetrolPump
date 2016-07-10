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
    public partial class EditVehicleForm : Form
    {
        public EditVehicleForm()
        {
            InitializeComponent();
        }

        private void EditVehicleForm_Load(object sender, EventArgs e)
        {
            foreach (string Name in Company.Name)
                CBCompany.Items.Add(Name);

            if (CBCompany.Items.Count > 0)
                CBCompany.SelectedIndex = 0;
        }

        private void CBCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBVehicle.Items.Clear();
            foreach (string Number in Company.Vehicles[CBCompany.SelectedIndex].Number)
                CBVehicle.Items.Add(Number);

            if (CBVehicle.Items.Count > 0)
                CBVehicle.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (CBCompany.Items.Count == 0)
            {
                MessageBox.Show("No company selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CBVehicle.Items.Count == 0)
            {
                MessageBox.Show("Company has no vehicle", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (Errors)
                return;

            if (MessageBox.Show("Update Vehicle:\n\nCompany Name: " + CBCompany.Text + "\nOld Vehicle Number: " + CBVehicle.Text + "\nNew Vehicle Number: " + TBNumber.Text + "\nDriver Name: " + TBName.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MySqlFunctions Func = new MySqlFunctions();

            if (Func.NonReturnQuery("update vehicles set Name='" + TBName.Text + "', Number='" + TBNumber.Text + "' where Number='" + CBVehicle.Text + "'"))
            {
                Company.Vehicles[CBCompany.SelectedIndex].Name[CBVehicle.SelectedIndex] = TBName.Text;
                Company.Vehicles[CBCompany.SelectedIndex].Number[CBVehicle.SelectedIndex] = TBNumber.Text;

                MessageBox.Show("Vehicle updated successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CBVehicle.Items[CBVehicle.SelectedIndex] = TBNumber.Text;
                CBVehicle.SelectedIndex = CBVehicle.SelectedIndex;
            }
            else
                MessageBox.Show("Vehicle not updated. Vehicle number not available", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            Func.Dest();
        }

        private void CBID_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBName.Text = Company.Vehicles[CBCompany.SelectedIndex].Name[CBVehicle.SelectedIndex];
            TBNumber.Text = Company.Vehicles[CBCompany.SelectedIndex].Number[CBVehicle.SelectedIndex];
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
