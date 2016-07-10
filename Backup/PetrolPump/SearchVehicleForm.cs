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
    public partial class SearchVehicleForm : Form
    {
        MySqlFunctions Func;

        public SearchVehicleForm()
        {
            InitializeComponent();
        }

        private void SearchVehicle()
        {
            DGVSearchVehicle.Rows.Clear();
            string Query = "select vehicles.ID as ID, vehicles.Name as VName,vehicles.Number as VNumber,companies.Name as CName from vehicles inner join companies on companies.ID = vehicles.companyID where vehicles.Name like '%" + TBDriver.Text + "%' and vehicles.number like '%" + TBVehicle.Text + "%' and companies.name like '%" + TBCompany.Text + "%' and vehicles.id like '%" + TBID.Text + "%'";
            if (CBOrderBy.Text == "Driver Name")
                Query += " order by vehicles.Name";
            else if (CBOrderBy.Text == "Vehicle No")
                Query += " order by vehicles.Number";
            else if (CBOrderBy.Text == "Company Name")
                Query += " order by companies.Name";
            else
                Query += " order by vehicles.ID";
            Query += " " + (RBAsc.Checked ? "asc" : "desc");
            MySql.Data.MySqlClient.MySqlDataReader Reader = Func.SelectQuery(Query);
            while (Reader.Read())
                DGVSearchVehicle.Rows.Add(Reader["ID"].ToString(), Reader["VName"].ToString(), Reader["VNumber"].ToString(), Reader["CName"].ToString());
            Reader.Close();
        }

        private void SearchVehicleForm_Load(object sender, EventArgs e)
        {
            Func = new MySqlFunctions();
            CBOrderBy.SelectedIndex = 0;
            SearchVehicle();

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void TBName_TextChanged(object sender, EventArgs e)
        {
            SearchVehicle();
        }

        private void TBVehicle_TextChanged(object sender, EventArgs e)
        {
            SearchVehicle();
        }

        private void CBOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchVehicle();
        }

        private void TBID_TextChanged(object sender, EventArgs e)
        {
            SearchVehicle();
        }

        private void TBDriver_TextChanged(object sender, EventArgs e)
        {
            SearchVehicle();
        }

        private void RBAsc_CheckedChanged(object sender, EventArgs e)
        {
            SearchVehicle();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
