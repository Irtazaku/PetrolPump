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
    public partial class AddLineCreditCustomerForm : Form
    {
        public AddLineCreditCustomerForm()
        {
            InitializeComponent();
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

            if (TBVehicle.Text.Trim().Length == 0)
            {
                TBVehicle.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }
            else
            {
                TBVehicle.BackColor = Color.White;
            }

            if (Errors)
                return;

            if (MessageBox.Show("Add New Customer:\n\nName: " + TBName.Text + "\nVehicle Number: " + TBVehicle.Text , "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MySqlFunctions Func = new MySqlFunctions();

            if (Func.NonReturnQuery("insert into linecustomers set Name='" + TBName.Text + "', VehicleNumber='" + TBVehicle.Text + "'"))
            {
                int InsertID = Func.ScalarInt("select LAST_INSERT_ID();");
                LineCustomer.Add(InsertID, TBName.Text, TBVehicle.Text);

                MessageBox.Show("Customer added successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TBName.Text = TBVehicle.Text = "";
            }
            else
                MessageBox.Show("Customer not added. Vehicle number not available", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Func.Dest();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
