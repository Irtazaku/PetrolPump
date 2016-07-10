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
    public partial class SummaryForm : Form
    {
        int MachineRows = 0;
        int InventoryRows = 0;
        int CreditSaleRows = 0;
        int LineCreditSaleRows = 0;
        int ExpenseRows = 0;
        public SummaryForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DGVSummary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SummaryForm_Load(object sender, EventArgs e)
        {
            MachineRows = 0;
            InventoryRows = 0;
            CreditSaleRows = 0;
            LineCreditSaleRows = 0;
            ExpenseRows = 0;

            string date = DateTime.Now.ToString("yyyy-MM-dd");

            for (int i = 0; i < 8; i++)
            {
                DGVSummary.Columns.Add("dgvc" + i, "");
                DGVSummary.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            MySqlFunctions Func = new MySqlFunctions();

            double CashSale = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM cash where date(DateTime) = '" + date + "'")), 2);
            double Expense = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM expense where date(DateTime)= '" + date + "'")), 2);
            double OldCash = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM (SELECT coalesce(sum(Amount),0) as 'Amount' FROM cash where date(DateTime) < '" + date + "' union all SELECT coalesce(sum(Amount),0) as 'Amount' FROM creditreceived where date(DateTime) < '" + date + "' union all SELECT coalesce(sum(Amount),0) as 'Amount' FROM linecreditreceived where date(DateTime) < '" + date + "' union all SELECT (coalesce(sum(Amount),0)*-1) as 'Amount' FROM expense where date(DateTime) < '" + date + "') as Temp")), 2);

            double LineCreditOpening = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT sum(Opening) FROM (SELECT linecredit.amount-sum(coalesce(linecreditreceived.amount,0)) as Opening FROM linecredit LEFT JOIN linecreditreceived on linecredit.id=linecreditreceived.LineCreditID group by linecredit.ID) as temp")), 2);
            double LineCreditSell = Math.Round(Convert.ToDouble(Func.ScalarString("select coalesce(sum(coalesce(linecredit.amount,0)),0) as `Today Sell` FROM linecredit where date(DateTime)= '" + date + "'")), 2);
            double LineCreditRec = Math.Round(Convert.ToDouble(Func.ScalarString("select coalesce(sum(coalesce(linecreditreceived.amount,0)),0) as `Today Received` FROM linecreditreceived where date(DateTime)= '" + date + "'")), 2);

            double CreditOpening = Math.Round(Convert.ToDouble(Func.ScalarString("select sum(Opening) from (SELECT credit.amount-sum(coalesce(creditreceived.amount,0)) as Opening FROM credit left JOIN creditreceived on credit.id=creditreceived.creditID group by credit.ID) as temp")), 2);
            double CreditSell = Math.Round(Convert.ToDouble(Func.ScalarString("select coalesce(sum(coalesce(credit.amount,0)),0) as `Today Sell` FROM credit where date(DateTime)='" + date + "'")), 2);
            double CreditRec = Math.Round(Convert.ToDouble(Func.ScalarString("select coalesce(sum(coalesce(creditreceived.amount,0)),0) as `Today Received` FROM creditreceived where date(DateTime)='" + date + "'")), 2);

            DGVSummary.Rows.Add("", "Line Cred. Sale", "Credit Sale", "", "", "Old Cash", OldCash);
            DGVSummary.Rows.Add("Opening", LineCreditOpening + "", CreditOpening + "", "", "", "Cash Sale", CashSale);
            DGVSummary.Rows.Add("Today Sell", LineCreditSell + "", CreditSell + "", "", "", "Credit Rec.", CreditRec);
            DGVSummary.Rows.Add("Total", (LineCreditOpening + LineCreditSell), (CreditOpening + CreditSell), "", "", "Line Cred. Rec.", LineCreditRec);
            DGVSummary.Rows.Add("Received", LineCreditRec, CreditRec, "", "", "Expenses", Expense);
            DGVSummary.Rows.Add("Balance Amt", LineCreditOpening + LineCreditSell - LineCreditRec, (CreditOpening + CreditSell) - CreditRec, "", "", "Balance", OldCash + CashSale + CreditRec + LineCreditRec - Expense);

            MySqlFunctions Func2 = new MySqlFunctions();
            MySqlFunctions Func3 = new MySqlFunctions();

            MySqlDataReader Machines = Func.SelectQuery("select ID, Name, Units from machines");
            MySqlDataReader MachinesUsed = Func2.SelectQuery("select MachineID, sum(Quantity) as Units from (select MachineID, sum(Liter) as Quantity from credit where date(datetime)='" + date + "' and machineid is not null group by MachineID union all select MachineID, sum(Liter) as Quantity from linecredit where date(datetime)='" + date + "' and machineid is not null group by MachineID union all select MachineID, sum(Liter) as Quantity from cash where date(datetime)='" + date + "' and machineid is not null group by MachineID) as temp group by MachineID order by MachineID");

            int CellIndex = 1;
            DGVSummary.Rows.Add();
            DGVSummary.Rows.Add();
            DGVSummary.Rows.Add("New");
            DGVSummary.Rows.Add("Old");
            DGVSummary.Rows.Add("Used");
            if (Machines.HasRows)
            {
                MachinesUsed.Read();
                while (Machines.Read())
                {
                    double Used = 0;
                    if (MachinesUsed.HasRows)
                    {
                        if (Machines[0].ToString() == MachinesUsed[0].ToString())
                        {
                            Used = Math.Round(Convert.ToDouble(MachinesUsed[1].ToString()), 2);
                            MachinesUsed.Read();
                        }
                    }

                    if (CellIndex >= 7)
                    {
                        CellIndex = 1;
                        DGVSummary.Rows.Add();
                        DGVSummary.Rows.Add();
                        DGVSummary.Rows.Add("New");
                        DGVSummary.Rows.Add("Old");
                        DGVSummary.Rows.Add("Used");

                        MachineRows++;
                    }

                    DGVSummary.Rows[DGVSummary.Rows.Count - 4].Cells[CellIndex].Value = Machines[1].ToString();
                    DGVSummary.Rows[DGVSummary.Rows.Count - 3].Cells[CellIndex].Value = Machines[2].ToString();
                    DGVSummary.Rows[DGVSummary.Rows.Count - 2].Cells[CellIndex].Value = Convert.ToDouble(Machines[2].ToString()) - Used;
                    DGVSummary.Rows[DGVSummary.Rows.Count - 1].Cells[CellIndex].Value = Used;
                    CellIndex++;
                }
            }
            Machines.Close();
            MachinesUsed.Close();

            DGVSummary.Rows.Add();

            MySqlDataReader InventorySale = Func.SelectQuery("select Name, sum(Quantity) as Quantity from (select type as Name, sum(Liter) as Quantity from credit where date(datetime)='" + date + "' group by type union all select type as Name, sum(Liter) as Quantity from linecredit where date(datetime)='" + date + "' group by type union all select type as Name, sum(Liter) as Quantity from cash where date(datetime)='" + date + "' group by type) as temp group by Name order by Name");
            MySqlDataReader InventoryClosing = Func2.SelectQuery("select name,rate,sum(quantity) from inventory group by name order by Name");
            MySqlDataReader InventoryPurchases = Func3.SelectQuery("select name,sum(quantity) from inventoryhistory where date(datetime)='" + date + "' group by name order by Name");

            DGVSummary.Rows.Add("", "Opening", "Purchase", "T. Stock", "Sales", "Closing", "Rates", "T. Amount");

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
                    double amount = sales * Math.Round(Convert.ToDouble(InventoryClosing[1]), 2);
                    grand_amount += amount;
                    DGVSummary.Rows.Add(InventoryClosing[0].ToString(), opening, purchase, total_stock, sales, closing, Math.Round(Convert.ToDouble(InventoryClosing[1]), 2), amount);

                    InventoryRows++;
                }
            }
            InventorySale.Close();
            InventoryClosing.Close();
            InventoryPurchases.Close();

            DGVSummary.Rows.Add("", "", "", "", "", "", "Total Sale", grand_amount);

            DGVSummary.Rows.Add("");

            DGVSummary.Rows.Add("", "Line Cred. Sale", "", "", "", "Credit Sale");
            DGVSummary.Rows.Add("Vehicle", "Name", "Amount", "", "", "Company", "Amount");

            int RowIndex = DGVSummary.Rows.Count;

            MySqlDataReader LineCreditSale = Func.SelectQuery("select linecustomers.VehicleNumber,linecustomers.Name, sum(linecredit.amount) as Amount FROM linecredit inner join linecustomers on linecustomers.ID=linecredit.CustomerID where date(datetime)='" + date + "' group by linecustomers.VehicleNumber");
            MySqlDataReader CreditSale = Func2.SelectQuery("select Name, sum(amount) as Amount FROM credit inner join companies on companies.ID=credit.CompanyID where date(datetime)='" + date + "' group by Name");

            double Sale = 0;
            while (LineCreditSale.Read())
            {
                double Amount = Math.Round(Convert.ToDouble(LineCreditSale[2]), 2);
                Sale += Amount;
                DGVSummary.Rows.Add(LineCreditSale[0].ToString(), LineCreditSale[1].ToString(), Amount);

                LineCreditSaleRows++;
                CreditSaleRows++;
            }
            DGVSummary.Rows.Add("", "Total Sale", Sale);
            LineCreditSale.Close();

            Sale = 0;
            while (CreditSale.Read())
            {
                double Amount = Math.Round(Convert.ToDouble(CreditSale[1]), 2);
                Sale += Amount;
                if (DGVSummary.Rows.Count > RowIndex)
                {
                    DGVSummary.Rows[RowIndex].Cells[5].Value = CreditSale[0].ToString();
                    DGVSummary.Rows[RowIndex].Cells[6].Value = Amount;
                }
                else
                {
                    DGVSummary.Rows.Add("", "", "", "", "", CreditSale[0].ToString(), Amount);

                    CreditSaleRows++;
                }
                RowIndex++;
            }
            if (DGVSummary.Rows.Count > RowIndex)
            {
                DGVSummary.Rows[RowIndex].Cells[5].Value = "Total Sale";
                DGVSummary.Rows[RowIndex].Cells[6].Value = Sale;
            }
            else
            {
                DGVSummary.Rows.Add("", "", "", "", "", "Total Sale", Sale);

                CreditSaleRows++;
            }
            RowIndex++;
            CreditSale.Close();

            DGVSummary.Rows.Add();

            double BankOpening = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM (SELECT coalesce(sum(Amount),0) as 'Amount' FROM deposit where date(DateTime) < '" + date + "' union all SELECT coalesce(sum(Amount),0)*-1 as 'Amount' FROM withdraw where date(DateTime) < '" + date + "' union all SELECT coalesce(sum(Amount),0)*-1 FROM expense where type='Cheque' and date(DateTime) < '" + date + "' union all SELECT coalesce(sum(Amount),0) as 'Amount' FROM creditreceived where type='Cheque' and date(DateTime) < '" + date + "') as temp")), 2);
            double BankDeposit = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM deposit where date(DateTime) = '" + date + "'")), 2);
            double BankWithdraw = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM withdraw where date(DateTime) = '" + date + "'")), 2);
            double BankExpense = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM expense where type='Cheque' and date(DateTime) = '" + date + "'")), 2);
            double BankCreditRec = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM creditreceived where type='Cheque' and date(DateTime) = '" + date + "'")), 2);

            MySqlDataReader Expenses = Func3.SelectQuery("select Description, sum(amount) as Amount FROM expense where date(datetime)='" + date + "' group by id");

            DGVSummary.Rows.Add("Expense", "", "", "", "", "Bank Balance");
            DGVSummary.Rows.Add("Description", "Amount", "", "", "", "Opening", BankOpening);

            RowIndex = DGVSummary.Rows.Count;

            Sale = 0;
            while (Expenses.Read())
            {
                double Amount = Math.Round(Convert.ToDouble(Expenses[1]), 2);
                Sale += Amount;
                DGVSummary.Rows.Add(Expenses[0].ToString(), Amount);

                ExpenseRows++;
            }
            DGVSummary.Rows.Add("Total Expense", Sale);
            Expenses.Close();

            DGVSummary.Rows[RowIndex].Cells[5].Value = "Deposit";
            DGVSummary.Rows[RowIndex].Cells[6].Value = BankDeposit;
            RowIndex++;

            if (DGVSummary.Rows.Count > RowIndex)
            {
                DGVSummary.Rows[RowIndex].Cells[5].Value = "Withdraw";
                DGVSummary.Rows[RowIndex].Cells[6].Value = BankWithdraw;
            }
            else
            {
                DGVSummary.Rows.Add("", "", "", "", "", "Withdraw", BankWithdraw);
            }
            RowIndex++;

            if (DGVSummary.Rows.Count > RowIndex)
            {
                DGVSummary.Rows[RowIndex].Cells[5].Value = "Expense";
                DGVSummary.Rows[RowIndex].Cells[6].Value = BankExpense;
            }
            else
            {
                DGVSummary.Rows.Add("", "", "", "", "", "Expense", BankExpense);
            }
            RowIndex++;

            if (DGVSummary.Rows.Count > RowIndex)
            {
                DGVSummary.Rows[RowIndex].Cells[5].Value = "Credit Rec";
                DGVSummary.Rows[RowIndex].Cells[6].Value = BankCreditRec;
            }
            else
            {
                DGVSummary.Rows.Add("", "", "", "", "", "Credit Rec", BankCreditRec);
            }
            RowIndex++;

            if (DGVSummary.Rows.Count > RowIndex)
            {
                DGVSummary.Rows[RowIndex].Cells[5].Value = "Closing";
                DGVSummary.Rows[RowIndex].Cells[6].Value = BankOpening + BankCreditRec + BankDeposit - BankWithdraw - BankExpense;
            }
            else
            {
                DGVSummary.Rows.Add("", "", "", "", "", "Closing", BankOpening + BankCreditRec + BankDeposit - BankWithdraw - BankExpense);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime GenerationTime = DateTime.Now;

            FileInfo newFile = new FileInfo("Summary - " + GenerationTime.ToString("dddd, MMMM dd, yyyy - hh;mm;ss tt") + ".xlsx");
            if (newFile.Exists)
            {
                newFile.Delete();  // ensures we create a new workbook
                newFile = new FileInfo("Summary - " + GenerationTime.ToString("dddd, MMMM dd, yyyy - hh;mm;ss tt") + ".xlsx");
            }
            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = null;
                worksheet = package.Workbook.Worksheets.Add("Summary");

                //Logo Title
                var MainLogo = worksheet.Drawings.AddPicture("Main Logo", new Bitmap(Properties.Resources.Main_Logo, 60, 60));
                MainLogo.SetPosition(0, 0, 0, 0);

                double ShellLogoWidthDouble = (double)Properties.Resources.Shell_Logo.Width / Properties.Resources.Shell_Logo.Height;
                ShellLogoWidthDouble = ShellLogoWidthDouble * 60;
                int ShellLogoWidth = Convert.ToInt32(ShellLogoWidthDouble);
                var ShellLogo = worksheet.Drawings.AddPicture("Shell Logo", new Bitmap(PetrolPump.Properties.Resources.Shell_Logo, ShellLogoWidth, 60));
                ShellLogo.SetPosition(0, 0, 8, Convert.ToInt32(worksheet.Column(8).Width) - 60);

                worksheet.Cells[1, 1].Value = "SITARA HILAL";
                worksheet.Cells[1, 1].Style.Font.Size = 18;
                worksheet.Row(1).Height = 23;
                worksheet.Cells[1, 1, 1, 8].Merge = true;
                worksheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[2, 1].Value = "PETROLEUM SERVICES";
                worksheet.Cells[2, 1].Style.Font.Size = 18;
                worksheet.Row(2).Height = 23;
                worksheet.Cells[2, 1, 2, 8].Merge = true;
                worksheet.Row(2).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[3, 1].Value = "144 KM SUPER HIGHWAY HYDERABAD - CELL: 0300-3240440, 0345-1404440";
                worksheet.Cells[3, 1].Style.Font.Size = 10;
                worksheet.Cells[3, 1, 3, 8].Merge = true;
                worksheet.Row(3).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Row(3).Style.VerticalAlignment = ExcelVerticalAlignment.Bottom;
                worksheet.Row(3).Height = 20;

                worksheet.Cells[4, 1].Value = "Summary";
                worksheet.Cells[4, 1, 4, 8].Merge = true;
                worksheet.Cells[4, 1].Style.Font.Size = 26;
                worksheet.Cells[4, 1].Style.Font.UnderLine = true;
                worksheet.Cells[4, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                int Row = 5;

                for (int i = 0; i < DGVSummary.Rows.Count; i++)
                {
                    for (int j = 0; j < DGVSummary.Columns.Count; j++)
                    {
                        worksheet.Cells[Row + i + 1, j + 1].Value = DGVSummary.Rows[i].Cells[j].Value;
                    }
                }

                worksheet.Cells.AutoFitColumns(1, 20);

                worksheet.Cells[1, 1, DGVSummary.Rows.Count, DGVSummary.Columns.Count].Style.Numberformat.Format = "General";
                worksheet.Cells[6, 2, 6, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[7, 2, 11, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                worksheet.Cells[6, 7, 11, 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                for (int i = 0; i <= MachineRows; i++)
                {
                    worksheet.Cells[13 + (i * 5), 2, 13 + (i * 5), 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[14 + (i * 5), 2, 16 + (i * 5), 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }

                worksheet.Cells[19 + (MachineRows * 5) - 1, 2, 19 + (MachineRows * 5) - 1, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[19 + (MachineRows * 5), 2, (19 + InventoryRows) + (MachineRows * 5), 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                worksheet.Cells[6, 1, 11, 3].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[6, 1, 11, 3].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[6, 1, 11, 3].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[6, 1, 11, 3].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[6, 1, 11, 3].Style.Border.BorderAround(ExcelBorderStyle.Thick);
                
                worksheet.Cells[6, 6, 11, 7].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[6, 6, 11, 7].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[6, 6, 11, 7].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[6, 6, 11, 7].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[6, 6, 11, 7].Style.Border.BorderAround(ExcelBorderStyle.Thick);

                for (int i = 0; i <= MachineRows; i++)
                {
                    worksheet.Cells[13 + (i * 5), 1, 16 + (i * 5), 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[13 + (i * 5), 1, 16 + (i * 5), 7].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[13 + (i * 5), 1, 16 + (i * 5), 7].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[13 + (i * 5), 1, 16 + (i * 5), 7].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[13 + (i * 5), 1, 16 + (i * 5), 7].Style.Border.BorderAround(ExcelBorderStyle.Thick);
                }

                worksheet.Cells[18 + (MachineRows * 5), 1, (19 + InventoryRows) + (MachineRows * 5), 8].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[18 + (MachineRows * 5), 1, (19 + InventoryRows) + (MachineRows * 5), 8].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[18 + (MachineRows * 5), 1, (19 + InventoryRows) + (MachineRows * 5), 8].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[18 + (MachineRows * 5), 1, (19 + InventoryRows) + (MachineRows * 5), 8].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[18 + (MachineRows * 5), 1, (19 + InventoryRows) + (MachineRows * 5), 8].Style.Border.BorderAround(ExcelBorderStyle.Thick);

                //worksheet.Cells[(21 + InventoryRows) + (MachineRows * 5), 1].Value = "Line Cred. Sale";
                //worksheet.Cells[(21 + InventoryRows) + (MachineRows * 5), 1, (21 + InventoryRows) + (MachineRows * 5), 3].Merge = true;
                worksheet.Cells[(21 + InventoryRows) + (MachineRows * 5), 1, (23 + LineCreditSaleRows + InventoryRows) + (MachineRows * 5), 3].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[(21 + InventoryRows) + (MachineRows * 5), 1, (23 + LineCreditSaleRows + InventoryRows) + (MachineRows * 5), 3].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[(21 + InventoryRows) + (MachineRows * 5), 1, (23 + LineCreditSaleRows + InventoryRows) + (MachineRows * 5), 3].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[(21 + InventoryRows) + (MachineRows * 5), 1, (23 + LineCreditSaleRows + InventoryRows) + (MachineRows * 5), 3].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[(21 + InventoryRows) + (MachineRows * 5), 1, (23 + LineCreditSaleRows + InventoryRows) + (MachineRows * 5), 3].Style.Border.BorderAround(ExcelBorderStyle.Thick);

                //worksheet.Cells[(21 + InventoryRows) + (MachineRows * 5), 6].Value = "Credit Sale";
                //worksheet.Cells[(21 + InventoryRows) + (MachineRows * 5), 6, (21 + InventoryRows) + (MachineRows * 5), 8].Merge = true;
                worksheet.Cells[(21 + InventoryRows) + (MachineRows * 5), 6, (23 + CreditSaleRows + InventoryRows) + (MachineRows * 5), 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[(21 + InventoryRows) + (MachineRows * 5), 6, (23 + CreditSaleRows + InventoryRows) + (MachineRows * 5), 7].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[(21 + InventoryRows) + (MachineRows * 5), 6, (23 + CreditSaleRows + InventoryRows) + (MachineRows * 5), 7].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[(21 + InventoryRows) + (MachineRows * 5), 6, (23 + CreditSaleRows + InventoryRows) + (MachineRows * 5), 7].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[(21 + InventoryRows) + (MachineRows * 5), 6, (23 + CreditSaleRows + InventoryRows) + (MachineRows * 5), 7].Style.Border.BorderAround(ExcelBorderStyle.Thick);

                if (CreditSaleRows > LineCreditSaleRows)
                {
                    //worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 1, (25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 2].Merge = true;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 1, (25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + ExpenseRows + 2, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 1, (25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + ExpenseRows + 2, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 1, (25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + ExpenseRows + 2, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 1, (25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + ExpenseRows + 2, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 1, (25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + ExpenseRows + 2, 2].Style.Border.BorderAround(ExcelBorderStyle.Thick);

                    //worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 6, (25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 7].Merge = true;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 6, (25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + 6, 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 6, (25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + 6, 7].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 6, (25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + 6, 7].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 6, (25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + 6, 7].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 6, (25 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + 6, 7].Style.Border.BorderAround(ExcelBorderStyle.Thick);
                }
                else
                {
                    //worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 1, (25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 2].Merge = true;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 1, (25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + ExpenseRows + 2, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 1, (25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + ExpenseRows + 2, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 1, (25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + ExpenseRows + 2, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 1, (25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + ExpenseRows + 2, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 1, (25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + ExpenseRows + 2, 2].Style.Border.BorderAround(ExcelBorderStyle.Thick);

                    //worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 6, (25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 7].Merge = true;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 6, (25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + 6, 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 6, (25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + 6, 7].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 6, (25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + 6, 7].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 6, (25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + 6, 7].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 6, (25 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + 6, 7].Style.Border.BorderAround(ExcelBorderStyle.Thick);
                }

                // add the page number to the footer plus the total number of pages
                worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page " + ExcelHeaderFooter.PageNumber + " of " + ExcelHeaderFooter.NumberOfPages);

                worksheet.HeaderFooter.OddFooter.LeftAlignedText = "Generated on " + GenerationTime.ToLongDateString() + " " + GenerationTime.ToLongTimeString();
                // add the sheet name to the footer
                //worksheet.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                worksheet.PrinterSettings.LeftMargin = (decimal).2 / 2.54M;
                worksheet.PrinterSettings.RightMargin = (decimal).2 / 2.54M;
                worksheet.PrinterSettings.PaperSize = ePaperSize.A4;

                package.Save();
                System.Diagnostics.Process.Start("Summary - " + GenerationTime.ToString("dddd, MMMM dd, yyyy - hh;mm;ss tt") + ".xlsx");
            }
        }
    }
}