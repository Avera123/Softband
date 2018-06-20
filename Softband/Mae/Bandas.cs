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
using Softband.Entities;
using Softband.DataAccess.DaoEntities;
using System.IO;

namespace Softband.Maestros
{
    public partial class Bandas : Form
    {
        Band newBand = new Band();
        DaoBand daoBand = new DaoBand();
        List<Band> Bands = new List<Band>();

        public Bandas()
        {
            InitializeComponent();
            CargarBandasGrid();
        }

        //Metodo de Carga de datos para DataGrid
        public void CargarBandasGrid()
        {
            DataTable dt = daoBand.fillBandsDT();
            dgvBandas.DataSource = dt;
            dgvBandas.Columns[0].HeaderText = "CÓDIGO";
            dgvBandas.Columns[1].HeaderText = "NOMBRE";
        }

        //Boton Insertar Banda
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNameBand.Text.Trim() != "")
                {
                    newBand.Name = txtNameBand.Text.Trim();
                    daoBand.insertBand(newBand);
                    CargarBandasGrid();

                    MessageBox.Show("Banda guardada:\n" + newBand.Name, 
                        "Información del sitema", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);                    
                }
                else
                {
                    MessageBox.Show("El Campo Nombre es obligatorio", 
                        "Validación del sistema", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n"+ex.Message, 
                    "Error al insertar banda", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            
        }

        private void Bandas_Load(object sender, EventArgs e)
        {
            daoBand.autoCompleteBandName(txtNameBand);
        }

        //Boton Limpiar
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtNameBand.Text = "";
        }

        //Boton borrar banda
        private void btnDeleteBand_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Realmente desea Eliminar esta Banda?",
                    "Confirmación",
                    MessageBoxButtons.YesNoCancel);

                DataGridViewRow dgvR = new DataGridViewRow();
                dgvR = dgvBandas.Rows[this.dgvBandas.CurrentCell.RowIndex];

                if (result == DialogResult.Yes)
                {
                    if (newBand.Id >= 1)
                    {
                        if (!daoBand.ExistBand(newBand.Id))
                        {
                            daoBand.deleteBand(newBand.Id);
                            newBand.Id = 0;
                            btnClear_Click(null, null);
                            CargarBandasGrid();
                            MessageBox.Show("Banda Eliminada Correctamente.",
                                "Información del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Banda No existente",
                                "Error del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo borrar la banda Indice Fuera del Rango",
                            "Error del Sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else if (result == DialogResult.No)
                {
                    txtNameBand.Text = "";
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

        //Doble click de Banda para carga de datos
        private void dgvBandas_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvR = new DataGridViewRow();
            dgvR = dgvBandas.Rows[this.dgvBandas.CurrentCell.RowIndex];

            newBand.Id = Convert.ToInt32(dgvR.Cells[0].Value);
            newBand.Name = dgvR.Cells[1].Value.ToString();

            if (dgvR.Cells[1].Value.ToString() != "")
            {
                txtNameBand.Text = dgvR.Cells[1].Value.ToString().Trim();
            }
        }

        //Boton Exportar Grid A Excel
        #region Exportar a excel
        private void btnExport_Click(object sender, EventArgs e)
        {
            //ExportToExcel();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Documentos de Excel (*.xls)|*.xls";
            sfd.FileName = "Softband - Listado de Bandas - " + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dgvBandas, sfd.FileName); // Here dataGridview1 is your grid view name
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
