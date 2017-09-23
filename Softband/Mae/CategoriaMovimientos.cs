using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Softband.DataAccess;
using Softband.DataAccess.DaoEntities;
using Softband.Entities;

namespace Softband.Mae
{
    public partial class CategoriaMovimientos : Form
    {
        public CategoriaMovimientos()
        {
            InitializeComponent();
            GetAllCats();
        }

        DaoCategoryMovements DaoCat = new DaoCategoryMovements();
        CategoryMovements newCat = new CategoryMovements();
        List<CategoryMovements> Cats = new List<CategoryMovements>();

        public void GetAllCats()
        {
            Cats = DaoCat.getAllCats();

            lvCats.Clear();

            ListViewItem listBands = new ListViewItem();

            foreach (CategoryMovements _cat in Cats)
            {
                ListViewItem lista = new ListViewItem(_cat.Id.ToString() + " | " + _cat.Code.ToString() + " | " + _cat.Name.ToString() + " | " + _cat.Description.ToString());
                lvCats.Items.Add(lista);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodeCatMov.Text.Trim() != "")
                {
                    if (DaoCat.ExistCatMovement(txtCodeCatMov.Text.Trim()))
                    {
                        newCat = DaoCat.selectCatMovements(txtCodeCatMov.Text.Trim());

                        txtCodeCatMov.Text = newCat.Code.Trim();
                        txtNameCatMov.Text = newCat.Name.Trim();
                        txtDescription.Text = newCat.Description;
                    }
                    else
                    {
                        btnClear_Click(null, null);
                        MessageBox.Show("Catagoria no existente",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    btnClear_Click(null, null);
                    MessageBox.Show("Los Campos Código y Nombre no deben estar vacíos",
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtCodeCatMov.Text = "";
            this.txtNameCatMov.Text = "";
            this.txtDescription.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodeCatMov.Text.Trim() != "" && txtNameCatMov.Text.Trim() != "")
                {
                    newCat.Code = txtCodeCatMov.Text.Trim();
                    newCat.Name = txtNameCatMov.Text.Trim();
                    newCat.Description = txtDescription.Text.Trim();

                    DaoCat.insertCatproduct(newCat);
                    MessageBox.Show("Categoria guardada:\n" + newCat.Name, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetAllCats();
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

        private void CategoriaMovimientos_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Realmente desea Eliminar esta Catagoria?",
                    "Confirmación",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (txtCodeCatMov.Text.Trim() != "")
                    {
                        if (DaoCat.deleteCatMovements(txtCodeCatMov.Text.Trim()))
                        {
                            MessageBox.Show("Categoría de Movimiento Eliminada",
                            "Información",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("La Categoría de Movimiento no pudo ser eliminada.",
                            "Información",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }
                        btnClear_Click(null, null);
                        GetAllCats();
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
                    txtCodeCatMov.Text = "";
                    txtNameCatMov.Text = "";
                    txtDescription.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar Catagoria de Movimiento:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
