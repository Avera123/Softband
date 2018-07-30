using Softband.DataAccess.DaoEntities;
using Softband.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Softband.Generics
{
    public partial class RevertirFactura : Form
    {
        public RevertirFactura()
        {
            InitializeComponent();
        }

        DaoFact daoFact = new DaoFact();
        DaoAccount daoAccount = new DaoAccount();
        Invoice invoice = new Invoice();
        Account account = new Account();


        private void RevertirFactura_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtIdentification.Text.Trim() != "")
            {
                if (daoFact.ExistInvoice(txtIdentification.Text.Trim()))
                {
                    invoice = daoFact.getInvoice(txtIdentification.Text.Trim());
                    account = daoFact.selectAccountId(invoice.IdAccountIn);
                    account.Amount -= invoice.Amount;
                    invoice.Active = false;

                    DialogResult result = MessageBox.Show("¿Realmente desea Revertir esta Factura?", "Confirmación",
                   MessageBoxButtons.YesNoCancel);

                    daoFact.insertInvoice(invoice);
                    daoAccount.insertAccount(account);
                }
            }
        }
    }
}
