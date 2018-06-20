using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Softband.DataAccess.DaoEntities;
using Softband.Entities;
using Softband.Functions;
using System.IO;

namespace Softband.Mae
{
    public partial class Proveedores : Form
    {
        Provider newProvider = new Provider();
        DaoProvider daoProvider = new DaoProvider();


        public Proveedores()
        {
            InitializeComponent();
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            CargarProveedoresGrid();
        }

        //Botón Guardar
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtIdentification.Text.Trim() != "")
            {
                newProvider.Identification = txtIdentification.Text.Trim();
                newProvider.Name = txtName.Text.Trim();
                newProvider.Adress = txtAddress.Text.Trim();
                newProvider.Phone = txtPhone.Text.Trim();

                daoProvider.insertProvider(newProvider);
                CargarProveedoresGrid();

                MessageBox.Show("Proveedor creado correctamente.", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El campo Identificacion no debe estar vacío.", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }
        //Botón Guardar

        //Cargar Datagrid con DataTable - PROVEEDORES
        public void CargarProveedoresGrid()
        {
            DataTable dt = daoProvider.fillProviderDT();
            dgvProveedores.DataSource = dt;
            dgvProveedores.Columns[0].HeaderText = "CÓDIGO";
            dgvProveedores.Columns[1].HeaderText = "IDENTIFICACIÓN";
            dgvProveedores.Columns[2].HeaderText = "NOMBRE";
            dgvProveedores.Columns[3].HeaderText = "DIRECCIÓN";
            dgvProveedores.Columns[4].HeaderText = "TELÉFONO";
        }

        //Doble Click para pasar datos del Grid a los textbox para su edición.
        private void dgvProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvR = new DataGridViewRow();
            dgvR = dgvProveedores.Rows[this.dgvProveedores.CurrentCell.RowIndex];
            
            txtIdentification.Text = dgvR.Cells[1].Value.ToString().Trim();
            txtName.Text = dgvR.Cells[2].Value.ToString().Trim();
            txtAddress.Text = dgvR.Cells[3].Value.ToString().Trim();
            txtPhone.Text = dgvR.Cells[4].Value.ToString().Trim();

            CargarProveedoresGrid();
        }

        //Botón Limpiar campos de texto
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtIdentification.Text = "";
            this.txtName.Text = "";
            this.txtAddress.Text = "";
            this.txtPhone.Text = "";
        }

        //Botón Elimiar proveedor por Identificación
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtIdentification.Text.Trim() != "")
            {
                daoProvider.deleteProvider(txtIdentification.Text);
                CargarProveedoresGrid();
                MessageBox.Show("Proveedor:" + txtIdentification.Text.Trim() + " Eliminado satisfactoriamente.", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Especifique una identificación de proveedor para eliminación", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Botón Exportar a Excel
        #region Botón de ExportExcel
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Documentos de Excel (*.xls)|*.xls";
            sfd.FileName = "Softband - Proveedores - " + DateTime.Now.ToShortDateString().Replace("/","_")+ ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToExcel(dgvProveedores, sfd.FileName); // Here dataGridview1 is your grid view name
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

        //Boton Buscar One
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtIdentification.Text.Trim() != "")
            {
                newProvider = daoProvider.selectProvider(txtIdentification.Text.Trim());

                var id = newProvider.Id;
                txtIdentification.Text = newProvider.Identification;
                txtName.Text = newProvider.Name;
                txtAddress.Text = newProvider.Adress;
                txtPhone.Text = newProvider.Phone;
            }
            else
            {
                MessageBox.Show("Especifique una identificación de proveedor para la consulta", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        //KeyEnterPress para busqueda
        private void txtIdentification_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (e.KeyChar == '\r')
            {
                btnSearch_Click(null, null);
            }
        }
    }
}
