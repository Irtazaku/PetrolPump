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
    public partial class SearchInventoryForm : Form
    {
        MySqlFunctions Func;

        public SearchInventoryForm()
        {
            InitializeComponent();
        }

        private void SearchInventory()
        {
            DGVSearchInventory.Rows.Clear();
            string Query="select * from inventory where Name like '%" + CBName.Text + "%' and Rate like '%" + TBRate.Text + "%' and Quantity like '%" + TBQuantity.Text + "%' order by " + CBOrderBy.Text + " " + (RBAsc.Checked ? "asc" : "desc");
            MySql.Data.MySqlClient.MySqlDataReader Reader = Func.SelectQuery(Query);
            while (Reader.Read())
                DGVSearchInventory.Rows.Add(Reader["Name"].ToString(), Reader["Rate"].ToString(), Reader["Quantity"].ToString());
            Reader.Close();
        }

        private void TBName_TextChanged(object sender, EventArgs e)
        {
            SearchInventory();
        }

        private void TBQuantity_TextChanged(object sender, EventArgs e)
        {
            SearchInventory();
        }

        private void TBRate_TextChanged(object sender, EventArgs e)
        {
            SearchInventory();
        }

        private void CBOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchInventory();
        }

        private void RBAsc_CheckedChanged(object sender, EventArgs e)
        {
            SearchInventory();
        }

        private void SearchInventoryForm_Load(object sender, EventArgs e)
        {
            Func = new MySqlFunctions();
            if (CBOrderBy.Items.Count > 0)
            CBOrderBy.SelectedIndex = 0;

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            foreach (string Item in Inventory.Name)
            {
                CBName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBName.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBName.Items.Add(Item);
            }
            if (CBName.Items.Count > 0)
                CBName.SelectedIndex = 0;

        }

        private void SearchInventoryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Func.Dest();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CBName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchInventory();
        }
    }
}
