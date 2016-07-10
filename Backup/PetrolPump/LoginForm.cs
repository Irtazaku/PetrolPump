using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
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
            //for (int i = 1; i < 21; i++)
            //{
            //    //for (int j = 1; j < 10; j++)
            //    //{
            //    //    if (i == 2 && j == 1)
            //    //        continue;
            //    if (i < 10)
            //        new MySqlFunctions().NonReturnQuery("insert into linecustomers set Name='Customer " + i + "', VehicleNumber='LC-00" + i + "'");
            //    else
            //        new MySqlFunctions().NonReturnQuery("insert into linecustomers set Name='Customer " + i + "', VehicleNumber='LC-0" + i + "'");
            //    //}
            //}
            PrintDialog PDialog = new PrintDialog();
            PrintDocument PDocument = new PrintDocument();
            PrintController PController = new StandardPrintController();
            PDialog.Document = PDocument;
            PDocument.PrintController = PController;
            PDocument.PrinterSettings.PrinterName = "Send To OneNote 2010";
            PDocument.PrintPage += new PrintPageEventHandler(PDocument_PrintPage);
            //PDocument.Print();

            //FileInfo newFile = new FileInfo(@"sample1.xlsx");
            //if (newFile.Exists)
            //{
            //    newFile.Delete();  // ensures we create a new workbook
            //    newFile = new FileInfo(@"sample1.xlsx");
            //}
            //using (ExcelPackage package = new ExcelPackage(newFile))
            //{
            //    // add a new worksheet to the empty workbook
            //    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Inventory");
            //    //Add the headers
            //    worksheet.Cells[1, 1].Value = "ID";
            //    worksheet.Cells[1, 2].Value = "Product";
            //    worksheet.Cells[1, 3].Value = "Quantity";
            //    worksheet.Cells[1, 4].Value = "Price";
            //    worksheet.Cells[1, 5].Value = "Value";

            //    //Add some items...
            //    worksheet.Cells["A2"].Value = 12001;
            //    worksheet.Cells["B2"].Value = "Nails";
            //    worksheet.Cells["C2"].Value = 37;
            //    worksheet.Cells["D2"].Value = 3.99;

            //    worksheet.Cells["A3"].Value = 12002;
            //    worksheet.Cells["B3"].Value = "Hammer";
            //    worksheet.Cells["C3"].Value = 5;
            //    worksheet.Cells["D3"].Value = 12.10;

            //    worksheet.Cells["A4"].Value = 12003;
            //    worksheet.Cells["B4"].Value = "Saw";
            //    worksheet.Cells["C4"].Value = 12;
            //    worksheet.Cells["D4"].Value = 15.37;

            //    //Add a formula for the value-column

            //    worksheet.Cells["A5:E5"].Style.Font.Bold = true;

            //    worksheet.Cells.AutoFitColumns(0);  //Autofit columns for all cells

            //    // lets set the header text 
            //    worksheet.HeaderFooter.OddHeader.CenteredText = "&24&U&\"Arial,Regular Bold\" Inventory";
            //    // add the page number to the footer plus the total number of pages
            //    worksheet.HeaderFooter.OddFooter.RightAlignedText =
            //        string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
            //    // add the sheet name to the footer
            //    worksheet.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;
            //    // add the file path to the footer
            //    worksheet.HeaderFooter.OddFooter.LeftAlignedText = ExcelHeaderFooter.FilePath + ExcelHeaderFooter.FileName;

            //    worksheet.PrinterSettings.RepeatRows = worksheet.Cells["1:2"];
            //    worksheet.PrinterSettings.RepeatColumns = worksheet.Cells["A:G"];

            //    // Change the sheet view to show it in page layout mode
            //    worksheet.View.PageLayoutView = true;

            //    // set some document properties
            //    package.Workbook.Properties.Title = "Invertory";
            //    package.Workbook.Properties.Author = "Jan Kallman";
            //    package.Workbook.Properties.Comments = "This sample demonstrates how to create an Excel 2007 workbook using EPPlus";

            //    // set some extended property values
            //    package.Workbook.Properties.Company = "AdventureWorks Inc.";

            //    // set some custom property values
            //    package.Workbook.Properties.SetCustomPropertyValue("Checked by", "Jan K�llman");
            //    package.Workbook.Properties.SetCustomPropertyValue("AssemblyName", "EPPlus");
            //    // save our new workbook and we are done!
            //    package.Save();
            //}

            //Application.Exit();
        }

        private void PDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics PGraphics = e.Graphics;
            Color PrintColor = Color.FromArgb(230, 230, 230);

            Pen DashedPen = new Pen(PrintColor);
            DashedPen.DashStyle = DashStyle.Dash;
            DashedPen.DashPattern = new float[] { 3, 3 };

            FontFamily FontName = this.Font.FontFamily;

            //int MaxX = 300;
            int MaxX = 780;
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
            PGraphics.DrawString("SITARA HILAL", new Font(FontName, 18), new SolidBrush(PrintColor), new PointF(X + 10 + ((MaxX - PGraphics.MeasureString("SITARA HILAL", new Font(FontName, 18)).Width) / 2), Y + Offset));
            Offset += 30;
            PGraphics.DrawString("PETROLEUM SERVICE", new Font(FontName, 11, FontStyle.Bold), new SolidBrush(PrintColor), new PointF(X + 10 + ((MaxX - PGraphics.MeasureString("PETROLEUM SERVICE", new Font(FontName, 11, FontStyle.Bold)).Width) / 2), Y + Offset));
            Offset += 40;
            PGraphics.DrawString("144 KM SUPER HIGHWAY HYDERABAD", new Font(FontName, 10), new SolidBrush(PrintColor), new PointF(X + ((MaxX - PGraphics.MeasureString("144 KM SUPER HIGHWAY HYDERABAD", new Font(FontName, 10)).Width) / 2), Y + Offset));
            Offset += 20;
            PGraphics.DrawString("CELL: 0300-3240440, 0345-1404440", new Font(FontName, 10), new SolidBrush(PrintColor), new PointF(X + ((MaxX - PGraphics.MeasureString("CELL: 0300-3240440, 0345-1404440", new Font(FontName, 10)).Width) / 2), Y + Offset));
            Offset += 25;
            PGraphics.FillRectangle(new SolidBrush(PrintColor), X, Y + Offset, MaxX, 3);
            Offset += 15;
            PGraphics.DrawString("CASH RECEIPT", new Font(FontName, 14), new SolidBrush(PrintColor), new PointF(X + ((MaxX - PGraphics.MeasureString("CASH RECEIPT", new Font(FontName, 14)).Width) / 2), Y + Offset));
            Offset += 30;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            Offset += 10;
            PGraphics.DrawString("Slip Number: 1334", new Font(FontName, 12), new SolidBrush(PrintColor), new PointF(X, Y + Offset));
            Offset += 25;
            PGraphics.DrawString("Cashier: Talha", new Font(FontName, 12), new SolidBrush(PrintColor), new PointF(X, Y + Offset));
            Offset += 30;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            Offset += 10;
            PGraphics.DrawString("Driver: Talha", new Font(FontName, 12), new SolidBrush(PrintColor), new PointF(X, Y + Offset));
            Offset += 25;
            PGraphics.DrawString("Type: Diesel", new Font(FontName, 12), new SolidBrush(PrintColor), new PointF(X, Y + Offset));
            Offset += 25;
            PGraphics.DrawString("Liter: 71.00 L", new Font(FontName, 12), new SolidBrush(PrintColor), new PointF(X, Y + Offset));
            Offset += 25;
            PGraphics.DrawString("Rate: 75.12 Rs", new Font(FontName, 12), new SolidBrush(PrintColor), new PointF(X, Y + Offset));
            Offset += 25;
            PGraphics.DrawString("Amount: 1241.21 Rs", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(PrintColor), new PointF(X, Y + Offset));
            Offset += 25;
            PGraphics.DrawString("Vehicle No: JU-1231", new Font(FontName, 12), new SolidBrush(PrintColor), new PointF(X, Y + Offset));
            Offset += 30;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            Offset += 10;
            PGraphics.DrawString("THANK YOU!", new Font(FontName, 14, FontStyle.Bold), new SolidBrush(PrintColor), new PointF(X + ((MaxX - PGraphics.MeasureString("THANK YOU!", new Font(FontName, 14, FontStyle.Bold)).Width) / 2), Y + Offset));
            Offset += 30;
            PGraphics.DrawString(DateTime.Now.ToString("F"), new Font(FontName, 10), new SolidBrush(PrintColor), new PointF(X + ((MaxX - PGraphics.MeasureString(DateTime.Now.ToString("F"), new Font(FontName, 10)).Width) / 2), Y + Offset));
            Offset += 25;
            PGraphics.FillRectangle(new SolidBrush(PrintColor), 0, Y + Offset, 300, 2);
            Offset += 10;
            PGraphics.DrawString("Software Developed By: Alphasoft", new Font(FontName, 10), new SolidBrush(PrintColor), new PointF(0, Y + Offset));
            Offset += 20;
            PGraphics.DrawString("03363356517, 03462811866, 03338287634", new Font(FontName, 10), new SolidBrush(PrintColor), new PointF(0, Y + Offset));
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

                Reader = Func.SelectQuery("Select * from accounts");

                Accounts.Init();

                while (Reader.Read())
                {
                    Accounts.Add(Convert.ToInt32(Reader["ID"]), Reader["BankName"].ToString(), Reader["AccountNumber"].ToString());
                }
                Reader.Close();

                this.Hide();
                TBID.Text = TBPassword.Text = "";
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
    }
}














