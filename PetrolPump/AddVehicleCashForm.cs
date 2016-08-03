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
            {
                CBCompany.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBCompany.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBCompany.Items.Add(Name);
            }

            if (CBCompany.Items.Count > 0)
                CBCompany.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (CBCompany.Items.Count == 0)
            {
                MessageBox.Show("No company selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            else if (double.Parse(TBAmount.Text) <= 0)
            {
                TBAmount.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }
            else
            {
                TBAmount.BackColor = Color.White;
            }

            if (CBCompany.Items.Count == 0)
            {
                MessageBox.Show("No company selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Errors = true;
            }

            if (Errors)
                return;

            if (MessageBox.Show("Add Vehicle Cash Entry For:\n\nCompany Name: " + CBCompany.Text + "\nReceiver Name: " + TBReceiverName.Text + "\nAmount: " + TBAmount.Text + " Rs", "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            
            MySqlFunctions Func = new MySqlFunctions();

            InsertTime = DateTime.Now;
            int SlipNo = Func.ScalarInt("Select Value from settings where type='Slip Number'");

            InsertID = Func.ScalarInt(@"
                                update settings set Value=Value+1 where type='Slip Number';
                                insert into vehiclecash set 
                                ID='" + SlipNo + @"',
                                CompanyID='" + Company.ID[CBCompany.SelectedIndex] + @"',
                                CashierID='" + MySqlFunctions.CashierID + @"',
                                ReceiverName='" + TBReceiverName.Text + @"',
                                Amount='" + TBAmount.Text + @"',
                                DateTime='" + InsertTime.ToString("yyyy-MM-dd H:mm:ss") + @"';
                                SELECT LAST_INSERT_ID();");

            Func.Dest();

            InsertID = SlipNo;

            if (CheckBoxPrint.Checked)
            {
                PrintDialog PDialog = new PrintDialog();
                PrintDocument PDocument = new PrintDocument();
                PrintController PController = new StandardPrintController();
                PDialog.Document = PDocument;
                PDocument.PrintController = PController;
                PDocument.PrinterSettings.PrinterName = Inventory.PrinterName;
                PDocument.PrintPage += new PrintPageEventHandler(PDocument_PrintPage);
                for (int i = 0; i < 3; i++)
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
            int MaxX = 750;
            int Y = 0;
            //int Offset = 0;
            int Offset = 70;
            int X = 0;
            //int Logo = 60;
            int MaxY = 333;
            
            //PGraphics.FillRectangle(new SolidBrush(Color.Black), X, MaxY, MaxX, 3);
            PGraphics.FillRectangle(new SolidBrush(Color.Black), X, Y + Offset, MaxX, 3);
            Offset += 10;
            PGraphics.DrawString("VEHICLE CASH RECEIPT", new Font(FontName, 14), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("VEHICLE CASH RECEIPT", new Font(FontName, 14)).Width) / 2), Y + Offset));
            Offset += 30;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            Offset += 8;
            PGraphics.DrawString("Slip Number: " + InsertID, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            PGraphics.DrawString("Cashier: " + MySqlFunctions.CashierName, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X + (MaxX - PGraphics.MeasureString("Cashier: " + MySqlFunctions.CashierName, new Font(FontName, 12)).Width), Y + Offset));
            Offset += 25;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            Offset += 20;
            PGraphics.DrawString("Company Name: " + Company.Name[CBCompany.SelectedIndex], new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            Offset += 30;
            PGraphics.DrawString("Receiver Name: " + TBReceiverName.Text, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            Offset += 30;
            PGraphics.DrawString("Amount: " + TBAmount.Text + " Rs", new Font(FontName, 14, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(X, Y + Offset));

            Offset += 30;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            Offset += 5;
            PGraphics.DrawString("THANK YOU!", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("THANK YOU!", new Font(FontName, 12, FontStyle.Bold)).Width) / 2), Y + Offset));
            Offset += 23;
            PGraphics.DrawString(InsertTime.ToString("F"), new Font(FontName, 10), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString(InsertTime.ToString("F"), new Font(FontName, 10)).Width) / 2), Y + Offset));
            Offset += 20;
            PGraphics.FillRectangle(new SolidBrush(Color.Black), X, Y + Offset, MaxX, 2);
            Offset += 5;
            PGraphics.DrawString("Software Developed By: Alphasoft - 03363356517", new Font(FontName, 9), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("Software Developed By: Alphasoft - 03363356517", new Font(FontName, 9)).Width) / 2), Y + Offset));
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
