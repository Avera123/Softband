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
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
            FillCbBands();
            CargarClientsGrid();
            rdName.Checked = true;
        }

        DaoClient daoClient = new DaoClient();
        Client newClient = new Client();
        List<Client> ListClients = new List<Client>();
        List<Band> ListBands = new List<Band>();
        GenericQuerys QueryBands = new GenericQuerys();
        DataTable dt;

        public void FillCbBands()
        {
            cbBands.DataSource = null;
            ListBands = QueryBands.getAllBands();

            cbBands.DataSource = ListBands;
            cbBands.ValueMember = "Id";
            cbBands.DisplayMember = "Name";
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtIDClient.Text = "";
            this.txtNameClient.Text = "";
            this.cbBands.SelectedIndex = 0;
            this.txtAddressClient.Text = "";
            this.txtEmailClient.Text = "";
            this.txtPhoneClient.Text = "";
            this.txtCelClient.Text = "";
            this.txtCreditClient.Text = "0.OO";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIDClient.Text.Trim() != "")
                {
                    if (daoClient.ExistClient(txtIDClient.Text.Trim()))
                    {
                        newClient = daoClient.selectClient(txtIDClient.Text.Trim());

                        txtIDClient.Text = newClient.ID.Trim();
                        txtNameClient.Text = newClient.Name.Trim();
                        cbBands.SelectedValue = newClient.IdBand;
                        txtEmailClient.Text = newClient.Email;
                        txtAddressClient.Text = newClient.Address;
                        txtPhoneClient.Text = newClient.Phone;
                        txtCelClient.Text = newClient.MobilePhone;
                        txtCreditClient.Text = newClient.Credit.ToString("C");
                    }
                    else
                    {
                        MessageBox.Show("Cliente no existente",
                            "Validación del Sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);

                        txtNameClient.Text = "";
                        cbBands.SelectedValue = "";
                        txtEmailClient.Text = "";
                        txtAddressClient.Text = "";
                        txtPhoneClient.Text = "";
                        txtCelClient.Text = "";
                        txtCreditClient.Text = "$0";
                    }
                }
                else
                {
                    btnClear_Click(null, null);
                    MessageBox.Show("El Campo Identificación no debe estar vacío",
                        "Validación del Sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del Cliente:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
           daoClient.autoCompleteClientID(txtIDClient);
           daoClient.autoCompleteClientName(txtNameClient);
        }

        // Metodo Cargar Datos de la Grid dgvClients
        public void CargarClientsGrid()
        {
            dt = daoClient.fillClientsDT();
            dgvClients.DataSource = dt;

            dgvClients.Columns[0].HeaderText = "ID";
            dgvClients.Columns[1].HeaderText = "IDENTIFICACIÓN";
            dgvClients.Columns[2].HeaderText = "NOMBRE";
            dgvClients.Columns[3].HeaderText = "IDBANDA";
            dgvClients.Columns[4].HeaderText = "BANDA";
            dgvClients.Columns[5].HeaderText = "CORREO";
            dgvClients.Columns[6].HeaderText = "DIRECCIÓN";
            dgvClients.Columns[7].HeaderText = "TELÉFONO";
            dgvClients.Columns[8].HeaderText = "CELULAR";
            dgvClients.Columns[9].HeaderText = "CRÉDITO";
            dgvClients.Columns[9].DefaultCellStyle.Format = "c";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIDClient.Text != "")
                {
                    newClient.ID = txtIDClient.Text.Trim();
                    newClient.Name = txtNameClient.Text.Trim();
                    newClient.IdBand = (int)cbBands.SelectedValue;
                    newClient.Email = txtEmailClient.Text.Trim();
                    newClient.Address = txtAddressClient.Text.Trim();
                    newClient.Phone = txtPhoneClient.Text.Trim();
                    newClient.MobilePhone = txtCelClient.Text.Trim();
                    newClient.Credit = Convert.ToDouble(txtCreditClient.Text.Trim().Replace("$", ""));

                    daoClient.insertClient(newClient);
                    CargarClientsGrid();

                    MessageBox.Show("Cliente guardado:\n" + newClient.Name,
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El campo Identificación no debe ir vacío", "Validación del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Realmente desea Eliminar este Cliente?",
                    "Confirmación",
                    MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (txtIDClient.Text.Trim() != "")
                    {
                        daoClient.deleteClient(txtIDClient.Text.Trim());
                        btnClear_Click(null, null);
                        MessageBox.Show("Cliente Eliminado Correctamente.",
                            "Información",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Campos obligatorios:\n*Identificación",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                else if (result == DialogResult.No)
                {
                    btnClear_Click(null, null);
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

        //Boton crear Banda
        private void btnBanda_Click(object sender, EventArgs e)
        {
            Bandas bandas = new Bandas();
            bandas.ShowDialog();
        }

        //Boton actualizar ComboBox Bandas
        private void btnRefreshBandas_Click(object sender, EventArgs e)
        {
            FillCbBands();
        }

        private void dgvClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvR = new DataGridViewRow();
            dgvR = dgvClients.Rows[this.dgvClients.CurrentCell.RowIndex];

            txtIDClient.Text = dgvR.Cells[1].Value.ToString();
            btnSearch_Click(null, null);
        }

        //Botón Exportar a Excel
        #region Botón de ExportExcel
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Documentos de Excel (*.xls)|*.xls";
            sfd.FileName = "Softband - Clientes - " + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToExcel(dgvClients, sfd.FileName); // Here dataGridview1 is your grid view name
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
        
        private void txtIDClient_Leave(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }
        
        private void txtSearchNameClient_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Filter = "";
            if (rdName.Checked)
            {
                Filter = "Name";
            }
            else if (rdBand.Checked)
            {
                Filter = "Banda";
            }
            else if (rdIdentification.Checked)
            {
                Filter = "Identification";
            }

            dt.DefaultView.RowFilter = (Filter + " like '%" + txtSearchNameClient.Text.Trim() + "%'");
            dgvClients.DataSource = dt.DefaultView;
        }

        private void btnRefreshGrid_Click(object sender, EventArgs e)
        {
            CargarClientsGrid();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
