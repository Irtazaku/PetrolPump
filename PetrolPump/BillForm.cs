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
    public partial class BillForm : Form
    {
        public BillForm()
        {
            InitializeComponent();
        }

        private void BillForm_Load(object sender, EventArgs e)
        {
            foreach (string Name in Company.Name)
                CBCompany.Items.Add(Name);

            if (CBCompany.Items.Count > 0)
                CBCompany.SelectedIndex = 0;

            DPFrom.Value = DateTime.Today.AddDays(-1);
            DPFrom.MaxDate = DateTime.Today;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string DateClause = " date(datetime) between '" + DPFrom.Value.ToString("yyyy-MM-dd") + "' and '" + DateTime.Today.ToString("yyyy-MM-dd") + "' ";

            if (CBCompany.Items.Count == 0)
            {
                MessageBox.Show("No company selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FileInfo newFile = new FileInfo("Bill - " + CBCompany.Text + " - " + DPFrom.Value.ToString("dd MMM yyyy") + " to " + DateTime.Today.ToString("dd MMM yyyy") + ".xlsx");
            //if (newFile.Exists)
            int FileNum = 0;
            while (newFile.Exists)
            {
                try
                {
                    newFile.Delete();
                    if (FileNum == 0)
                        newFile = new FileInfo("Bill - " + CBCompany.Text + " - " + DPFrom.Value.ToString("dd MMM yyyy") + " to " + DateTime.Today.ToString("dd MMM yyyy") + ".xlsx");
                    else
                        newFile = new FileInfo("Bill - " + CBCompany.Text + " - " + DPFrom.Value.ToString("dd MMM yyyy") + " to " + DateTime.Today.ToString("dd MMM yyyy") + " (" + FileNum + ").xlsx");
                }
                catch (Exception)
                {
                    FileNum++;
                    newFile = new FileInfo("Bill - " + CBCompany.Text + " - " + DPFrom.Value.ToString("dd MMM yyyy") + " to " + DateTime.Today.ToString("dd MMM yyyy") + " (" + FileNum + ").xlsx");
                }
            }
            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = null;
                worksheet = package.Workbook.Worksheets.Add("Bill - " + CBCompany.Text);

                int Row = 1;


                var MainLogo = worksheet.Drawings.AddPicture("Main Logo", new Bitmap(Properties.Resources.Main_Logo, 45, 30));
                MainLogo.SetPosition(0, 5, 0, 5);
                var ShellLogo = worksheet.Drawings.AddPicture("Shell Logo", new Bitmap(PetrolPump.Properties.Resources.Shell_Logo, 45, 30));
                ShellLogo.SetPosition(0, 5, 7, 5);


                worksheet.Cells[Row, 1].Value = "SITARA HILAL PETROLEUM SERVICES";
                worksheet.Cells[Row, 1].Style.Font.Size = 22;
                worksheet.Cells[Row, 1, Row, 8].Merge = true;
                worksheet.Cells[Row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[Row, 1, Row, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                worksheet.Cells[Row, 1, Row, 8].Style.Border.Bottom.Style = ExcelBorderStyle.None;

                Row++;

                worksheet.Cells[Row, 1].Value = "144 KM SUPER HIGHWAY HYDERABAD - CELL: 0300-3240440, 0345-1404440";
                worksheet.Cells[Row, 1].Style.Font.Size = 10;
                worksheet.Cells[Row, 1, Row, 8].Merge = true;
                worksheet.Cells[Row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[Row, 1, Row, 8].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                worksheet.Cells[Row, 1, Row, 8].Style.Border.Top.Style = ExcelBorderStyle.None;


                Row++;
                int TableStart = Row;

                worksheet.Cells[Row, 1].Value = CBCompany.Text;
                worksheet.Cells[Row, 1].Style.Font.Size = 14;
                worksheet.Cells[Row, 1].Style.Font.Bold = true;
                worksheet.Cells[Row, 1, Row, 8].Merge = true;
                worksheet.Cells[Row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                Row++;

                worksheet.Cells[Row, 1].Value = "BILLING PERIOD " + DateTime.Today.AddDays(1).Subtract(DPFrom.Value).Days + " DAYS";
                worksheet.Cells[Row, 1].Style.Font.Bold = true;
                worksheet.Cells[Row, 1, Row, 4].Merge = true;
                worksheet.Cells[Row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells[Row, 5].Value = "DATE " + DPFrom.Value.ToString("dd MMM yyyy") + " TO " + DateTime.Today.ToString("dd MMM yyyy");
                worksheet.Cells[Row, 5].Style.Font.Bold = true;
                worksheet.Cells[Row, 5, Row, 8].Merge = true;
                worksheet.Cells[Row, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                Row++;

                worksheet.Cells[Row, 1].Value = "S. No";
                worksheet.Cells[Row, 2].Value = "Sale Date";
                worksheet.Cells[Row, 3].Value = "V. No";
                worksheet.Cells[Row, 4].Value = "Slip No";
                worksheet.Cells[Row, 5].Value = "Fuel Type";
                worksheet.Cells[Row, 6].Value = "Liter";
                worksheet.Cells[Row, 7].Value = "Rate";
                worksheet.Cells[Row, 8].Value = "Balance";
                worksheet.Cells[Row, 1, Row, 8].Style.Font.Bold = true;
                worksheet.Cells[Row, 1, Row, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                Row++;

                MySqlFunctions Func = new MySqlFunctions();

                MySqlDataReader Transactions = Func.SelectQuery("SELECT credit.datetime, vehicles.number, credit.id, type, liter, rate, liter*rate,amount,credit.companyid FROM `credit` inner join vehicles on vehicles.id = credit.vehicleid where credit.companyid = '" + Company.ID[CBCompany.SelectedIndex] + "' and " + DateClause + " union all SELECT datetime,null, id, 'Cash', null, null, amount,amount,companyid FROM vehiclecash where companyid = '" + Company.ID[CBCompany.SelectedIndex] + "' and " + DateClause + " order by datetime");

                double TotalLiter = 0;
                double TotalAmount = 0;
                double TotalDiscount = 0;

                if (Transactions.HasRows)
                {
                    int SerialNum = 1;

                    while (Transactions.Read())
                    {
                        worksheet.Cells[Row, 1].Value = SerialNum++;
                        worksheet.Cells[Row, 2].Value = Convert.ToDateTime(Transactions[0]).ToString("dd-MM-yyyy");
                        worksheet.Cells[Row, 3].Value = Transactions[1].ToString();
                        worksheet.Cells[Row, 4].Value = Convert.ToDouble(Transactions[2].ToString());
                        worksheet.Cells[Row, 5].Value = Transactions[3].ToString();

                        if (Transactions[1].ToString() != "")
                        {
                            double Liter = Convert.ToDouble(Transactions[4].ToString());
                            worksheet.Cells[Row, 6].Value = Liter;
                            TotalLiter += Liter;

                            worksheet.Cells[Row, 7].Value = Convert.ToDouble(Transactions[5].ToString());
                        }

                        double Amount = Math.Round(Convert.ToDouble(Transactions[6].ToString()), 2);
                        worksheet.Cells[Row, 8].Value = Amount;

                        TotalAmount += Amount;
                        TotalDiscount += Math.Round(Convert.ToDouble(Transactions[7].ToString()), 2);

                        Row++;
                    }
                }
                Transactions.Close();

                Row--;

                worksheet.Cells[TableStart, 2, Row, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[TableStart, 3, Row, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[TableStart, 5, Row, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells[TableStart + 2, 6, Row, 7].Style.Numberformat.Format = "#,###.00";
                worksheet.Cells[TableStart + 2, 8, Row, 8].Style.Numberformat.Format = "#,###";
                worksheet.Cells[TableStart, 1, Row, 8].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[TableStart, 1, Row, 8].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[TableStart, 1, Row, 8].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[TableStart, 1, Row, 8].Style.Border.Top.Style = ExcelBorderStyle.Thin;

                Row += 2;

                int SummaryTableStart = Row;

                worksheet.Cells[Row, 4].Value = "TOTAL LTRS";
                worksheet.Cells[Row, 4, Row, 5].Merge = true;
                worksheet.Cells[Row, 6].Value = TotalLiter;
                worksheet.Cells[Row, 8].Value = TotalAmount;

                Row++;

                worksheet.Cells[Row, 4].Value = "LESS DISCOUNT";
                worksheet.Cells[Row, 4, Row, 7].Merge = true;
                worksheet.Cells[Row, 8].Value = TotalAmount - TotalDiscount;

                Row++;

                worksheet.Cells[Row, 4].Value = "CURRENT BILL AMOUNT";
                worksheet.Cells[Row, 4, Row, 7].Merge = true;
                worksheet.Cells[Row, 8].Value = TotalDiscount;
                worksheet.Cells[Row, 4, Row, 8].Style.Font.Bold = true;

                Row++;

                double BalanceCredit = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT sum(amount) FROM credit where companyid = '" + Company.ID[CBCompany.SelectedIndex] + "'")), 2);
                double BalanceVehicleCash = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT sum(amount) FROM vehiclecash where companyid = '" + Company.ID[CBCompany.SelectedIndex] + "'")), 2);
                double Balance = BalanceCredit + BalanceVehicleCash;
                worksheet.Cells[Row, 4].Value = "BALANCE";
                worksheet.Cells[Row, 4, Row, 7].Merge = true;
                worksheet.Cells[Row, 8].Value = Balance - TotalDiscount;

                Row++;

                worksheet.Cells[Row, 4].Value = "TOTAL AMOUNT";
                worksheet.Cells[Row, 4, Row, 7].Merge = true;
                worksheet.Cells[Row, 8].Value = Balance;
                worksheet.Cells[Row, 4, Row, 8].Style.Font.Bold = true;

                Row++;

                double ReceivedCredit = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(creditreceived.amount),0) FROM creditreceived inner join credit on credit.id = creditreceived.creditid where companyid = '" + Company.ID[CBCompany.SelectedIndex] + "'")), 2);
                double ReceivedVehicleCash = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(vehiclecashreceived.amount),0) FROM vehiclecashreceived inner join vehiclecash on vehiclecash.id = vehiclecashreceived.vehiclecashid where companyid = '" + Company.ID[CBCompany.SelectedIndex] + "'")), 2);
                double Received = ReceivedCredit + ReceivedVehicleCash;
                worksheet.Cells[Row, 4].Value = "TOTAL RECEIVED AMOUNT";
                worksheet.Cells[Row, 4, Row, 7].Merge = true;
                worksheet.Cells[Row, 8].Value = Received;

                Row++;

                worksheet.Cells[Row, 4].Value = "GRAND TOTAL";
                worksheet.Cells[Row, 4, Row, 7].Merge = true;
                worksheet.Cells[Row, 8].Value = Balance - Received;
                worksheet.Cells[Row, 4, Row, 8].Style.Font.Bold = true;

                worksheet.Cells[SummaryTableStart, 8, Row, 8].Style.Numberformat.Format = "#,###";
                worksheet.Cells[SummaryTableStart, 4, Row, 8].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[SummaryTableStart, 4, Row, 8].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[SummaryTableStart, 4, Row, 8].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                Row--;

                // add the page number to the footer plus the total number of pages
                worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page " + ExcelHeaderFooter.PageNumber + " of " + ExcelHeaderFooter.NumberOfPages);

                worksheet.HeaderFooter.OddFooter.LeftAlignedText = "Bill - " + CBCompany.Text + " - " + DPFrom.Value.ToString("dd MMM yyyy") + " to " + DateTime.Today.ToString("dd MMM yyyy");

                worksheet.Cells.AutoFitColumns(200);

                package.Save();
                if (FileNum == 0)
                    System.Diagnostics.Process.Start("Bill - " + CBCompany.Text + " - " + DPFrom.Value.ToString("dd MMM yyyy") + " to " + DateTime.Today.ToString("dd MMM yyyy") + ".xlsx");
                else
                    System.Diagnostics.Process.Start("Bill - " + CBCompany.Text + " - " + DPFrom.Value.ToString("dd MMM yyyy") + " to " + DateTime.Today.ToString("dd MMM yyyy") + " (" + FileNum + ").xlsx");
            }
        }
    }
}