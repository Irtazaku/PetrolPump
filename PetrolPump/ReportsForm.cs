using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace PetrolPump
{
    public partial class ReportsForm : Form
    {
        int ClickedItem;

        public ReportsForm()
        {
            InitializeComponent();
        }

        private void DGVVisibleColumns_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DGVReports.Columns[e.RowIndex].Visible = (bool)DGVVisibleColumns.Rows[e.RowIndex].Cells[0].EditedFormattedValue;
        }

        private void FormatDGV()
        {
            if (DGVVisibleColumns.Rows.Count == 0)
            {
                for (int i = 0; i < DGVReports.Columns.Count; i++)
                    DGVVisibleColumns.Rows.Add(true, DGVReports.Columns[i].HeaderText);
            }

            for (int i = 0; i < DGVVisibleColumns.Rows.Count; i++)
            {
                if ((bool)DGVVisibleColumns.Rows[i].Cells[0].Value == false)
                    DGVReports.Columns[i].Visible = false;
            }

            //for (int i = 0; i < DGVReports.Columns.Count - 3; i++)
            //DGVReports.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //for (int i = DGVReports.Columns.Count - 3; i < DGVReports.Columns.Count; i++)
            for (int i = 0; i < DGVReports.Columns.Count; i++)
                DGVReports.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DGVReports.DefaultCellStyle = DGVVisibleColumns.DefaultCellStyle;
            DGVReports.ColumnHeadersDefaultCellStyle = DGVVisibleColumns.ColumnHeadersDefaultCellStyle;
        }

        private void AppendQuery(ref string Query, string Column)
        {
            if (RBDate.Checked)
            {
                if (CBTo.Checked)
                {
                    Query += " and date(" + Column + ") between '" + DPFrom.Value.ToString("yyyy-MM-dd") + "' and '" + DPTo.Value.ToString("yyyy-MM-dd") + "' ";
                }
                else
                {
                    Query += " and date(" + Column + ") = '" + DPFrom.Value.ToString("yyyy-MM-dd") + "' ";
                }
            }
            else if (RBToday.Checked)
            {
                Query += " and date(" + Column + ") = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ";
            }
            else if (RBLast7.Checked)
            {
                Query += " and date(" + Column + ") between '" + DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ";
            }
            else if (RBLast15.Checked)
            {
                Query += " and date(" + Column + ") between '" + DateTime.Now.AddDays(-14).ToString("yyyy-MM-dd") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ";
            }
            else if (RBLast30.Checked)
            {
                Query += " and date(" + Column + ") between '" + DateTime.Now.AddDays(-29).ToString("yyyy-MM-dd") + "' and '" + DateTime.Now.ToString("yyyy-MM-dd") + "' ";
            }
        }

        private void RBDate_CheckedChanged(object sender, EventArgs e)
        {
            DPFrom.Enabled = CBTo.Enabled = RBDate.Checked;
        }

        private void CBTo_CheckedChanged(object sender, EventArgs e)
        {
            DPTo.Enabled = CBTo.Checked;
        }

        private void DGVReports_SelectionChanged(object sender, EventArgs e)
        {
            DGVReports.ClearSelection();
        }

        private void BtnGetLineCredit_Click(object sender, EventArgs e)
        {
            double TotalAmount = 0;
            double Received = 0;

            DGVReports.DataSource = null;
            DGVReports.Rows.Clear();
            MySqlFunctions Func = new MySqlFunctions();

            string Query = "SELECT linecredit.id,linecredit.datetime as Date, linecustomers.name as `Customer Name`, linecustomers.vehiclenumber as `Vehicle Number`, linecredit.Amount as `Debit`,cashiers.Name as `Cashier Name`, linecredit.Type, Liter, Rate,count(linecreditreceived.linecreditid),linecredit.Amount-sum(linecreditreceived.amount) from linecredit inner join linecustomers on linecustomers.id = linecredit.customerid inner join cashiers on cashiers.id = linecredit.cashierid left join linecreditreceived on linecreditreceived.linecreditid = linecredit.id where linecustomers.name like '%" + TBLineCreditCustomer.Text + "%' and linecustomers.vehiclenumber like '%" + CBLineCreditVehicle.Text + "%' and linecredit.Type like '%" + CBLineCreditType.Text + "%'";
            AppendQuery(ref Query, "linecredit.datetime");

            Query += " group by linecredit.id";

            if (CBLineCreditOrderBy.Text == "Slip No")
                Query += " order by linecredit.id";
            else if (CBLineCreditOrderBy.Text == "Customer")
                Query += " order by linecustomers.name";
            else if (CBLineCreditOrderBy.Text == "Vehicle Number")
                Query += " order by linecustomers.vehiclenumber";
            else if (CBLineCreditOrderBy.Text == "Date")
                Query += " order by linecredit.DateTime";
            else
                Query += " order by linecredit." + CBLineCreditOrderBy.Text;

            Query += " " + (RBLineCreditAsc.Checked ? " asc" : " desc");

            DGVReports.Columns.Clear();
            DGVReports.Columns.Add("dgvc0", "Slip No");
            DGVReports.Columns.Add("dgvc1", "Date");
            DGVReports.Columns.Add("dgvc2", "Customer Name");
            DGVReports.Columns.Add("dgvc3", "Vehicle Number");
            DGVReports.Columns.Add("dgvc4", "Amount");
            DGVReports.Columns.Add("dgvc6", "Cashier Name");
            DGVReports.Columns.Add("dgvc7", "Remarks");
            DGVReports.Columns.Add("dgvc8", "Type");
            DGVReports.Columns.Add("dgvc9", "Liter");
            DGVReports.Columns.Add("dgvc10", "Rate");

            MySqlDataReader Reader = Func.SelectQuery(Query);
            while (Reader.Read())
            {
                TotalAmount += Convert.ToDouble(Reader[4].ToString());

                DGVReports.Rows.Add(Reader[0].ToString(),
                                    Reader[1].ToString(),
                                    Reader[2].ToString(),
                                    Reader[3].ToString(),
                                    string.Format("{0:#,###.##}", Convert.ToDecimal(Reader[4].ToString())),
                                    Reader[5].ToString(),
                                    "Amount Receivable",
                                    Reader[6].ToString(),
                                    Reader[7].ToString(),
                                    Reader[8].ToString());
                if (Reader[9].ToString() == "0" || Math.Round(Convert.ToDouble(Reader[10].ToString()), 0) != 0)
                    DGVReports.Rows[DGVReports.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(233, 234, 242);

                MySqlFunctions Func2 = new MySqlFunctions();

                string Query2 = "SELECT datetime, Amount,cashiers.Name from linecreditreceived inner join cashiers on cashiers.id = linecreditreceived.cashierid where linecreditreceived.linecreditid='" + Reader[0].ToString() + "'";

                MySqlDataReader Reader2 = Func2.SelectQuery(Query2);
                while (Reader2.Read())
                {
                    Received += Convert.ToDouble(Reader2[1].ToString());

                    DGVReports.Rows.Add(Reader[0].ToString(),
                                        Reader2[0].ToString(),
                                        Reader[2].ToString(),
                                        Reader[3].ToString(),
                                        string.Format("{0:#,###.##}", Convert.ToDecimal(Reader2[1].ToString())),
                                        Reader2[2].ToString(),
                                        "Amount Received",
                                        Reader[6].ToString(),
                                        Reader[7].ToString(),
                                        Reader[8].ToString());
                }
                Reader2.Close();
                Func2.Dest();
            }

            DGVReports.Rows.Add();
            
            DGVReports.Rows.Add("", "", "", "Total Amount", string.Format("{0:#,###.##}", Convert.ToDecimal(Math.Round(TotalAmount, 2))));
            DGVReports.Rows.Add("", "", "", "Amount Received", string.Format("{0:#,###.##}", Convert.ToDecimal(Math.Round(Received, 2))));
            DGVReports.Rows.Add("", "", "", "Amount Receivable", string.Format("{0:#,###.##}", Convert.ToDecimal(Math.Round((TotalAmount - Received), 2))));

            FormatDGV();

            Reader.Close();
            Func.Dest();
        }

        private void BtnGetInventory_Click(object sender, EventArgs e)
        {
            DGVReports.DataSource = null;
            DGVReports.Rows.Clear();
            MySqlFunctions Func = new MySqlFunctions();

            string Query = "SELECT DateTime as Date, Name, Quantity, Rate from inventoryhistory where Name like '%" + CBInventoryAddType.Text + "%' ";
            AppendQuery(ref Query, "datetime");

            if (CBInventoryOrderBy.Text == "Date")
                Query += " order by DateTime";
            else
                Query += " order by " + CBInventoryOrderBy.Text;

            Query += " " + (RBInventoryAsc.Checked ? " asc" : " desc");

            MySqlDataReader Reader = Func.SelectQuery(Query);
            DataTable dt = new DataTable();
            dt.Load(Reader);
            DGVReports.AutoGenerateColumns = true;
            DGVReports.DataSource = dt;

            FormatDGV();

            Func.Dest();
        }

        private void BtnGetVehicleCash_Click(object sender, EventArgs e)
        {
            double TotalAmount = 0;
            double Received = 0;

            DGVReports.DataSource = null;
            DGVReports.Rows.Clear();
            MySqlFunctions Func = new MySqlFunctions();

            string Query = "SELECT vehiclecash.id,vehiclecash.datetime as Date, companies.name as `Company Name`, vehiclecash.receivername as `Receiver Name`, vehiclecash.Amount as `Debit`,cashiers.Name as `Cashier Name`,count(vehiclecashreceived.vehiclecashid),vehiclecash.Amount-sum(vehiclecashreceived.amount) from vehiclecash inner join companies on companies.id = vehiclecash.companyid inner join cashiers on cashiers.id = vehiclecash.cashierid left join vehiclecashreceived on vehiclecashreceived.vehiclecashid = vehiclecash.id where companies.name like '%" + CBVehicleCashCompany.Text + "%' and vehiclecash.receivername like '%" + TBVehicleCashReceiver.Text + "%' ";
            AppendQuery(ref Query, "vehiclecash.datetime");

            Query += " group by vehiclecash.id";

            if (CBVehicleCashOrderBy.Text == "Slip No")
                Query += " order by vehiclecash.id";
            else if (CBVehicleCashOrderBy.Text == "Company Name")
                Query += " order by companies.name";
            else if (CBVehicleCashOrderBy.Text == "Receiver Name")
                Query += " order by vehiclecash.receivername";
            else if (CBVehicleCashOrderBy.Text == "Date")
                Query += " order by vehiclecash.DateTime";

            Query += " " + (RBVehicleCashAsc.Checked ? " asc" : " desc");

            DGVReports.Columns.Clear();
            DGVReports.Columns.Add("dgvc1", "Slip No");
            DGVReports.Columns.Add("dgvc1", "Date");
            DGVReports.Columns.Add("dgvc2", "Company Name");
            DGVReports.Columns.Add("dgvc2", "Receiver Name");
            DGVReports.Columns.Add("dgvc4", "Amount");
            DGVReports.Columns.Add("dgvc6", "Cashier Name");
            DGVReports.Columns.Add("dgvc7", "Remarks");

            MySqlDataReader Reader = Func.SelectQuery(Query);
            while (Reader.Read())
            {
                TotalAmount += Convert.ToDouble(Reader[4].ToString());

                DGVReports.Rows.Add(Reader[0].ToString(),
                                    Reader[1].ToString(),
                                    Reader[2].ToString(),
                                    Reader[3].ToString(),
                                    string.Format("{0:#,###.##}", Convert.ToDecimal(Reader[4].ToString())),
                                    Reader[5].ToString(),
                                    "Amount Receivable");
                if (Reader[6].ToString() == "0" || Math.Round(Convert.ToDouble(Reader[7].ToString()), 0) != 0)
                    DGVReports.Rows[DGVReports.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(233, 234, 242);

                MySqlFunctions Func2 = new MySqlFunctions();

                string Query2 = "SELECT datetime, Amount,cashiers.Name from vehiclecashreceived inner join cashiers on cashiers.id = vehiclecashreceived.cashierid where vehiclecashreceived.vehiclecashid='" + Reader[0].ToString() + "'";

                MySqlDataReader Reader2 = Func2.SelectQuery(Query2);
                while (Reader2.Read())
                {
                    Received += Convert.ToDouble(Reader2[1].ToString());

                    DGVReports.Rows.Add(Reader[0].ToString(),
                                        Reader2[0].ToString(),
                                        Reader[2].ToString(),
                                        Reader[3].ToString(),
                                        string.Format("{0:#,###.##}", Convert.ToDecimal(Reader2[1].ToString())),
                                        Reader2[2].ToString(),
                                        "Amount Received");
                }
                Reader2.Close();
                Func2.Dest();
            }

            DGVReports.Rows.Add();

            DGVReports.Rows.Add("", "", "", "Total Amount", string.Format("{0:#,###.##}", Convert.ToDecimal(Math.Round(TotalAmount, 2))));
            DGVReports.Rows.Add("", "", "", "Amount Received", string.Format("{0:#,###.##}", Convert.ToDecimal(Math.Round(Received, 2))));
            DGVReports.Rows.Add("", "", "", "Amount Receivable", string.Format("{0:#,###.##}", Convert.ToDecimal(Math.Round((TotalAmount - Received), 2))));

            FormatDGV();

            Reader.Close();
            Func.Dest();
        }

        private void BtnGetCredit_Click(object sender, EventArgs e)
        {
            double TotalAmount = 0;
            double Received = 0;

            DGVReports.DataSource = null;
            DGVReports.Rows.Clear();
            MySqlFunctions Func = new MySqlFunctions();

            string Query = "SELECT credit.id,credit.datetime as Date, companies.name as `Company Name`, vehicles.number as `Vehicle Number`, credit.Amount as `Debit`,cashiers.Name as `Cashier Name`, credit.Type, Liter, Rate,count(creditreceived.creditid),credit.Amount-sum(creditreceived.amount) from credit inner join companies on companies.id = credit.companyid inner join vehicles on vehicles.id=credit.vehicleid inner join cashiers on cashiers.id = credit.cashierid left join creditreceived on creditreceived.creditid = credit.id where companies.name like '%" + CBCreditCompany.Text + "%' and vehicles.number like '%" + CBCreditVehicle.Text + "%' and credit.Type like '%" + CBCreditType.Text + "%'";
            AppendQuery(ref Query, "credit.datetime");

            Query += " group by credit.id";

            if (CBCreditOrderBy.Text == "Slip No")
                Query += " order by credit.id";
            else if (CBCreditOrderBy.Text == "Company Name")
                Query += " order by companies.name";
            else if (CBCreditOrderBy.Text == "Vehicle Number")
                Query += " order by vehicles.number";
            else if (CBCreditOrderBy.Text == "Date")
                Query += " order by credit.DateTime";
            else
                Query += " order by credit." + CBCreditOrderBy.Text;

            Query += " " + (RBCreditAsc.Checked ? " asc" : " desc");

            DGVReports.Columns.Clear();
            DGVReports.Columns.Add("dgvc0", "Slip No");
            DGVReports.Columns.Add("dgvc1", "Date");
            DGVReports.Columns.Add("dgvc2", "Company Name");
            DGVReports.Columns.Add("dgvc3", "Vehicle Number");
            DGVReports.Columns.Add("dgvc4", "Amount");
            DGVReports.Columns.Add("dgvc6", "Cashier Name");
            DGVReports.Columns.Add("dgvc7", "Remarks");
            DGVReports.Columns.Add("dgvc8", "Type");
            DGVReports.Columns.Add("dgvc9", "Liter");
            DGVReports.Columns.Add("dgvc10", "Rate");

            MySqlDataReader Reader = Func.SelectQuery(Query);
            while (Reader.Read())
            {
                TotalAmount += Convert.ToDouble(Reader[4].ToString());

                DGVReports.Rows.Add(Reader[0].ToString(),
                                    Reader[1].ToString(),
                                    Reader[2].ToString(),
                                    Reader[3].ToString(),
                                    string.Format("{0:#,###.##}", Convert.ToDecimal(Reader[4].ToString())),
                                    Reader[5].ToString(),
                                    "Amount Receivable",
                                    Reader[6].ToString(),
                                    Reader[7].ToString(),
                                    Reader[8].ToString());
                if (Reader[9].ToString() == "0" || Math.Round(Convert.ToDouble(Reader[10].ToString()), 0) != 0)
                    DGVReports.Rows[DGVReports.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(233, 234, 242);

                MySqlFunctions Func2 = new MySqlFunctions();

                string Query2 = "SELECT datetime, Amount,cashiers.Name from creditreceived inner join cashiers on cashiers.id = creditreceived.cashierid where creditreceived.creditid='" + Reader[0].ToString() + "'";

                MySqlDataReader Reader2 = Func2.SelectQuery(Query2);
                while (Reader2.Read())
                {
                    Received += Convert.ToDouble(Reader2[1].ToString());

                    DGVReports.Rows.Add(Reader[0].ToString(),
                                        Reader2[0].ToString(),
                                        Reader[2].ToString(),
                                        Reader[3].ToString(),
                                        string.Format("{0:#,###.##}", Convert.ToDecimal(Reader2[1].ToString())),
                                        Reader2[2].ToString(),
                                        "Amount Received",
                                        Reader[6].ToString(),
                                        Reader[7].ToString(),
                                        Reader[8].ToString());
                }
                Reader2.Close();
                Func2.Dest();
            }

            DGVReports.Rows.Add();

            DGVReports.Rows.Add("", "", "", "Total Amount", string.Format("{0:#,###.##}", Convert.ToDecimal(Math.Round(TotalAmount, 2))));
            DGVReports.Rows.Add("", "", "", "Amount Received", string.Format("{0:#,###.##}", Convert.ToDecimal(Math.Round(Received, 2))));
            DGVReports.Rows.Add("", "", "", "Amount Receivable", string.Format("{0:#,###.##}", Convert.ToDecimal(Math.Round((TotalAmount - Received), 2))));

            FormatDGV();

            Reader.Close();
            Func.Dest();
        }

        private void BtnCashGet_Click(object sender, EventArgs e)
        {
            DGVReports.DataSource = null;
            DGVReports.Rows.Clear();
            MySqlFunctions Func = new MySqlFunctions();

            string Query = "SELECT cash.id as `Slip No`,DateTime as Date, cash.Name as `Driver Name`, VehicleNumber as `Vehicle Number`, Amount, cashiers.Name as `Cashier Name`, cash.Type, Liter, Rate FROM cash inner join cashiers on cashiers.id = cash.cashierid where cash.Name like '%" + TBCashName.Text + "%' and vehiclenumber like '%" + TBCashNumber.Text + "%' and cash.type like '%" + CBCashType.Text + "%' ";
            AppendQuery(ref Query, "datetime");

            if (CBCashOrderBy.Text == "Slip No")
                Query += " order by cash.id";
            else if (CBCashOrderBy.Text == "Vehicle Number")
                Query += " order by VehicleNumber";
            else if (CBCashOrderBy.Text == "Date")
                Query += " order by DateTime";
            else
                Query += " order by cash." + CBCashOrderBy.Text;

            Query += " " + (RBCashAsc.Checked ? " asc" : " desc");

            MySqlDataReader Reader = Func.SelectQuery(Query);
            DataTable dt = new DataTable();
            dt.Load(Reader);
            DGVReports.AutoGenerateColumns = true;
            DGVReports.DataSource = dt;

            FormatDGV();

            Func.Dest();
        }

        private void BtnGetCreditVehicleCash_Click(object sender, EventArgs e)
        {
            double TotalAmount = 0;
            double Received = 0;

            DGVReports.DataSource = null;
            DGVReports.Rows.Clear();
            MySqlFunctions Func = new MySqlFunctions();

            string Query = "select * from ( Select credit.ID ,  credit.DateTime  as Date, 'Credit' as `Sale Type`, companies.name as `Company Name`,  vehicles.number as `Vehicle Number`,  credit.Amount as `Debit`, cashiers.Name as `Cashier Name`,  credit.Type,  Liter,  Rate, count(creditreceived.creditid),  credit.Amount-sum(creditreceived.amount)  from credit inner join companies on companies.id = credit.companyid inner join vehicles on vehicles.id=credit.vehicleid inner join  cashiers on cashiers.id = credit.cashierid left join creditreceived on creditreceived.creditid = credit.id where companies.name like '%" + CBCreditVehicleCashName.Text + "%'  group by credit.id union all Select  vehiclecash.ID , vehiclecash.DateTime as Date,'V. Cash' as `Sale Type`, companies.name as `Company Name`, vehiclecash.receivername as `Receiver Name`, vehiclecash.Amount as `Debit`, cashiers.Name as `Cashier Name`, '-' as Type,  '-' as Liter,  '-' as Rate, count(vehiclecashreceived.vehiclecashid), vehiclecash.Amount-sum(vehiclecashreceived.amount) from vehiclecash inner join companies on companies.id = vehiclecash.companyid inner join cashiers on cashiers.id = vehiclecash.cashierid left join vehiclecashreceived on vehiclecashreceived.vehiclecashid = vehiclecash.id where companies.name like '%" + CBCreditVehicleCashName.Text + "%' group by vehiclecash.id) as temp ";
            AppendQuery(ref Query, "Date");

            if (CBCreditVehicleCashOrder.Text == "Slip No")
                Query += " order by ID";
            else
                Query += " order by `" + CBCreditVehicleCashOrder.Text + "`";

            Query += " " + (RBCreditVehicleCashAsc.Checked ? " asc" : " desc");

            DGVReports.Columns.Clear();
            DGVReports.Columns.Add("dgvc0", "Slip No");
            DGVReports.Columns.Add("dgvc1", "Date");
            DGVReports.Columns.Add("dgvc2", "Sale Type");
            DGVReports.Columns.Add("dgvc3", "Company Name");
            DGVReports.Columns.Add("dgvc4", "V. No / Rec. Name");
            DGVReports.Columns.Add("dgvc5", "Amount");
            DGVReports.Columns.Add("dgvc7", "Cashier Name");
            DGVReports.Columns.Add("dgvc8", "Remarks");
            DGVReports.Columns.Add("dgvc9", "Fuel Type");
            DGVReports.Columns.Add("dgvc10", "Liter");
            DGVReports.Columns.Add("dgvc11", "Rate");

            MySqlDataReader Reader = Func.SelectQuery(Query);
            while (Reader.Read())
            {
                TotalAmount += Convert.ToDouble(Reader[5].ToString());

                DGVReports.Rows.Add(Reader[0].ToString(),
                                    Reader[1].ToString(),
                                    Reader[2].ToString(),
                                    Reader[3].ToString(),
                                    Reader[4].ToString(),
                                    string.Format("{0:#,###.##}", Convert.ToDecimal(Reader[5].ToString())),
                                    Reader[6].ToString(),
                                    "Amount Receivable",
                                    Reader[7].ToString(),
                                    Reader[8].ToString(),
                                    Reader[9].ToString());
                if (Reader[10].ToString() == "0" || Math.Round(Convert.ToDouble(Reader[11].ToString()), 0) != 0)
                    DGVReports.Rows[DGVReports.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(233, 234, 242);

                MySqlFunctions Func2 = new MySqlFunctions();

                string Query2 = ""; ;
                if (Reader[2].ToString() == "Credit")
                {
                    Query2 = "SELECT datetime, Amount,cashiers.Name from creditreceived inner join cashiers on cashiers.id = creditreceived.cashierid where creditreceived.creditid='" + Reader[0].ToString() + "'";
                }
                else
                {
                    Query2 = "SELECT datetime, Amount,cashiers.Name from vehiclecashreceived inner join cashiers on cashiers.id = vehiclecashreceived.cashierid where vehiclecashreceived.vehiclecashid='" + Reader[0].ToString() + "'";
                }

                MySqlDataReader Reader2 = Func2.SelectQuery(Query2);
                while (Reader2.Read())
                {
                    Received += Convert.ToDouble(Reader2[1].ToString());

                    DGVReports.Rows.Add(Reader[0].ToString(),
                                        Reader2[0].ToString(),
                                        Reader[2].ToString(),
                                        Reader[3].ToString(),
                                        Reader[4].ToString(),
                                        string.Format("{0:#,###.##}", Convert.ToDecimal(Reader2[1].ToString())),
                                        Reader2[2].ToString(),
                                        "Amount Received",
                                        Reader[7].ToString(),
                                        Reader[8].ToString(),
                                        Reader[9].ToString());
                }
                Reader2.Close();
                Func2.Dest();
            }

            DGVReports.Rows.Add();

            DGVReports.Rows.Add("", "", "", "", "Total Amount", string.Format("{0:#,###.##}", Convert.ToDecimal(Math.Round(TotalAmount, 2))));
            DGVReports.Rows.Add("", "", "", "", "Amount Received", string.Format("{0:#,###.##}", Convert.ToDecimal(Math.Round(Received, 2))));
            DGVReports.Rows.Add("", "", "", "", "Amount Receivable", string.Format("{0:#,###.##}", Convert.ToDecimal(Math.Round((TotalAmount - Received), 2))));

            FormatDGV();

            Reader.Close();
            Func.Dest();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            PanelCash.Visible = true;
            PanelCredit.Visible = false;
            PanelCreditVehicleCash.Visible = false;
            PanelInventoryAdded.Visible = false;
            PanelLineCredit.Visible = false;
            PanelVehicleCash.Visible = false;

            //inventory
            
            
            foreach (string Item in Inventory.Name)
            {
                CBCashType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBCashType.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBCashType.Items.Add(Item);
                CBCreditType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBCreditType.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBCreditType.Items.Add(Item);
                CBLineCreditType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBLineCreditType.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBLineCreditType.Items.Add(Item);
                CBInventoryAddType.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBInventoryAddType.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBInventoryAddType.Items.Add(Item);
            }

            if (CBCashType.Items.Count > 0)
                CBCashType.SelectedIndex = 0;

            if (CBCreditType.Items.Count > 0)
                CBCreditType.SelectedIndex = 0;

            if (CBLineCreditType.Items.Count > 0)
                CBLineCreditType.SelectedIndex = 0;

            if (CBInventoryAddType.Items.Count > 0)
                CBInventoryAddType.SelectedIndex = 0;

            //company
            foreach (string Name in Company.Name)
            {
                CBCreditCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBCreditCompany.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBCreditCompany.Items.Add(Name);
                CBVehicleCashCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBVehicleCashCompany.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBVehicleCashCompany.Items.Add(Name);
                CBCreditVehicleCashName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBCreditVehicleCashName.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBCreditVehicleCashName.Items.Add(Name);
            }

            if (CBCreditCompany.Items.Count > 0)
                CBCreditCompany.SelectedIndex = 0;

            if (CBVehicleCashCompany.Items.Count > 0)
                CBVehicleCashCompany.SelectedIndex = 0;

            if (CBCreditVehicleCashName.Items.Count > 0)
                CBCreditVehicleCashName.SelectedIndex = 0;

            //line customer
            foreach (string Name in LineCustomer.Number)
            {
                CBLineCreditVehicle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBLineCreditVehicle.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBLineCreditVehicle.Items.Add(Name);
            }
            if (CBLineCreditVehicle.Items.Count > 0)
                CBLineCreditVehicle.SelectedIndex = 0;

            //order by
            if (CBCashOrderBy.Items.Count > 0)
                CBCashOrderBy.SelectedIndex = 0;

            if (CBCreditOrderBy.Items.Count > 0)
                CBCreditOrderBy.SelectedIndex = 0;

            if (CBLineCreditOrderBy.Items.Count > 0)
                CBLineCreditOrderBy.SelectedIndex = 0;

            if (CBInventoryOrderBy.Items.Count > 0)
                CBInventoryOrderBy.SelectedIndex = 0;

            if (CBVehicleCashOrderBy.Items.Count > 0)
                CBVehicleCashOrderBy.SelectedIndex = 0;

            if (CBCreditVehicleCashOrder.Items.Count > 0)
                CBCreditVehicleCashOrder.SelectedIndex = 0;

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            ClickedItem = 0;
        }

        private void CBDateMenu_CheckedChanged(object sender, EventArgs e)
        {
            PanelDate.Visible = CBDateMenu.Checked;
        }

        private void cashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelCash.Visible = true;
            PanelCredit.Visible = false;
            PanelCreditVehicleCash.Visible = false;
            PanelInventoryAdded.Visible = false;
            PanelLineCredit.Visible = false;
            PanelVehicleCash.Visible = false;

            ClickedItem = 0;
            PanelCash.BringToFront();
            button1.BringToFront();
        }

        private void creditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelCash.Visible = false;
            PanelCredit.Visible = true;
            PanelCreditVehicleCash.Visible = false;
            PanelInventoryAdded.Visible = false;
            PanelLineCredit.Visible = false;
            PanelVehicleCash.Visible = false;

            ClickedItem = 1;
            PanelCredit.BringToFront();
            button1.BringToFront();
        }

        private void lineCreditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelCash.Visible = false;
            PanelCredit.Visible = false;
            PanelCreditVehicleCash.Visible = false;
            PanelInventoryAdded.Visible = false;
            PanelLineCredit.Visible = true;
            PanelVehicleCash.Visible = false;

            ClickedItem = 2;
            PanelLineCredit.BringToFront();
            button1.BringToFront();
        }

        private void vehicleCashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelCash.Visible = false;
            PanelCredit.Visible = false;
            PanelCreditVehicleCash.Visible = false;
            PanelInventoryAdded.Visible = false;
            PanelLineCredit.Visible = false;
            PanelVehicleCash.Visible = true;

            ClickedItem = 3;
            PanelVehicleCash.BringToFront();
            button1.BringToFront();
        }

        private void inventoryAddedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelCash.Visible = false;
            PanelCredit.Visible = false;
            PanelCreditVehicleCash.Visible = false;
            PanelInventoryAdded.Visible = true;
            PanelLineCredit.Visible = false;
            PanelVehicleCash.Visible = false;

            ClickedItem = 4;
            PanelInventoryAdded.BringToFront();
            button1.BringToFront();
        }

        private void CreditVehicleCashToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PanelCash.Visible = false;
            PanelCredit.Visible = false;
            PanelCreditVehicleCash.Visible = true;
            PanelInventoryAdded.Visible = false;
            PanelLineCredit.Visible = false;
            PanelVehicleCash.Visible = false;

            ClickedItem = 5;
            PanelCreditVehicleCash.BringToFront();
            button1.BringToFront();
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            DGVVisibleColumns.Rows.Clear();
            DGVReports.DataSource = null;
            DGVReports.Columns.Clear();
            DGVReports.Rows.Clear();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DGVReports.Columns.Count == 0)
                return;

            string ReportType = "";
            DateTime GenerationTime = DateTime.Now;

            int[] Columns = null;
            if (ClickedItem == 0)
            {
                ReportType = "Cash Report";
                Columns = new int[] { 0, 1, 3, 4, 5, 6, 7, 8 };
            }
            else if (ClickedItem == 1)
            {
                ReportType = "Credit Report";
                Columns = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            }
            else if (ClickedItem == 2)
            {
                ReportType = "Line Credit Report";
                Columns = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            }
            else if (ClickedItem == 3)
            {
                ReportType = "Vehicle Cash Report";
                Columns = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            }
            else if (ClickedItem == 4)
            {
                ReportType = "Inventory Added Report";
                Columns = new int[] { 0, 1, 2, 3 };
            }
            else if (ClickedItem == 5)
            {
                ReportType = "Credit and Vehicle Cash Report";
                Columns = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            }

            FileInfo newFile = new FileInfo(ReportType + " - " + GenerationTime.ToString("dddd, MMMM dd, yyyy - hh;mm;ss tt") + ".xlsx");
            if (newFile.Exists)
            {
                newFile.Delete();  // ensures we create a new workbook
                newFile = new FileInfo(ReportType + " - " + GenerationTime.ToString("dddd, MMMM dd, yyyy - hh;mm;ss tt") + ".xlsx");
            }
            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                int Row = 5;

                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = null;
                //Add the headers

                worksheet = package.Workbook.Worksheets.Add(ReportType);
                worksheet.Cells[Row, 1].Value = ReportType;

                worksheet.Cells[Row, 1, Row, Columns.Length].Merge = true;
                worksheet.Cells[Row, 1].Style.Font.Size = 26;
                worksheet.Cells[Row, 1].Style.Font.UnderLine = true;
                worksheet.Cells[Row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                //if (ClickedItem == 0)
                //{
                //    worksheet.Cells[Row + 1, 1].Value = "Driver Name: " + TBCashName.Text;
                //    worksheet.Cells[Row + 2, 1].Value = "Vehicle Number: " + TBCashNumber.Text;
                //    worksheet.Cells[Row + 3, 1].Value = "Fuel Type: " + TBCashType.Text;
                //    worksheet.Cells[Row + 1, 1, Row + 1, Columns.Length].Merge = true;
                //    worksheet.Cells[Row + 2, 1, Row + 2, Columns.Length].Merge = true;
                //    worksheet.Cells[Row + 3, 1, Row + 3, Columns.Length].Merge = true;
                //    worksheet.Cells[Row, 1, Row + 3, 1].Style.Font.Size = 16;

                //    worksheet.Row(Row + 1).Height = 25;
                //    worksheet.Row(Row + 1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //    worksheet.Row(Row + 2).Height = 25;
                //    worksheet.Row(Row + 2).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //    worksheet.Row(Row + 3).Height = 25;
                //    worksheet.Row(Row + 3).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //    Row += 3;
                //}

                //else if (ClickedItem == 1)
                //{
                //    worksheet.Cells[Row + 1, 1].Value = "Company Name: " + TBCreditCompany.Text;
                //    worksheet.Cells[Row + 2, 1].Value = "Vehicle Number: " + TBCreditVehicle.Text;
                //    worksheet.Cells[Row + 3, 1].Value = "Fuel Type: " + TBCashType.Text;
                //    worksheet.Cells[Row + 1, 1, Row + 1, Columns.Length].Merge = true;
                //    worksheet.Cells[Row + 2, 1, Row + 2, Columns.Length].Merge = true;
                //    worksheet.Cells[Row + 3, 1, Row + 3, Columns.Length].Merge = true;
                //    worksheet.Cells[Row, 1, Row + 3, 1].Style.Font.Size = 16;

                //    worksheet.Row(Row + 1).Height = 25;
                //    worksheet.Row(Row + 1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //    worksheet.Row(Row + 2).Height = 25;
                //    worksheet.Row(Row + 2).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //    worksheet.Row(Row + 3).Height = 25;
                //    worksheet.Row(Row + 3).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //    Row += 3;
                //}

                //else if (ClickedItem == 2)
                //{
                //    worksheet.Cells[Row + 1, 1].Value = "Customer Name: " + TBLineCreditCustomer.Text;
                //    worksheet.Cells[Row + 2, 1].Value = "Vehicle Number: " + TBLineCreditVehicle.Text;
                //    worksheet.Cells[Row + 3, 1].Value = "Fuel Type: " + TBCashType.Text;
                //    worksheet.Cells[Row + 1, 1, Row + 1, Columns.Length].Merge = true;
                //    worksheet.Cells[Row + 2, 1, Row + 2, Columns.Length].Merge = true;
                //    worksheet.Cells[Row + 3, 1, Row + 3, Columns.Length].Merge = true;
                //    worksheet.Cells[Row, 1, Row + 3, 1].Style.Font.Size = 16;

                //    worksheet.Row(Row + 1).Height = 25;
                //    worksheet.Row(Row + 1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //    worksheet.Row(Row + 2).Height = 25;
                //    worksheet.Row(Row + 2).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //    worksheet.Row(Row + 3).Height = 25;
                //    worksheet.Row(Row + 3).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //    Row += 3;
                //}

                //else if (ClickedItem == 3)
                //{
                //    worksheet.Cells[Row + 1, 1].Value = "Company Name: " + TBVehicleCashCompany.Text;
                //    worksheet.Cells[Row + 2, 1].Value = "Receiver Name: " + TBVehicleCashReceiver.Text;
                //    worksheet.Cells[Row + 1, 1, Row + 1, Columns.Length].Merge = true;
                //    worksheet.Cells[Row + 2, 1, Row + 2, Columns.Length].Merge = true;
                //    worksheet.Cells[Row, 1, Row + 2, 1].Style.Font.Size = 16;

                //    worksheet.Row(Row + 1).Height = 25;
                //    worksheet.Row(Row + 1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //    worksheet.Row(Row + 2).Height = 25;
                //    worksheet.Row(Row + 2).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //    Row += 2;
                //}

                //else if (ClickedItem == 4)
                //{
                //    worksheet.Cells[Row + 1, 1].Value = "Fuel Type: " + TBInventoryAddType.Text;
                //    worksheet.Cells[Row + 1, 1, Row + 1, Columns.Length].Merge = true;
                //    worksheet.Cells[Row, 1, Row + 1, 1].Style.Font.Size = 16;

                //    worksheet.Row(Row + 1).Height = 25;
                //    worksheet.Row(Row + 1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //    Row += 1;
                //}

                //else if (ClickedItem == 5)
                //{
                //    worksheet.Cells[Row + 1, 1].Value = "Company Name: " + TBCreditCompany.Text;
                //    worksheet.Cells[Row + 1, 1, Row + 1, Columns.Length].Merge = true;
                //    worksheet.Cells[Row, 1, Row + 1, 1].Style.Font.Size = 16;

                //    worksheet.Row(Row + 1).Height = 25;
                //    worksheet.Row(Row + 1).Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                //    Row += 1;
                //}

                //Logo Title
                var MainLogo = worksheet.Drawings.AddPicture("Main Logo", new Bitmap(Properties.Resources.Main_Logo, 60, 60));
                MainLogo.SetPosition(0, 0, 0, 0);

                double ShellLogoWidthDouble = (double)Properties.Resources.Shell_Logo.Width / Properties.Resources.Shell_Logo.Height;
                ShellLogoWidthDouble = ShellLogoWidthDouble * 60;
                int ShellLogoWidth = Convert.ToInt32(ShellLogoWidthDouble);
                var ShellLogo = worksheet.Drawings.AddPicture("Shell Logo", new Bitmap(PetrolPump.Properties.Resources.Shell_Logo, ShellLogoWidth, 60));
                ShellLogo.SetPosition(0, 0, Columns.Length, Convert.ToInt32(worksheet.Column(Columns.Length).Width) - 60);

                worksheet.Cells[1, 1].Value = "SITARA HILAL";
                worksheet.Cells[1, 1].Style.Font.Size = 18;
                worksheet.Row(1).Height = 23;
                worksheet.Cells[1, 1, 1, Columns.Length].Merge = true;
                worksheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[2, 1].Value = "PETROLEUM SERVICES";
                worksheet.Cells[2, 1].Style.Font.Size = 18;
                worksheet.Row(2).Height = 23;
                worksheet.Cells[2, 1, 2, Columns.Length].Merge = true;
                worksheet.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[3, 1].Value = "144 KM SUPER HIGHWAY HYDERABAD - CELL: 0300-3240440, 0345-1404440";
                worksheet.Cells[3, 1].Style.Font.Size = 10;
               // worksheet.Cells[3, 1, 3, Columns.Length].Merge = true;
                //worksheet.Row(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                //worksheet.Row(3).Style.VerticalAlignment = ExcelVerticalAlignment.Bottom;
                //worksheet.Row(3).Height = 20;

                Row += 2;

                if (RBAll.Checked)
                    worksheet.Cells[Row, 1].Value = "Billing Period: All Records";

                if (RBDate.Checked)
                    worksheet.Cells[Row, 1].Value = "Billing Period: Specific Duration";

                if (RBToday.Checked)
                    worksheet.Cells[Row, 1].Value = "Billing Period: Today";

                if (RBLast7.Checked)
                    worksheet.Cells[Row, 1].Value = "Billing Period: Last 7 Days";

                if (RBLast15.Checked)
                    worksheet.Cells[Row, 1].Value = "Billing Period: Last 15 Days";

                if (RBLast30.Checked)
                    worksheet.Cells[Row, 1].Value = "Billing Period: Last 30 Days";

                worksheet.Cells[Row, 1, Row, Columns.Length].Merge = true;
                worksheet.Cells[Row, 1, Row, 1].Style.Font.Size = 14;

                Row++;

                bool DateRowAdded = false;

                if (RBToday.Checked)
                {
                    worksheet.Cells[Row, 1].Value = "Date: " + DateTime.Now.ToString("dd-MM-yyyy");
                    DateRowAdded = true;
                }
                else if (RBLast7.Checked)
                {
                    worksheet.Cells[Row, 1].Value = "From " + DateTime.Now.AddDays(-6).ToString("dd-MM-yyyy") + " To " + DateTime.Now.ToString("dd-MM-yyyy");
                    DateRowAdded = true;
                }
                else if (RBLast15.Checked)
                {
                    worksheet.Cells[Row, 1].Value = "From " + DateTime.Now.AddDays(-14).ToString("dd-MM-yyyy") + " To " + DateTime.Now.ToString("dd-MM-yyyy");
                    DateRowAdded = true;
                }
                else if (RBLast30.Checked)
                {
                    worksheet.Cells[Row, 1].Value = "From " + DateTime.Now.AddDays(-29).ToString("dd-MM-yyyy") + " To " + DateTime.Now.ToString("dd-MM-yyyy");
                    DateRowAdded = true;
                }

                else if (RBDate.Checked)
                {
                    if (CBTo.Checked)
                        worksheet.Cells[Row, 1].Value = "From " + DPFrom.Value.ToString("dd-MM-yyyy") + " To " + DPTo.Value.ToString("dd-MM-yyyy");
                    else
                        worksheet.Cells[Row, 1].Value = "From " + DPFrom.Value.ToString("dd-MM-yyyy") + " To " + DateTime.Now.ToString("dd-MM-yyyy");
                    DateRowAdded = true;
                }

                if (DateRowAdded)
                {
                    worksheet.Cells[Row, 1, Row, Columns.Length].Merge = true;
                    worksheet.Cells[Row, 1, Row, 1].Style.Font.Size = 14;

                    Row++;
                }
                else
                    worksheet.Row(Row).Height = 10;

                Row++;

                int MainRow = Row;

                int CurrentExcelColumn = 1;
                foreach (int c in Columns)
                {
                    if (DGVReports.Columns[c].HeaderText == "Slip No")
                        worksheet.Cells[Row, CurrentExcelColumn].Value = "No";

                    else if (DGVReports.Columns[c].HeaderText == "Vehicle Number")
                        worksheet.Cells[Row, CurrentExcelColumn].Value = "V. No";

                    else if (DGVReports.Columns[c].HeaderText == "Cashier Name")
                        worksheet.Cells[Row, CurrentExcelColumn].Value = "Cashier";

                    else if (DGVReports.Columns[c].HeaderText == "Company Name")
                        worksheet.Cells[Row, CurrentExcelColumn].Value = "Company";

                    else if (DGVReports.Columns[c].HeaderText == "Customer Name")
                        worksheet.Cells[Row, CurrentExcelColumn].Value = "Customer";

                    else if (DGVReports.Columns[c].HeaderText == "Receiver Name")
                        worksheet.Cells[Row, CurrentExcelColumn].Value = "Receiver";

                    else if (DGVReports.Columns[c].HeaderText == "Sale Type")
                        worksheet.Cells[Row, CurrentExcelColumn].Value = "Type";

                    else if (DGVReports.Columns[c].HeaderText == "V. No / Rec. Name")
                        worksheet.Cells[Row, CurrentExcelColumn].Value = "V. No / Name";

                    else
                        worksheet.Cells[Row, CurrentExcelColumn].Value = DGVReports.Columns[c].HeaderText;

                    worksheet.Cells[Row, CurrentExcelColumn].Style.Font.Bold = true;
                    worksheet.Cells[Row, CurrentExcelColumn].Style.Font.Size = 14;
                    worksheet.Cells[Row, CurrentExcelColumn].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    CurrentExcelColumn++;
                }

                worksheet.Row(Row).Height = 25;
                worksheet.Row(Row).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                Row += 1;

                int RowCount = DGVReports.Rows.Count;
                if (ClickedItem != 0 && ClickedItem != 4)
                    RowCount -= 4;

                for (int r = 0; r < RowCount; r++)
                {
                    CurrentExcelColumn = 1;
                    foreach (int c in Columns)
                    {
                        if (ClickedItem != 4 && c == 1)
                            worksheet.Cells[Row, CurrentExcelColumn].Value = Convert.ToDateTime(DGVReports.Rows[r].Cells[c].Value).ToString("dd-MM-yyyy");

                        else
                            worksheet.Cells[Row, CurrentExcelColumn].Value = DGVReports.Rows[r].Cells[c].Value.ToString().Replace("Amount ", "");

                        worksheet.Cells[Row, CurrentExcelColumn].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        CurrentExcelColumn++;
                    }

                    worksheet.Row(Row).Height = 23;
                    if (DGVReports.Rows[r].DefaultCellStyle.BackColor == Color.FromArgb(233, 234, 242))
                    {
                        worksheet.Cells[Row, 1, Row, Columns.Length].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        worksheet.Cells[Row, 1, Row, Columns.Length].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(233, 234, 242));
                    }
                    Row++;
                }

                if (ClickedItem != 0 && ClickedItem != 4)
                {
                    Row++;
                    int Cell = 3;
                    if (ClickedItem == 5)
                        Cell = 4;

                    worksheet.Cells[Row, Cell].Value = "Total Amount";
                    worksheet.Cells[Row + 1, Cell].Value = "Amount Received";
                    worksheet.Cells[Row + 2, Cell].Value = "Amount Receivable";
                    worksheet.Cells[Row, Cell + 1].Value = DGVReports.Rows[DGVReports.Rows.Count - 3].Cells[Cell + 1].Value.ToString();
                    worksheet.Cells[Row + 1, Cell + 1].Value = DGVReports.Rows[DGVReports.Rows.Count - 2].Cells[Cell + 1].Value.ToString();
                    worksheet.Cells[Row + 2, Cell + 1].Value = DGVReports.Rows[DGVReports.Rows.Count - 1].Cells[Cell + 1].Value.ToString();

                    worksheet.Cells[Row, Cell, Row + 2, Cell + 1].Style.Border.BorderAround(ExcelBorderStyle.Thick);
                    worksheet.Cells[Row, Cell, Row + 2, Cell].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[Row, Cell, Row, Cell + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[Row + 1, Cell, Row + 1, Cell + 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                    worksheet.Row(Row).Height = 23;
                    worksheet.Row(Row + 1).Height = 23;
                    worksheet.Row(Row + 2).Height = 23;

                    Row += 2;
                }

                worksheet.Cells[MainRow + 1, 1, Row, Columns.Length].Style.Font.Size = 12;
                worksheet.Cells[MainRow, 1, Row, Columns.Length].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells.AutoFitColumns(1, 20);

                if (ClickedItem == 4)
                    worksheet.Column(1).Width = 25;

                // add the page number to the footer plus the total number of pages
                worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page " + ExcelHeaderFooter.PageNumber + " of " + ExcelHeaderFooter.NumberOfPages);

                worksheet.HeaderFooter.OddFooter.LeftAlignedText = "Generated on " + GenerationTime.ToLongDateString() + " " + GenerationTime.ToLongTimeString();
                // add the sheet name to the footer
                //worksheet.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                worksheet.PrinterSettings.LeftMargin = (decimal).2 / 2.54M;
                worksheet.PrinterSettings.RightMargin = (decimal).2 / 2.54M;
                worksheet.PrinterSettings.PaperSize = ePaperSize.A4;

                package.Save();
                System.Diagnostics.Process.Start(ReportType + " - " + GenerationTime.ToString("dddd, MMMM dd, yyyy - hh;mm;ss tt") + ".xlsx");
            }
            //Application.Exit();
        }

        private void PDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics PGraphics = e.Graphics;

            Pen DashedPen = new Pen(Color.Black);
            DashedPen.DashStyle = DashStyle.Dash;
            DashedPen.DashPattern = new float[] { 3, 3 };

            FontFamily FontName = this.Font.FontFamily;

            int MaxX = 300;
            int Y = 0;
            int Offset = 0;
            int X = 0;
            int Logo = 60;

            PGraphics.DrawImage(new Bitmap(PetrolPump.Properties.Resources.Main_Logo, Logo, Logo), new Point(X, Y));
            double ShellLogoWidthDouble = (double)PetrolPump.Properties.Resources.Shell_Logo.Width / PetrolPump.Properties.Resources.Shell_Logo.Height;
            ShellLogoWidthDouble = ShellLogoWidthDouble * Logo;
            int ShellLogoWidth = Convert.ToInt32(ShellLogoWidthDouble);
            PGraphics.DrawImage(new Bitmap(PetrolPump.Properties.Resources.Shell_Logo, ShellLogoWidth, Logo), new Point(MaxX - ShellLogoWidth, Y));
            //Offset += Logo+10;
            Offset += 5;
            PGraphics.DrawString("SITARA HILAL", new Font(FontName, 18), new SolidBrush(Color.Black), new PointF(X + 10 + ((MaxX - PGraphics.MeasureString("SITARA HILAL", new Font(FontName, 18)).Width) / 2), Y + Offset));
            Offset += 30;
            PGraphics.DrawString("PETROLEUM SERVICE", new Font(FontName, 11, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(X + 10 + ((MaxX - PGraphics.MeasureString("PETROLEUM SERVICE", new Font(FontName, 11, FontStyle.Bold)).Width) / 2), Y + Offset));
            Offset += 40;
            PGraphics.DrawString("144 KM SUPER HIGHWAY HYDERABAD", new Font(FontName, 10), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("144 KM SUPER HIGHWAY HYDERABAD", new Font(FontName, 10)).Width) / 2), Y + Offset));
            Offset += 20;
            PGraphics.DrawString("CELL: 0300-3240440, 0345-1404440", new Font(FontName, 10), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("CELL: 0300-3240440, 0345-1404440", new Font(FontName, 10)).Width) / 2), Y + Offset));
            Offset += 25;
            PGraphics.FillRectangle(new SolidBrush(Color.Black), X, Y + Offset, MaxX, 3);
            Offset += 15;
            PGraphics.DrawString("LINE CREDIT RECEIPT", new Font(FontName, 14), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("LINE CREDIT RECEIPT", new Font(FontName, 14)).Width) / 2), Y + Offset));
            Offset += 30;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            Offset += 10;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DGVVisibleColumns.Visible = checkBox1.Checked;
        }

        private void CBCreditCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBCreditVehicle.Items.Clear();
            foreach (string Number in Company.Vehicles[CBCreditCompany.SelectedIndex].Number)
            {
                CBCreditVehicle.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBCreditVehicle.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBCreditVehicle.Items.Add(Number);
            }


            if (CBCreditVehicle.Items.Count > 0)
                CBCreditVehicle.SelectedIndex = 0;
        }

        private void CBCreditVehicle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}