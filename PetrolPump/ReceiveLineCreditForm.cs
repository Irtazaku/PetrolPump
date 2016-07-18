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
    public partial class ReceiveLineCreditForm : Form
    {
        int CustomerID;
        DateTime ReceivingTime;
        double[] AmountReceiving;
        double TotalAmountReceived;
        List<int> SelectedRows;

        public ReceiveLineCreditForm()
        {
            InitializeComponent();
        }

        private void ReceiveLineCreditForm_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
            
            RBNumber.Checked = true;

            foreach (int ID in LineCustomer.ID)
            {
                CBID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBID.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBID.Items.Add(ID + "");
            }

            foreach (string Name in LineCustomer.Number)
            {
                CBNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBNumber.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBNumber.Items.Add(Name + "");
            }

            if (CBID.Items.Count > 0)
                CBID.SelectedIndex = 0;
            if (CBNumber.Items.Count > 0)
                CBNumber.SelectedIndex = 0;
            LblAmount.Text = "Amount: 0 Rs";
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            TotalAmountReceived = 0;
            LblAmount.Text = "Amount: 0 Rs";
            DGVReceiveLineCredit.Rows.Clear();
            MySqlFunctions Func = new MySqlFunctions();

            if (RBNumber.Checked)
                CustomerID = Func.ScalarInt("select ID from linecustomers where vehiclenumber='" + CBNumber.Text + "'");
            else
                CustomerID = Convert.ToInt32(CBID.Text);

            MySqlDataReader CreditHistory = Func.SelectQuery("select linecredit.ID, Type, Liter, Rate, linecredit.Amount as TotalAmount, linecredit.datetime,sum(COALESCE(linecreditreceived.Amount,0)) as AmountReceived,linecredit.Amount-sum(COALESCE(linecreditreceived.Amount,0)) as AmountReceivable from linecredit left join linecreditreceived on linecredit.ID = linecreditreceived.LineCreditID where CustomerID='" + CustomerID + "'  group by linecredit.ID having AmountReceivable >0");

            while (CreditHistory.Read())
            {
                DGVReceiveLineCredit.Rows.Add(false, CreditHistory["TotalAmount"].ToString(), Math.Round(Convert.ToDouble(CreditHistory["AmountReceived"]), 2), Math.Round(Convert.ToDouble(CreditHistory["AmountReceivable"]), 2), Math.Round(Convert.ToDouble(CreditHistory["AmountReceivable"]), 2), CreditHistory["DateTime"].ToString(), CreditHistory["Type"].ToString(), CreditHistory["Liter"].ToString(), CreditHistory["Rate"].ToString(), CreditHistory["ID"].ToString());
            }
            CreditHistory.Close();

            AmountReceiving = new double[DGVReceiveLineCredit.Rows.Count];
            SelectedRows = new List<int>(DGVReceiveLineCredit.Rows.Count);

            Func.Dest();
        }

        private void RBNumber_CheckedChanged(object sender, EventArgs e)
        {
            CBNumber.Enabled = RBNumber.Checked;
            CBID.Enabled = !RBNumber.Checked;
        }

        private void BtnReceive_Click(object sender, EventArgs e)
        {
            if (SelectedRows.Count == 0)
                return;

            foreach (int Row in SelectedRows)
            {
                if (DGVReceiveLineCredit.Rows[Row].Cells[4].Style.BackColor == Color.FromArgb(255, 207, 207))
                {
                    MessageBox.Show("One or more selected row contains invalid format of receiving amount", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (MessageBox.Show("Receive Line Credit:\n\nAmount Receiving: " + AmountReceiving.Sum() + " Rs\nTotal Records: " + SelectedRows.Count, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            ReceivingTime = DateTime.Now;
            MySqlFunctions Func = new MySqlFunctions();

            foreach (int Row in SelectedRows)
            {
                Func.NonReturnQuery("insert into linecreditreceived set amount='" + DGVReceiveLineCredit.Rows[Row].Cells[4].Value.ToString() + "', datetime='" + ReceivingTime.ToString("yyyy-MM-dd HH:mm:ss") + "', LineCreditID='" + DGVReceiveLineCredit.Rows[Row].Cells[9].Value.ToString() + "', CashierID='" + MySqlFunctions.CashierID + "'");
                TotalAmountReceived += Convert.ToDouble(DGVReceiveLineCredit.Rows[Row].Cells[4].Value.ToString());
            }

            Func.Dest();

            if (CheckBoxPrint.Checked)
            {
                PrintDialog PDialog = new PrintDialog();
                PrintDocument PDocument = new PrintDocument();
                PrintController PController = new StandardPrintController();
                PDialog.Document = PDocument;
                PDocument.PrintController = PController;
                PDocument.PrinterSettings.PrinterName = Inventory.PrinterName;
                PDocument.PrintPage += new PrintPageEventHandler(PDocument_PrintPage);
                PDocument.Print();
            }

            MessageBox.Show("Line Credit successfully received", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            BtnSelect_Click(sender, e);
        }

        private void PDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            MySqlFunctions Func = new MySqlFunctions();
            string CustomerName = Func.ScalarString("select Name from linecustomers where ID='" + CustomerID + "'");

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
            PGraphics.DrawString("LINE CREDIT RECEIVED", new Font(FontName, 14), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("LINE CREDIT RECEIVED", new Font(FontName, 14)).Width) / 2), Y + Offset));
            Offset += 30;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            Offset += 8;
            PGraphics.DrawString("Cashier: " + MySqlFunctions.CashierName, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X + (MaxX - PGraphics.MeasureString("Cashier: " + MySqlFunctions.CashierName, new Font(FontName, 12)).Width), Y + Offset));
            PGraphics.DrawString("Customer Name: " + CustomerName, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            Offset += 25;
            string VehicleNumber = (RBNumber.Checked) ? CBNumber.Text : Func.ScalarString("select VehicleNumber from linecustomers where id='" + CBID.Text + "'");
            PGraphics.DrawString("Vehicle Number: " + VehicleNumber, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            Offset += 25;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            Offset += 15;

            double AmountReceivable = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT Coalesce(SUM( AmountReceivable ),0)  FROM ( SELECT linecredit.Amount - SUM( COALESCE( linecreditreceived.Amount, 0 ) ) AS AmountReceivable FROM linecredit LEFT JOIN linecreditreceived ON linecredit.ID = linecreditreceived.linecreditID WHERE linecredit.CustomerID = '" + CustomerID + "' GROUP BY linecredit.id ) AS Temp")), 2);
            PGraphics.DrawString("Amount Received: " + TotalAmountReceived + " Rs", new Font(FontName, 14, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            Offset += 35; 
            PGraphics.DrawString("Amount Receivable: " + AmountReceivable + " Rs", new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));

            Offset += 30;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            Offset += 5;
            PGraphics.DrawString("THANK YOU!", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("THANK YOU!", new Font(FontName, 12, FontStyle.Bold)).Width) / 2), Y + Offset));
            Offset += 23;
            PGraphics.DrawString(ReceivingTime.ToString("F"), new Font(FontName, 10), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString(ReceivingTime.ToString("F"), new Font(FontName, 10)).Width) / 2), Y + Offset));
            Offset += 20;
            PGraphics.FillRectangle(new SolidBrush(Color.Black), X, Y + Offset, MaxX, 2);
            Offset += 5;
            PGraphics.DrawString("Software Developed By: Alphasoft - 03363356517", new Font(FontName, 9), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("Software Developed By: Alphasoft - 03363356517", new Font(FontName, 9)).Width) / 2), Y + Offset));
        }

        private void DGVReceiveLineCredit_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 4)
            {
                if (Regex.IsMatch(DGVReceiveLineCredit.Rows[e.RowIndex].Cells[4].EditedFormattedValue.ToString(), "^[0-9]*[.]{0,1}[0-9]{1,2}$"))
                {
                    DGVReceiveLineCredit.Rows[e.RowIndex].Cells[4].Style.SelectionBackColor = Color.White;
                    DGVReceiveLineCredit.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.White;
                    if ((bool)DGVReceiveLineCredit.Rows[e.RowIndex].Cells[0].EditedFormattedValue == true)
                    {
                        AmountReceiving[e.RowIndex] = Convert.ToDouble(DGVReceiveLineCredit.Rows[e.RowIndex].Cells[4].EditedFormattedValue);
                    }
                }
                else
                {
                    AmountReceiving[e.RowIndex] = 0;
                    DGVReceiveLineCredit.Rows[e.RowIndex].Cells[4].Style.SelectionBackColor = Color.FromArgb(255, 207, 207);
                    DGVReceiveLineCredit.Rows[e.RowIndex].Cells[4].Style.BackColor = Color.FromArgb(255, 207, 207);
                }

                LblAmount.Text = "Amount: " + AmountReceiving.Sum() + " Rs";
            }
        }

        private void DGVReceiveLineCredit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex == 0)
            {
                if ((bool)DGVReceiveLineCredit.Rows[e.RowIndex].Cells[0].EditedFormattedValue == true)
                {
                    if (DGVReceiveLineCredit.Rows[e.RowIndex].Cells[4].Style.BackColor != Color.FromArgb(255, 207, 207))
                        AmountReceiving[e.RowIndex] = Convert.ToDouble(DGVReceiveLineCredit.Rows[e.RowIndex].Cells[4].Value);
                    SelectedRows.Add(e.RowIndex);
                    DGVReceiveLineCredit.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(233, 234, 242);
                }
                else
                {
                    AmountReceiving[e.RowIndex] = 0;
                    SelectedRows.Remove(e.RowIndex);
                    DGVReceiveLineCredit.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }

                LblAmount.Text = "Amount: " + AmountReceiving.Sum() + " Rs";
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGVReceiveLineCredit_SelectionChanged(object sender, EventArgs e)
        {
            DGVReceiveLineCredit.ClearSelection();
        }
    }
}