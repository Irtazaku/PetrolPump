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
    public partial class InventoryManagementForm : Form
    {
        public InventoryManagementForm()
        {
            InitializeComponent();
        }

        private void BtnAddInventory_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("AddInventoryForm"))
                new AddInventoryForm().Show();
        }

        private void BtnEditInventory_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("EditInventoryForm"))
                new EditInventoryForm().Show();
        }

        private void BtnDeleteInventory_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("DeleteInventoryForm"))
                new DeleteInventoryForm().Show();
        }

        private void BtnSearchInventory_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("SearchInventoryForm"))
                new SearchInventoryForm().Show();
        }
    }
}