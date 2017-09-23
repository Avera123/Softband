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

namespace Softband.Maestros
{
    public partial class CategoriaProducto : Form
    {
        public CategoriaProducto()
        {
            InitializeComponent();
            GetAllCats();
        }

        CategoriaProduct newCatProduct = new CategoriaProduct();
        DaoCatProduct DaoCat = new DaoCatProduct();
        List<CategoriaProduct> Cats = new List<CategoriaProduct>();

        public void GetAllCats()
        {
            Cats = DaoCat.getAllCats();

            lvCats.Clear();

            ListViewItem listBands = new ListViewItem();

            foreach (CategoriaProduct _catProduct in Cats)
            {
                string active = "";
                if (_catProduct.Active) { active = "ACTIVO"; } else { active = "INACTIVO"; };
                ListViewItem lista = new ListViewItem(_catProduct.Id.ToString() + " | " + _catProduct.Code.ToString() + " | " + _catProduct.Name.ToString() + " | ESTADO* " + active);
                lvCats.Items.Add(lista);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodeCatProd.Text.Trim() != "")
                {
                    if (DaoCat.ExistCatProduct(txtCodeCatProd.Text.Trim()))
                    {
                        newCatProduct = DaoCat.selectCatProduct(txtCodeCatProd.Text.Trim());

                        txtCodeCatProd.Text = newCatProduct.Code.Trim();
                        txtNameCatProd.Text = newCatProduct.Name.Trim();
                        ckbActive.Checked = newCatProduct.Active;
                    }
                    else
                    {
                        btnClean_Click(null, null);
                        MessageBox.Show("Banda no existente",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    btnClean_Click(null, null);
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

        private void btnClean_Click(object sender, EventArgs e)
        {
            this.txtCodeCatProd.Text = "";
            this.txtNameCatProd.Text = "";
            this.ckbActive.Checked = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Realmente desea Eliminar esta banda?",
                    "Confirmación",
                    MessageBoxButtons.YesNoCancel, 
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (txtCodeCatProd.Text.Trim() != "")
                    {
                        if (DaoCat.deleteCatProduct(txtCodeCatProd.Text.Trim()))
                        {
                            MessageBox.Show("Categoría de Producto Eliminado",
                            "Información",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }else{
                            MessageBox.Show("La Categoría de Producto no pudo ser eliminada.",
                            "Información",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }
                        btnClean_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Campos obligatorios:\n*Código",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    }
                }
                else if (result == DialogResult.No)
                {
                    txtNameCatProd.Text = "";
                    txtCodeCatProd.Text = "";
                    ckbActive.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar Banda:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodeCatProd.Text.Trim() != "" && txtNameCatProd.Text.Trim() != "")
                {
                    newCatProduct.Code = txtCodeCatProd.Text.Trim();
                    newCatProduct.Name = txtNameCatProd.Text.Trim();
                    newCatProduct.Active = ckbActive.Checked;

                    DaoCat.insertCatproduct(newCatProduct);
                    MessageBox.Show("Banda guardada:\n" + newCatProduct.Name, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Campos obligatorios:\n*Código\n*Nombre", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error al insertar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void CategoriaProducto_Load(object sender, EventArgs e)
        {

        }
    }
}
