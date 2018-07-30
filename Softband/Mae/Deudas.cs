using Softband.DataAccess.DaoEntities;
using Softband.DataAccess.Generics;
using Softband.Entities;
using Softband.Maestros;
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
    public partial class Deudas : Form
    {
        public Deudas()
        {
            InitializeComponent();
            CargarDebtsGrid();
            CargarDebtsGridTotales();
            FillCbAccountsIn();
            TotalDeudas();
        }

        DaoClient daoClient = new DaoClient();
        DaoDebt daoDebt = new DaoDebt();
        DaoAccount daoAccount = new DaoAccount();
        Client newClient = new Client();
        Debt newDebt = new Debt();
        Account account = new Account();
        DataTable dt;
        GenericQuerys GenericQuerys = new GenericQuerys();

        public void CargarDebtsGrid()
        {
            dt = daoDebt.fillDebtsDT();
            dgvDeudas.DataSource = dt;
            dgvDeudas.Columns[5].DefaultCellStyle.Format = "c";
            TotalDeudas();
        }

        public void TotalDeudas()
        {
            double montoTotal = 0;
            if (dgvDeudasClientes.Rows.Count >= 1)
            {
                foreach (DataGridViewRow item in dgvDeudasClientes.Rows)
                {
                    montoTotal += Convert.ToDouble(item.Cells[0].Value);
                }
            }

            lblTotalizarDeudas.Text = montoTotal.ToString("C");
        }
        private void btnTotalizarDeudas_Click(object sender, EventArgs e)
        {
            this.TotalDeudas();
        }

        public void CargarDebtsGridTotales()
        {
            dt = daoDebt.fillDebtsTotalClientDT();
            dgvDeudasClientes.DataSource = dt;
            dgvDeudasClientes.Columns[0].DefaultCellStyle.Format = "c";
            TotalDeudas();
        }

        public void CargarDebtsGridTodas()
        {
            dt = daoDebt.fillDebtsDTTodas();
            dgvDeudas.DataSource = dt;
            dgvDeudas.Columns[5].DefaultCellStyle.Format = "c";
            TotalDeudas();
        }

        public void CargarDebtsGridSaldadas()
        {
            dt = daoDebt.fillDebtsDTSaldadas();
            dgvDeudas.DataSource = dt;
            dgvDeudas.Columns[5].DefaultCellStyle.Format = "c";
            TotalDeudas();
        }

        public void FillCbAccountsIn()
        {
            cbAccounts.DataSource = null;
            List<Account> ListAccount = GenericQuerys.getAllAccounts();

            cbAccounts.DataSource = ListAccount;
            cbAccounts.ValueMember = "Id";
            cbAccounts.DisplayMember = "Name";
        }

        //Boton de enlace para crear nuevo cliente
        private void btnNewCliente_Click(object sender, EventArgs e)
        {
            Cliente newFormClient = new Cliente();
            newFormClient.ShowDialog();
        }

        //Boton para consultar cliente por cedula
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtIDClient.Text.Trim() != "")
            {
                newClient = daoClient.selectClient(txtIDClient.Text);
                lblNameCliente.Text = newClient.Name;
            }
            else
            {
                txtAmount.Text = "";
                txtFact.Text = "";
                lblNameCliente.Text = "---";
                dtpDate.Value = DateTime.Now;
                MessageBox.Show("Cliente no existente por favor valide la información.", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //txt Identificacion Leave
        private void txtIDClient_Leave(object sender, EventArgs e)
        {
            btnSearch_Click(null, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblNameCliente.Text != "---" && txtIDClient.Text.Trim() != "")
            {
                if (txtAmount.Text.Trim() != "" && Convert.ToDouble(txtAmount.Text.Trim()) >= 50)
                {
                    if (daoClient.ExistClient(txtIDClient.Text))
                    {
                        newClient = daoClient.selectClient(txtIDClient.Text.Trim());
                        newDebt.IDClient = newClient.ID;
                        newDebt.IDBanda = newClient.IdBand;
                        newDebt.NameClient = newClient.Name;
                        newDebt.CodFact = txtFact.Text.Trim();
                        newDebt.Amount = Convert.ToDouble(txtAmount.Text);
                        newDebt.Date = dtpDate.Value.ToShortDateString();
                        newDebt.Active = true;

                        daoDebt.insertDebt(newDebt);
                        CargarDebtsGrid();
                        CargarDebtsGridTotales();
                        MessageBox.Show("Deuda creada al cliente: " + lblNameCliente.Text, "Información el Sitema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnClear_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Cliente inexistente, pruebe con otro documento y presione el boton de buscar para consultar los datos del cliente; o de ser necesario creelo pulsando en el botón mas(+) de color verde.", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("El monto excede el Crédito del cliente.", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("El campo de identificación es obligatorio y debe estar creado el sistema.", "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Deudas_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAmount.Text = "";
            txtFact.Text = "";
            txtIDClient.Text = "";
            lblNameCliente.Text = "---";
            dtpDate.Value = DateTime.Now;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvR = new DataGridViewRow();
            dgvR = dgvDeudas.Rows[this.dgvDeudas.CurrentCell.RowIndex];
            string cliente = Convert.ToString(dgvR.Cells[2].Value);
            
            if (dgvDeudas.SelectedRows.Count > 1)
            {
                if (Convert.ToString(dgvR.Cells[7].Value) != "SALDADA")
                {
                    List<Account> _Accounts = new List<Account>();
                    account = daoAccount.selectAccount(Convert.ToInt32(cbAccounts.SelectedValue));
                    foreach (DataGridViewRow row in this.dgvDeudas.SelectedRows)
                    {
                        daoDebt.changeState(Convert.ToInt32(row.Cells[0].Value));

                        account.Amount += Convert.ToDouble(row.Cells[5].Value);

                        _Accounts.Add(account);

                        daoAccount.updateValuesAccount(_Accounts);
                    }

                    MessageBox.Show("Deuda saldada para el cliente: " + cliente);
                    CargarDebtsGrid();
                    CargarDebtsGridTotales();
                }
                else
                {
                    MessageBox.Show("Esta deuda ya ha sido saldada.", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (dgvDeudas.SelectedRows.Count == 1)
                {
                    if (Convert.ToString(dgvR.Cells[7].Value) == "SALDADA")
                    {
                        MessageBox.Show("Esta deuda ya ha sido saldada.", "Información del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("¿Realmente desea saldar la deuda para el cliente: \n " + dgvR.Cells[2].Value
                           + " por valor de: \n" + dgvR.Cells[5].Value + "?",
                               "Confirmación",
                               MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            daoDebt.changeState(Convert.ToInt32(dgvR.Cells[0].Value));
                            account = daoAccount.selectAccount(Convert.ToInt32(cbAccounts.SelectedValue));

                            account.Amount += Convert.ToDouble(dgvR.Cells[5].Value);
                            daoAccount.insertAccount(account);

                            MessageBox.Show("Deuda saldada para el cliente: " + dgvR.Cells[2].Value);
                            CargarDebtsGrid();
                            CargarDebtsGridTotales();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No ha seleccionado ninguna deuda para saldar","Validación del sistema", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }     
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //ExportToExcel();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Documentos de Excel (*.xls)|*.xls";
            sfd.FileName = "Softband - Listado de Deudas - " + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dgvDeudas, sfd.FileName); // Here dataGridview1 is your grid view name
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

        //Ver todas las deudas
        private void button1_Click(object sender, EventArgs e)
        {
            CargarDebtsGrid();
            CargarDebtsGridTotales();
        }

        private void btnTodas_Click(object sender, EventArgs e)
        {
            CargarDebtsGridTodas();
        }

        private void btnSaldadas_Click(object sender, EventArgs e)
        {
            CargarDebtsGridSaldadas();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
