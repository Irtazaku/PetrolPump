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
    public partial class AddVehicleForm : Form
    {
        public AddVehicleForm()
        {
            InitializeComponent();
        }

        private void AddVehicleForm_Load(object sender, EventArgs e)
        {
            foreach (string Name in Company.Name)
                CBCompany.Items.Add(Name);

            CBCompany.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
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

            if (MessageBox.Show("Add Vehicle For:\n\nCompany Name: " + CBCompany.Text + "\nVehicle Number: " + TBNumber.Text + "\nDriver Name: " + TBName.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MySqlFunctions Func = new MySqlFunctions();

            if (Func.NonReturnQuery("insert into vehicles set Name='" + TBName.Text + "', Number='" + TBNumber.Text + "', CompanyID='" + Company.ID[CBCompany.SelectedIndex] + "'"))
            {
                int InsertID = Func.ScalarInt("select LAST_INSERT_ID();");
                Company.Vehicles[CBCompany.SelectedIndex].Add(InsertID, TBNumber.Text, TBName.Text);

                MessageBox.Show("Vechicle added successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TBName.Text = TBNumber.Text = "";
            }
            else
                MessageBox.Show("Vechicle not added. Vechicle number not available", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Func.Dest();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
