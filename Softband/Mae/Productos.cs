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

namespace Softband.Maestros
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
            FillCbCategories();
            GetAllProducts();
        }

        GenericQuerys GenericQuerys = new GenericQuerys();
        List<CategoriaProduct> ListCategories = new List<CategoriaProduct>();
        List<Product> ListProducts = new List<Product>();
        DaoProduct DaoProduct = new DaoProduct();
        Product newProduct = new Product();

        public void FillCbCategories()
        {
            cbCategoryProduct.DataSource = null;
            ListCategories = GenericQuerys.getAllCategoryProducts();

            cbCategoryProduct.DataSource = ListCategories;
            cbCategoryProduct.ValueMember = "Id";
            cbCategoryProduct.DisplayMember = "Name";
        }

        public void GetAllProducts()
        {
            ListProducts = DaoProduct.getAllProducts();
            lvProducts.Clear();
            ListViewItem listProdctus = new ListViewItem();

            foreach (Product _product in ListProducts)
            {
                //string active = "";
                //if (_product.Active) { active = "ACTIVO"; } else { active = "INACTIVO"; };
                ListViewItem lista = new ListViewItem("°: " + _product.Stock.ToString() +" | " +_product.Code.ToString() + " | " + _product.Name.ToString()+" | "+_product.Description+" | "+_product.CostSale.ToString("C"));
                lvProducts.Items.Add(lista);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
                    if (DaoProduct.ExistProduct(txtCodeProduct.Text.Trim()))
                    {
                        newProduct = DaoProduct.selectProduct(txtCodeProduct.Text.Trim());

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
                        btnClear_Click(null, null);
                        MessageBox.Show("Banda no existente",
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
                    newProduct.Stock = Convert.ToInt32(txtStock.Text.Trim());
                    GetAllProducts();
                    DaoProduct.insertProduct(newProduct);
                    MessageBox.Show("Banda guardada:\n" + newProduct.Name,
                        "Información",
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
    }
}
