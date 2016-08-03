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
    public partial class AddInventoryForm : Form
    {
        public AddInventoryForm()
        {
            InitializeComponent();
        }

        private void RBNewInventory_CheckedChanged(object sender, EventArgs e)
        {
            LblName.Visible = TBName.Visible = RBNewInventory.Checked;
            LblType.Visible = CBType.Visible = !RBNewInventory.Checked;
            TBName.Text = TBLiter.Text = TBRate.Text = "";
            TBName.BackColor = TBLiter.BackColor = TBRate.BackColor = Color.White;
            if (RBOldInventory.Checked)
                TBRate.Text = Math.Round(Inventory.GetRate(CBType.Text), 2) + "";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            bool Errors = false;

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

            if (RBNewInventory.Checked)
            {
                if (TBName.Text.Trim().Length == 0)
                {
                    TBName.BackColor = Color.FromArgb(255, 207, 207);
                    Errors = true;
                }
                else
                {
                    TBName.BackColor = Color.White;
                }

                if (Errors)
                    return;

                if (MessageBox.Show("Add New Inventory:\n\nName: " + TBName.Text + "\nLiter / Qty: " + TBLiter.Text + "\nRate: " + TBRate.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                MySqlFunctions Func = new MySqlFunctions();

                if (Func.NonReturnQuery("insert into inventory set Name='" + TBName.Text + "', quantity='" + TBLiter.Text + "', rate='" + TBRate.Text + "'"))
                {
                    Func.NonReturnQuery("insert into inventoryhistory set Name='" + TBName.Text + "', quantity='" + TBLiter.Text + "', rate='" + TBRate.Text + "', datetime='" + DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") + "'");

                    //Inventory.Init();

                    //MySql.Data.MySqlClient.MySqlDataReader Reader = Func.SelectQuery("Select Name, Rate from inventory order by Name");
                    //while (Reader.Read())
                    //{
                    Inventory.Add(TBName.Text, Convert.ToDouble(TBRate.Text));
                    //}
                    //Reader.Close();

                    MessageBox.Show("Inventory added successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    //CBType.Items.Clear();
                    //foreach (string Item in Inventory.Name)
                        //CBType.Items.Add(Item);

                    //CBType.SelectedIndex = 0;

                    CBType.Items.Add(TBName.Text);

                    TBRate.Text = TBLiter.Text = TBName.Text = "";
                }
                else
                    MessageBox.Show("Inventory not added. Inventory name not available", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Func.Dest();
            }
            
            else if (RBOldInventory.Checked)
            {
                if (Errors)
                    return;

                if (MessageBox.Show("Add Quantity In Inventory:\n\nName: " + TBName.Text + "\nLiter / Qty: " + TBLiter.Text + "\nRate: " + TBRate.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                MySqlFunctions Func = new MySqlFunctions();

                if (Func.NonReturnQuery("update inventory set quantity=quantity+" + TBLiter.Text + ", rate='" + TBRate.Text + "' where name='" + CBType.Text + "'"))
                {
                    Func.NonReturnQuery("insert into inventoryhistory set Name='" + CBType.Text + "', quantity='" + TBLiter.Text + "', rate='" + TBRate.Text + "', datetime='" + DateTime.Now.ToString("yyyy-MM-dd H:mm:ss") + "'");

                    Inventory.Rate[CBType.SelectedIndex] = Convert.ToDouble(TBRate.Text);

                    MessageBox.Show("Inventory added successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TBRate.Text = TBLiter.Text = TBName.Text = "";
                }
                else
                    MessageBox.Show("Inventory not added. Inventory not found in records. Reopen form to get updated records", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Func.Dest();
            }
        }

        private void AddInventoryForm_Load(object sender, EventArgs e)
        {
            foreach (string Item in Inventory.Name)
                CBType.Items.Add(Item);

            if (CBType.Items.Count > 0)
                CBType.SelectedIndex = 0;
            else
            {
                RBOldInventory.Enabled = false;
                RBNewInventory.Checked = true;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RBOldInventory.Checked)
            {
                TBRate.Text = Math.Round(Inventory.GetRate(CBType.Text), 2) + "";
            }
        }
    }
}
