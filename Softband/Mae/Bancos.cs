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
using Excel = Softband.Functions.ExportGridExcel;

namespace Softband.Mae
{
    public partial class Bancos : Form
    {
        Bank newBank = new Bank();
        DaoBank daoBank = new DaoBank();
        List<Bank> Banks = new List<Bank>();
        GenericQuerys GenericQuerys = new GenericQuerys();

        public Bancos()
        {
            InitializeComponent();
            CargarBancosGrid();
        }
        
        //Cargar Datagrid con DataTable - PROVEEDORES
        public void CargarBancosGrid()
        {
            DataTable dt = daoBank.fillBanksDT();
            dgvBancos.DataSource = dt;
            dgvBancos.Columns[0].HeaderText = "CÓDIGO";
            dgvBancos.Columns[1].HeaderText = "NOMBRE";
        }

        //Boton guardar/insertar Banco
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNameBanc.Text.Trim() != "")
                {
                    newBank.Name = txtNameBanc.Text.Trim();
                    daoBank.insertBank(newBank);
                    CargarBancosGrid();
                    MessageBox.Show("Banco guardadosatisfactoriamente:\n" + newBank.Name,
                        "Información del Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El campo Nombre es obligatorio",
                        "Validación del Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message,
                    "Error al insertar el nuevo Banco",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        //Boton Limpiar Textbox
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtNameBanc.Text = "";
        }

        private void Bancos_Load(object sender, EventArgs e)
        {
            daoBank.autoCompleteBankName(txtNameBanc);
        }

        //Boton Borrar Banco
        private void btnDelete_Click(object sender, MouseEventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Realmente desea Eliminar este Banco?",
                    "Confirmación",
                    MessageBoxButtons.YesNoCancel);

                DataGridViewRow dgvR = new DataGridViewRow();
                dgvR = dgvBancos.Rows[this.dgvBancos.CurrentCell.RowIndex];

                if (result == DialogResult.Yes)
                {
                    if (newBank.Id >= 1)
                    {
                        if (daoBank.ExistBank(newBank.Id))
                        {
                            daoBank.deleteBank(newBank.Id);
                            newBank.Id = 0;
                            btnClear_Click(null, null);
                            CargarBancosGrid();
                            MessageBox.Show("Banco Eliminado Correctamente.",
                                "Información del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Banco No existente",
                                "Error del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo borrar el banco Indice Fuera del Rango",
                            "Error del Sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else if (result == DialogResult.No)
                {
                    txtNameBanc.Text = "";
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

        //Doble clic para carga de datos al textbox
        private void dgvBancos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvR = new DataGridViewRow();
            dgvR = dgvBancos.Rows[this.dgvBancos.CurrentCell.RowIndex];
            
            newBank.Id = Convert.ToInt32(dgvR.Cells[0].Value);
            newBank.Name = dgvR.Cells[1].Value.ToString();

            txtNameBanc.Text = dgvR.Cells[1].Value.ToString();
        }

        //Boton Exportar Grid A Excel
        #region Exportar a excel
        private void btnExport_Click_1(object sender, EventArgs e)
        {
            //ExportToExcel();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Documentos de Excel (*.xls)|*.xls";
            sfd.FileName = "Softband - Listado de Bancos - " + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dgvBancos, sfd.FileName); // Here dataGridview1 is your grid view name
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Realmente desea Eliminar este Banco?",
                    "Confirmación",
                    MessageBoxButtons.YesNoCancel);

                DataGridViewRow dgvR = new DataGridViewRow();
                dgvR = dgvBancos.Rows[this.dgvBancos.CurrentCell.RowIndex];

                if (result == DialogResult.Yes)
                {
                    if (newBank.Id >= 1)
                    {
                        if (daoBank.ExistBank(newBank.Id))
                        {
                            daoBank.deleteBank(newBank.Id);
                            newBank.Id = 0;
                            btnClear_Click(null, null);
                            CargarBancosGrid();
                            MessageBox.Show("Banco Eliminado Correctamente.",
                                "Información del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Banco No existente",
                                "Error del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo borrar el banco Indice Fuera del Rango",
                            "Error del Sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else if (result == DialogResult.No)
                {
                    txtNameBanc.Text = "";
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

        //private void txtNameBanc_TextChanged(object sender, EventArgs e)
        //{
        //    dt.DefaultView.RowFilter = ("Banco like '%" + txtNameBanc.Text.Trim() + "%'");
        //    dgvBancos.DataSource = dt.DefaultView;
        //}
    }
}
