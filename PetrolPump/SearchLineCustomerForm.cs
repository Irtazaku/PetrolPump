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
    public partial class SearchLineCustomerForm : Form
    {
        MySqlFunctions Func;

        public SearchLineCustomerForm()
        {
            InitializeComponent();
        }

        private void SearchCustomer()
        {
            DGVSearchCustomer.Rows.Clear();
            string Query = "select * from linecustomers where Name like '%" + CBName.Text + "%' and vehicleNumber like '%" + CBVehicle.Text + "%'";
            if (CBOrderBy.Text == "Vehicle No")
                Query += " order by vehiclenumber " + (RBAsc.Checked ? "asc" : "desc");
            else
                Query += " order by " + CBOrderBy.Text + " " + (RBAsc.Checked ? "asc" : "desc");
            MySql.Data.MySqlClient.MySqlDataReader Reader = Func.SelectQuery(Query);
            while (Reader.Read())
                DGVSearchCustomer.Rows.Add(Reader["ID"].ToString(), Reader["Name"].ToString(), Reader["VehicleNumber"].ToString());
            Reader.Close();
        }

        private void SearchLineCustomerForm_Load(object sender, EventArgs e)
        {
            Func = new MySqlFunctions();
            if (CBOrderBy.Items.Count > 0)
            CBOrderBy.SelectedIndex = 0;
            SearchCustomer();

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            foreach (string Number in LineCustomer.Number)
            {
                CBVehicle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBVehicle.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBVehicle.Items.Add(Number);
            }
            if (CBVehicle.Items.Count > 0)
                CBVehicle.SelectedIndex = 0;

            foreach (string Name in LineCustomer.Name)
            {
                CBName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBName.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBName.Items.Add(Name);
            }
            if (CBName.Items.Count > 0)
                CBName.SelectedIndex = 0;

            foreach (int ID in LineCustomer.ID)
            {
                CBID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBID.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBID.Items.Add(ID);
            }
            if (CBID.Items.Count > 0)
                CBID.SelectedIndex = 0;
        }

        private void TBName_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer();
        }

        private void TBVehicle_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer();
        }

        private void SearchLineCustomerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Func.Dest();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CBName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchCustomer();
        }

        private void CBVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchCustomer();
        }

        private void CBID_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchCustomer();
        }
    }
}
