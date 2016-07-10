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
    public partial class EditLineCreditCustomerForm : Form
    {
        public EditLineCreditCustomerForm()
        {
            InitializeComponent();
        }

        private void EditLineCreditCustomerForm_Load(object sender, EventArgs e)
        {
            foreach (string Number in LineCustomer.Number)
                CBNumber.Items.Add(Number);

            if (CBNumber.Items.Count > 0)
                CBNumber.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (CBNumber.Items.Count == 0)
            {
                MessageBox.Show("No customer selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (MessageBox.Show("Update Customer:\n\nOld Vehicle Number: " + CBNumber.Text + "\nNew Vehicle Number: " + TBNumber.Text + "\nDriver Name: " + TBName.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MySqlFunctions Func = new MySqlFunctions();

            if (Func.NonReturnQuery("update linecustomers set Name='" + TBName.Text + "', VehicleNumber='" + TBNumber.Text + "' where number='" + CBNumber.Text + "'"))
            {
                LineCustomer.Name[CBNumber.SelectedIndex] = TBName.Text;
                LineCustomer.Number[CBNumber.SelectedIndex] = TBNumber.Text;

                MessageBox.Show("Customer updated successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CBNumber.Items[CBNumber.SelectedIndex] = TBNumber.Text;
                CBNumber.SelectedIndex = CBNumber.SelectedIndex;
            }
            else
                MessageBox.Show("Customer not updated. Customer name not available", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            Func.Dest();
        }

        private void CBID_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBName.Text = LineCustomer.Name[CBNumber.SelectedIndex];
            TBNumber.Text = LineCustomer.Number[CBNumber.SelectedIndex];
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}