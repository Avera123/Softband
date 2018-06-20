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

namespace Softband.Mae
{
    public partial class Cuentas : Form
    {
        Account newAccount = new Account();
        DaoAccount daoAccount = new DaoAccount();
        GenericQuerys GenericQuerys = new GenericQuerys();
        List<Bank> ListBanks = new List<Bank>();
        DataTable dt;

        public Cuentas()
        {
            InitializeComponent();
            FillCbBanks();
            CargarAccountsGrid();
        }

        public void FillCbBanks()
        {
            cbBancos.DataSource = null;
            ListBanks = GenericQuerys.getAllBanks();

            cbBancos.DataSource = ListBanks;
            cbBancos.ValueMember = "Id";
            cbBancos.DisplayMember = "Name";            
        }

        public void CargarAccountsGrid()
        {
            dt = daoAccount.fillAccountsDT();
            dgvAccounts.DataSource = dt;

            dgvAccounts.Columns[0].HeaderText = "ID";
            dgvAccounts.Columns[1].HeaderText = "NOMBRE";
            dgvAccounts.Columns[2].HeaderText = "IDBANCO";
            dgvAccounts.Columns[3].HeaderText = "BANCO";
            dgvAccounts.Columns[4].HeaderText = "DESCRIPCIÓN";
            dgvAccounts.Columns[5].HeaderText = "TIPOCUENTA";
            dgvAccounts.Columns[6].HeaderText = "MONTOACTUAL";
            dgvAccounts.Columns[6].DefaultCellStyle.Format = "c";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int idBank = Convert.ToInt32(cbBancos.SelectedValue);
                int typeAccount = cbTypeAccount.SelectedIndex;

                if (idBank < 0) { idBank = 1; }
                if (typeAccount < 0) { typeAccount = 1; }

                if (txtNameAccount.Text.Trim() != "" &&
                txtDescriptionAccount.Text.Trim() != "" &&
                txtAmount.Text.Trim() != "")
                {
                    newAccount.Name = txtNameAccount.Text.Trim();
                    newAccount.IdBank = idBank;
                    newAccount.Description = txtDescriptionAccount.Text.Trim();
                    newAccount.Type = typeAccount;

                    try
                    {
                        newAccount.Amount = Convert.ToDouble(txtAmount.Text.Trim().Replace("$", ""));
                        daoAccount.insertAccount(newAccount);
                        CargarAccountsGrid();
                        newAccount.Id = 0;
                        MessageBox.Show("Cuenta guardada Satisfactoriamente:\n" + newAccount.Name,
                            "Información del sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al convertir campo de Monto inicial\n:" + ex.Message, "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Campos obligatorios:\n* Nombre\n* Monto inicial",
                        "Validación del sistema",
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNameAccount.Text.Trim() != "")
                {
                    if (daoAccount.ExistAccount(newAccount.Id))
                    {
                        newAccount = daoAccount.selectAccount(newAccount.Id);
                        
                        txtNameAccount.Text = newAccount.Name.Trim();
                        txtDescriptionAccount.Text = newAccount.Description;
                        cbBancos.SelectedIndex = newAccount.IdBank-1;
                        cbTypeAccount.SelectedIndex = newAccount.Type;
                        txtAmount.Text = newAccount.Amount.ToString("C");
                    }
                    else
                    {
                        btnClear_Click(null, null);
                        MessageBox.Show("Cuenta no existente",
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
                MessageBox.Show("Error al cargar datos de la Cuenta:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtNameAccount.Text = "";
            this.txtDescriptionAccount.Text = "";
            this.cbBancos.SelectedIndex = 0;
            this.cbTypeAccount.SelectedIndex = 1;
            this.txtAmount.Text= "$0.00";
            newAccount.Id = 0;
            CargarAccountsGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Realmente desea Eliminar esta Cuenta?",
                    "Confirmación",
                    MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (newAccount.Id >= 1)
                    {
                        daoAccount.deleteAccount(newAccount.Id);
                        btnClear_Click(null, null);
                        CargarAccountsGrid();
                        MessageBox.Show("Cuenta Eliminada Correctamente.",
                            "Información del sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Campos obligatorios:\n*Código\n También puede provar seleccionar primero la cuenta de la rejilla de datos.",
                            "Validación del sistema",
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
                MessageBox.Show("Error al Eliminar Cuenta:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Cuentas_Load(object sender, EventArgs e)
        {

        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            //Double valor = Double.Parse(txtAmount.Text.Trim());
            //txtAmount.Text = valor.ToString("C");
        }

        private void btnNewBank_Click(object sender, EventArgs e)
        {
            Bancos newBank = new Bancos();
            newBank.ShowDialog();
        }

        private void btnRefreshBanks_Click(object sender, EventArgs e)
        {
            FillCbBanks();
        }

        private void dgvBandas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvR = new DataGridViewRow();
            dgvR = dgvAccounts.Rows[this.dgvAccounts.CurrentCell.RowIndex];

            newAccount.Id = Convert.ToInt32(dgvR.Cells[0].Value);
            newAccount.Name = dgvR.Cells[1].Value.ToString();
            newAccount.IdBank = Convert.ToInt32(dgvR.Cells[2].Value);
            newAccount.Description = dgvR.Cells[4].Value.ToString();
            newAccount.Type = Convert.ToInt32(dgvR.Cells[5].Value);
            newAccount.Amount = Convert.ToDouble(dgvR.Cells[6].Value);

            if (dgvR.Cells[1].Value.ToString() != "")
            {
                txtNameAccount.Text = newAccount.Name;
                txtDescriptionAccount.Text = newAccount.Description;
                cbBancos.SelectedValue = newAccount.IdBank;
                cbTypeAccount.SelectedIndex = newAccount.Type;
                txtAmount.Text = newAccount.Amount.ToString("C");
            }
        }

        //Botón Exportar a Excel
        #region Botón de ExportExcel
        private void btnExport_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Documentos de Excel (*.xls)|*.xls";
            sfd.FileName = "Softband - Cuentas - " + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToExcel(dgvAccounts, sfd.FileName); // Here dataGridview1 is your grid view name
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
    }
}
