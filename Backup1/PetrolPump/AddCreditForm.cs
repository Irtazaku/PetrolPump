﻿using System;
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
    public partial class AddCreditForm : Form
    {
        int InsertID;
        DateTime InsertTime;

        public AddCreditForm()
        {
            InitializeComponent();
        }

        private void AddCreditForm_Load(object sender, EventArgs e)
        {
            foreach (string Name in Company.Name)
                CBCompany.Items.Add(Name);

            foreach (string Item in Inventory.Name)
                CBType.Items.Add(Item);

            CBCompany.SelectedIndex = 0;
            CBType.SelectedIndex = 0;
        }

        private void CBCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBVehicle.Items.Clear();

            foreach (string Number in Company.Vehicles[CBCompany.SelectedIndex].Number)
                CBVehicle.Items.Add(Number);

            if (CBVehicle.Items.Count > 0)
                CBVehicle.SelectedIndex = 0;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            bool Errors = false;
            if (!Regex.IsMatch(TBLiter.Text, "^[0-9]*[.]{0,1}[0-9]{1,2}$"))
            {
                TBLiter.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }
            else
            {
                TBLiter.BackColor = Color.White;
            }

            if (TBDiscount.Text != "" && !Regex.IsMatch(TBDiscount.Text, "^[0-9]{0,2}[.]{0,1}[0-9]{1,2}$"))
            {
                TBDiscount.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }
            else
            {
                TBDiscount.BackColor = Color.White;
            }

            if (CBVehicle.Items.Count == 0)
            {
                MessageBox.Show("Company has no vehicle", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Errors = true;
            }

            if (Errors)
                return;

            if (MessageBox.Show("Add Credit Entry For:\n\nCompany Name: " + CBCompany.Text + "\nVehicle Number: " + CBVehicle.Text + "\nFuel Type: " + CBType.Text + "\nLiter / Qty: " + TBLiter.Text + "\n" + LblRate.Text + "\nDiscount: " + (Regex.IsMatch(TBDiscount.Text, "^[0-9]{0,2}[.]{0,1}[0-9]{1,2}$") ? TBDiscount.Text : "0") + "%\n" + LblAmount.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MySqlFunctions Func = new MySqlFunctions();

            double Rate = Math.Round(Inventory.GetRate(CBType.Text),2);
            double Amount = Convert.ToDouble(Rate) * Convert.ToDouble(TBLiter.Text);
            if (Regex.IsMatch(TBDiscount.Text, "^([0-9]{1,2}|[.][0-9]{1,2}|[0-9]{1,2}[.][0-9]{1,2})$"))
                Amount -= Math.Round((Amount * Convert.ToDouble(TBDiscount.Text)) / 100, 2);

            InsertTime = DateTime.Now;

            if (CBMachine.Items.Count == 0)
                InsertID = Func.ScalarInt(@"
                                update inventory set quantity=quantity-" + TBLiter.Text + @"
                                where name='" + CBType.Text + @"';
                                insert into credit set 
                                CompanyID='" + Company.ID[CBCompany.SelectedIndex] + @"',
                                VehicleID='" + Company.Vehicles[CBCompany.SelectedIndex].ID[CBVehicle.SelectedIndex] + @"',
                                CashierID='" + MySqlFunctions.CashierID + @"',
                                Type='" + CBType.Text + @"',
                                Liter='" + TBLiter.Text + @"',
                                Rate='" + Rate + @"',
                                Amount='" + Amount + @"',
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
                                insert into credit set 
                                CompanyID='" + Company.ID[CBCompany.SelectedIndex] + @"',
                                VehicleID='" + Company.Vehicles[CBCompany.SelectedIndex].ID[CBVehicle.SelectedIndex] + @"',
                                CashierID='" + MySqlFunctions.CashierID + @"',
                                MachineID='" + MachineID + @"',
                                Type='" + CBType.Text + @"',
                                Liter='" + TBLiter.Text + @"',
                                Rate='" + Rate + @"',
                                Amount='" + Amount + @"',
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

            MessageBox.Show("Credit sale recorded at ID: " + InsertID, "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TBLiter.Text = TBDiscount.Text = "";
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
            PGraphics.DrawString("CREDIT SALE RECEIPT", new Font(FontName, 14), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("CREDIT SALE RECEIPT", new Font(FontName, 14)).Width) / 2), Y + Offset));
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
            PGraphics.DrawString("Vehicle Number: " + Company.Vehicles[CBCompany.SelectedIndex].Number[CBVehicle.SelectedIndex], new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            Offset += 25;
            PGraphics.DrawString("Type: " + CBType.Text, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            Offset += 25;
            PGraphics.DrawString("Liter: " + TBLiter.Text + " L", new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            Offset += 25;
            PGraphics.DrawString(LblRate.Text, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            Offset += 25;
            if (Regex.IsMatch(TBDiscount.Text, "^([0-9]{1,2}|[.][0-9]{1,2}|[0-9]{1,2}[.][0-9]{1,2})$"))
            {
                PGraphics.DrawString("Discount: " + TBDiscount.Text + "%", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
                Offset += 25;
            }
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

        private void CBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblRate.Text = "Rate: " + Math.Round(Inventory.GetRate(CBType.Text),2) + " Rs";
            if (Regex.IsMatch(TBLiter.Text, "^[0-9]*[.]{0,1}[0-9]{1,2}$"))
            {
                double Amount = Math.Round(Convert.ToDouble(Inventory.GetRate(CBType.Text)) * Convert.ToDouble(TBLiter.Text), 2);
                if (Regex.IsMatch(TBDiscount.Text, "^([0-9]{1,2}|[.][0-9]{1,2}|[0-9]{1,2}[.][0-9]{1,2})$"))
                    Amount -= Math.Round((Amount * Convert.ToDouble(TBDiscount.Text)) / 100, 2);

                LblAmount.Text = "Amount: " + Amount + " Rs";
            }
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

        private void TBLiter_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(TBLiter.Text, "^[0-9]*[.]{0,1}[0-9]{1,2}$"))
            {
                double Amount = Math.Round(Convert.ToDouble(Inventory.GetRate(CBType.Text)) * Convert.ToDouble(TBLiter.Text), 2);
                if (Regex.IsMatch(TBDiscount.Text, "^([0-9]{1,2}|[.][0-9]{1,2}|[0-9]{1,2}[.][0-9]{1,2})$"))
                    Amount -= Math.Round((Amount * Convert.ToDouble(TBDiscount.Text)) / 100, 2);

                LblAmount.Text = "Amount: " + Amount + " Rs"; 
            }
            else
                LblAmount.Text = "Amount: 0 Rs";
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TBDiscount_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(TBLiter.Text, "^[0-9]*[.]{0,1}[0-9]{1,2}$"))
            {
                double Amount = Math.Round(Convert.ToDouble(Inventory.GetRate(CBType.Text)) * Convert.ToDouble(TBLiter.Text), 2);
                if (Regex.IsMatch(TBDiscount.Text, "^([0-9]{1,2}|[.][0-9]{1,2}|[0-9]{1,2}[.][0-9]{1,2})$"))
                    Amount -= Math.Round((Amount * Convert.ToDouble(TBDiscount.Text)) / 100, 2);
                
                LblAmount.Text = "Amount: " + Amount + " Rs";
            }
            else
                LblAmount.Text = "Amount: 0 Rs";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}