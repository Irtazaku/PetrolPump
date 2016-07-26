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
    public partial class ReceiveCreditForm : Form
    {
        int CompanyID;
        DateTime ReceivingTime;
        double TotalAmountReceivable;

        public ReceiveCreditForm()
        {
            InitializeComponent();
        }

        private void ReceiveCreditForm_Load(object sender, EventArgs e)
        {
            RBCashPayment.Checked = true;

            foreach (string Name in Company.Name)
            {
                CBName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBName.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBName.Items.Add(Name + "");
            }

            if (CBName.Items.Count > 0)
                CBName.SelectedIndex = 0;

            foreach (string Name in Accounts.BankName)
                CBBankName.Items.Add(Name + "");

            if (CBBankName.Items.Count > 0)
                CBBankName.SelectedIndex = 0;
        }

        private void BtnReceive_Click(object sender, EventArgs e)
        {
            if (CBName.Items.Count == 0)
            {
                MessageBox.Show("No company selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (RBChequePayment.Checked)
            {
                if (CBBankName.Items.Count == 0)
                {
                    MessageBox.Show("No bank selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (CBAccountNo.Items.Count == 0)
                {
                    MessageBox.Show("No account selected", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            if (LblAmount.Text == "Amount Receivable: 0 Rs")
            {
                MessageBox.Show("Company has no amount due", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (RBChequePayment.Checked && CBAccountNo.Items.Count == 0)
            {
                MessageBox.Show("Bank has no account", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(TBAmount.Text, "^[0-9]*[.]{0,1}[0-9]{1,2}$"))
            {
                TBAmount.BackColor = Color.FromArgb(255, 207, 207);
                return;
            }
            else
            {
                TBAmount.BackColor = Color.White;
            }
            
            double TotalAmountReceived = Convert.ToDouble(TBAmount.Text);
            if (TotalAmountReceived > TotalAmountReceivable)
            {
                MessageBox.Show("Can not receive more than " + TotalAmountReceivable + " Rs", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Receive Credit:\n\nCompany Name: " + CBName.Text + "\nAmount Receiving: " + TBAmount.Text + " Rs", "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            ReceivingTime = DateTime.Now;

            MySqlFunctions Func = new MySqlFunctions();

            MySqlDataReader Reader = Func.SelectQuery("select * from ( Select credit.ID , credit.DateTime ,credit.Amount-sum(COALESCE(creditreceived.Amount,0)) as AmountReceivable ,'Credit' as Type from credit left join creditreceived on credit.ID = creditreceived.CreditID where credit.CompanyID='" + CompanyID + "' group by credit.id having AmountReceivable >0 union all Select vehiclecash.ID , vehiclecash.DateTime ,vehiclecash.Amount-sum(COALESCE(vehiclecashreceived.Amount,0)) as AmountReceivable ,'VehicleCash' as Type from vehiclecash left join vehiclecashreceived on vehiclecash.ID = vehiclecashreceived.vehiclecashID where vehiclecash.CompanyID='" + CompanyID + "' group by vehiclecash.id having AmountReceivable >0 ) as temp order by temp.DateTime asc");

            if (Reader.Read())
            {
                MySqlFunctions Func2 = new MySqlFunctions();
                do
                {
                    if (TotalAmountReceived == 0)
                        break;

                    double AmountReceivable = Math.Round(Convert.ToDouble(Reader["AmountReceivable"].ToString()), 2);
                    if (AmountReceivable == 0)
                        continue;
                    string ID = Reader["ID"].ToString();

                    double AmountReceiving = 0;

                    if (TotalAmountReceived >= AmountReceivable)
                        AmountReceiving = AmountReceivable;
                    else
                        AmountReceiving = TotalAmountReceived;

                    if (Reader["Type"].ToString() == "Credit")
                    {
                        if (RBCashPayment.Checked)
                            Func2.NonReturnQuery("insert into creditreceived set amount='" + AmountReceiving + "', datetime='" + ReceivingTime.ToString("yyyy-MM-dd HH:mm:ss") + "', CreditID='" + ID + "',Type='Cash', CashierID='" + MySqlFunctions.CashierID + "'");
                        else
                        {
                            Func2.NonReturnQuery("insert into creditreceived set amount='" + AmountReceiving + "', datetime='" + ReceivingTime.ToString("yyyy-MM-dd HH:mm:ss") + "', CreditID='" + ID + "',Type='Cheque',AccountID='" +Accounts.GetAccountID(CBBankName.Text, CBAccountNo.Text) + "',ChequeNumber='" + TBChequeNo.Text + "', CashierID='" + MySqlFunctions.CashierID + "'");
                            //Func2.NonReturnQuery("insert into accounthistory set accountid='" + Accounts.GetAccountID(CBBankName.Text,CBAccountNo.Text) + "', datetime='" + ReceivingTime.ToString("yyyy-MM-dd HH:mm:ss") + "', CreditID='" + ID + "',Type='Cheque',AccountNumber='" + CBAccountNo.Text + "',ChequeNumber='" + TBChequeNo.Text + "',Bank='" + CBBankName.Text + "', CashierID='" + MySqlFunctions.CashierID + "'");
                        }
                    }

                    else
                    {
                        if (RBCashPayment.Checked)
                            Func2.NonReturnQuery("insert into vehiclecashreceived set amount='" + AmountReceiving + "', datetime='" + ReceivingTime.ToString("yyyy-MM-dd HH:mm:ss") + "', VehicleCashID='" + ID + "',Type='Cash', CashierID='" + MySqlFunctions.CashierID + "'");
                        else
                            Func2.NonReturnQuery("insert into vehiclecashreceived set amount='" + AmountReceiving + "', datetime='" + ReceivingTime.ToString("yyyy-MM-dd HH:mm:ss") + "', VehicleCashID='" + ID + "',Type='Cheque',AccountID='" + Accounts.GetAccountID(CBBankName.Text, CBAccountNo.Text) + "', CashierID='" + MySqlFunctions.CashierID + "'");
                    }

                    TotalAmountReceived -= AmountReceiving;
                }
                while (Reader.Read());
                Func2.Dest();
            }
            Reader.Close();
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
                for (int i = 0; i < 3; i++)
                    PDocument.Print();
            }

            MessageBox.Show("Credit successfully received", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TBAmount.Text = "";
            RBCashPayment.Checked = true;
            TBChequeNo.Text = "";
            CBName_SelectedIndexChanged(sender, e);
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
            PGraphics.DrawString("CREDIT RECEIVED", new Font(FontName, 14), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("CREDIT RECEIVED", new Font(FontName, 14)).Width) / 2), Y + Offset));
            Offset += 30;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            Offset += 8;
            PGraphics.DrawString("Cashier: " + MySqlFunctions.CashierName, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X + (MaxX - PGraphics.MeasureString("Cashier: " + MySqlFunctions.CashierName, new Font(FontName, 12)).Width), Y + Offset));
            PGraphics.DrawString("Company Name: " + CBName.Text, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            Offset += 25;
            PGraphics.DrawString("Payment Type: " + (RBCashPayment.Checked ? "Cash" : "Cheque"), new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            if (RBChequePayment.Checked)
            {
                Offset += 25;
                string AccountNo = CBAccountNo.Text;
                if (CBAccountNo.Text.Length > 6)
                {
                    AccountNo = CBAccountNo.Text.Substring(0, 3);
                    for (int i = 3; i < CBAccountNo.Text.Length - 3; i++)
                        AccountNo += "x";
                    string Temp = new string(CBAccountNo.Text.ToCharArray().Reverse().ToArray());
                    Temp = Temp.Substring(0, 3);
                    AccountNo += new string(Temp.ToCharArray().Reverse().ToArray());
                }

                string ChequeNo = TBChequeNo.Text;
                if (TBChequeNo.Text.Length > 4)
                {
                    ChequeNo = TBChequeNo.Text.Substring(0, 3);
                    for (int i = 3; i < TBChequeNo.Text.Length - 2; i++)
                        ChequeNo += "x";
                    string Temp = new string(TBChequeNo.Text.ToCharArray().Reverse().ToArray());
                    Temp = Temp.Substring(0, 2);
                    ChequeNo += new string(Temp.ToCharArray().Reverse().ToArray());
                }

                PGraphics.DrawString("Account No: " + AccountNo, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
                PGraphics.DrawString("Cheque No: " + ChequeNo, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("Cheque No: " + ChequeNo, new Font(FontName, 12)).Width) / 2), Y + Offset));
                PGraphics.DrawString("Bank Name: " + CBBankName.Text, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X + MaxX - PGraphics.MeasureString("Bank Name: " + CBBankName.Text, new Font(FontName, 12)).Width, Y + Offset));
            }
            Offset += 25;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            if (RBChequePayment.Checked)
                Offset += 8;
            else
                Offset += 15;

            MySqlFunctions Func = new MySqlFunctions();
            double AmountReceivable = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT Coalesce(SUM( AmountReceivable ),0)  FROM ( SELECT vehiclecash.Amount - SUM( COALESCE( vehiclecashreceived.Amount, 0 ) ) AS AmountReceivable FROM vehiclecash LEFT JOIN vehiclecashreceived ON vehiclecash.ID = vehiclecashreceived.vehiclecashID WHERE vehiclecash.CompanyID = '" + CompanyID + "' GROUP BY vehiclecash.id union all SELECT Coalesce(SUM( AmountReceivable ),0)  FROM ( SELECT credit.Amount - SUM( COALESCE( creditreceived.Amount, 0 ) ) AS AmountReceivable FROM credit LEFT JOIN creditreceived ON credit.ID = creditreceived.CreditID WHERE credit.CompanyID = '" + CompanyID + "' GROUP BY credit.id ) AS Temp ) AS Temp")), 2);
            
            PGraphics.DrawString("Amount Received: " + TBAmount.Text + " Rs", new Font(FontName, 14, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            if (RBChequePayment.Checked)
                Offset += 28;
            else
                Offset += 35;
            PGraphics.DrawString("Amount Receivable: " + AmountReceivable + " Rs", new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));

            if (RBChequePayment.Checked)
                Offset += 25;
            else
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

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CBName_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlFunctions Func = new MySqlFunctions();

            CompanyID = Func.ScalarInt("select ID from companies where name='" + CBName.Text + "'");
            
            TotalAmountReceivable = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT Coalesce(SUM( AmountReceivable ),0)  FROM ( SELECT vehiclecash.Amount - SUM( COALESCE( vehiclecashreceived.Amount, 0 ) ) AS AmountReceivable FROM vehiclecash LEFT JOIN vehiclecashreceived ON vehiclecash.ID = vehiclecashreceived.vehiclecashID WHERE vehiclecash.CompanyID = '" + CompanyID + "' GROUP BY vehiclecash.id union all SELECT Coalesce(SUM( AmountReceivable ),0)  FROM ( SELECT credit.Amount - SUM( COALESCE( creditreceived.Amount, 0 ) ) AS AmountReceivable FROM credit LEFT JOIN creditreceived ON credit.ID = creditreceived.CreditID WHERE credit.CompanyID = '" + CompanyID + "' GROUP BY credit.id ) AS Temp ) AS Temp")), 2);
            LblAmount.Text = "Amount Receivable: " + TotalAmountReceivable + " Rs";
        }

        private void RBCashPayment_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = !RBCashPayment.Checked;
            if (RBCashPayment.Checked)
            {
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y - 141);
                this.Size = new Size(this.Size.Width, this.Size.Height - 141);
            }
            else
            {
                panel2.Location = new Point(panel2.Location.X, panel2.Location.Y + 141);
                this.Size = new Size(this.Size.Width, this.Size.Height + 141);
            }
        }

        private void CBBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            CBAccountNo.Items.Clear();
            List<string> AccountNumbers = Accounts.GetAccountNumbers(CBBankName.Text);
            foreach (string Number in AccountNumbers)
            {
                CBAccountNo.Items.Add(Number);
            }

            if (CBAccountNo.Items.Count > 0)
                CBAccountNo.SelectedIndex = 0;
        }
    }
}
