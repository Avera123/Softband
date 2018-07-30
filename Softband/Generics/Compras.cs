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
    public partial class Compras : Form
    {
        DaoProvider daoProvider = new DaoProvider();
        DataTable dtProvider;
        DataTable ds;
        GenericQuerys GenericQuerys = new GenericQuerys();
        DaoClient DaoClient = new DaoClient();
        DaoProduct DaoProduct = new DaoProduct();
        DaoFact DaoFact = new DaoFact();
        DaoAccount DaoAccount = new DaoAccount();
        DaoBand DaoBand = new DaoBand();
        DaoItemInvoice DaoItemInvoice = new DaoItemInvoice();
        Product newProduct = new Product();
        List<Account> ListAccount = new List<Account>();
        List<Product> ListProducts = new List<Product>();
        List<Band> ListBands = new List<Band>();
        Account AccountOut = new Account();
        DaoBill daoBill = new DaoBill();

        public Compras()
        {
            InitializeComponent();
            FillCbProvider();
            GetAllProducts();
            FillCbAccounts();
            rdCode.Checked = true;
        }

        public void FillCbAccounts()
        {
            cbAccountOut.DataSource = null;

            dtProvider = DaoAccount.fillAccountsDT();

            cbAccountOut.DataSource = dtProvider;
            cbAccountOut.ValueMember = "id";
            cbAccountOut.DisplayMember = "name";
        }

        public void FillCbProvider()
        {
            cbProviders.DataSource = null;

            dtProvider = daoProvider.fillProviderDT();

            cbProviders.DataSource = dtProvider;
            cbProviders.ValueMember = "id";
            cbProviders.DisplayMember = "name";
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
            txtAmount.Text = Total.ToString("C");
        }

        private void Compras_Load(object sender, EventArgs e)
        {

        }

        public void GetAllProducts()
        {
            ds = GenericQuerys.fillProductsDS();
            dgvProducts.DataSource = ds;
        }

        private void txtSearchProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                DataGridViewRow dgvR = new DataGridViewRow();
                dgvR = dgvProducts.Rows[this.dgvProducts.CurrentCell.RowIndex];

                dgvListado.Rows.Add(dgvR);
            }
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

        private void btnCrearProducto_Click(object sender, EventArgs e)
        {
            Productos newPrdo = new Productos();
            newPrdo.ShowDialog();
        }

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvR = new DataGridViewRow();
            dgvR = dgvProducts.Rows[this.dgvProducts.CurrentCell.RowIndex];

            txtAddItem.Text = dgvR.Cells[1].Value.ToString().Trim();
            btnAddItem_Click(null, null);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAddItem.Text.Trim() != "")
                {
                    if (DaoProduct.ExistProduct(txtAddItem.Text.Trim()))
                    {
                        newProduct = DaoProduct.selectProduct(txtAddItem.Text.Trim());

                        dgvListado.Rows.Add(newProduct.Code, newProduct.Name, newProduct.CostBuy);
                        //CalcularTotal();
                    }
                    else
                    {
                        //btnClear_Click(null, null);
                        MessageBox.Show("No existente",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    //btnClear_Click(null, null);
                    MessageBox.Show("El Campo Código no debe estar vacío",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del Producto:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvListado_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcularTotal();
        }

        private void btnDelItem_Click(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                dgvListado.Rows.Remove(dgvListado.CurrentRow);
            }
            CalcularTotal();
        }

        private void btnGenerarTotales_Click(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CalcularTotal();
            int idProvider = Convert.ToInt32(cbProviders.SelectedValue);
            int idAccount = Convert.ToInt32(cbAccountOut.SelectedValue);
            try
            {
                if (txtDescription.Text != "" && idProvider >= 1 && idAccount >= 1)
                {
                    if (dgvListado.Rows.Count >= 1)
                    {
                        int stock = 1;

                        for (int i = 0; i < dgvListado.Rows.Count; i++)
                        {
                            if (Convert.ToInt32(dgvListado.Rows[i].Cells[3].Value) >= 1)
                            {
                                stock = Convert.ToInt32(dgvListado.Rows[i].Cells[3].Value);
                            }
                            else
                            {
                                stock = 1;
                            }

                            daoBill.updateProduc(dgvListado.Rows[i].Cells[0].Value.ToString(), stock);

                            newProduct = DaoProduct.selectProduct(dgvListado.Rows[i].Cells[0].Value.ToString());

                            daoBill.insertBillProducts(newProduct.Id, stock, dgvListado.Rows[i].Cells[2].Value.ToString());
                        }

                        daoBill.insertBill(idProvider, idAccount, txtDescription.Text.Trim(), Convert.ToDouble(txtAmount.Text.Replace("$", "")), dtpFecha.Value.ToShortDateString());

                        daoBill.updateAccount(Convert.ToInt32(cbAccountOut.SelectedValue), Convert.ToDouble(txtAmount.Text.Replace("$", "")));
                        MessageBox.Show("Compra realizada con éxito", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.btnClear_Click(null,null);
                    }
                    else
                    {
                        MessageBox.Show("Ingrese productos seleccionando del listado con doclbe clic para poder generar una compra con valores válidos", "Validación del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                    
                }
                else
                {
                    MessageBox.Show("El campo descripción es necesario para hacer seguimiento a las compras", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAddItem.Text = "";
            txtAmount.Text = "0.00";
            txtDescription.Text = "";
            txtSearchProduct.Text = "";
            dgvListado.Rows.Clear();
        }

        private void btnAddProveedor_Click(object sender, EventArgs e)
        {
            Proveedores prov = new Proveedores();
            prov.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetAllProducts();
        }
    }
}
