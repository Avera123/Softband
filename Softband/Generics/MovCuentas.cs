using Softband.DataAccess.DaoEntities;
using Softband.DataAccess.Generics;
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
    public partial class MovCuentas : Form
    {
        public MovCuentas()
        {
            InitializeComponent();
            FillCbAccountsOut();
            FillCbAccountsIn();
        }

        List<Account> ListAccount = new List<Account>();
        GenericQuerys GenericQuerys = new GenericQuerys();
        Account AccountIn = new Account();
        Account AccountOut = new Account();
        DaoAccount DaoAccount = new DaoAccount();

        public void FillCbAccountsOut()
        {
            cbAccountOut.DataSource = null;
            ListAccount = GenericQuerys.getAllAccounts();

            cbAccountOut.DataSource = ListAccount;
            cbAccountOut.ValueMember = "Id";
            cbAccountOut.DisplayMember = "Name";
        }

        public void FillCbAccountsIn()
        {
            cbAccountIn.DataSource = null;
            ListAccount = GenericQuerys.getAllAccounts();

            cbAccountIn.DataSource = ListAccount;
            cbAccountIn.ValueMember = "Id";
            cbAccountIn.DisplayMember = "Name";
        }

        private void MovCuentas_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AccountIn = DaoAccount.selectAccountId(Convert.ToInt32(cbAccountIn.SelectedValue));
                AccountOut = DaoAccount.selectAccountId(Convert.ToInt32(cbAccountOut.SelectedValue));

                if (AccountOut.Amount >= Convert.ToDouble(txtAmount.Text.Trim()))
                {
                    double ValueOut = AccountOut.Amount - Convert.ToDouble(txtAmount.Text.Trim());
                    double ValueIn = AccountIn.Amount + Convert.ToDouble(txtAmount.Text.Trim());

                    AccountOut.Amount = ValueOut;
                    AccountIn.Amount = ValueIn;
                    DaoAccount.insertAccount(AccountOut);
                    DaoAccount.insertAccount(AccountIn);

                    MessageBox.Show("Movimiento realizado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Fondos Insuficientes", "Error de Validación", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de la Cuenta:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cbAccountIn.SelectedIndex = 0;
            cbAccountOut.SelectedIndex = 0;
            this.txtAmount.Text= "0.00";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
