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
            string Query = "select * from linecustomers where Name like '%" + TBName.Text + "%' and vehicleNumber like '%" + TBVehicle.Text + "%'";
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
            CBOrderBy.SelectedIndex = 0;
            SearchCustomer();

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
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
    }
}
