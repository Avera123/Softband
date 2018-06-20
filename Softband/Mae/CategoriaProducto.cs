using Softband.DataAccess.DaoEntities;
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
    public partial class CategoriaProducto : Form
    {
        public CategoriaProducto()
        {
            InitializeComponent();
            CargarCategoriasGrid();
        }

        CategoriaProduct newCatProduct = new CategoriaProduct();
        DaoCatProduct daoCat = new DaoCatProduct();
        List<CategoriaProduct> Cats = new List<CategoriaProduct>();

        public void CargarCategoriasGrid()
        {
            DataTable dt = daoCat.fillCategoriesDT();
            dgvCategorias.DataSource = dt;
            dgvCategorias.Columns[0].HeaderText = "CÓDIGO";
            dgvCategorias.Columns[1].HeaderText = "NOMBRE";
        }

        //Boton limpiar campos de texto
        private void btnClean_Click(object sender, EventArgs e)
        {
            this.txtNameCatProd.Text = "";
        }

        //Boton Borrar Categoria de producto
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Realmente desea Eliminar esta categoría de producto?",
                    "Confirmación",
                    MessageBoxButtons.YesNoCancel, 
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (txtNameCatProd.Text.Trim() != "")
                    {
                        if (daoCat.deleteCatProduct(newCatProduct.Id))
                        {
                            CargarCategoriasGrid();
                            MessageBox.Show("Categoría de Producto Eliminado",
                            "Información del sistema",
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
                        MessageBox.Show("Campos obligatorios:\n*Nombre",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    }
                }
                else if (result == DialogResult.No)
                {
                    txtNameCatProd.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar Categoría de Producto:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        //Boton Guardar Categoria de producto
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNameCatProd.Text.Trim() != "")
                {
                    newCatProduct.Name = txtNameCatProd.Text.Trim();

                    daoCat.insertCatproduct(newCatProduct);
                    CargarCategoriasGrid();
                    MessageBox.Show("Categoría de producto guardada:\n" + newCatProduct.Name, "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Campos obligatorios:\n*Nombre", "Validación del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message, "Error al insertar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CategoriaProducto_Load(object sender, EventArgs e)
        {
            daoCat.autoCompleteCatName(txtNameCatProd);
        }

        private void dgvCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvR = new DataGridViewRow();
            dgvR = dgvCategorias.Rows[this.dgvCategorias.CurrentCell.RowIndex];

            newCatProduct.Id = Convert.ToInt32(dgvR.Cells[0].Value);
            newCatProduct.Name = dgvR.Cells[1].Value.ToString();

            txtNameCatProd.Text = newCatProduct.Name;
        }

        //Boton Exportar Grid A Excel
        #region Exportar a excel
        private void btnExport_Click_1(object sender, EventArgs e)
        {
            //ExportToExcel();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Documentos de Excel (*.xls)|*.xls";
            sfd.FileName = "Softband - Listado de Categorias de Productos - " + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dgvCategorias, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }

        private void ToExcel(DataGridView dGV, string filename)
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

        private void releaseObject(object obj)
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

        
    }
}
