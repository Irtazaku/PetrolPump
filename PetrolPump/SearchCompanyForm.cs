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
            string Query = "select * from companies where ID like '%" + CBID.Text + "%' and Name like '%" + CBNAME.Text + "%' and Number like '%" + CBNUMBER.Text + "%' and Email like '%" + CBEMAIL.Text + "%' order by " + CBOrderBy.Text + " " + (RBAsc.Checked ? "asc" : "desc");
            MySql.Data.MySqlClient.MySqlDataReader Reader = Func.SelectQuery(Query);
            while (Reader.Read())
                DGVSearchCompany.Rows.Add(Reader["ID"].ToString(), Reader["Name"].ToString(), Reader["Number"].ToString(), Reader["Email"].ToString());
            Reader.Close();
        }

        private void SearchCompanyForm_Load(object sender, EventArgs e)
        {
            Func = new MySqlFunctions();
            if (CBOrderBy.Items.Count > 0)
            CBOrderBy.SelectedIndex = 0;
            SearchCompany();

            //this.MinimumSize = this.Size;
            //this.MaximumSize = this.Size;
            foreach (string Name in Company.Name)
            {
                CBNAME.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBNAME.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBNAME.Items.Add(Name);
            }
            if (CBNAME.Items.Count > 0)
                CBNAME.SelectedIndex = 0;
            foreach (string Number in Company.Number)
            {
                CBNUMBER.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBNUMBER.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBNUMBER.Items.Add(Number);
            }
            if (CBNUMBER.Items.Count > 0)
                CBNUMBER.SelectedIndex = 0;
            foreach (int ID in Company.ID)
            {
                CBID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBID.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBID.Items.Add(ID);
            }
            if (CBID.Items.Count > 0)
                CBID.SelectedIndex = 0;
            foreach (string Email in Company.Email)
            {
                CBEMAIL.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                CBEMAIL.AutoCompleteSource = AutoCompleteSource.ListItems;
                CBEMAIL.Items.Add(Email);
            }
            if (CBEMAIL.Items.Count > 0)
                CBEMAIL.SelectedIndex = 0;
        }

        private void TBName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TBNumber_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TBEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchCompanyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Func.Dest();
        }

        private void TBID_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RBAsc_CheckedChanged(object sender, EventArgs e)
        {
            SearchCompany();
        }

        private void CBID_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchCompany();
        }

        private void CBNAME_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchCompany();
        }

        private void CBNUMBER_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchCompany();
        }

        private void CBEMAIL_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchCompany();
        }
    }
}
