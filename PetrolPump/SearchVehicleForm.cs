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
            string Query = "select vehicles.ID as ID, vehicles.Name as VName,vehicles.Number as VNumber,companies.Name as CName from vehicles inner join companies on companies.ID = vehicles.companyID where vehicles.Name like '%" + CBCompany.Text + "%' and vehicles.number like '%" + CBVehicle.Text + "%' and companies.name like '%" + CBCompany.Text + "%' and vehicles.id like '%" + CBID.Text + "%'";
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
            if (CBOrderBy.Items.Count > 0)
            CBOrderBy.SelectedIndex = 0;
            SearchVehicle();

            //this.MinimumSize = this.Size;
            //this.MaximumSize = this.Size;
            foreach (string Name in Company.Name)
            {
                CBCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBCompany.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBCompany.Items.Add(Name);
            }
            if (CBCompany.Items.Count > 0)
                CBCompany.SelectedIndex = 0;
        }

        private void CBOrderBy_SelectedIndexChanged(object sender, EventArgs e)
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

        private void CBVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchVehicle();
        }

        private void CBID_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchVehicle();
        }

        private void CBVehicle_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            SearchVehicle();
        }

        private void CBDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchVehicle();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBVehicle.Items.Clear();
            foreach (string Number in Company.Vehicles[CBCompany.SelectedIndex].Number)
            {
                CBVehicle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBVehicle.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBVehicle.Items.Add(Number);
            }
            if (CBVehicle.Items.Count > 0)
                CBVehicle.SelectedIndex = 0;

            CBID.Items.Clear();
            foreach (int ID in Company.Vehicles[CBCompany.SelectedIndex].ID)
            {
                CBID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBID.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBID.Items.Add(ID);
            }
            if (CBID.Items.Count > 0)
                CBID.SelectedIndex = 0;

            CBDriver.Items.Clear();
            foreach (string Driver in Company.Vehicles[CBCompany.SelectedIndex].Name)
            {
                CBDriver.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBDriver.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBDriver.Items.Add(Driver);
            }
            if (CBDriver.Items.Count > 0)
                CBDriver.SelectedIndex = 0;
            
            SearchVehicle();

            
        }
    }
}
