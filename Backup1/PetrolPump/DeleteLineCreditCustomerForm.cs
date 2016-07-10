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
    public partial class DeleteLineCreditCustomerForm : Form
    {
        public DeleteLineCreditCustomerForm()
        {
            InitializeComponent();
        }

        private void DeleteLineCreditCustomerForm_Load(object sender, EventArgs e)
        {
            foreach (string Item in LineCustomer.Number)
                CBVehicle.Items.Add(Item);

            CBVehicle.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete Customer:\n\nVehicle Number: " + CBVehicle.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MySqlFunctions Func = new MySqlFunctions();

            Func.NonReturnQuery("delete from linecustomers where vehiclenumber='" + CBVehicle.Text + "'");

            Func.Dest();

            LineCustomer.ID.RemoveAt(CBVehicle.SelectedIndex);
            LineCustomer.Name.RemoveAt(CBVehicle.SelectedIndex);
            LineCustomer.Number.RemoveAt(CBVehicle.SelectedIndex);

            MessageBox.Show("Customer deleted successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            CBVehicle.Items.RemoveAt(CBVehicle.SelectedIndex);
            CBVehicle.SelectedIndex = 0;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
