using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PetrolPump
{
    public partial class AddCompanyForm : Form
    {
        public AddCompanyForm()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (TBName.Text.Trim().Length == 0)
            {
                TBName.BackColor = Color.FromArgb(255, 207, 207);
                return;
            }

            else
            {
                TBName.BackColor = Color.White;
            }

            if (MessageBox.Show("Add New Company:\n\nName: " + TBName.Text + "\nPhone: " + TBNumber.Text + "\nEmail: " + TBEmail.Text, "Confirm Operation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            
            MySqlFunctions Func = new MySqlFunctions();

            if (Func.NonReturnQuery("insert into companies set Name='" + TBName.Text + "', Number='" + TBNumber.Text + "', Email='" + TBEmail.Text + "'"))
            {
                int InsertID = Func.ScalarInt("select LAST_INSERT_ID();");
                Company.Add(InsertID, TBName.Text, TBNumber.Text, TBEmail.Text, new Vehicle());

                MessageBox.Show("Company added successfully", "Operation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TBName.Text = TBNumber.Text = TBEmail.Text = "";
            }
            else
                MessageBox.Show("Company not added. Company name not available", "Operation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Func.Dest();

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
}
