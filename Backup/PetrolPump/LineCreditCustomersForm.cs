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
    public partial class LineCreditCustomersForm : Form
    {
        public LineCreditCustomersForm()
        {
            InitializeComponent();
        }

        private void BtnAddCustomer_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("AddLineCreditCustomerForm"))
                new AddLineCreditCustomerForm().Show();
        }

        private void BtnEditCustomer_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("EditLineCreditCustomerForm"))
                new EditLineCreditCustomerForm().Show();
        }

        private void BtnSearchCustomer_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("SearchLineCustomerForm"))
                new SearchLineCustomerForm().Show();
        }

        private void BtnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (!Forms.IsOpened("DeleteLineCreditCustomerForm"))
                new DeleteLineCreditCustomerForm().Show();
        }
    }
}