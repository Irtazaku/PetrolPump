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
    public partial class DeleteVehicleForm : Form
    {
        public DeleteVehicleForm()
        {
            InitializeComponent();
        }

        private void DeleteVehicleForm_Load(object sender, EventArgs e)
        {
            foreach (string Name in Company.Name)
                CBCompany.Items.Add(Name);

            if (CBCompany.Items.Count > 0)
                CBCompany.SelectedIndex = 0;
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

            if (MessageBox.Show("Delete Vehicle:\n\nCompany Name: " + CBCompany.Text + "\nVehicle Number: " + CBVehicle.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MySqlFunctions Func = new MySqlFunctions();

            Func.NonReturnQuery("delete from vehicles where number='" + CBVehicle.Text + "'");

            Func.Dest();

            Company.Vehicles[CBCompany.SelectedIndex].ID.RemoveAt(CBVehicle.SelectedIndex);
            Company.Vehicles[CBCompany.SelectedIndex].Name.RemoveAt(CBVehicle.SelectedIndex);
            Company.Vehicles[CBCompany.SelectedIndex].Number.RemoveAt(CBVehicle.SelectedIndex);

            MessageBox.Show("Vehicle deleted successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CBVehicle.Items.RemoveAt(CBVehicle.SelectedIndex);
            if (CBVehicle.Items.Count > 0)
            CBVehicle.SelectedIndex = 0;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CBCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBVehicle.Items.Clear();
            foreach (string Number in Company.Vehicles[CBCompany.SelectedIndex].Number)
                CBVehicle.Items.Add(Number);

            if (CBVehicle.Items.Count > 0)
                CBVehicle.SelectedIndex = 0;
        }
    }
}
