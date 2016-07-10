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

        public ReceiveCreditForm()
        {
            InitializeComponent();
        }

        private void ReceiveCreditForm_Load(object sender, EventArgs e)
        {
            RBCashPayment.Checked = true;

            foreach (string Name in Company.Name)
                CBName.Items.Add(Name + "");

            CBName.SelectedIndex = 0;

            foreach (string Name in Accounts.BankName)
                CBBankName.Items.Add(Name + "");

            CBBankName.SelectedIndex = 0;
        }

        private void BtnReceive_Click(object sender, EventArgs e)
        {
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

            if (MessageBox.Show("Receive Credit:\n\nCompany Name: " + CBName.Text + "\nAmount Receiving: " + TBAmount.Text + " Rs", "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            ReceivingTime = DateTime.Now;

            double TotalAmountReceived = Convert.ToDouble(TBAmount.Text);

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
                            Func2.NonReturnQuery("insert into vehiclecashreceived set amount='" + AmountReceiving + "', datetime='" + ReceivingTime.ToString("yyyy-MM-dd HH:mm:ss") + "', VehicleCashID='" + ID + "',Type='Cheque',AccountNumber='" + CBAccountNo.Text + "',ChequeNumber='" + TBChequeNo.Text + "',Bank='" + CBBankName.Text + "', CashierID='" + MySqlFunctions.CashierID + "'");
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
                PDocument.PrinterSettings.PrinterName = "Send To OneNote 2010";
                PDocument.PrintPage += new PrintPageEventHandler(PDocument_PrintPage);
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
            PGraphics.DrawString("CREDIT RECEIVED", new Font(FontName, 14), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("CREDIT RECEIVED", new Font(FontName, 14)).Width) / 2), Y + Offset));
            Offset += 30;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            Offset += 10;
            PGraphics.DrawString("Cashier: " + MySqlFunctions.CashierName, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X + (MaxX - PGraphics.MeasureString("Cashier: " + MySqlFunctions.CashierName, new Font(FontName, 12)).Width), Y + Offset));
            PGraphics.DrawString("Company Name: " + CBName.Text, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            Offset += 25;
            PGraphics.DrawString("Payment Type: " + (RBCashPayment.Checked ? "Cash" : "Cheque"), new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
            if (RBChequePayment.Checked)
            {
                Offset += 25;
                string AccountNo = CBAccountNo.Text.Substring(0, 3);
                for (int i = 3; i < CBAccountNo.Text.Length - 3; i++)
                    AccountNo += "x";
                AccountNo += CBAccountNo.Text.Substring(AccountNo.Length, 3);
                string ChequeNo = TBChequeNo.Text.Substring(0, 2);
                for (int i = 2; i < TBChequeNo.Text.Length - 2; i++)
                    ChequeNo += "x";
                ChequeNo += TBChequeNo.Text.Substring(ChequeNo.Length, 2);
                PGraphics.DrawString("Account No: " + AccountNo, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X, Y + Offset));
                PGraphics.DrawString("Cheque No: " + ChequeNo, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("Cheque No: " + ChequeNo, new Font(FontName, 12)).Width) / 2), Y + Offset));
                PGraphics.DrawString("Bank Name: " + CBBankName.Text, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(X + MaxX - PGraphics.MeasureString("Bank Name: " + CBBankName.Text, new Font(FontName, 12)).Width, Y + Offset));
            }
            Offset += 25;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            Offset += 5;

            MySqlFunctions Func = new MySqlFunctions();

            MySqlDataReader CreditSaleID = Func.SelectQuery("select CreditID from creditreceived where DateTime='" + ReceivingTime.ToString("yyyy-MM-dd HH:mm:ss") + "'");

            int BorderStart = Offset;
            if (CreditSaleID.Read())
            {
                PGraphics.DrawString("CREDIT SALE", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("CREDIT SALE", new Font(FontName, 12, FontStyle.Bold)).Width) / 2), Y + Offset));
                Offset += 22;
                PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
                Offset += 10;

                BorderStart = Offset;
                Offset += 5;

                PGraphics.DrawString("S. No", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(5, Y + Offset));
                PGraphics.DrawString("Date", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(60, Y + Offset));
                PGraphics.DrawString("V. No", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(150, Y + Offset));
                PGraphics.DrawString("Type", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(250, Y + Offset));
                PGraphics.DrawString("Liter", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(345, Y + Offset));
                PGraphics.DrawString("Rate", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(410, Y + Offset));
                PGraphics.DrawString("Total Amt.", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(475, Y + Offset));
                PGraphics.DrawString("Received", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(575, Y + Offset));
                PGraphics.DrawString("Receivable", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(675, Y + Offset));
                Offset += 25;

                do
                {
                    MySqlFunctions Func2 = new MySqlFunctions();

                    MySqlDataReader CreditSaleReceived = Func2.SelectQuery("select credit.ID, vehicles.Number, credit.Type, Liter, Rate, credit.Amount as TotalAmount, credit.DateTime,sum(COALESCE(creditreceived.Amount,0)) as AmountReceived,credit.Amount-sum(COALESCE(creditreceived.Amount,0)) as AmountReceivable from credit left join creditreceived on credit.ID = creditreceived.CreditID left join vehicles on vehicles.id=credit.vehicleid where creditreceived.CreditID='" + CreditSaleID["CreditID"] + "' group by credit.ID limit 1");

                    CreditSaleReceived.Read();

                    string ID = CreditSaleReceived["ID"].ToString();
                    string VehicleNumber = CreditSaleReceived["Number"].ToString();
                    double TotalAmount = Math.Round(Convert.ToDouble(CreditSaleReceived["TotalAmount"].ToString()), 2);
                    double AmountReceivable = Math.Round(Convert.ToDouble(CreditSaleReceived["AmountReceivable"].ToString()), 2);
                    double AmountReceived = Math.Round(Convert.ToDouble(CreditSaleReceived["AmountReceived"].ToString()), 2);
                    string Type = CreditSaleReceived["Type"].ToString();
                    string Liter = CreditSaleReceived["Liter"].ToString();
                    string Rate = CreditSaleReceived["Rate"].ToString();
                    string Date = CreditSaleReceived["DateTime"].ToString();

                    PGraphics.DrawString(ID, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(5, Y + Offset));
                    PGraphics.DrawString(Convert.ToDateTime(Date).ToString("dd-MM-yy"), new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(60, Y + Offset));
                    PGraphics.DrawString(VehicleNumber, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(150, Y + Offset));
                    PGraphics.DrawString(Type, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(250, Y + Offset));
                    PGraphics.DrawString(Liter, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(345, Y + Offset));
                    PGraphics.DrawString(Rate, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(410, Y + Offset));
                    PGraphics.DrawString(TotalAmount+"", new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(475, Y + Offset));
                    PGraphics.DrawString(AmountReceived + "", new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(575, Y + Offset));
                    PGraphics.DrawString(AmountReceivable + "", new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(675, Y + Offset));
                    Offset += 25;

                    CreditSaleReceived.Close();
                    Func2.Dest();
                }
                while (CreditSaleID.Read());

                PGraphics.DrawLine(new Pen(Color.Black), new Point(X, BorderStart), new Point(MaxX, BorderStart));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(X, BorderStart + 25), new Point(MaxX, BorderStart + 25));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(X, BorderStart), new Point(X, Offset));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(55, BorderStart), new Point(55, Offset));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(145, BorderStart), new Point(145, Offset));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(245, BorderStart), new Point(245, Offset));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(340, BorderStart), new Point(340, Offset));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(405, BorderStart), new Point(405, Offset));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(470, BorderStart), new Point(470, Offset));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(570, BorderStart), new Point(570, Offset));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(670, BorderStart), new Point(670, Offset));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(X, Offset), new Point(MaxX, Offset));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(MaxX, BorderStart), new Point(MaxX, Offset));

                Offset += 10;
                PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
                Offset += 5;
            }

            CreditSaleID.Close();

            CreditSaleID = Func.SelectQuery("select VehicleCashID from vehiclecashreceived where Datetime='" + ReceivingTime.ToString("yyyy-MM-dd HH:mm:ss") + "'");

            if (CreditSaleID.Read())
            {
                PGraphics.DrawString("VEHICLE CASH", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("VEHICLE CASH", new Font(FontName, 12, FontStyle.Bold)).Width) / 2), Y + Offset));
                Offset += 22;
                PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
                Offset += 10;

                BorderStart = Offset;
                Offset += 5;
                
                PGraphics.DrawString("S. No", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(5, Y + Offset));
                PGraphics.DrawString("Date", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(100, Y + Offset));
                PGraphics.DrawString("Rec. Name", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(200, Y + Offset));
                PGraphics.DrawString("Total Amt.", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(450, Y + Offset));
                PGraphics.DrawString("Received", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(560, Y + Offset));
                PGraphics.DrawString("Receivable", new Font(FontName, 12, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(670, Y + Offset));
                Offset += 25;

                do
                {
                    MySqlFunctions Func2 = new MySqlFunctions();

                    MySqlDataReader VehicleCashReceived = Func2.SelectQuery("select vehiclecash.ID, vehiclecash.Amount as TotalAmount,sum(COALESCE(vehiclecashreceived.Amount,0)) as AmountReceived, vehiclecash.DateTime,vehiclecash.Amount-sum(COALESCE(vehiclecashreceived.Amount,0)) as AmountReceivable,vehiclecash.ReceiverName from vehiclecash left join vehiclecashreceived on vehiclecash.ID = vehiclecashreceived.vehiclecashID where vehiclecashreceived.vehiclecashid='" + CreditSaleID["VehicleCashID"] + "' group by vehiclecash.ID limit 1");

                    VehicleCashReceived.Read();

                    string ID = VehicleCashReceived["ID"].ToString();
                    string ReceiverName = VehicleCashReceived["ReceiverName"].ToString();
                    double TotalAmount = Math.Round(Convert.ToDouble(VehicleCashReceived["TotalAmount"].ToString()), 2);
                    double AmountReceived = Math.Round(Convert.ToDouble(VehicleCashReceived["AmountReceived"].ToString()), 2);
                    double AmountReceivable = Math.Round(Convert.ToDouble(VehicleCashReceived["AmountReceivable"].ToString()), 2);
                    string Date = VehicleCashReceived["DateTime"].ToString();

                    PGraphics.DrawString(ID, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(5, Y + Offset));
                    PGraphics.DrawString(Convert.ToDateTime(Date).ToString("dd-MM-yy"), new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(100, Y + Offset));
                    PGraphics.DrawString(ReceiverName, new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(200, Y + Offset));
                    PGraphics.DrawString(TotalAmount + "", new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(450, Y + Offset));
                    PGraphics.DrawString(AmountReceived + "", new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(560, Y + Offset));
                    PGraphics.DrawString(AmountReceivable + "", new Font(FontName, 12), new SolidBrush(Color.Black), new PointF(670, Y + Offset));
                    Offset += 25;

                    VehicleCashReceived.Close();
                    Func2.Dest();
                }
                while (CreditSaleID.Read());

                PGraphics.DrawLine(new Pen(Color.Black), new Point(X, BorderStart), new Point(MaxX, BorderStart));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(X, BorderStart + 25), new Point(MaxX, BorderStart + 25));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(X, BorderStart), new Point(X, Offset));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(95, BorderStart), new Point(95, Offset));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(195, BorderStart), new Point(195, Offset));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(445, BorderStart), new Point(445, Offset));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(555, BorderStart), new Point(555, Offset));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(665, BorderStart), new Point(665, Offset));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(X, Offset), new Point(MaxX, Offset));
                PGraphics.DrawLine(new Pen(Color.Black), new Point(MaxX, BorderStart), new Point(MaxX, Offset));
            }

            Func.Dest();

            Offset += 10;
            PGraphics.DrawString("Total Amount: Rs " + TBAmount.Text, new Font(FontName, 18, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("Total Amount: Rs " + TBAmount.Text, new Font(FontName, 18, FontStyle.Bold)).Width) / 2), Y + Offset));
            Offset += 37;
            PGraphics.DrawLine(DashedPen, X, Y + Offset, MaxX, Y + Offset);
            Offset += 10;
            PGraphics.DrawString("THANK YOU!", new Font(FontName, 14, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("THANK YOU!", new Font(FontName, 14, FontStyle.Bold)).Width) / 2), Y + Offset));
            Offset += 25;
            PGraphics.DrawString(ReceivingTime.ToString("F"), new Font(FontName, 10), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString(ReceivingTime.ToString("F"), new Font(FontName, 10)).Width) / 2), Y + Offset));
            Offset += 25;
            PGraphics.FillRectangle(new SolidBrush(Color.Black), X, Y + Offset, MaxX, 2);
            Offset += 10;
            PGraphics.DrawString("Software Developed By: Alphasoft - 03363356517, 03462811866, 03338287634", new Font(FontName, 10), new SolidBrush(Color.Black), new PointF(X + ((MaxX - PGraphics.MeasureString("Software Developed By: Alphasoft - 03363356517, 03462811866, 03338287634", new Font(FontName, 10)).Width) / 2), Y + Offset));
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CBName_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlFunctions Func = new MySqlFunctions();

            CompanyID = Func.ScalarInt("select ID from companies where name='" + CBName.Text + "'");

            double AmountReceivable = Math.Round(Convert.ToDouble(Func.ScalarString("SELECT Coalesce(SUM( AmountReceivable ),0)  FROM ( SELECT vehiclecash.Amount - SUM( COALESCE( vehiclecashreceived.Amount, 0 ) ) AS AmountReceivable FROM vehiclecash LEFT JOIN vehiclecashreceived ON vehiclecash.ID = vehiclecashreceived.vehiclecashID WHERE vehiclecash.CompanyID = '" + CompanyID + "' GROUP BY vehiclecash.id union all SELECT Coalesce(SUM( AmountReceivable ),0)  FROM ( SELECT credit.Amount - SUM( COALESCE( creditreceived.Amount, 0 ) ) AS AmountReceivable FROM credit LEFT JOIN creditreceived ON credit.ID = creditreceived.CreditID WHERE credit.CompanyID = '" + CompanyID + "' GROUP BY credit.id ) AS Temp ) AS Temp")), 2);
            LblAmount.Text = "Amount Receivable: " + AmountReceivable + " Rs";
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
            CBAccountNo.SelectedIndex = 0;
        }
    }
}
