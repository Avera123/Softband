using Softband.DataAccess.DaoEntities;
using Softband.DataAccess.Generics;
using Softband.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Softband.Maestros
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
            FillCbCategories();
            CargarProductsGrid();
            this.rdCodigo.Checked = true;
        }

        GenericQuerys GenericQuerys = new GenericQuerys();
        List<CategoriaProduct> ListCategories = new List<CategoriaProduct>();
        List<Product> ListProducts = new List<Product>();
        DaoProduct daoProduct = new DaoProduct();
        Product newProduct = new Product();
        DataTable dt;

        public void FillCbCategories()
        {
            cbCategoryProduct.DataSource = null;
            ListCategories = GenericQuerys.getAllCategoryProducts();

            cbCategoryProduct.DataSource = ListCategories;
            cbCategoryProduct.ValueMember = "Id";
            cbCategoryProduct.DisplayMember = "Name";
        }

        //Metodo de Carga de datos para DataGrid
        public void CargarProductsGrid()
        {
            dt = daoProduct.fillProductsDT();
            dgvProducts.DataSource = dt;

            dgvProducts.Columns[0].HeaderText = "ID";
            dgvProducts.Columns[1].HeaderText = "CÓDIGO";
            dgvProducts.Columns[2].HeaderText = "NOMBRE";
            dgvProducts.Columns[3].HeaderText = "IDCATEGORÍA";
            dgvProducts.Columns[4].HeaderText = "CATEGORÍA";
            dgvProducts.Columns[5].HeaderText = "DESCRIPCIÓN";
            dgvProducts.Columns[6].HeaderText = "VENTA";
            dgvProducts.Columns[7].HeaderText = "COMPRA";
            dgvProducts.Columns[8].HeaderText = "STOCK";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtCodeProduct.Text = "";
            this.txtNameProduct.Text = "";
            this.txtDescriptionProduct.Text = "";
            this.cbCategoryProduct.SelectedIndex = 0;
            this.txtCostBuy.Text = "$0.00";
            this.txtCostSale.Text = "$0.00";
            this.txtStock.Text = "00000";
        }

        private void Productos_Load(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodeProduct.Text.Trim() != "")
                {
                    if (daoProduct.ExistProduct(txtCodeProduct.Text.Trim()))
                    {
                        newProduct = daoProduct.selectProduct(txtCodeProduct.Text.Trim());

                        txtCodeProduct.Text = newProduct.Code.Trim();
                        txtNameProduct.Text = newProduct.Name.Trim();
                        cbCategoryProduct.SelectedValue = newProduct.IdCategory;
                        txtDescriptionProduct.Text = newProduct.Description;
                        txtCostBuy.Text = newProduct.CostBuy.ToString("C");
                        txtCostSale.Text = newProduct.CostSale.ToString("C");
                        txtStock.Text = newProduct.Stock.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Producto no existente",
                            "Validación del sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    btnClear_Click(null, null);
                    MessageBox.Show("El Campo Código no debe estar vacío",
                        "Validación del sistema",
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNameProduct.Text.Trim() != "" && 
                    txtCodeProduct.Text.Trim() != "" &&
                    txtCostBuy.Text.Trim() != "" &&
                    txtCostSale.Text.Trim() !="")
                {

                    newProduct.Code = txtCodeProduct.Text.Trim();
                    newProduct.Name = txtNameProduct.Text.Trim();
                    newProduct.IdCategory = (int)cbCategoryProduct.SelectedValue;
                    newProduct.Description = txtDescriptionProduct.Text.Trim();
                    newProduct.CostSale =  Convert.ToDouble(txtCostSale.Text.Trim().Replace("$",""));
                    newProduct.CostBuy = Convert.ToDouble(txtCostBuy.Text.Trim().Replace("$", ""));

                    if (Convert.ToInt32(txtStock.Text.Trim()) > 0)
                        newProduct.Stock = Convert.ToInt32(txtStock.Text.Trim());
                    else
                        newProduct.Stock = 0;

                    daoProduct.insertProduct(newProduct);
                    CargarProductsGrid();
                    MessageBox.Show("Producto guardado:\n" + newProduct.Name,
                        "Información del sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Campos obligatorios:\n*Código\n*Nombre",
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

        private void dgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvR = new DataGridViewRow();
            dgvR = dgvProducts.Rows[this.dgvProducts.CurrentCell.RowIndex];

            newProduct.Id = Convert.ToInt32(dgvR.Cells[0].Value);
            newProduct.Code = dgvR.Cells[1].Value.ToString();
            newProduct.Name = dgvR.Cells[2].Value.ToString();
            newProduct.IdCategory = Convert.ToInt32(dgvR.Cells[3].Value);
            newProduct.Description = dgvR.Cells[5].Value.ToString();
            newProduct.CostSale = Convert.ToDouble(dgvR.Cells[6].Value);
            newProduct.CostBuy = Convert.ToDouble(dgvR.Cells[7].Value);
            newProduct.Stock = Convert.ToInt32(dgvR.Cells[8].Value);

            if (dgvR.Cells[1].Value.ToString() != "")
            {
                txtCodeProduct.Text = newProduct.Code;
                txtNameProduct.Text = newProduct.Name;
                cbCategoryProduct.SelectedValue = newProduct.IdCategory;
                txtDescriptionProduct.Text = newProduct.Description;
                txtCostBuy.Text = newProduct.CostBuy.ToString("C");
                txtCostSale.Text = newProduct.CostSale.ToString("C");
                txtStock.Text = newProduct.Stock.ToString();
            }
        }

        private void txtSearchNameClient_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Filter = "";
            if (rdCodigo.Checked)
            {
                Filter = "code";
            }
            else if (rdNombre.Checked)
            {
                Filter = "name";
            }
            else if (rdDescription.Checked)
            {
                Filter = "description";
            }

            dt.DefaultView.RowFilter = (Filter + " like '%" + txtSearchNameClient.Text.Trim() + "%'");
            dgvProducts.DataSource = dt.DefaultView;
        }

        //Botón Exportar a Excel
        #region Botón de ExportExcel
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Documentos de Excel (*.xls)|*.xls";
            sfd.FileName = "Softband - Productos - " + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToExcel(dgvProducts, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }

        public void ToExcel(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        public void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion

        private void txtCodeProduct_Leave(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        private void btnRefreshGrid_Click(object sender, EventArgs e)
        {
            CargarProductsGrid();
        }

        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            CategoriaProducto newCat = new CategoriaProducto();
            newCat.ShowDialog();
        }

        private void btnRefreshCategories_Click(object sender, EventArgs e)
        {
            FillCbCategories();
        }
    }
}
