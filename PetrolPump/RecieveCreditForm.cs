using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;

namespace PetrolPump
{
    public partial class RecieveCreditForm : Form
    {
        List<Company> Companies;

        public RecieveCreditForm()
        {
            InitializeComponent();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            MySqlFunctions Func = new MySqlFunctions();

            MySqlDataReader CreditHistory = Func.SelectQuery("select credit.ID, credit.Type, Liter, Rate, credit.Amount, credit.datetime,vehicles.Number from credit inner join vehicles on credit.vehicleID = vehicles.ID inner join creditrecieved on credit.ID = creditrevieved.creditid");
            
            Func.Dest();
        }

        private void RecieveCreditForm_Load(object sender, EventArgs e)
        {
            MySqlFunctions Func = new MySqlFunctions();

            Companies = new List<Company>();
            MySqlDataReader CompanyReader = Func.SelectQuery("select ID, Name from companies");
            while (CompanyReader.Read())
            {
                CBCompany.Items.Add(CompanyReader["Name"]);
                Companies.Add(new Company((int)CompanyReader["ID"], (string)CompanyReader["Name"], new List<Vehicle>()));
            }
            CompanyReader.Close();

            Func.Dest();
        }
    }
}
