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
        int VCRows = 0;
        public SummaryForm()
        {
            InitializeComponent();
        }

        private void SummaryForm_Load(object sender, EventArgs e)
        {
            MachineRows = 0;
            InventoryRows = 0;
            CreditSaleRows = 0;
            LineCreditSaleRows = 0;
            ExpenseRows = 0;
            VCRows = 0;

            string date = DateTime.Now.ToString("yyyy-MM-dd");

            for (int i = 0; i < 8; i++)
            {
                DGVSummary.Columns.Add("dgvc" + i, "");
                DGVSummary.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            MySqlFunctions Func = new MySqlFunctions();

            double CashSale = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM cash where date(DateTime) = '" + date + "'")), 2);
            double CreditReceivedCash = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM creditreceived where type='Cash' and date(DateTime) = '" + date + "'")), 2);
            double LineCreditReceivedCash = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM linecreditreceived where date(DateTime) = '" + date + "'")), 2);
            double VehicleCashReceivedCash = Math.Round(Convert.ToDouble(Func.ScalarString("select coalesce(sum(coalesce(amount,0)),0) FROM vehiclecashreceived where type='Cash' and date(DateTime)= '" + date + "'")), 2);
            double CashExpense = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM expense where type='Cash' and date(DateTime)= '" + date + "'")), 2);
            double Deposit = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM deposit where date(DateTime) = '" + date + "'")), 2);
            double Withdraw = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM withdraw where date(DateTime) = '" + date + "'")), 2);
            double CashOpening = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM (SELECT coalesce(sum(Amount),0) as 'Amount' FROM cash where date(DateTime) < '" + date + "' union all SELECT coalesce(sum(Amount),0) as 'Amount' FROM creditreceived where type='Cash' and date(DateTime) < '" + date + "' union all SELECT coalesce(sum(Amount),0) as 'Amount' FROM vehiclecashreceived where type='Cash' and date(DateTime) < '" + date + "' union all SELECT coalesce(sum(Amount),0)*-1 as 'Amount' FROM vehiclecash where date(DateTime) < '" + date + "' union all SELECT coalesce(sum(Amount),0) as 'Amount' FROM linecreditreceived where date(DateTime) < '" + date + "' union all SELECT (coalesce(sum(Amount),0)*-1) as 'Amount' FROM expense where type='Cash' and date(DateTime) < '" + date + "' union all SELECT (coalesce(sum(Amount),0)*-1) as 'Amount' FROM deposit where date(DateTime) < '" + date + "' union all SELECT coalesce(sum(Amount),0) as 'Amount' FROM withdraw where date(DateTime) < '" + date + "') as Temp")), 2);

            double VehicleCashPayment = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM vehiclecash where date(DateTime) = '" + date + "'")), 2);
            double VehicleCashOpening = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM (select sum(coalesce(linecredit.amount,0)) as 'Amount' FROM linecredit where date(DateTime)< '" + date + "' union all select sum(coalesce(linecreditreceived.amount,0))*-1 as 'Amount' FROM linecreditreceived where date(DateTime)< '" + date + "') as temp")), 2);

            double LineCreditSell = Math.Round(Convert.ToDouble(Func.ScalarString("select coalesce(sum(coalesce(linecredit.amount,0)),0) FROM linecredit where date(DateTime)= '" + date + "'")), 2);
            double LineCreditRec = Math.Round(Convert.ToDouble(Func.ScalarString("select coalesce(sum(coalesce(linecreditreceived.amount,0)),0) FROM linecreditreceived where date(DateTime)= '" + date + "'")), 2);
            double LineCreditOpening = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM (select sum(coalesce(linecredit.amount,0)) as 'Amount' FROM linecredit where date(DateTime)< '" + date + "' union all select sum(coalesce(linecreditreceived.amount,0))*-1 as 'Amount' FROM linecreditreceived where date(DateTime)< '" + date + "') as temp")), 2);

            double CreditSell = Math.Round(Convert.ToDouble(Func.ScalarString("select coalesce(sum(coalesce(credit.amount,0)),0) FROM credit where date(DateTime)= '" + date + "'")), 2);
            double CreditRec = Math.Round(Convert.ToDouble(Func.ScalarString("select coalesce(sum(coalesce(creditreceived.amount,0)),0) FROM creditreceived where date(DateTime)= '" + date + "'")), 2);
            double CreditOpening = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM (select sum(coalesce(credit.amount,0)) as 'Amount' FROM credit where date(DateTime)< '" + date + "' union all select sum(coalesce(creditreceived.amount,0))*-1 as 'Amount' FROM creditreceived where date(DateTime)< '" + date + "') as temp")), 2);

            //double LineCreditOpening = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT sum(Opening) FROM (SELECT linecredit.amount-sum(coalesce(linecreditreceived.amount,0)) as Opening FROM linecredit LEFT JOIN linecreditreceived on linecredit.id=linecreditreceived.LineCreditID where linecredit.DateTime < '" + date + "' group by linecredit.ID ) as temp")), 2);
            //double CreditOpening = Math.Round(Convert.ToDouble(Func.ScalarString("select sum(Opening) from (SELECT credit.amount-sum(coalesce(creditreceived.amount,0)) as Opening FROM credit left JOIN creditreceived on credit.id=creditreceived.creditID where credit.DateTime < '" + date + "' group by credit.ID) as temp")), 2);

            DGVSummary.Rows.Add("", "Line Cred. Sale", "Credit Sale", "", "", "Old Cash", CashOpening);
            DGVSummary.Rows.Add("Opening", LineCreditOpening + "", CreditOpening + "", "", "", "Cash Sale", CashSale);
            DGVSummary.Rows.Add("Today Sell", LineCreditSell + "", CreditSell + "", "", "", "Credit Rec.", CreditReceivedCash);
            DGVSummary.Rows.Add("Total", (LineCreditOpening + LineCreditSell), (CreditOpening + CreditSell), "", "", "Line Cred. Rec.", LineCreditReceivedCash);
            DGVSummary.Rows.Add("Received", LineCreditRec, CreditRec, "", "", "VC Payment", VehicleCashPayment);
            DGVSummary.Rows.Add("Balance Amt", LineCreditOpening + LineCreditSell - LineCreditRec, (CreditOpening + CreditSell) - CreditRec, "", "", "VC Rec.", VehicleCashReceivedCash);
            DGVSummary.Rows.Add("", "", "", "", "", "Expenses", CashExpense);
            DGVSummary.Rows.Add("", "", "", "", "", "Deposit", Deposit);
            DGVSummary.Rows.Add("", "", "", "", "", "Withdraw", Withdraw);
            DGVSummary.Rows.Add("", "", "", "", "", "Balance", CashOpening + CashSale + CreditReceivedCash + LineCreditReceivedCash - VehicleCashPayment + VehicleCashReceivedCash + Withdraw - CashExpense - Deposit);

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

            DGVSummary.Rows.Add("Line Cred. Sale", "", "", "", "", "Credit Sale");
            DGVSummary.Rows.Add("Name", "Vehicle", "Amount", "", "", "Company", "Amount");

            int RowIndex = DGVSummary.Rows.Count;

            MySqlDataReader LineCreditSale = Func.SelectQuery("select linecustomers.VehicleNumber,linecustomers.Name, sum(linecredit.amount) as Amount FROM linecredit inner join linecustomers on linecustomers.ID=linecredit.CustomerID where date(datetime)='" + date + "' group by linecustomers.VehicleNumber");
            MySqlDataReader CreditSale = Func2.SelectQuery("select Name, sum(amount) as Amount FROM credit inner join companies on companies.ID=credit.CompanyID where date(datetime)='" + date + "' group by Name");

            double Sale = 0;
            while (LineCreditSale.Read())
            {
                double Amount = Math.Round(Convert.ToDouble(LineCreditSale[2]), 2);
                Sale += Amount;
                DGVSummary.Rows.Add(LineCreditSale[1].ToString(), LineCreditSale[0].ToString(), Amount);

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

            double BankOpening = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM (SELECT coalesce(sum(InitialBalance),0) as 'Amount' FROM accounts union all SELECT coalesce(sum(Amount),0) as 'Amount' FROM deposit where date(DateTime) < '" + date + "' union all SELECT coalesce(sum(Amount),0)*-1 as 'Amount' FROM withdraw where date(DateTime) < '" + date + "' union all SELECT coalesce(sum(Amount),0)*-1 FROM expense where type='Cheque' and date(DateTime) < '" + date + "' union all SELECT coalesce(sum(Amount),0) as 'Amount' FROM creditreceived where type='Cheque' and date(DateTime) < '" + date + "' union all SELECT coalesce(sum(Amount),0) as 'Amount' FROM vehiclecashreceived where type='Cheque' and date(DateTime) < '" + date + "') as temp")), 2);
            double BankExpense = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM expense where type='Cheque' and date(DateTime) = '" + date + "'")), 2);
            double BankCreditRec = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(Amount),0) FROM creditreceived where type='Cheque' and date(DateTime) = '" + date + "'")), 2);
            double BankVehicleCashRec = Math.Round(Convert.ToDouble(Func.ScalarString("select coalesce(sum(coalesce(amount,0)),0) FROM vehiclecashreceived where type='Cheque' and date(DateTime)= '" + date + "'")), 2);

            MySqlDataReader Expenses = Func3.SelectQuery("select Description, sum(amount) as Amount FROM expense where date(datetime)='" + date + "' group by id");
            MySqlDataReader VCPayment = Func2.SelectQuery("select Name, sum(amount) as Amount FROM vehiclecash inner join companies on companies.ID=vehiclecash.CompanyID where date(datetime)='" + date + "' group by Name");

            DGVSummary.Rows.Add("Expense", "", "", "Vehicle Cash", "", "", "Bank Balance");
            DGVSummary.Rows.Add("Description", "Amount", "", "Company", "Amount", "", "Opening", BankOpening);

            RowIndex = DGVSummary.Rows.Count;
            int RowIndex2 = RowIndex;

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

            Sale = 0;
            while (VCPayment.Read())
            {
                double Amount = Math.Round(Convert.ToDouble(VCPayment[1]), 2);
                Sale += Amount;
                if (DGVSummary.Rows.Count > RowIndex2)
                {
                    DGVSummary.Rows[RowIndex2].Cells[3].Value = VCPayment[0].ToString();
                    DGVSummary.Rows[RowIndex2].Cells[4].Value = Amount;
                }
                else
                {
                    DGVSummary.Rows.Add("", "", "", VCPayment[0].ToString(), Amount);
                }
                VCRows++;
                RowIndex2++;
            }
            if (DGVSummary.Rows.Count > RowIndex2)
            {
                DGVSummary.Rows[RowIndex2].Cells[3].Value = "Total Payment";
                DGVSummary.Rows[RowIndex2].Cells[4].Value = Sale;
            }
            else
            {
                DGVSummary.Rows.Add("", "", "", "Total Payment", Sale);
            }

            DGVSummary.Rows[RowIndex].Cells[6].Value = "Deposit";
            DGVSummary.Rows[RowIndex].Cells[7].Value = Deposit;
            RowIndex++;

            if (DGVSummary.Rows.Count > RowIndex)
            {
                DGVSummary.Rows[RowIndex].Cells[6].Value = "Withdraw";
                DGVSummary.Rows[RowIndex].Cells[7].Value = Withdraw;
            }
            else
            {
                DGVSummary.Rows.Add("", "", "", "", "", "", "Withdraw", Withdraw);
            }
            RowIndex++;

            if (DGVSummary.Rows.Count > RowIndex)
            {
                DGVSummary.Rows[RowIndex].Cells[6].Value = "Expense";
                DGVSummary.Rows[RowIndex].Cells[7].Value = BankExpense;
            }
            else
            {
                DGVSummary.Rows.Add("", "", "", "", "", "", "Expense", BankExpense);
            }
            RowIndex++;

            if (DGVSummary.Rows.Count > RowIndex)
            {
                DGVSummary.Rows[RowIndex].Cells[6].Value = "Credit Rec";
                DGVSummary.Rows[RowIndex].Cells[7].Value = BankCreditRec;
            }
            else
            {
                DGVSummary.Rows.Add("", "", "", "", "", "", "Credit Rec", BankCreditRec);
            }
            RowIndex++;

            if (DGVSummary.Rows.Count > RowIndex)
            {
                DGVSummary.Rows[RowIndex].Cells[6].Value = "VC Rec";
                DGVSummary.Rows[RowIndex].Cells[7].Value = BankVehicleCashRec;
            }
            else
            {
                DGVSummary.Rows.Add("", "", "", "", "", "", "VC Rec", BankVehicleCashRec);
            }
            RowIndex++;

            if (DGVSummary.Rows.Count > RowIndex)
            {
                DGVSummary.Rows[RowIndex].Cells[6].Value = "Closing";
                DGVSummary.Rows[RowIndex].Cells[7].Value = BankOpening + BankCreditRec + BankVehicleCashRec + Deposit - Withdraw - BankExpense;
            }
            else
            {
                DGVSummary.Rows.Add("", "", "", "", "", "", "Closing", BankOpening + BankCreditRec + Deposit - Withdraw - BankExpense);
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
                        if (DGVSummary.Rows[i].Cells[j].Value != null && DGVSummary.Rows[i].Cells[j].Value.ToString() != "")
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
                    worksheet.Cells[17 + (i * 5), 2, 17 + (i * 5), 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[18 + (i * 5), 2, 20 + (i * 5), 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                }

                worksheet.Cells[23 + (MachineRows * 5) - 1, 2, 23 + (MachineRows * 5) - 1, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[23 + (MachineRows * 5), 2, (23 + InventoryRows) + (MachineRows * 5), 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                worksheet.Cells[6, 1, 11, 3].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[6, 1, 11, 3].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[6, 1, 11, 3].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[6, 1, 11, 3].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[6, 1, 11, 3].Style.Border.BorderAround(ExcelBorderStyle.Thick);

                worksheet.Cells[6, 6, 15, 7].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[6, 6, 15, 7].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[6, 6, 15, 7].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[6, 6, 15, 7].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[6, 6, 15, 7].Style.Border.BorderAround(ExcelBorderStyle.Thick);

                for (int i = 0; i <= MachineRows; i++)
                {
                    worksheet.Cells[17 + (i * 5), 1, 20 + (i * 5), 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[17 + (i * 5), 1, 20 + (i * 5), 7].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[17 + (i * 5), 1, 20 + (i * 5), 7].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[17 + (i * 5), 1, 20 + (i * 5), 7].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[17 + (i * 5), 1, 20 + (i * 5), 7].Style.Border.BorderAround(ExcelBorderStyle.Thick);
                }

                worksheet.Cells[22 + (MachineRows * 5), 1, (23 + InventoryRows) + (MachineRows * 5), 8].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[22 + (MachineRows * 5), 1, (23 + InventoryRows) + (MachineRows * 5), 8].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[22 + (MachineRows * 5), 1, (23 + InventoryRows) + (MachineRows * 5), 8].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[22 + (MachineRows * 5), 1, (23 + InventoryRows) + (MachineRows * 5), 8].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[22 + (MachineRows * 5), 1, (23 + InventoryRows) + (MachineRows * 5), 8].Style.Border.BorderAround(ExcelBorderStyle.Thick);

                worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5), 1, (25 + InventoryRows) + (MachineRows * 5), 3].Merge = true;
                worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5), 1, (25 + InventoryRows) + (MachineRows * 5), 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5), 1, (27 + LineCreditSaleRows + InventoryRows) + (MachineRows * 5), 3].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5), 1, (27 + LineCreditSaleRows + InventoryRows) + (MachineRows * 5), 3].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5), 1, (27 + LineCreditSaleRows + InventoryRows) + (MachineRows * 5), 3].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5), 1, (27 + LineCreditSaleRows + InventoryRows) + (MachineRows * 5), 3].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5), 1, (27 + LineCreditSaleRows + InventoryRows) + (MachineRows * 5), 3].Style.Border.BorderAround(ExcelBorderStyle.Thick);

                worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5), 6, (25 + InventoryRows) + (MachineRows * 5), 7].Merge = true;
                worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5), 6, (25 + InventoryRows) + (MachineRows * 5), 7].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5), 6, (27 + CreditSaleRows + InventoryRows) + (MachineRows * 5), 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5), 6, (27 + CreditSaleRows + InventoryRows) + (MachineRows * 5), 7].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5), 6, (27 + CreditSaleRows + InventoryRows) + (MachineRows * 5), 7].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5), 6, (27 + CreditSaleRows + InventoryRows) + (MachineRows * 5), 7].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[(25 + InventoryRows) + (MachineRows * 5), 6, (27 + CreditSaleRows + InventoryRows) + (MachineRows * 5), 7].Style.Border.BorderAround(ExcelBorderStyle.Thick);

                if (CreditSaleRows > LineCreditSaleRows)
                {
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5), 1, (29 + InventoryRows) + (MachineRows * 5), 2].Merge = true;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5), 1, (29 + InventoryRows) + (MachineRows * 5), 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 1, (29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + ExpenseRows + 2, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 1, (29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + ExpenseRows + 2, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 1, (29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + ExpenseRows + 2, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 1, (29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + ExpenseRows + 2, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 1, (29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + ExpenseRows + 2, 2].Style.Border.BorderAround(ExcelBorderStyle.Thick);

                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 4, (29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 5].Merge = true;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 4, (29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 4, (29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + VCRows + 2, 5].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 4, (29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + VCRows + 2, 5].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 4, (29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + VCRows + 2, 5].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 4, (29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + VCRows + 2, 5].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 4, (29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + VCRows + 2, 5].Style.Border.BorderAround(ExcelBorderStyle.Thick);

                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 7, (29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 8].Merge = true;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 7, (29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 7, (30 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + 6, 8].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 7, (30 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + 6, 8].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 7, (30 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + 6, 8].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 7, (30 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + 6, 8].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + CreditSaleRows, 7, (30 + InventoryRows) + (MachineRows * 5) + CreditSaleRows + 6, 8].Style.Border.BorderAround(ExcelBorderStyle.Thick);
                }
                else
                {
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 1, (29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 2].Merge = true;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 1, (29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 1, (29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + ExpenseRows + 2, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 1, (29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + ExpenseRows + 2, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 1, (29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + ExpenseRows + 2, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 1, (29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + ExpenseRows + 2, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 1, (29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + ExpenseRows + 2, 2].Style.Border.BorderAround(ExcelBorderStyle.Thick);

                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 4, (29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 5].Merge = true;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 4, (29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 4, (29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + VCRows + 2, 5].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 4, (29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + VCRows + 2, 5].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 4, (29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + VCRows + 2, 5].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 4, (29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + VCRows + 2, 5].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 4, (29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + VCRows + 2, 5].Style.Border.BorderAround(ExcelBorderStyle.Thick);

                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 7, (29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 8].Merge = true;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 7, (29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 7, (30 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + 6, 8].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 7, (30 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + 6, 8].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 7, (30 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + 6, 8].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 7, (30 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + 6, 8].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    worksheet.Cells[(29 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows, 7, (30 + InventoryRows) + (MachineRows * 5) + LineCreditSaleRows + 6, 8].Style.Border.BorderAround(ExcelBorderStyle.Thick);
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