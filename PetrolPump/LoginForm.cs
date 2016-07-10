using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Management;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace PetrolPump
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //BtnLogin_Click(sender, e);
                //ManagementObjectSearcher searcher =
                //        new ManagementObjectSearcher("root\\CIMV2",
                //        "SELECT ProcessorId FROM Win32_Processor");

                //bool Match = false;

                ////build x86 kia he?han
                //foreach (ManagementObject queryObj in searcher.Get())
                //{
                //    TBID.Text = queryObj["ProcessorId"].ToString();
                //    if (queryObj["ProcessorId"].ToString() == "178BFBFF00300F10")
                //        //if (queryObj["ProcessorId"].ToString() == "BFEBFBFF0001067A")
                //        Match = true;
                //}
                //if (!Match)
                //{
                //    MessageBox.Show("Software is not licensed for this computer");
                //    Application.Exit();
            //}
           
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            bool Errors = false;

            if (TBID.Text.Trim().Length == 0)
            {
                TBID.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }
            else
            {
                TBID.BackColor = Color.White;
            }

            if (TBPassword.Text.Trim().Length == 0)
            {
                TBPassword.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }
            else
            {
                TBPassword.BackColor = Color.White;
            }

            if (Errors)
                return;

            MySqlFunctions Func = new MySqlFunctions();
            var Result = Func.SelectQuery("select Name,Type from cashiers where ID='" + TBID.Text + "' and password='" + TBPassword.Text + "'");
            while (Result.Read())
            {
                MySqlFunctions.CashierName = Result["Name"].ToString();
                MySqlFunctions.CashierType = Result["Type"].ToString();
            }
            Result.Close();

            if (MySqlFunctions.CashierName + "" != "")
            {
                Company.Init();
                MySqlDataReader CompanyReader = Func.SelectQuery("select ID, Name,Number,Email from companies order by Name");
                while (CompanyReader.Read())
                {
                    MySqlFunctions Func2 = new MySqlFunctions();
                    MySqlDataReader VehicleReader = Func2.SelectQuery("select ID, Number,Name from vehicles where CompanyID='" + CompanyReader["ID"] + "' order by Number");
                    Vehicle Vechiles = new Vehicle();
                    while (VehicleReader.Read())
                    {
                        Vechiles.Add((int)VehicleReader["ID"], (string)VehicleReader["Number"], (string)VehicleReader["Name"]);
                    }
                    Company.Add((int)CompanyReader["ID"], (string)CompanyReader["Name"], (string)CompanyReader["Number"], (string)CompanyReader["Email"], Vechiles);
                    VehicleReader.Close();
                    Func2.Dest();
                }
                CompanyReader.Close();

                LineCustomer.Init();
                MySqlDataReader CustomerReader = Func.SelectQuery("select ID,Name, VehicleNumber from linecustomers order by Name");
                while (CustomerReader.Read())
                {
                    LineCustomer.Add((int)CustomerReader["ID"], (string)CustomerReader["Name"], (string)CustomerReader["VehicleNumber"]);
                }
                CustomerReader.Close();

                Machines.Init();
                MySqlDataReader MachinesReader = Func.SelectQuery("select machines.ID, machines.Name as 'MachineName', inventory.Name as 'InventoryName' from machines inner join inventory on inventory.id = machines.inventoryid order by inventory.Name, machines.name");
                while (MachinesReader.Read())
                {
                    Machines.Add((int)MachinesReader["ID"], (string)MachinesReader["MachineName"], (string)MachinesReader["InventoryName"]);
                }
                MachinesReader.Close();

                MySqlFunctions.CashierID = Convert.ToInt32(TBID.Text);

                MySqlDataReader Reader = Func.SelectQuery("Select Name, Rate from inventory order by Name");

                Inventory.Init();

                while (Reader.Read())
                {
                    Inventory.Add(Reader["Name"].ToString(), Convert.ToDouble(Reader["Rate"]));
                }
                Reader.Close();

                Inventory.PrinterName = Func.ScalarString("select Value from settings where Type='Printer'");

                Reader = Func.SelectQuery("Select * from accounts");

                Accounts.Init();

                while (Reader.Read())
                {
                    Accounts.Add(Convert.ToInt32(Reader["ID"]), Reader["BankName"].ToString(), Reader["AccountNumber"].ToString());
                }
                Reader.Close();

                this.Hide();
                TBID.Text = TBPassword.Text = "";
                //new CombinedReport().ShowDialog();
                //new BillForm().ShowDialog();
                //new ReceiveCreditForm().ShowDialog();
                //new ReceiveLineCreditForm().Show();
                //this.SendToBack();
                //new AddCreditForm().ShowDialog();
                //new AddLineCreditForm().ShowDialog();
                new MainForm().ShowDialog();
                this.Show();
                this.BringToFront();
            }
            else
                MessageBox.Show("Incorrect user ID or password", "Incorrect user ID or password", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Func.Dest();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void TBID_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}














