using Softband.DataAccess.DaoEntities;
using Softband.DataAccess.Generics;
using Softband.Entities;
using Softband.Mae;
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
        DaoDebt daoDebt = new DaoDebt();
        Debt newDebt = new Debt();

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

        //Carga de Combos
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

        //Cargar y llenar el grid de productos
        public void GetAllProducts()
        {
            ds = GenericQuerys.fillProductsDS();
            dgvProducts.DataSource = ds;
            dgvProducts.Columns[4].DefaultCellStyle.Format = "c";
        }

        //Botón busca cliente
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
                        lblBanda.Text = newClient.Banda;
                        if (newClient.IdBand >= 1)
                        {
                            cbBandas.SelectedValue = newClient.IdBand;
                        }
                        else
                        {
                            cbBandas.SelectedValue = 1;
                        }

                        getCreditByIDCliente();
                    }
                    else
                    {
                        btnClear_Click(null, null);
                        MessageBox.Show("Cliente no existente",
                            "Validación del Sistema",
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

        //Botón limpiar factura
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvListado.Rows.Count >= 1)
                {
                    DialogResult result = MessageBox.Show("¿Realmente desea Limpiar la factura en curso?",
                    "Confirmación del Sistema",
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
                        ckbCredito.Checked = false;
                        txtAbono.Text = "";
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
                    ckbCredito.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar Venta:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        //Metodo Load del Form
        private void Ventas_Load(object sender, EventArgs e)
        {
            DaoClient.autoCompleteClientID(txtIdentification);
            DaoClient.autoCompleteClientName(txtNameCliente);
        }


        //Filtro del grid de productos
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

        //Metodo para el calculo de totales de los productos a facturar
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

                if (Convert.ToDouble(item.Cells[3].Value) >= 1)
                {
                    item.Cells[4].Value = Convert.ToDouble(item.Cells[2].Value) * Convert.ToDouble(item.Cells[3].Value);
                }
                else
                {
                    item.Cells[3].Value = 1;
                    item.Cells[4].Value = Convert.ToDouble(item.Cells[2].Value) * Convert.ToDouble(item.Cells[3].Value);
                }          
            }
            dgvListado.Columns[2].DefaultCellStyle.Format = "c";
            dgvListado.Columns[4].DefaultCellStyle.Format = "c";
            txtAmount.Text = Total.ToString("C");
        }

        //Boton agregar producto al listado defacturación
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

        //Eliminar Fila de Grid de productos cargados
        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                dgvListado.Rows.Remove(dgvListado.CurrentRow);
            }
            CalcularTotal();
        }

        //Metodos Calcular con el grid
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

        private void dgvListado_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            CalcularTotal();
        }

        //Botón guardar Factura
        private void btnSaveExpence_Click(object sender, EventArgs e)
        {
            CalcularTotal();

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
                    if (lblNameClient.Text != "---" || lblNameClient.Text != "")
                    {
                        newInvoice.NameClient = newClient.Name;
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
                        newItemInvoice.Note = Convert.ToString(item.Cells[5].Value);

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
                if (dgvListado.Rows.Count >= 1)
                {
                    Double val = 0;
                    if (txtAbono.Text.ToString().Trim() != "")
                    {
                        if (Convert.ToDouble(Convert.ToDouble(txtAmount.Text.Replace("$", "")) - Convert.ToDouble(txtAbono.Text)) <= newClient.Credit && getCreditByIDCliente())
                        {
                            newInvoice.Code = "FAC" + GenericQuerys.Consecutivo().ToString();
                            newInvoice.Identification = newClient.ID;
                            newInvoice.NameClient = newClient.Name;

                            Band bdn = DaoBand.selectBandByID(newClient.IdBand);

                            newInvoice.Band = bdn.Name;
                            newInvoice.Fecha = DateTime.Now.ToShortDateString();
                            newInvoice.Amount = Convert.ToDouble(txtAmount.Text.ToString().Replace("$", "")) - Convert.ToDouble(txtAbono.Text);
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
                                newItemInvoice.Note = Convert.ToString(item.Cells[5].Value);

                                DaoItemInvoice.insertItemInvoice(newItemInvoice);
                            }

                            AccountIn = DaoAccount.selectAccountId(Convert.ToInt32(cbAccountIn.SelectedValue));

                            double ValueIn = AccountIn.Amount + Convert.ToDouble(txtAbono.Text);

                            AccountIn.Amount = ValueIn;

                            DaoAccount.insertAccount(AccountIn);
                            
                            newDebt.IDClient = newClient.ID;
                            newDebt.NameClient = newClient.Name;
                            newDebt.IDBanda = bdn.Id;
                            newDebt.Date = DateTime.Now.ToShortDateString();
                            newDebt.CodFact = ("FAC" + Convert.ToString(GenericQuerys.Consecutivo() - 1));
                            newDebt.Amount = Math.Abs(Convert.ToDouble(Convert.ToDouble(txtAmount.Text.Replace("$","")) - Convert.ToDouble(txtAbono.Text)));
                            newDebt.Active = true;

                            daoDebt.insertDebt(newDebt);
                            MessageBox.Show("Deuda guardada satisfactoriamente", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            btnClear_Click(null, null);

                            lblConsecutivo.Text = "FAC" + GenericQuerys.Consecutivo().ToString();

                            MessageBox.Show("Factura guardada satisfactoriamente", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
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

        private void txtIdentification_Leave(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetAllProducts();
        }

        //CheckBox de Crédito para clientes
        private void ckbCredito_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbCredito.Checked == true)
            {
                if (newClient.ID != "" || lblIDClient.Text != "---" || lblIDClient.Text != "")
                {
                    if (newClient.Credit > 0 && newClient.Credit >= Convert.ToDouble(txtAmount.Text.ToString().Replace("$", "")) && getCreditByIDCliente())
                    {
                        MessageBox.Show("La cuenta será enviada a deudas a nombre del cliente: "
                            + newClient.Name + " con número de identificación: " + newClient.ID, "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El Cliente no cuenta con el saldo suficiente de crédito para enviar a deudas", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ckbCredito.Checked = false;
                    }
                }
                else
                {
                    MessageBox.Show("No se puede asignar crédito a este cliente, tal ves falta la Identificación del cliente.", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }            
        }

        private void btnRefreshBandas_Click(object sender, EventArgs e)
        {
            setCbBands();
        }

        private void btnRefreshCuentas_Click(object sender, EventArgs e)
        {
            setCbAccounts();
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            Cuentas newCuenta = new Cuentas();
            newCuenta.ShowDialog();
        }

        private void txtAbono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private bool getCreditByIDCliente()
        {
            double saldoIn = daoDebt.getSaldoByIDCliente(newClient.ID);
            double credito = newClient.Credit - saldoIn;

            if (txtAbono.Text == "")
            {
                txtAbono.Text = "0";
            }

            if (Math.Abs(Convert.ToDouble(txtAmount.Text.Replace("$", "")) - Convert.ToDouble(txtAbono.Text)) > credito)
            {
                lblCreditoDisponible.Text = "$" + Convert.ToString(credito);
                return false;
            }
            else
            {
                lblCreditoDisponible.Text ="$" + Convert.ToString(credito);
                return true;
            }
        }
    }
}
