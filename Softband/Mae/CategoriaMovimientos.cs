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
using System.IO;

namespace Softband.Mae
{
    public partial class CategoriaMovimientos : Form
    {
        public CategoriaMovimientos()
        {
            InitializeComponent();
            CargarCategoriasGrid();
        }

        DaoCategoryMovements daoCat = new DaoCategoryMovements();
        CategoryMovements newCat = new CategoryMovements();
        List<CategoryMovements> Cats = new List<CategoryMovements>();

        public void CargarCategoriasGrid()
        {
            DataTable dt = daoCat.fillCategoriesDT();
            dgvCategorias.DataSource = dt;
            dgvCategorias.Columns[0].HeaderText = "CÓDIGO";
            dgvCategorias.Columns[1].HeaderText = "NOMBRE";
            dgvCategorias.Columns[2].HeaderText = "DESCRIPCIÓN";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtNameCatMov.Text = "";
            this.txtDescription.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNameCatMov.Text.Trim() != "")
                {
                    newCat.Name = txtNameCatMov.Text.Trim();
                    newCat.Description = txtDescription.Text.Trim();

                    daoCat.insertCatproduct(newCat);
                    newCat.Id = 0;
                    CargarCategoriasGrid();
                    MessageBox.Show("Categoria guardada:\n" + newCat.Name, "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void CategoriaMovimientos_Load(object sender, EventArgs e)
        {
            daoCat.autoCompleteCatName(txtNameCatMov);
        }

        //Boton Borrar Categoria de Movimientos
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
                    if (newCat.Id >= 1)
                    {
                        if (daoCat.deleteCatMovements(newCat.Id))
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
                        CargarCategoriasGrid();
                    }
                    else
                    {
                        MessageBox.Show("Seleccione una categoria para ser eliminada", "Validación del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }                    
                }
                else if (result == DialogResult.No)
                {
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

        //Doble clicl para cargar de los datos del grid a los textbox
        private void dgvCategorias_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvR = new DataGridViewRow();
            dgvR = dgvCategorias.Rows[this.dgvCategorias.CurrentCell.RowIndex];

            newCat.Id = Convert.ToInt32(dgvR.Cells[0].Value);
            newCat.Name = dgvR.Cells[1].Value.ToString();
            newCat.Description = dgvR.Cells[2].Value.ToString();

            txtNameCatMov.Text = newCat.Name;
            txtDescription.Text = newCat.Description;
        }

        //Boton Exportar Grid A Excel
        #region Exportar a excel
        private void btnExport_Click(object sender, EventArgs e)
        {
            //ExportToExcel();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Documentos de Excel (*.xls)|*.xls";
            sfd.FileName = "Softband - Listado de Categorias de Movimientos - " + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xls";
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
