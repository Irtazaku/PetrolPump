using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace PetrolPump
{
    public partial class EditInventoryForm : Form
    {
        public EditInventoryForm()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (CBName.Items.Count == 0)
            {
                MessageBox.Show("No inventory selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (!Regex.IsMatch(TBLiter.Text, "^[0-9]*[.]{0,1}[0-9]{1,2}$"))
            {
                TBLiter.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }
            else if (double.Parse(TBLiter.Text) <= 0)
            {
                TBLiter.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }
            else
            {
                TBLiter.BackColor = Color.White;
            }

            if (!Regex.IsMatch(TBRate.Text, "^[0-9]*[.]{0,1}[0-9]{1,2}$"))
            {
                TBRate.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }
            else if (double.Parse(TBRate.Text) <= 0)
            {
                TBRate.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }
            else
            {
                TBRate.BackColor = Color.White;
            }

            if (Errors)
                return;

            if (MessageBox.Show("Update Inventory:\n\nOld Name: " + CBName.Text + "\nNew Name: " + TBName.Text + "\nLiter / Qty: " + TBLiter.Text + "\nRate: " + TBRate.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MySqlFunctions Func = new MySqlFunctions();

            if (Func.NonReturnQuery("update inventory set name='" + TBName.Text + "',quantity='" + TBLiter.Text + "',rate='" + TBRate.Text + "' where name='" + CBName.Text + "'"))
            {
                Inventory.Name[CBName.SelectedIndex] = TBName.Text;
                Inventory.Rate[CBName.SelectedIndex] = Convert.ToDouble(TBRate.Text);

                MessageBox.Show("Inventory updated successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CBName.Items[CBName.SelectedIndex] = TBName.Text;
                CBName.SelectedIndex = CBName.SelectedIndex;
            }
            else
                MessageBox.Show("Inventory not updated. Inventory name not available", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Func.Dest();
        }

        private void EditInventoryForm_Load(object sender, EventArgs e)
        {
            foreach (string Item in Inventory.Name)
                CBName.Items.Add(Item);

            if (CBName.Items.Count > 0)
                CBName.SelectedIndex = 0;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void CBName_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBName.Text = Inventory.Name[CBName.SelectedIndex];
            TBRate.Text = Math.Round(Inventory.Rate[CBName.SelectedIndex], 2) + "";

            string Query = "select Quantity from Inventory where name='" + Inventory.Name[CBName.SelectedIndex] + "'";
            TBLiter.Text = Math.Round(Convert.ToDouble(new MySqlFunctions().ScalarString(Query)), 2) + "";
        }
    }
}
