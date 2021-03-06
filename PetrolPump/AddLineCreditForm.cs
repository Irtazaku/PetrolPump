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
    public partial class AddLineCreditForm : Form
    {
        int InsertID;
        DateTime InsertTime;
        double Quantity;
        public AddLineCreditForm()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM dd yyyy hh mm ss";
            if (CBCustomer.Items.Count == 0)
            {
                MessageBox.Show("No vehicle selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CBType.Items.Count == 0)
            {
                MessageBox.Show("No fuel type selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool Errors = false;
            //validation for inventory
            MySqlFunctions Func = new MySqlFunctions();
            string Query = "select Quantity from inventory where Name like '%" + CBType.Text + "%'";
            MySql.Data.MySqlClient.MySqlDataReader Reader = Func.SelectQuery(Query);

            while (Reader.Read())
            {
                Quantity = double.Parse(Reader["Quantity"].ToString());
            }
            Reader.Close();

            if (!Regex.IsMatch(TBLiter.Text, "^[0-9]*[.]{0,1}[0-9]{1,2}$"))
            {
                TBLiter.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
            }
            else if (Quantity < double.Parse(TBLiter.Text))
            {
                TBLiter.BackColor = Color.FromArgb(255, 207, 207);
                Errors = true;
                MessageBox.Show("No enough quantity available", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (double.Parse(TBLiter.Text) <= 0)
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

            if (CBCustomer.Items.Count == 0)
            {
                MessageBox.Show("No customer selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Errors = true;
            }

            else if (CBType.Items.Count == 0)
            {
                MessageBox.Show("No fuel type selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Errors = true;
            }
            if (Errors)
                return;

            if (MessageBox.Show("Add Line Credit Entry For:\n\nVehicle Number: " + CBCustomer.Text + "\nFuel Type: " + CBType.Text + "\nLiter / Qty: " + TBLiter.Text + "\n" + LblRate.Text + "\nDiscount: " + (Regex.IsMatch(TBDiscount.Text, "^[0-9]{0,2}[.]{0,1}[0-9]{1,2}$") ? TBDiscount.Text : "0") + "%\n" + LblAmount.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            //MySqlFunctions Func = new MySqlFunctions();

            double Rate = Math.Round(Inventory.GetRate(CBType.Text),2);
            double Amount = Convert.ToDouble(Rate) * Convert.ToDouble(TBLiter.Text);
            if (Regex.IsMatch(TBDiscount.Text, "^([0-9]{1,2}|[.][0-9]{1,2}|[0-9]{1,2}[.][0-9]{1,2})$"))
                Amount -= Math.Round((Amount * Convert.ToDouble(TBDiscount.Text)) / 100, 2);

            InsertTime = dateTimePicker1.Value;
            int SlipNo = Func.ScalarInt("Select Value from settings where type='Slip Number'");

            if (CBMachine.Items.Count == 0)
                InsertID = Func.ScalarInt(@"
                                update inventory set quantity=quantity-" + TBLiter.Text + @"
                                where name='" + CBType.Text + @"';
                                update settings set Value=Value+1 where type='Slip Number';
                                insert into linecredit set 
                                ID='" + SlipNo + @"',
                                CustomerID='" + LineCustomer.ID[CBCustomer.SelectedIndex] + @"',
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
                                update settings set Value=Value+1 where type='Slip Number';
                                insert into linecredit set 
                                ID='" + SlipNo + @"',
                                CustomerID='" + LineCustomer.ID[CBCustomer.SelectedIndex] + @"',
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

            MessageBox.Show("Line credit sale recorded at ID: " + InsertID, "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TBLiter.Text = TBDiscount.Text="";
        }

        private void PDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics PGraphics = e.Graphics;

            Pen DashedPen = new Pen(Color.Black);
            DashedPen.DashStyle = DashStyle.Dash;
            DashedPen.DashPattern = new float[2] { 3, 3 };

            FontFamily FontName = this.Font.FontFamily;

            //int MaxX = 300;
            int MaxX = 720;
            int Y = 0;
            //int Offset = 0;
            int Offset = 70;
            int X = 30;
            //int Logo = 60;
            int MaxY = 333;

            //PGraphics.FillRectangle(new SolidBrush(Color.Black), X, MaxY, MaxX, 3);
            PGraphics.FillRectangle(new SolidBrush(Color.Black), X, Y + Offset, MaxX, 3);
            Offset += 10;
            PGraphics.DrawString("Line Credit Sale Receipt", new Font(FontName, 14), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("Line Credit Sale Receipt", new Font(FontName, 14)).Width) / 2), Y + Offset));
            Offset += 30;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX + X, Y + Offset);
            Offset += 8;
            PGraphics.DrawString("Slip Number: " + InsertID, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            PGraphics.DrawString("Cashier: " + MySqlFunctions.CashierName, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X + (MaxX - PGraphics.MeasureString("Cashier: " + MySqlFunctions.CashierName, new Font(FontName, 12)).Width), Y + Offset));
            Offset += 25;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX + X, Y + Offset);
            Offset += 20;
            PGraphics.DrawString("Vehicle Number: " + LineCustomer.Number[CBCustomer.SelectedIndex], new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            PGraphics.DrawString("Liter: " + TBLiter.Text + " L", new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X + 500, Y + Offset));
            Offset += 30;
            PGraphics.DrawString("Type: " + CBType.Text, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            PGraphics.DrawString(LblRate.Text, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X + 500, Y + Offset));
            if (Regex.IsMatch(TBDiscount.Text, "^([0-9]{1,2}|[.][0-9]{1,2}|[0-9]{1,2}[.][0-9]{1,2})$"))
            {
                float Len = PGraphics.MeasureString(LblRate.Text, new Font(FontName, 12)).Width;
                PGraphics.DrawString(" (Disc: " + TBDiscount.Text + "%)", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(X + 500 + Len, Y + Offset));
            }
            Offset += 30;
            PGraphics.DrawString(LblAmount.Text, new Font(FontName, 14, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(X + 500, Y + Offset));

            Offset += 30;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX + X, Y + Offset);
            Offset += 5;
            PGraphics.DrawString("THANK YOU!", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("THANK YOU!", new Font(FontName, 12, FontStyle.Bold)).Width) / 2), Y + Offset));
            Offset += 23;
            PGraphics.DrawString(InsertTime.ToString("F"), new Font(FontName, 10), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString(InsertTime.ToString("F"), new Font(FontName, 10)).Width) / 2), Y + Offset));
            Offset += 20;
            PGraphics.FillRectangle(new SolidBrush(Color.Black), X, Y + Offset, MaxX, 2);
            Offset += 5;
            PGraphics.DrawString("Software Developed By: Alphasoft - 03363356517", new Font(FontName, 9), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("Software Developed By: Alphasoft - 03363356517", new Font(FontName, 9)).Width) / 2), Y + Offset));
        }

        private void AddLineCreditForm_Load(object sender, EventArgs e)
        {
            foreach (string Name in LineCustomer.Number)
            {
                CBCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBCustomer.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBCustomer.Items.Add(Name);
            }

            foreach (string Item in Inventory.Name)
                CBType.Items.Add(Item);

            if (CBCustomer.Items.Count > 0)
                CBCustomer.SelectedIndex = 0;
            if (CBType.Items.Count > 0)
                CBType.SelectedIndex = 0;

            CBCustomer.MaxDropDownItems = 8;
            CBType.MaxDropDownItems = 8;
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
    }
}
