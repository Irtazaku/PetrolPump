using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;

namespace PetrolPump
{
    public partial class AddCashForm : Form
    {
        int InsertID;
        DateTime InsertTime;

        public AddCashForm()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(TBLiter.Text, "^[0-9]*[.]{0,1}[0-9]{1,2}$"))
            {
                TBLiter.BackColor = Color.FromArgb(255, 207, 207);
                return;
            }
            else
            {
                TBLiter.BackColor = Color.White;
            }
                

            if (MessageBox.Show("Add Cash Sale For:\n\nDriver Name: " + TBName.Text + "\nFuel Type: " + CBType.Text + "\nLiter / Qty: " + TBLiter.Text + "\n" + LblRate.Text + "\n" + LblAmount.Text + "\nVehicle No: " + TBVehicleNumber.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MySqlFunctions Func = new MySqlFunctions();

            double Rate = Math.Round(Inventory.GetRate(CBType.Text),2);
            double Amount = Convert.ToDouble(Rate) * Convert.ToDouble(TBLiter.Text);
            InsertTime = DateTime.Now;

            if (CBMachine.Items.Count == 0)
                InsertID = Func.ScalarInt(@"
                                update inventory set quantity=quantity-" + TBLiter.Text + @"
                                where name='" + CBType.Text + @"';
                                insert into cash set 
                                CashierID='" + MySqlFunctions.CashierID + @"',
                                Name='" + TBName.Text + @"',
                                Type='" + CBType.Text + @"',
                                Liter='" + TBLiter.Text + @"',
                                Rate='" + Rate + @"',
                                Amount='" + Amount + @"',
                                VehicleNumber='" + TBVehicleNumber.Text + @"',
                                DateTime='" + InsertTime.ToString("yyyy-MM-dd H:mm:ss") + @"';
                                SELECT LAST_INSERT_ID();");
            else
            {
                int MachineID = Machines.GetMachineID(CBMachine.Text, CBType.Text);
                InsertID = Func.ScalarInt(@"
                                update inventory set quantity=quantity-" + TBLiter.Text + @"
                                where name='" + CBType.Text + @"';
                                update machines set units=units+" + TBLiter.Text + @"
                                where id='" + MachineID + @"';
                                insert into cash set 
                                CashierID='" + MySqlFunctions.CashierID + @"',
                                MachineID='" + MachineID + @"',
                                Name='" + TBName.Text + @"',
                                Type='" + CBType.Text + @"',
                                Liter='" + TBLiter.Text + @"',
                                Rate='" + Rate + @"',
                                Amount='" + Amount + @"',
                                VehicleNumber='" + TBVehicleNumber.Text + @"',
                                DateTime='" + InsertTime.ToString("yyyy-MM-dd H:mm:ss") + @"';
                                SELECT LAST_INSERT_ID();");
            }

            Func.Dest();

            if (CheckBoxPrint.Checked)
            {
                PrintDialog PDialog = new PrintDialog();
                PrintDocument PDocument = new PrintDocument();
                PrintController PController = new StandardPrintController();
                PDialog.Document = PDocument;
                PDocument.PrintController = PController;
                PDocument.PrinterSettings.PrinterName = "Send To OneNote 2010";
                PDocument.PrintPage += new PrintPageEventHandler(PDocument_PrintPage);
                PDocument.Print();
            }

            MessageBox.Show("Cash sale recorded at ID: " + InsertID, "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TBName.Text = TBLiter.Text = TBVehicleNumber.Text = "";
            CBType.SelectedIndex = 0;
        }

        private void PDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics PGraphics = e.Graphics;

            Pen DashedPen = new Pen(Color.Black);
            DashedPen.DashStyle = DashStyle.Dash;
            DashedPen.DashPattern = new float[2] { 3, 3 };

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
            PGraphics.DrawString("SITARA HILAL PETROLEUM SERVICE", new Font(FontName, 20), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("SITARA HILAL PETROLEUM SERVICE", new Font(FontName, 20)).Width) / 2), Y + Offset));
            Offset += 35;
            PGraphics.DrawString("144 KM SUPER HIGHWAY HYDERABAD - CELL: 0300-3240440, 0345-1404440", new Font(FontName, 10), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("144 KM SUPER HIGHWAY HYDERABAD - CELL: 0300-3240440, 0345-1404440", new Font(FontName, 10)).Width) / 2), Y + Offset));
            Offset += 30;
            PGraphics.FillRectangle(new SolidBrush(Color.Black), X, Y + Offset, MaxX, 3);
            Offset += 10;
            PGraphics.DrawString("CASH SALE RECEIPT", new Font(FontName, 14), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("CASH SALE RECEIPT", new Font(FontName, 14)).Width) / 2), Y + Offset));
            Offset += 30;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            Offset += 10;
            PGraphics.DrawString("Slip Number: " + InsertID, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            PGraphics.DrawString("Cashier: " + MySqlFunctions.CashierName, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X + (MaxX - PGraphics.MeasureString("Cashier: " + MySqlFunctions.CashierName, new Font(FontName, 12)).Width), Y + Offset));
            Offset += 25;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            Offset += 10;
            if (TBName.Text != "")
            {
                PGraphics.DrawString("Driver Name: " + TBName.Text, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
                Offset += 25;
            }
            if (TBVehicleNumber.Text != "")
            {
                PGraphics.DrawString("Vehicle No: " + TBVehicleNumber.Text, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
                Offset += 25;
            }
            PGraphics.DrawString("Type: " + CBType.Text, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            Offset += 25;
            PGraphics.DrawString("Liter: " + TBLiter.Text + " L", new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            Offset += 25;
            PGraphics.DrawString(LblRate.Text, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            Offset += 25;
            PGraphics.DrawString(LblAmount.Text, new Font(FontName, 14, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            Offset += 30;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            Offset += 10;
            PGraphics.DrawString("THANK YOU!", new Font(FontName, 14, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("THANK YOU!", new Font(FontName, 14, FontStyle.Bold)).Width) / 2), Y + Offset));
            Offset += 25;
            PGraphics.DrawString(InsertTime.ToString("F"), new Font(FontName, 10), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString(InsertTime.ToString("F"), new Font(FontName, 10)).Width) / 2), Y + Offset));
            Offset += 25;
            PGraphics.FillRectangle(new SolidBrush(Color.Black), X, Y + Offset, MaxX, 2);
            Offset += 10;
            PGraphics.DrawString("Software Developed By: Alphasoft - 03363356517, 03462811866, 03338287634", new Font(FontName, 10), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("Software Developed By: Alphasoft - 03363356517, 03462811866, 03338287634", new Font(FontName, 10)).Width) / 2), Y + Offset));
        }

        private void AddCashForm_Load(object sender, EventArgs e)
        {
            foreach (string Item in Inventory.Name)
                CBType.Items.Add(Item);

            CBType.SelectedIndex = 0;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TBLiter_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(TBLiter.Text, "^[0-9]*[.]{0,1}[0-9]{1,2}$"))
                LblAmount.Text = "Amount: " + Math.Round(Convert.ToDouble(Inventory.GetRate(CBType.Text)) * Convert.ToDouble(TBLiter.Text), 2) + " Rs";
            else
                LblAmount.Text = "Amount: 0 Rs";
        }

        private void CBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblRate.Text = "Rate: " + Math.Round(Inventory.GetRate(CBType.Text), 2) + " Rs";
            if (Regex.IsMatch(TBLiter.Text, "^[0-9]*[.]{0,1}[0-9]{1,2}$"))
                LblAmount.Text = "Amount: " + Math.Round(Convert.ToDouble(Inventory.GetRate(CBType.Text)) * Convert.ToDouble(TBLiter.Text), 2) + " Rs";
            else
                LblAmount.Text = "Amount: 0 Rs";

            CBMachine.Items.Clear();
            List<string> MachineNames = Machines.GetMachineNames(CBType.Text);
            foreach (string Name in MachineNames)
            {
                CBMachine.Items.Add(Name);
            }
            if (CBMachine.Items.Count > 0)
                CBMachine.SelectedIndex = 0;
        }
    }
}