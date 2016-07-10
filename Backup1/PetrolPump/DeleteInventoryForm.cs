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
    public partial class DeleteInventoryForm : Form
    {
        public DeleteInventoryForm()
        {
            InitializeComponent();
        }

        private void DeleteInventoryForm_Load(object sender, EventArgs e)
        {
            foreach (string Item in Inventory.Name)
                CBType.Items.Add(Item);

            CBType.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete Inventory:\n\nInventory Name: " + CBType.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MySqlFunctions Func = new MySqlFunctions();

            Func.NonReturnQuery("delete from inventory where name='" + CBType.Text + "'");
            
            Func.Dest();

            Inventory.Name.RemoveAt(CBType.SelectedIndex);
            Inventory.Rate.RemoveAt(CBType.SelectedIndex);

            MessageBox.Show("Inventory deleted successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CBType.Items.RemoveAt(CBType.SelectedIndex);
            CBType.SelectedIndex = 0;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
