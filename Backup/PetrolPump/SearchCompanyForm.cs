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
    public partial class SearchCompanyForm : Form
    {
        MySqlFunctions Func;

        public SearchCompanyForm()
        {
            InitializeComponent();
        }

        private void SearchCompany()
        {
            DGVSearchCompany.Rows.Clear();
            string Query = "select * from companies where ID like '%" + TBID.Text + "%' and Name like '%" + TBName.Text + "%' and Number like '%" + TBNumber.Text + "%' and Email like '%" + TBEmail.Text + "%' order by " + CBOrderBy.Text + " " + (RBAsc.Checked ? "asc" : "desc");
            MySql.Data.MySqlClient.MySqlDataReader Reader = Func.SelectQuery(Query);
            while (Reader.Read())
                DGVSearchCompany.Rows.Add(Reader["ID"].ToString(), Reader["Name"].ToString(), Reader["Number"].ToString(), Reader["Email"].ToString());
            Reader.Close();
        }

        private void SearchCompanyForm_Load(object sender, EventArgs e)
        {
            Func = new MySqlFunctions();
            CBOrderBy.SelectedIndex = 0;
            SearchCompany();

            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }

        private void TBName_TextChanged(object sender, EventArgs e)
        {
            SearchCompany();
        }

        private void TBNumber_TextChanged(object sender, EventArgs e)
        {
            SearchCompany();
        }

        private void TBEmail_TextChanged(object sender, EventArgs e)
        {
            SearchCompany();
        }

        private void SearchCompanyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Func.Dest();
        }

        private void TBID_TextChanged(object sender, EventArgs e)
        {
            SearchCompany();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RBAsc_CheckedChanged(object sender, EventArgs e)
        {
            SearchCompany();
        }
    }
}
