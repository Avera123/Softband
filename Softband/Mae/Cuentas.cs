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

namespace Softband.Mae
{
    public partial class Cuentas : Form
    {
        Account newAccount = new Account();
        DaoAccount DaoAccount = new DaoAccount();
        GenericQuerys GenericQuerys = new GenericQuerys();
        List<Bank> ListBanks = new List<Bank>();


        public Cuentas()
        {
            InitializeComponent();
            FillCbBanks();
            getAllAccounts();
        }

        public void FillCbBanks()
        {
            cbBancos.DataSource = null;
            ListBanks = GenericQuerys.getAllBanks();

            cbBancos.DataSource = ListBanks;
            cbBancos.ValueMember = "Id";
            cbBancos.DisplayMember = "Name";            
        }

        public void getAllAccounts()
        {
            List<Account> Accounts = new List<Account>();

            listView1.Clear();

            Accounts = DaoAccount.getAllAccounts();            

            foreach (Account _account in Accounts)
            {
                string active = "";
                if (_account.Active) { active = "ACTIVO"; } else { active = "INACTIVO"; };
                ListViewItem lista = new ListViewItem(_account.Id.ToString() + " | " + _account.Code.ToString() + " | " + _account.Name.ToString() + " | ESTADO* " + active);
                listView1.Items.Add(lista);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int idBank = cbBancos.SelectedIndex + 1;
                int typeAccount = cbTypeAccount.SelectedIndex;

                if (idBank < 0) { idBank = 1; }
                if (typeAccount < 0) { typeAccount = 1; }
                
                if (txtNameAccount.Text.Trim() != "" &&
                txtCodeAccount.Text.Trim() != "" &&
                txtDescriptionAccount.Text.Trim() != "" &&
                txtAmount.Text.Trim()!="")
                {
                    newAccount.Code = txtCodeAccount.Text.Trim();
                    newAccount.Name = txtNameAccount.Text.Trim();
                    newAccount.IdBank = idBank;
                    newAccount.Description = txtDescriptionAccount.Text.Trim();
                    newAccount.Type = typeAccount;
                    newAccount.Active = ckbActive.Checked;
                    try
                    {
                        newAccount.Amount = Convert.ToDouble(txtAmount.Text.Trim().Replace("$",""));
                        DaoAccount.insertAccount(newAccount);
                        getAllAccounts();
                        MessageBox.Show("Cuenta guardada:\n" + newAccount.Name,
                            "Información",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al convertir campo de Monto inicial\n:"+ex.Message, "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Campos obligatorios:\n* Código\n* Nombre\n* Descripción\n* Monto inicial",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message,
                    "Error al insertar",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodeAccount.Text.Trim() != "")
                {
                    if (DaoAccount.ExistAccount(txtCodeAccount.Text.Trim()))
                    {
                        newAccount = DaoAccount.selectAccount(txtCodeAccount.Text.Trim());

                        txtCodeAccount.Text = newAccount.Code.Trim();
                        txtNameAccount.Text = newAccount.Name.Trim();
                        txtDescriptionAccount.Text = newAccount.Description;
                        ckbActive.Checked = newAccount.Active;
                        cbBancos.SelectedIndex = newAccount.IdBank-1;
                        cbTypeAccount.SelectedIndex = newAccount.Type;
                        txtAmount.Text = newAccount.Amount.ToString("C");
                    }
                    else
                    {
                        btnClear_Click(null, null);
                        MessageBox.Show("Cuenta no existente",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    btnClear_Click(null, null);
                    MessageBox.Show("El Campo Código no debe estar vacío",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
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
            this.txtCodeAccount.Text = "";
            this.txtNameAccount.Text = "";
            this.txtDescriptionAccount.Text = "";
            this.cbBancos.SelectedIndex = 0;
            this.cbTypeAccount.SelectedIndex = 1;
            this.ckbActive.Checked = false;
            this.txtAmount.Text= "$0.00";

            getAllAccounts();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Realmente desea Eliminar esta banda?",
                    "Confirmación",
                    MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (txtCodeAccount.Text.Trim() != "")
                    {
                        DaoAccount.deleteAccount(txtCodeAccount.Text.Trim());
                        btnClear_Click(null, null);
                        getAllAccounts();
                        MessageBox.Show("Cuenta Eliminada Correctamente.",
                            "Información",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Campos obligatorios:\n*Código",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                else if (result == DialogResult.No)
                {
                    btnClear_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar Cuenta:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Cuentas_Load(object sender, EventArgs e)
        {

        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            //Double valor = Double.Parse(txtAmount.Text.Trim());
            //txtAmount.Text = valor.ToString("C");
        }
    }
}
