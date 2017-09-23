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
    public partial class IngresosYEgresos : Form
    {
        public IngresosYEgresos()
        {
            InitializeComponent();
            FillCbAccounts();
            FillCbCategoriesMovements();
        }

        List<Account> ListAccount = new List<Account>();
        List<CategoryMovements> ListCategoriesMovements = new List<CategoryMovements>();
        GenericQuerys GenericQuerys = new GenericQuerys();
        DaoAccount DaoAccount = new DaoAccount();
        Account AccountIn = new Account();
        MovesMoney MovesMoney = new MovesMoney();
        MovementMoney MoveMoney = new MovementMoney();

        public void FillCbAccounts()
        {
            cbAccount.DataSource = null;
            ListAccount = GenericQuerys.getAllAccounts();

            cbAccount.DataSource = ListAccount;
            cbAccount.ValueMember = "Id";
            cbAccount.DisplayMember = "Name";
        }

        public void FillCbCategoriesMovements()
        {
            cbCatagoriaMovimiento.DataSource = null;
            ListCategoriesMovements = GenericQuerys.getAllCategoryMovements();

            cbCatagoriaMovimiento.DataSource = ListCategoriesMovements;
            cbCatagoriaMovimiento.ValueMember = "Id";
            cbCatagoriaMovimiento.DisplayMember = "Name";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.cbAccount.SelectedItem = 0;
            this.cbTipoMovimiento.SelectedItem = 0;
            this.cbCatagoriaMovimiento.SelectedItem = 0;
            this.txtAmount.Text = "0.00";
            this.txtDescription.Text = "";
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AccountIn = DaoAccount.selectAccountId(Convert.ToInt32(cbAccount.SelectedValue));
                
                if (AccountIn.Amount >= Convert.ToDouble(txtAmount.Text.Trim()))
                {
                    double ValueIn = 0;
                    if (cbTipoMovimiento.SelectedIndex == 0)
                    {
                        ValueIn = AccountIn.Amount + Convert.ToDouble(txtAmount.Text.Trim());
                    }
                    else
                    {
                        ValueIn = AccountIn.Amount - Convert.ToDouble(txtAmount.Text.Trim());
                    }

                    AccountIn.Amount = ValueIn;                    

                    MoveMoney.IdAccount = AccountIn.Id;
                    MoveMoney.IdCatMovement = Convert.ToInt32(cbCatagoriaMovimiento.SelectedValue);
                    MoveMoney.IdTypeMovement = cbTipoMovimiento.SelectedIndex;
                    MoveMoney.Amount = Convert.ToDouble(txtAmount.Text.Trim());
                    MoveMoney.Description = txtDescription.Text.Trim();
                    try
                    {
                        MovesMoney.insertMovementMoney(MoveMoney);
                        DaoAccount.insertAccount(AccountIn);
                        MessageBox.Show("Movimiento generado correctamente","Información del Sistema",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error al crear el movimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Fondos Insuficientes", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
    }
}
