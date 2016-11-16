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
            //string DateClause = " date(datetime) between '" + DPFrom.Value.ToString("yyyy-MM-dd") + "' and '" + DateTime.Today.ToString("yyyy-MM-dd") + "' ";
            string DateClause = " date(datetime) between '" + DPFrom.Value.ToString("yyyy-MM-dd") + "' and '" + DPTo.Value.ToString("yyyy-MM-dd") + "' ";

            if (CBCompany.Items.Count == 0)
            {
                MessageBox.Show("No company selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fileName = "Bill - " + CBCompany.Text + " - " + DPFrom.Value.ToString("dd MMM yyyy") + " to " + DPTo.Value.ToString("yyyy-MM-dd");
            FileInfo newFile = new FileInfo( fileName + ".xlsx");
            //if (newFile.Exists)
            int FileNum = 0;
            while (newFile.Exists)
            {
                try
                {
                    newFile.Delete();
                    if (FileNum == 0)
                        newFile = new FileInfo(fileName + ".xlsx");
                    else
                        newFile = new FileInfo(fileName + " (" + FileNum + ").xlsx");
                }
                catch (Exception)
                {
                    FileNum++;
                    newFile = new FileInfo(fileName + " (" + FileNum + ").xlsx");
                }
            }
            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = null;
                worksheet = package.Workbook.Worksheets.Add("Bill - " + CBCompany.Text);

                int Row = 2;

                worksheet.Cells[Row, 1].Value = CBCompany.Text;
                worksheet.Cells[Row, 1].Style.Font.Size = 14;
                worksheet.Cells[Row, 1].Style.Font.Bold = true;
                worksheet.Cells[Row, 1, Row+1, 5].Merge = true;
                worksheet.Cells[Row, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[Row, 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                worksheet.Cells[Row, 6].Value = "BILLING PERIOD " + DateTime.Today.AddDays(1).Subtract(DPFrom.Value).Days + " DAYS";
                worksheet.Cells[Row, 6].Style.Font.Bold = true;
                worksheet.Cells[Row, 6, Row, 9].Merge = true;
                worksheet.Cells[Row, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                Row++;

                worksheet.Cells[Row, 6].Value = "DATE " + DPFrom.Value.ToString("dd MMM yyyy") + " TO " + DateTime.Today.ToString("dd MMM yyyy");
                worksheet.Cells[Row, 6].Style.Font.Bold = true;
                worksheet.Cells[Row, 6, Row, 9].Merge = true;
                worksheet.Cells[Row, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells[2, 1, 3, 9].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[2, 1, 3, 9].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[2, 1, 3, 9].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[2, 1, 3, 9].Style.Border.Top.Style = ExcelBorderStyle.Thin;

                Row+=2;

                worksheet.Cells[Row, 1].Value = "S #";
                worksheet.Cells[Row, 2].Value = "Date";
                worksheet.Cells[Row, 3].Value = "Slip #";
                worksheet.Cells[Row, 4].Value = "Vehicle";
                worksheet.Cells[Row, 5].Value = "Product";
                worksheet.Cells[Row, 6].Value = "Quantity";
                worksheet.Cells[Row, 7].Value = "Rate";
                worksheet.Cells[Row,8].Value = "Discount";
                worksheet.Cells[Row,9].Value = "Amount";
                worksheet.Cells[Row, 1, Row, 9].Style.Font.Bold = true;
                worksheet.Cells[Row, 1, Row, 9].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                ExcelRange HeaderCell = worksheet.Cells[Row, 1, Row, 9];

                Row++;

                MySqlFunctions Func = new MySqlFunctions();

                MySqlDataReader Transactions = Func.SelectQuery("SELECT credit.datetime, vehicles.number, credit.id, type, liter, rate, liter*rate,amount,credit.companyid FROM `credit` inner join vehicles on vehicles.id = credit.vehicleid where credit.companyid = '" + Company.ID[CBCompany.SelectedIndex] + "' and " + DateClause + " union all SELECT datetime,null, id, 'Cash', null, null, amount,amount,companyid FROM vehiclecash where companyid = '" + Company.ID[CBCompany.SelectedIndex] + "' and " + DateClause + " order by datetime");

                double TotalAmount = 0;
                double TotalDiscount = 0;

                if (Transactions.HasRows)
                {
                    int SerialNum = 1;

                    while (Transactions.Read())
                    {
                        if (SerialNum % 40 == 0)
                        {
                            HeaderCell.Copy(worksheet.Cells[Row, 1, Row, 9]);
                            Row++;
                        }

                        worksheet.Cells[Row, 1].Value = SerialNum++;
                        worksheet.Cells[Row, 2].Value = Convert.ToDateTime(Transactions[0]).ToString("dd-MM-yyyy");
                        worksheet.Cells[Row, 3].Value = Convert.ToInt32(Transactions[2]);
                        worksheet.Cells[Row, 4].Value = Transactions[1].ToString();
                        worksheet.Cells[Row, 5].Value = Transactions[3].ToString();

                        if (Transactions[1].ToString() != "")
                        {
                            worksheet.Cells[Row, 6].Value = Math.Round(Convert.ToDouble(Transactions[4].ToString()), 2);
                            worksheet.Cells[Row, 7].Value = Math.Round(Convert.ToDouble(Transactions[5].ToString()), 2);
                        }

                        double Amount = Math.Round(Convert.ToDouble(Transactions[6].ToString()), 2);
                        double Discount = Math.Round(Convert.ToDouble(Transactions[7].ToString()), 2);

                        TotalAmount += Amount;
                        TotalDiscount += Discount;

                        if (Amount - Discount != 0)
                            worksheet.Cells[Row, 8].Value = Amount - Discount;
                        worksheet.Cells[Row, 9].Value = Amount;

                        Row++;
                    }
                }
                Transactions.Close();

                Row--;

                worksheet.Cells[6, 6, Row, 9].Style.Numberformat.Format = "#,##0.00";
                worksheet.Cells[5, 1, Row, 9].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, Row, 9].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, Row, 9].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[5, 1, Row, 9].Style.Border.Top.Style = ExcelBorderStyle.Thin;

                Row += 2;

                int SummaryTableStart = Row;

                worksheet.Cells[Row, 6].Value = "Total Bill Amount";
                worksheet.Cells[Row, 6, Row, 8].Merge = true;
                worksheet.Cells[Row, 9].Value = TotalAmount;

                Row++;

                worksheet.Cells[Row, 6].Value = "Discounts";
                worksheet.Cells[Row, 6, Row, 8].Merge = true;
                worksheet.Cells[Row, 9].Value = TotalAmount - TotalDiscount;

                Row++;

                worksheet.Cells[Row, 6].Value = "Total Dues (Current)";
                worksheet.Cells[Row, 6, Row, 8].Merge = true;
                worksheet.Cells[Row, 9].Value = TotalDiscount;
                worksheet.Cells[Row, 6, Row, 9].Style.Font.Bold = true;

                Row++;

                double BalanceCredit = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT sum(amount) FROM credit where companyid = '" + Company.ID[CBCompany.SelectedIndex] + "'").ToString()), 2);
                double BalanceVehicleCash = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT sum(amount) FROM vehiclecash where companyid = '" + Company.ID[CBCompany.SelectedIndex] + "'").ToString()), 2);
                double Balance = BalanceCredit + BalanceVehicleCash;
                worksheet.Cells[Row, 6].Value = "Previous Dues";
                worksheet.Cells[Row, 6, Row, 8].Merge = true;
                worksheet.Cells[Row, 9].Value = Balance - TotalDiscount;

                Row++;
                
                double ReceivedCredit = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(creditreceived.amount),0) FROM creditreceived inner join credit on credit.id = creditreceived.creditid where companyid = '" + Company.ID[CBCompany.SelectedIndex] + "'")), 2);
                double ReceivedVehicleCash = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT coalesce(sum(vehiclecashreceived.amount),0) FROM vehiclecashreceived inner join vehiclecash on vehiclecash.id = vehiclecashreceived.vehiclecashid where companyid = '" + Company.ID[CBCompany.SelectedIndex] + "'")), 2);
                double Received = ReceivedCredit + ReceivedVehicleCash;
                worksheet.Cells[Row, 6].Value = "Amount Received";
                worksheet.Cells[Row, 6, Row, 8].Merge = true;
                worksheet.Cells[Row, 9].Value = Received;

                Row++;

                worksheet.Cells[Row, 6].Value = "Total Amount Payable";
                worksheet.Cells[Row, 6, Row, 8].Merge = true;
                worksheet.Cells[Row, 9].Value = Balance - Received;
                worksheet.Cells[Row, 6, Row, 9].Style.Font.Bold = true;

                worksheet.Cells[SummaryTableStart, 9, Row, 9].Style.Numberformat.Format = "#,##0.00";
                worksheet.Cells[SummaryTableStart, 6, Row, 9].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[SummaryTableStart, 6, Row, 9].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                worksheet.Cells[SummaryTableStart, 6, Row, 9].Style.Border.BorderAround(ExcelBorderStyle.Medium);

                Row--;

                // add the page number to the footer plus the total number of pages
                worksheet.HeaderFooter.OddFooter.RightAlignedText = string.Format("Page " + ExcelHeaderFooter.PageNumber + " of " + ExcelHeaderFooter.NumberOfPages);

                worksheet.HeaderFooter.OddFooter.LeftAlignedText = fileName;

                worksheet.Cells.AutoFitColumns();

                worksheet.Cells.Style.Font.Size = 11;
                worksheet.Cells.Style.Font.Name = "Times New Roman";

                package.Save();
                if (FileNum == 0)
                    System.Diagnostics.Process.Start(fileName + ".xlsx");
                else
                    System.Diagnostics.Process.Start(fileName + " (" + FileNum + ").xlsx");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}