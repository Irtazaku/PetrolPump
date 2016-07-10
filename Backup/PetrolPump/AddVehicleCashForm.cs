using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Text.RegularExpressions;

namespace PetrolPump
{
    public partial class AddVehicleCashForm : Form
    {
        int InsertID;
        DateTime InsertTime;

        public AddVehicleCashForm()
        {
            InitializeComponent();
        }

        private void AddVehicleCashForm_Load(object sender, EventArgs e)
        {
            foreach (string Name in Company.Name)
                CBCompany.Items.Add(Name);

            CBCompany.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            bool Errors = false;

            if (TBReceiverName.Text.Trim().Length == 0)
            {
                TBReceiverName.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }
            else
            {
                TBReceiverName.BackColor = Color.White;
            }

            if (!Regex.IsMatch(TBAmount.Text, "^[0-9]*[.]{0,1}[0-9]{1,2}$"))
            {
                TBAmount.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }
            else
            {
                TBAmount.BackColor = Color.White;
            }

            if (Errors)
                return;

            if (MessageBox.Show("Add Vehicle Cash Entry For:\n\nCompany Name: " + CBCompany.Text + "\nReceiver Name: " + TBReceiverName.Text + "\nAmount: " + TBAmount.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            
            MySqlFunctions Func = new MySqlFunctions();

            InsertTime = DateTime.Now;

            InsertID = Func.ScalarInt(@"insert into vehiclecash set 
                                CompanyID='" + Company.ID[CBCompany.SelectedIndex] + @"',
                                CashierID='" + MySqlFunctions.CashierID + @"',
                                ReceiverName='" + TBReceiverName.Text + @"',
                                Amount='" + TBAmount.Text + @"',
                                DateTime='" + InsertTime.ToString("yyyy-MM-dd H:mm:ss") + @"';
                                SELECT LAST_INSERT_ID();");

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

            MessageBox.Show("Vehicle cash recorded at ID: " + InsertID, "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TBReceiverName.Text = TBAmount.Text = "";
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
            PGraphics.DrawString("VEHICLE CASH RECEIPT", new Font(FontName, 14), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("VEHICLE CASH RECEIPT", new Font(FontName, 14)).Width) / 2), Y + Offset));
            Offset += 30;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            Offset += 10;
            PGraphics.DrawString("Slip Number: " + InsertID, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            PGraphics.DrawString("Cashier: " + MySqlFunctions.CashierName, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X + (MaxX - PGraphics.MeasureString("Cashier: " + MySqlFunctions.CashierName, new Font(FontName, 12)).Width), Y + Offset));
            Offset += 25;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            Offset += 10;
            PGraphics.DrawString("Company Name: " + Company.Name[CBCompany.SelectedIndex], new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            Offset += 25;
            PGraphics.DrawString("Receiver Name: " + TBReceiverName.Text, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            Offset += 25;
            PGraphics.DrawString("Amount: " + TBAmount.Text, new Font(FontName, 14, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
