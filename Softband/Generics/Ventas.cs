using Softband.DataAccess.DaoEntities;
using Softband.DataAccess.Generics;
using Softband.Entities;
using Softband.Maestros;
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
    public partial class Ventas : Form
    {
        DaoClient DaoClient = new DaoClient();
        DaoProduct DaoProduct = new DaoProduct();
        DaoFact DaoFact = new DaoFact();
        DaoAccount DaoAccount = new DaoAccount();
        DaoBand DaoBand = new DaoBand();
        DaoItemInvoice DaoItemInvoice = new DaoItemInvoice();
        Client newClient = new Client();
        Product newProduct = new Product();
        Invoice newInvoice = new Invoice();
        InvoiceItemcs newItemInvoice = new InvoiceItemcs();
        List<Account> ListAccount = new List<Account>();
        List<Product> ListProducts = new List<Product>();
        List<Band> ListBands = new List<Band>();
        GenericQuerys GenericQuerys = new GenericQuerys();
        DataTable ds;
        Account AccountIn = new Account();

        public Ventas()
        {
            InitializeComponent();
            //Carga de ComboBoxs
            setCbAccounts();
            setCbBands();
            //Recuperacion de todos los poductos
            GetAllProducts();
            // Inicializacion de Variables
            rdName.Checked = true;
            lblConsecutivo.Text = "FAC" + GenericQuerys.Consecutivo().ToString();
            lblBanda.Text = "";
        }

        private void setCbAccounts()
        {
            cbAccountIn.DataSource = null;
            ListAccount = GenericQuerys.getAllAccounts();

            cbAccountIn.DataSource = ListAccount;
            cbAccountIn.ValueMember = "Id";
            cbAccountIn.DisplayMember = "Name";
        }

        private void setCbBands()
        {
            cbBandas.DataSource = null;
            ListBands = DaoBand.getAllBands();

            cbBandas.DataSource = ListBands;
            cbBandas.ValueMember = "Id";
            cbBandas.DisplayMember = "Name";
        }

        public void GetAllProducts()
        {
            ds = GenericQuerys.fillProductsDS();
            dgvProducts.DataSource = ds;
            dgvProducts.Columns[4].DefaultCellStyle.Format = "c";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIdentification.Text.Trim() != "")
                {
                    if (DaoClient.ExistClient(txtIdentification.Text.Trim()))
                    {
                        newClient = DaoClient.selectClient(txtIdentification.Text.Trim());
                        lblIDClient.Text = newClient.Id.ToString();
                        lblNameClient.Text = newClient.Name.Trim();
                        lblMail.Text = newClient.Email;
                        lblAddress.Text = newClient.Address;
                        lblPhone.Text = newClient.Phone;
                        lblCel.Text = newClient.MobilePhone;
                        lblCredit.Text = newClient.Credit.ToString("C");
                    }
                    else
                    {
                        btnClear_Click(null, null);
                        MessageBox.Show("Cliente no existente",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    btnClear_Click(null, null);
                    MessageBox.Show("El Campo Identificación no debe estar vacío",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del Cliente:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListado.Rows.Count >= 1)
                {
                    DialogResult result = MessageBox.Show("¿Realmente desea Limpiar la factura en curso?",
                    "Confirmación",
                    MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.Yes)
                    {
                        lblIDClient.Text = "---";
                        lblNameClient.Text = "---";
                        lblMail.Text = "---";
                        lblAddress.Text = "---";
                        lblPhone.Text = "---";
                        lblCel.Text = "---";
                        lblCredit.Text = "---";
                        lblConsecutivo.Text = "---";
                        dgvListado.Rows.Clear();
                        txtAmount.Text = "0.00";
                        lblBanda.Text = "---";
                    }
                }
                else
                {
                    lblIDClient.Text = "---";
                    lblNameClient.Text = "---";
                    lblMail.Text = "---";
                    lblAddress.Text = "---";
                    lblPhone.Text = "---";
                    lblCel.Text = "---";
                    lblCredit.Text = "---";
                    lblConsecutivo.Text = "---";
                    dgvListado.Rows.Clear();
                    txtAmount.Text = "0.00";
                    lblBanda.Text = "---";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar Banco:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            DaoClient.autoCompleteClientID(txtIdentification);
            DaoClient.autoCompleteClientName(txtNameCliente);
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string Filter = "";
            if (rdCode.Checked)
            {
                Filter = "CODIGO";
            }
            else if (rdName.Checked)
            {
                Filter = "NOMBRE";
            }
            else if (rdDescription.Checked)
            {
                Filter = "DESCRIPCION";
            }

            ds.DefaultView.RowFilter = (Filter + " like '%" + txtSearchProduct.Text.Trim() + "%'");
            dgvProducts.DataSource = ds.DefaultView;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CalcularTotal()
        {
            Double Total = 0;
            foreach (DataGridViewRow item in dgvListado.Rows)
            {
                if (Convert.ToDouble(item.Cells[3].Value) >= 1)
                {
                    Total += (Convert.ToDouble(item.Cells[2].Value) * Convert.ToDouble(item.Cells[3].Value));
                }
                else
                {
                    Total += (Convert.ToDouble(item.Cells[2].Value) * 1);
                }
            }
            dgvListado.Columns[2].DefaultCellStyle.Format = "c";
            txtAmount.Text = Total.ToString("C");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAddItem.Text.Trim() != "")
                {
                    if (DaoProduct.ExistProduct(txtAddItem.Text.Trim()))
                    {
                        newProduct = DaoProduct.selectProduct(txtAddItem.Text.Trim());

                        dgvListado.Rows.Add(newProduct.Code, newProduct.Name, newProduct.CostSale);
                        CalcularTotal();
                    }
                    else
                    {
                        btnClear_Click(null, null);
                        MessageBox.Show("No existente",
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
                MessageBox.Show("Error al cargar datos de la Banda:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                dgvListado.Rows.Remove(dgvListado.CurrentRow);
            }
            CalcularTotal();
        }

        private void dgvListado_Leave(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void dgvListado_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            CalcularTotal();
        }

        private void dgvListado_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            CalcularTotal();
        }

        private void btnSaveExpence_Click(object sender, EventArgs e)
        {
            if (!ckbCredito.Checked)
            {
                if (dgvListado.Rows.Count >= 1)
                {
                    newInvoice.Code = "FAC" + GenericQuerys.Consecutivo().ToString();
                    if (txtIdentification.Text.Trim() != "")
                    {
                        newInvoice.Identification = txtIdentification.Text.Trim();
                    }
                    else
                    {
                        newInvoice.Identification = "1";
                    }
                    if (txtNameCliente.Text != "" && txtNameCliente.Text != "---")
                    {
                        newInvoice.NameClient = lblNameClient.Text;
                    }
                    else
                    {
                        newInvoice.NameClient = "CLIENTE GENÉRICO";
                    }
                    
                    newInvoice.Band = lblBanda.Text;

                    newInvoice.Fecha = DateTime.Now.ToShortDateString();
                    newInvoice.Amount = Convert.ToDouble(txtAmount.Text.ToString().Replace("$", ""));
                    newInvoice.IdAccountIn = (int)cbAccountIn.SelectedValue;
                    newInvoice.Active = true;

                    DaoFact.insertInvoice(newInvoice);
                    newInvoice = new Invoice();
                    foreach (DataGridViewRow item in dgvListado.Rows)
                    {
                        newItemInvoice.Code = item.Cells[0].Value.ToString();
                        newItemInvoice.Name = item.Cells[1].Value.ToString();
                        newItemInvoice.Price = Convert.ToDouble(item.Cells[2].Value);

                        if (Convert.ToInt32(item.Cells[3].Value) == 0)
                        {
                            newItemInvoice.Quantity = 1;
                        }
                        else
                        {
                            newItemInvoice.Quantity = Convert.ToInt32(item.Cells[3].Value);
                        }

                        newItemInvoice.CodeInvoice = lblConsecutivo.Text.Trim();
                        newItemInvoice.Note = Convert.ToString(item.Cells[4].Value);

                        DaoItemInvoice.insertItemInvoice(newItemInvoice);
                    }

                    AccountIn = DaoAccount.selectAccountId(Convert.ToInt32(cbAccountIn.SelectedValue));

                    double ValueIn = AccountIn.Amount + Convert.ToDouble(txtAmount.Text.Trim().Replace("$", ""));

                    AccountIn.Amount = ValueIn;
                    DaoAccount.insertAccount(AccountIn);

                    btnClear_Click(null, null);

                    lblConsecutivo.Text = "FAC" + GenericQuerys.Consecutivo().ToString();

                    MessageBox.Show("Factura guardada satisfactoriamente", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Agregue productos atraves del código", "Error al guardar factura", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("IR ACREDITO");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCrearProducto_Click(object sender, EventArgs e)
        {
            Productos pdcto = new Productos();
            pdcto.ShowDialog();
        }

        private void btnCrearProducto_Click_1(object sender, EventArgs e)
        {
            Productos pdcto = new Productos();
            pdcto.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtIdentification_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void cbBandas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblBanda.Text = cbBandas.Text;
        }

        private void btnSendNameClient_Click(object sender, EventArgs e)
        {
            this.lblNameClient.Text = txtNameCliente.Text;
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvR = new DataGridViewRow();
            dgvR = dgvProducts.Rows[this.dgvProducts.CurrentCell.RowIndex];

            txtAddItem.Text = dgvR.Cells[1].Value.ToString().Trim();
            button1_Click(null, null);
        }

        private void txtSearchProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                DataGridViewRow dgvR = new DataGridViewRow();
                dgvR = dgvProducts.Rows[this.dgvProducts.CurrentCell.RowIndex];

                txtAddItem.Text = dgvR.Cells[1].Value.ToString().Trim();
            }
        }

        private void btnAddBand_Click(object sender, EventArgs e)
        {
            Bandas bdn = new Bandas();
            bdn.ShowDialog();
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void dgvListado_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            CalcularTotal();
        }

        private void txtIdentification_Leave(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetAllProducts();
        }
    }
}
