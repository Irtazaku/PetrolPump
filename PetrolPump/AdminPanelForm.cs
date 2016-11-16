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
    public partial class AdminPanelForm : Form
    {
        MySqlFunctions Func;
        public AdminPanelForm()
        {
            InitializeComponent();
            Func = new MySqlFunctions();
        }

        private void MIBackup_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "Database - " + DateTime.Now.ToString("dddd, MMMM dd, yyyy - hh;mm;ss tt");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MySqlFunctions Func2 = new MySqlFunctions();
                Func2.BackUp(saveFileDialog1.FileName);
                Func2.Dest();
                MessageBox.Show("Record backed up successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MIRestore_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "Database File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MySqlFunctions Func2 = new MySqlFunctions();
                Func2.Restore(openFileDialog1.FileName);
                Func2.Dest();
                MessageBox.Show("Record restored successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnAddCashier_Click(object sender, EventArgs e)
        {
            bool Errors = false;

            if (TBAddName.Text.Trim().Length == 0)
            {
                TBAddName.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }

            else
            {
                TBAddName.BackColor = Color.White;
            }

            if (TBAddPassword.Text.Trim().Length == 0)
            {
                TBAddPassword.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }

            else
            {
                TBAddPassword.BackColor = Color.White;
            }

            if (Errors)
                return;

            if (MessageBox.Show("Add New Cashier:\n\nName: " + TBAddName.Text + "\nType: " + CBAddType.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MySqlFunctions Func2 = new MySqlFunctions();

            int InsertID = Func2.ScalarInt(@"
                                insert into cashiers set 
                                Name='" + TBAddName.Text + @"',
                                Password='" + TBAddPassword.Text + @"',
                                Type='" + CBAddType.Text + @"';
                                SELECT LAST_INSERT_ID();");

            Func2.Dest();

            MessageBox.Show(CBAddType.Text + " added at ID: " + InsertID, "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TBAddName.Text = TBAddPassword.Text = "";
        }

        private void SearchCashier()
        {
            DGVSearchCashier.Rows.Clear();
            string Query = "select * from cashiers where Name like '%" + TBSearchName.Text + "%' and ID like '%" + TBSearchID.Text + "%' ";
            if (CBSearchType.Text != "All")
                Query += " and Type like '%" + CBSearchType.Text + "%' ";
            Query += " order by " + CBOrderBy.Text + " " + (RBAsc.Checked ? "asc" : "desc");

            MySql.Data.MySqlClient.MySqlDataReader Reader = Func.SelectQuery(Query);
            while (Reader.Read())
                DGVSearchCashier.Rows.Add(Reader["ID"].ToString(), Reader["Name"].ToString(), Reader["Type"].ToString());
            Reader.Close();
        }

        private void TBSearchName_TextChanged(object sender, EventArgs e)
        {
            SearchCashier();
        }

        private void CBSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchCashier();
        }

        private void MISearchCashier_Click(object sender, EventArgs e)
        {
            PanelAddCashier.Visible = false;
            PanelAddMachine.Visible = false;
            PanelEditMachine.Visible = false;
            PanelSearchCashier.Visible = true;
            PanelPrinter.Visible = false; 
            PanelSearchCashier.BringToFront();
        }

        private void MIAddCashier_Click(object sender, EventArgs e)
        {
            PanelAddCashier.Visible = true;
            PanelAddMachine.Visible = false;
            PanelEditMachine.Visible = false;
            PanelSearchCashier.Visible = false;
            PanelPrinter.Visible = false;
            PanelAddCashier.BringToFront();
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            if (CBOrderBy.Items.Count > 0)
                CBOrderBy.SelectedIndex = 0;

            if (CBSearchType.Items.Count > 0)
                CBSearchType.SelectedIndex = 0;

            if (CBAddType.Items.Count > 0)
                CBAddType.SelectedIndex = 0;

            foreach (string Item in Inventory.Name)
            {
                CBAddMachineType.Items.Add(Item);
                CBEditMachineType.Items.Add(Item);
            }

            foreach (string Name in Machines.MachineName)
            {
                CBEditMachineName.Items.Add(Name);
            }

            int PrinterIndex = -1;
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                CBPrinterName.Items.Add(printer);
                if (printer == Inventory.PrinterName)
                    PrinterIndex = CBPrinterName.Items.Count - 1;
            }

            if (CBAddMachineType.Items.Count > 0)
                CBAddMachineType.SelectedIndex = 0;
            if (CBEditMachineType.Items.Count > 0)
                CBEditMachineType.SelectedIndex = 0;
            if (CBPrinterName.Items.Count > 0)
            {
                if (PrinterIndex != -1)
                {
                    PrinterIndex = CBPrinterName.Items.IndexOf(Inventory.PrinterName);
                }
                else
                    PrinterIndex = 0;
                CBPrinterName.SelectedIndex = PrinterIndex;
            }
        }

        private void TBSearchID_TextChanged(object sender, EventArgs e)
        {
            SearchCashier();
        }

        private void CBOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchCashier();
        }

        private void RBAsc_CheckedChanged(object sender, EventArgs e)
        {
            SearchCashier();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAddMachine_Click(object sender, EventArgs e)
        {
            if (CBAddMachineType.Items.Count == 0)
            {
                MessageBox.Show("No fuel type selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool Errors = false;

            if (TBAddMachineName.Text.Trim().Length == 0)
            {
                TBAddMachineName.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }

            else
            {
                TBAddMachineName.BackColor = Color.White;
            }

            if (TBAddMachineUnit.Text.Trim().Length == 0)
            {
                TBAddMachineUnit.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }

            else
            {
                TBAddMachineUnit.BackColor = Color.White;
            }

            if (Errors)
                return;

            if (MessageBox.Show("Add New Machine:\n\nName: " + TBAddMachineName.Text + "\nUnits: " + TBAddMachineUnit.Text + "\nType: " + CBAddMachineType.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MySqlFunctions Func2 = new MySqlFunctions();

            int InventoryID = Func2.ScalarInt(@"SELECT id from inventory where name = '" + CBAddMachineType.Text + "'");

            int InsertID = Func2.ScalarInt(@"
                                insert into machines set 
                                Name='" + TBAddMachineName.Text + @"',
                                Units='" + TBAddMachineUnit.Text + @"',
                                InventoryID='" + InventoryID + @"';
                                SELECT LAST_INSERT_ID();");

            Func2.Dest();

            Machines.Add(InsertID, TBAddMachineName.Text, CBAddMachineType.Text);

            MessageBox.Show("Machine added successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TBAddMachineName.Text = TBAddMachineUnit.Text = "";
        }

        private void MIAddMachine_Click(object sender, EventArgs e)
        {
            PanelAddCashier.Visible = false;
            PanelAddMachine.Visible = true;
            PanelEditMachine.Visible = false;
            PanelSearchCashier.Visible = false;
            PanelPrinter.Visible = false; 
            PanelAddMachine.BringToFront();
        }

        private void CBEditMachineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlFunctions Func2 = new MySqlFunctions();

            double Units = Func2.ScalarInt(@"SELECT units from machines where name = '" + CBEditMachineName.Text + "'");
            Func2.Dest();

            if (Units != -1)
            {
                TBEditMachineName.Text = CBEditMachineName.Text;
                TBEditMachineUnits.Text = Units + "";
                CBEditMachineType.Text = Machines.InventoryName[Machines.MachineName.IndexOf(CBEditMachineName.Text)];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEditMachine_Click(object sender, EventArgs e)
        {
            if (CBEditMachineType.Items.Count == 0)
            {
                MessageBox.Show("No fuel type selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool Errors = false;

            if (TBEditMachineName.Text.Trim().Length == 0)
            {
                TBEditMachineName.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }

            else
            {
                TBEditMachineName.BackColor = Color.White;
            }

            if (TBEditMachineUnits.Text.Trim().Length == 0)
            {
                TBEditMachineUnits.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }

            else
            {
                TBEditMachineUnits.BackColor = Color.White;
            }

            if (Errors)
                return;

            if (MessageBox.Show("Edit Machine:\n\nName: " + TBEditMachineName.Text + "\nUnits: " + TBEditMachineUnits.Text + "\nType: " + CBEditMachineType.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MySqlFunctions Func2 = new MySqlFunctions();

            int InventoryID = Func2.ScalarInt(@"SELECT id from inventory where name = '" + CBEditMachineType.Text + "'");

            int InsertID = Func2.ScalarInt(@"
                                update machines set 
                                Name='" + TBEditMachineName.Text + @"',
                                Units='" + TBEditMachineUnits.Text + @"',
                                InventoryID='" + InventoryID + @"';
                                SELECT LAST_INSERT_ID();");

            Func2.Dest();

            int Index = Machines.MachineName.IndexOf(CBEditMachineName.Text);
            Machines.MachineName[Index] = TBEditMachineName.Text;
            Machines.InventoryName[Index]= CBEditMachineType.Text;

            MessageBox.Show("Machine edited successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TBEditMachineName.Text = TBEditMachineUnits.Text = "";
        }

        private void MIEditMachine_Click(object sender, EventArgs e)
        {
            PanelAddCashier.Visible = false;
            PanelAddMachine.Visible = false;
            PanelEditMachine.Visible = true;
            PanelSearchCashier.Visible = false;
            PanelPrinter.Visible = false; 
            PanelEditMachine.BringToFront();
        }

        private void printerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelAddCashier.Visible = false;
            PanelAddMachine.Visible = false;
            PanelEditMachine.Visible = false;
            PanelSearchCashier.Visible = false;
            PanelPrinter.Visible = true;
            PanelPrinter.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnChangePrinter_Click(object sender, EventArgs e)
        {
            if (CBPrinterName.Items.Count <= 0)
                return;

            if (MessageBox.Show("Edit Printer:\n\nName: " + CBPrinterName.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MySqlFunctions Func2 = new MySqlFunctions();

            Func2.NonReturnQuery("UPDATE settings set Value = '" + CBPrinterName.Text + "' where Type='Printer'");

            Func2.Dest();
            Inventory.PrinterName = CBPrinterName.Text;

            MessageBox.Show("Printer edited successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
