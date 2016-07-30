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
    public partial class CombinedReport : Form
    {
        public CombinedReport()
        {
            InitializeComponent();
        }

        private void CombinedReport_Load(object sender, EventArgs e)
        {
            DPFrom.Value = DateTime.Today.AddDays(-1);
            DPTo.Value = DateTime.Today;
            DPTo.MaxDate = DateTime.Today;
            DPFrom.MaxDate = DPTo.Value;
            //BtnAdd_Click(sender, e);
            //Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string DateClause= " date(datetime) between '" + DPFrom.Value.ToString("yyyy-MM-dd") + "' and '" + DPTo.Value.ToString("yyyy-MM-dd") + "' ";
            string ReportType = "All";
            if (RBCash.Checked)
                ReportType = "Cash";
            else if (RBBank.Checked)
                ReportType = "Bank";

            FileInfo newFile = new FileInfo("Combined Report - " + DPFrom.Value.ToString("dd MMM yyyy") + " to " + DPTo.Value.ToString("dd MMM yyyy") + " (" + ReportType + ").xlsx");
            //if (newFile.Exists)
            int FileNum = 0;
            while (newFile.Exists)
            {
                try
                {
                    newFile.Delete();
                    if (FileNum==0)
                        newFile = new FileInfo("Combined Report - " + DPFrom.Value.ToString("dd MMM yyyy") + " to " + DPTo.Value.ToString("dd MMM yyyy") + " (" + ReportType + ").xlsx");
                    else
                        newFile = new FileInfo("Combined Report - " + DPFrom.Value.ToString("dd MMM yyyy") + " to " + DPTo.Value.ToString("dd MMM yyyy") + " (" + ReportType + ") (" + FileNum + ").xlsx"); 
                }
                catch (Exception)
                {
                    FileNum++;
                    newFile = new FileInfo("Combined Report - " + DPFrom.Value.ToString("dd MMM yyyy") + " to " + DPTo.Value.ToString("dd MMM yyyy") + " (" + ReportType + ") (" + FileNum + ").xlsx"); 
                }
            }
            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = null;
                worksheet = package.Workbook.Worksheets.Add("Combined Report");

                int Row = 2;

                worksheet.Cells[Row, 2].Value = "Sitara Hilal Petroleum Service";
                worksheet.Cells[Row, 2, Row, 10].Merge = true;
                worksheet.Cells[Row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[Row, 2].Style.Font.Size = 22;
                worksheet.Cells[Row, 2].Style.Font.Bold = true;

                Row++;

                worksheet.Cells[Row, 2].Value = "144 KM SUPER HIGHWAY HYDERABAD - CELL: 0300-3240440, 0345-1404440";
                worksheet.Cells[Row, 2, Row, 10].Merge = true;
                worksheet.Cells[Row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                Row += 3;

                MySqlFunctions Func = new MySqlFunctions();
                MySqlFunctions Func2 = new MySqlFunctions();
                MySqlFunctions Func3 = new MySqlFunctions();

                worksheet.Cells[Row, 2].Value = "Inventory Report";
                worksheet.Cells[Row, 2, Row, 10].Merge = true;
                worksheet.Cells[Row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[Row, 2].Style.Font.Size = 14;
                worksheet.Cells[Row, 2].Style.Font.Bold = true;

                Row += 2;

                worksheet.Cells[Row, 2].Value = "Dates";
                worksheet.Cells[Row, 3].Value = DPFrom.Value.ToString("dd MMM yyyy");
                worksheet.Cells[Row, 3, Row, 4].Merge = true;
                worksheet.Cells[Row, 5].Value = DPTo.Value.ToString("dd MMM yyyy");
                worksheet.Cells[Row, 5, Row, 6].Merge = true;

                Row += 2;
                int TableStart = Row;

                worksheet.Cells[Row, 3].Value = "Opening";
                worksheet.Cells[Row, 4].Value = "Purchase";
                worksheet.Cells[Row, 5].Value = "T. Stock";
                worksheet.Cells[Row, 6].Value = "Sales";
                worksheet.Cells[Row, 7].Value = "Closing";
                worksheet.Cells[Row, 7, Row, 8].Merge = true;
                worksheet.Cells[Row, 9].Value = "Rates";
                worksheet.Cells[Row, 10].Value = "Total Amount";
                worksheet.Cells[Row, 3, Row, 10].Style.Font.Bold = true;

                Row++;

                MySqlDataReader InventorySale = Func.SelectQuery("select Name, sum(Quantity) as Quantity from (select type as Name, sum(Liter) as Quantity from credit where " + DateClause + " group by type union all select type as Name, sum(Liter) as Quantity from linecredit where " + DateClause + " group by type union all select type as Name, sum(Liter) as Quantity from cash where " + DateClause + " group by type) as temp group by Name order by Name");
                MySqlDataReader InventoryClosing = Func2.SelectQuery("select name,rate,sum(quantity) from inventory group by name order by Name");
                MySqlDataReader InventoryPurchases = Func3.SelectQuery("select name,sum(quantity) from inventoryhistory where " + DateClause + " group by name order by Name");

                double grand_amount = 0;
                if (InventoryClosing.HasRows)
                {
                    InventorySale.Read();
                    InventoryPurchases.Read();
                    while (InventoryClosing.Read())
                    {
                        double sales = 0;
                        if (InventorySale.HasRows)
                        {
                            if (InventoryClosing[0].ToString() == InventorySale[0].ToString())
                            {
                                sales = Math.Round(Convert.ToDouble(InventorySale[1]), 2);
                                InventorySale.Read();
                            }
                        }

                        double purchase = 0;

                        if (InventoryPurchases.HasRows)
                        {
                            if (InventoryClosing[0].ToString() == InventoryPurchases[0].ToString())
                            {
                                purchase = Math.Round(Convert.ToDouble(InventoryPurchases[1]), 2);
                                InventoryPurchases.Read();
                            }
                        }

                        double closing = Math.Round(Convert.ToDouble(InventoryClosing[2]), 2);
                        double total_stock = sales + closing;
                        double opening = total_stock - purchase;
                        //double amount = sales * Math.Round(Convert.ToDouble(InventoryClosing[1]), 2);
                        double amount = Math.Round(Convert.ToDouble(InventoryClosing[2]), 2) * Math.Round(Convert.ToDouble(InventoryClosing[1]), 2);

                        grand_amount += amount;

                        worksheet.Cells[Row, 2].Value = InventoryClosing[0].ToString();
                        worksheet.Cells[Row, 3].Value = opening;
                        worksheet.Cells[Row, 4].Value = purchase;
                        worksheet.Cells[Row, 5].Value = total_stock;
                        worksheet.Cells[Row, 6].Value = sales;
                        worksheet.Cells[Row, 7].Value = closing;
                        worksheet.Cells[Row, 7, Row, 8].Merge = true;
                        worksheet.Cells[Row, 9].Value = Math.Round(Convert.ToDouble(InventoryClosing[1]), 2);
                        worksheet.Cells[Row, 10].Value = amount;

                        Row++;
                    }
                }

                worksheet.Cells[Row, 7].Value = "Grand Total Amount";
                worksheet.Cells[Row, 7, Row, 9].Merge = true;
                worksheet.Cells[Row, 10].Value = grand_amount;
                worksheet.Cells[Row, 7, Row, 9].Style.Font.Bold = true;

                worksheet.Cells[TableStart, 2, Row, 10].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[TableStart, 2, Row, 10].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[TableStart, 2, Row, 10].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                Row+=4;

                InventorySale.Close();
                InventoryClosing.Close();
                InventoryPurchases.Close();               


                
                worksheet.Cells[Row, 2].Value = "Sales Report";
                worksheet.Cells[Row, 2, Row, 7].Merge = true;
                worksheet.Cells[Row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[Row, 2].Style.Font.Size = 14;
                worksheet.Cells[Row, 2].Style.Font.Bold = true;

                Row += 2;

                worksheet.Cells[Row, 2].Value = "Dates";
                worksheet.Cells[Row, 3].Value = DPFrom.Value.ToString("dd MMM yyyy");
                worksheet.Cells[Row, 3, Row, 4].Merge = true;
                worksheet.Cells[Row, 5].Value = DPTo.Value.ToString("dd MMM yyyy");
                worksheet.Cells[Row, 5, Row, 6].Merge = true;

                Row += 2;
                TableStart = Row;

                double GrandDiesel = 0;
                double GrandPetrol = 0;
                double GrandOthers = 0;
                double GrandTotal = 0;

                worksheet.Cells[Row, 2].Value = "Company Name";
                worksheet.Cells[Row, 3].Value = "Diesel";
                worksheet.Cells[Row, 4].Value = "Petrol";
                worksheet.Cells[Row, 5].Value = "Cash";
                worksheet.Cells[Row, 6].Value = "Others";
                worksheet.Cells[Row, 7].Value = "Total";
                worksheet.Cells[Row, 2, Row, 7].Style.Font.Bold = true;

                Row++;

                MySqlDataReader CashSale = Func.SelectQuery("SELECT SUM(amount), type FROM cash where " + DateClause + " GROUP BY type");
                MySqlDataReader LineSale = Func2.SelectQuery("SELECT SUM(amount), type FROM linecredit where " + DateClause + " GROUP BY type");
                MySqlDataReader CreditSale = Func3.SelectQuery("SELECT sum(amount), type, companies.name, companies.id FROM credit inner join companies on companies.id = credit.companyid where " + DateClause + " group by type, companyid union all select sum(amount), 'Cash' as 'type', companies.name, companies.id from vehiclecash inner join companies on companies.id = vehiclecash.companyid where " + DateClause + " group by companyid order by name");

                double CashGrandTotal = 0;
                double LineGrandTotal = 0;
                double CreditGrandTotal = 0;

                double Diesel = 0;
                double Petrol = 0;
                double Others = 0;
                double Total = 0; 
                if (CashSale.HasRows)
                {    
                    while (CashSale.Read())
                    {
                        if (CashSale[1].ToString() == "Diesel")
                        {
                            Diesel = Math.Round(Convert.ToDouble(CashSale[0]),2);
                            Total += Diesel;
                        }

                        else if (CashSale[1].ToString() == "Petrol")
                        {
                            Petrol = Math.Round(Convert.ToDouble(CashSale[0]), 2);
                            Total += Petrol;
                        }

                        else
                        {
                            Others += Math.Round(Convert.ToDouble(CashSale[0]), 2);
                            Total += Others;
                        }
                    }
                }
                worksheet.Cells[Row, 2].Value = "Cash Sales";
                worksheet.Cells[Row, 3].Value = Diesel + "";
                worksheet.Cells[Row, 4].Value = Petrol + "";
                worksheet.Cells[Row, 6].Value = Others + "";
                worksheet.Cells[Row, 7].Value = Total + "";

                CashGrandTotal = Total;

                GrandDiesel += Diesel;
                GrandPetrol += Petrol;
                GrandOthers += Others;
                GrandTotal += Total;

                Row++;

                Diesel = 0;
                Petrol = 0;
                Others = 0;
                Total = 0;
                if (LineSale.HasRows)
                {
                    while (LineSale.Read())
                    {
                        if (LineSale[1].ToString() == "Diesel")
                        {
                            Diesel = Math.Round(Convert.ToDouble(LineSale[0]), 2);
                            Total += Diesel;
                        }

                        else if (LineSale[1].ToString() == "Petrol")
                        {
                            Petrol = Math.Round(Convert.ToDouble(LineSale[0]), 2);
                            Total += Petrol;
                        }

                        else
                        {
                            Others += Math.Round(Convert.ToDouble(LineSale[0]), 2);
                            Total += Others;
                        }
                    }
                }
                worksheet.Cells[Row, 2].Value = "Line Credit Sales";
                worksheet.Cells[Row, 3].Value = Diesel + "";
                worksheet.Cells[Row, 4].Value = Petrol + "";
                worksheet.Cells[Row, 6].Value = Others + "";
                worksheet.Cells[Row, 7].Value = Total + "";

                LineGrandTotal = Total;

                GrandDiesel += Diesel;
                GrandPetrol += Petrol;
                GrandOthers += Others;
                GrandTotal += Total;

                Row++;

                worksheet.Cells[Row, 2].Value = "Credit Sales";
                worksheet.Cells[Row, 2].Style.Font.UnderLine = true;
                worksheet.Cells[Row, 2].Style.Font.Bold = true;

                Row++;

                double CreditDiesel = 0;
                double CreditPetrol = 0;
                double CreditCash = 0;
                double CreditOthers = 0;
                double CreditTotal = 0;

                double Cash = 0;
                Diesel = 0;
                Petrol = 0;
                Others = 0;
                Total = 0;
                string LastID = "0";
                string LastName = "0";
                if (CreditSale.HasRows)
                {
                    CreditSale.Read();
                    LastID = CreditSale[3].ToString();
                    LastName = CreditSale[2].ToString();
                    do
                    {
                        if (LastID != CreditSale[3].ToString())
                        {
                            worksheet.Cells[Row, 2].Value = LastName;
                            worksheet.Cells[Row, 3].Value = Diesel + "";
                            worksheet.Cells[Row, 4].Value = Petrol + "";
                            worksheet.Cells[Row, 5].Value = Cash + "";
                            worksheet.Cells[Row, 6].Value = Others + "";
                            worksheet.Cells[Row, 7].Value = Total + "";

                            Row++;

                            CreditDiesel += Diesel;
                            CreditPetrol += Petrol;
                            CreditCash += Cash;
                            CreditOthers += Others;
                            CreditTotal += Total;

                            Diesel = 0;
                            Petrol = 0;
                            Cash = 0;
                            Others = 0;
                            Total = 0;
                        }

                        LastID = CreditSale[3].ToString();
                        LastName = CreditSale[2].ToString();

                        if (CreditSale[1].ToString() == "Diesel")
                        {
                            Diesel = Math.Round(Convert.ToDouble(CreditSale[0]), 2);
                            Total += Diesel;
                        }

                        else if (CreditSale[1].ToString() == "Petrol")
                        {
                            Petrol = Math.Round(Convert.ToDouble(CreditSale[0]), 2);
                            Total += Petrol;
                        }

                        else if (CreditSale[1].ToString() == "Cash")
                        {
                            Cash = Math.Round(Convert.ToDouble(CreditSale[0]), 2);
                            Total += Cash;
                        }

                        else
                        {
                            Others += Math.Round(Convert.ToDouble(CreditSale[0]), 2);
                            Total += Others;
                        }
                    }
                    while (CreditSale.Read());

                    CreditDiesel += Diesel;
                    CreditPetrol += Petrol;
                    CreditCash += Cash;
                    CreditOthers += Others;
                    CreditTotal += Total;

                    worksheet.Cells[Row, 2].Value = LastName;
                    worksheet.Cells[Row, 3].Value = Diesel + "";
                    worksheet.Cells[Row, 4].Value = Petrol + "";
                    worksheet.Cells[Row, 5].Value = Cash + "";
                    worksheet.Cells[Row, 6].Value = Others + "";
                    worksheet.Cells[Row, 7].Value = Total + "";

                    Row++;
                }

                CreditGrandTotal = CreditTotal;

                GrandDiesel += CreditDiesel;
                GrandPetrol += CreditPetrol;
                GrandOthers += CreditOthers;
                GrandTotal += CreditTotal;

                worksheet.Cells[Row, 2].Value = "Total Credit Sales";
                worksheet.Cells[Row, 3].Value = CreditDiesel + "";
                worksheet.Cells[Row, 4].Value = CreditPetrol + "";
                worksheet.Cells[Row, 5].Value = CreditCash + "";
                worksheet.Cells[Row, 6].Value = CreditOthers + "";
                worksheet.Cells[Row, 7].Value = CreditTotal + "";

                worksheet.Cells[TableStart, 2, Row, 7].Style.Font.Size = 10;

                Row++;

                worksheet.Cells[Row, 2].Value = "Total Sales";
                worksheet.Cells[Row, 3].Value = GrandDiesel + "";
                worksheet.Cells[Row, 4].Value = GrandPetrol + "";
                worksheet.Cells[Row, 5].Value = CreditCash + "";
                worksheet.Cells[Row, 6].Value = GrandOthers + "";
                worksheet.Cells[Row, 7].Value = GrandTotal + "";

                worksheet.Cells[Row, 2, Row, 7].Style.Font.Bold = true;
                worksheet.Cells[Row, 2, Row, 7].Style.Font.Size = 12;

                worksheet.Cells[TableStart, 2, Row, 7].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[TableStart, 2, Row, 7].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[TableStart, 2, Row, 7].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                Row+=4;





                worksheet.Cells[Row, 2].Value = "Summary";
                worksheet.Cells[Row, 2, Row, 6].Merge = true;
                worksheet.Cells[Row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[Row, 2].Style.Font.Size = 14;
                worksheet.Cells[Row, 2].Style.Font.Bold = true;

                Row += 2;

                worksheet.Cells[Row, 2].Value = "Sales";
                worksheet.Cells[Row, 2].Style.Font.Bold = true;
                worksheet.Cells[Row, 2, Row + 1, 2].Merge = true;
                worksheet.Cells[Row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[Row, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells[Row, 3].Value = "Cash";
                worksheet.Cells[Row, 4].Value = "Line Credit";
                worksheet.Cells[Row, 5].Value = "Credit";
                worksheet.Cells[Row, 6].Value = "Total";

                Row++;

                worksheet.Cells[Row, 3].Value = CashGrandTotal + "";
                worksheet.Cells[Row, 4].Value = LineGrandTotal + "";
                worksheet.Cells[Row, 5].Value = CreditGrandTotal + "";
                worksheet.Cells[Row, 6].Value = GrandTotal + "";

                worksheet.Cells[Row - 1, 2, Row, 6].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[Row - 1, 2, Row, 6].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[Row - 1, 2, Row, 6].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                Row += 2;

                CashSale.Close();
                LineSale.Close();
                CreditSale.Close();

                double CashClosing = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) as 'Amount' FROM cash where " + DateClause)), 2);
                double CashWithdraw = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM withdraw where " + DateClause)), 2);

                worksheet.Cells[Row, 2].Value = "Cash";
                worksheet.Cells[Row, 2].Style.Font.Bold = true;
                worksheet.Cells[Row, 2, Row + 1, 2].Merge = true;
                worksheet.Cells[Row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[Row, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells[Row, 3].Value = "Opennig";
                worksheet.Cells[Row, 4].Value = "Sales";
                worksheet.Cells[Row, 5].Value = "Withdraw";
                worksheet.Cells[Row, 6].Value = "Closing";

                Row++;

                worksheet.Cells[Row, 3].Value = (CashClosing - CashGrandTotal) + "";
                worksheet.Cells[Row, 4].Value = CashGrandTotal + "";
                worksheet.Cells[Row, 5].Value = CashWithdraw + "";
                worksheet.Cells[Row, 6].Value = (CashClosing + CashWithdraw) + "";

                worksheet.Cells[Row - 1, 2, Row, 6].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[Row - 1, 2, Row, 6].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[Row - 1, 2, Row, 6].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                Row += 4;

                //string ReceiptQuery = "select temp.*, accounts.accountnumber from (SELECT sum(creditreceived.amount), creditreceived.type, companies.name,creditreceived.datetime, creditreceived.accountid, 'Credit' from creditreceived inner join credit on credit.id = creditreceived.creditid inner join companies on companies.id = credit.companyid group by creditreceived.type, companies.name,accountid union all SELECT sum(vehiclecashreceived.amount), vehiclecashreceived.type, companies.name,vehiclecashreceived.datetime, vehiclecashreceived.accountid, 'Vehicle Cash' from vehiclecashreceived inner join vehiclecash on vehiclecash.id = vehiclecashreceived.vehiclecashid inner join companies on companies.id = vehiclecash.companyid group by vehiclecashreceived.type, companies.name,accountid union all SELECT sum(linecreditreceived.amount), 'Cash', linecustomers.vehiclenumber,linecreditreceived.datetime,null, 'Line Credit' from linecreditreceived inner join linecredit on linecredit.id = linecreditreceived.linecreditid inner join linecustomers on linecustomers.id = linecredit.customerid group by linecustomers.vehiclenumber) as temp left join accounts on accounts.id = temp.accountid where " + DateClause;
                string ReceiptQuery = "select temp.*, accounts.accountnumber from (SELECT sum(creditreceived.amount), creditreceived.type, companies.name,creditreceived.datetime, creditreceived.accountid, credit.id, 'Credit' from creditreceived inner join credit on credit.id = creditreceived.creditid inner join companies on companies.id = credit.companyid group by credit.id,accountid union all SELECT sum(vehiclecashreceived.amount), vehiclecashreceived.type, companies.name,vehiclecashreceived.datetime, vehiclecashreceived.accountid, vehiclecash.id, 'Vehicle Cash' from vehiclecashreceived inner join vehiclecash on vehiclecash.id = vehiclecashreceived.vehiclecashid inner join companies on companies.id = vehiclecash.companyid group by vehiclecash.id,accountid union all SELECT sum(linecreditreceived.amount), 'Cash', linecustomers.vehiclenumber,linecreditreceived.datetime,null, linecredit.id, 'Line Credit' from linecreditreceived inner join linecredit on linecredit.id = linecreditreceived.linecreditid inner join linecustomers on linecustomers.id = linecredit.customerid group by linecredit.id) as temp left join accounts on accounts.id = temp.accountid where " + DateClause;
                if (ReportType == "Cash")
                    ReceiptQuery += " and type='Cash' ";
                if (ReportType == "Bank")
                    ReceiptQuery += " and type='Cheque' ";

                MySqlDataReader Receipts = Func.SelectQuery(ReceiptQuery);

                worksheet.Cells[Row, 2].Value = "Receipts";
                worksheet.Cells[Row, 2, Row, 8].Merge = true;
                worksheet.Cells[Row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[Row, 2].Style.Font.Size = 14;
                worksheet.Cells[Row, 2].Style.Font.Bold = true;

                Row += 2;

                worksheet.Cells[Row, 2].Value = "Filter";
                worksheet.Cells[Row, 3].Value = ReportType;

                Row += 2;
                TableStart = Row;

                worksheet.Cells[Row, 2].Value = "Date";
                worksheet.Cells[Row, 3].Value = "Slip No";
                worksheet.Cells[Row, 4].Value = "Type";
                worksheet.Cells[Row, 5].Value = "Description";
                worksheet.Cells[Row, 6].Value = "Account";
                worksheet.Cells[Row, 7].Value = "Cash/Bank";
                worksheet.Cells[Row, 8].Value = "Amount";
                worksheet.Cells[Row, 2, Row, 8].Style.Font.Bold = true;

                Row++;

                if (Receipts.HasRows)
                {
                    double ReceiptAmount = 0;
                    while (Receipts.Read())
                    {
                        worksheet.Cells[Row, 2].Value = Receipts[3].ToString().Split(' ')[0];
                        worksheet.Cells[Row, 3].Value = Receipts[5].ToString();
                        worksheet.Cells[Row, 4].Value = Receipts[6].ToString();
                        worksheet.Cells[Row, 5].Value = Receipts[2].ToString();
                        worksheet.Cells[Row, 6].Value = Receipts[7].ToString();
                        if (Receipts[1].ToString() == "Cheque")
                            worksheet.Cells[Row, 7].Value = "Bank";
                        else
                            worksheet.Cells[Row, 7].Value = "Cash";

                        double Temp = Math.Round(Convert.ToDouble(Receipts[0].ToString()), 2);
                        worksheet.Cells[Row, 8].Value = Temp + "";
                        ReceiptAmount += Temp;

                        Row++;
                    }

                    worksheet.Cells[Row, 6].Value = "Total Amount";
                    worksheet.Cells[Row, 6, Row, 7].Merge = true;
                    worksheet.Cells[Row, 8].Value = ReceiptAmount;
                    worksheet.Cells[Row, 6, Row, 8].Style.Font.Bold = true;
                }

                worksheet.Cells[TableStart, 2, Row, 8].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[TableStart, 2, Row, 8].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[TableStart, 2, Row, 8].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                Row += 4;

                Receipts.Close();

                string PaymentQuery = "select amount, description, type, accounts.accountnumber, datetime from  expense left join accounts on accounts.id = expense.accountid where " + DateClause;
                if (ReportType == "Cash")
                    PaymentQuery += " and type='Cash' ";
                if (ReportType == "Bank")
                    PaymentQuery += " and type='Cheque' ";

                MySqlDataReader Payments = Func.SelectQuery(PaymentQuery);

                worksheet.Cells[Row, 2].Value = "Payments";
                worksheet.Cells[Row, 2, Row, 6].Merge = true;
                worksheet.Cells[Row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[Row, 2].Style.Font.Size = 14;
                worksheet.Cells[Row, 2].Style.Font.Bold = true;

                Row += 2;

                worksheet.Cells[Row, 2].Value = "Filter";
                worksheet.Cells[Row, 3].Value = ReportType;

                Row += 2;
                TableStart = Row;

                worksheet.Cells[Row, 2].Value = "Date";
                worksheet.Cells[Row, 3].Value = "Description";
                worksheet.Cells[Row, 4].Value = "Account";
                worksheet.Cells[Row, 5].Value = "Cash/Bank";
                worksheet.Cells[Row, 6].Value = "Amount";
                worksheet.Cells[Row, 2, Row, 6].Style.Font.Bold = true;

                Row++;

                if (Payments.HasRows)
                {
                    double PaymentAmount = 0;
                    while (Payments.Read())
                    {
                        worksheet.Cells[Row, 2].Value = Payments[4].ToString().Split(' ')[0];
                        worksheet.Cells[Row, 3].Value = Payments[1].ToString();
                        worksheet.Cells[Row, 4].Value = Payments[3].ToString();
                        if (Payments[2].ToString() == "Cheque")
                            worksheet.Cells[Row, 5].Value = "Bank";
                        else
                            worksheet.Cells[Row, 5].Value = "Cash";

                        double Temp = Math.Round(Convert.ToDouble(Payments[0].ToString()), 2);
                        worksheet.Cells[Row, 6].Value = Temp + "";
                        PaymentAmount += Temp;

                        Row++;
                    }

                    worksheet.Cells[Row, 4].Value = "Total Amount";
                    worksheet.Cells[Row, 4, Row, 5].Merge = true;
                    worksheet.Cells[Row, 6].Value = PaymentAmount;
                    worksheet.Cells[Row, 4, Row, 6].Style.Font.Bold = true;
                }

                worksheet.Cells[TableStart, 2, Row , 6].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[TableStart, 2, Row , 6].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[TableStart, 2, Row , 6].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                Row += 2;
                

                
                
                
                // add the page number to the footer plus the total number of pages
                worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page " + ExcelHeaderFooter.PageNumber + " of " + ExcelHeaderFooter.NumberOfPages);

                worksheet.HeaderFooter.OddFooter.LeftAlignedText = "Combined Report - " + DPFrom.Value.ToString("dd MMM yyyy") + " to " + DPTo.Value.ToString("dd MMM yyyy") + " (" + ReportType + ")";

                worksheet.Cells.AutoFitColumns(200);

                package.Save();
                if (FileNum == 0)
                    System.Diagnostics.Process.Start("Combined Report - " + DPFrom.Value.ToString("dd MMM yyyy") + " to " + DPTo.Value.ToString("dd MMM yyyy") + " (" + ReportType + ").xlsx");
                else
                    System.Diagnostics.Process.Start("Combined Report - " + DPFrom.Value.ToString("dd MMM yyyy") + " to " + DPTo.Value.ToString("dd MMM yyyy") + " (" + ReportType + ") (" + FileNum + ").xlsx");
            }
        }

        private void DPTo_ValueChanged(object sender, EventArgs e)
        {
            DPFrom.MaxDate = DPTo.Value;
            DPFrom.Value = DPTo.Value.AddDays(-1);
        }
    }
}
