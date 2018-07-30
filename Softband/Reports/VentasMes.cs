using MySql.Data.MySqlClient;
using Softband.DataAccess;
using Softband.DataAccess.Generics;
using Softband.Mae;
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

namespace Softband.Reports
{
    public partial class VentasMes : Form
    {
        public VentasMes()
        {
            InitializeComponent();
        }

        ConectionDB ConectDB = new ConectionDB();

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DaoRepVentas daoRepVentas = new DaoRepVentas();
            DataSet dsData = daoRepVentas.getVentasMes(dtpFecha.Value.ToShortDateString());
            refreshData();
            dgvData.Columns.Clear();
            dgvData.Rows.Clear();
            dgvData.DataSource = dsData.Tables[0];

            DataGridViewColumn colum = new DataGridViewColumn();
            colum.HeaderText = "FacturaEnDeuda";
            colum.CellTemplate = new DataGridViewTextBoxCell();
            dgvData.Columns.Add(colum);

            int idFact = 0;
            string Fact = "";
            double totalDeudas = 0;
            int countDeudas = 0;

            System.Collections.IList list = dgvData.Rows;
            for (int i = 0; i < list.Count; i++)
            {
                DataGridViewRow row = (DataGridViewRow)list[i];
                string Query = "SELECT deuda.id AS CODIGODEUDA, deuda.codeFact AS FACTURA, amount AS MONTO FROM deuda WHERE deuda.codeFact = '" + row.Cells[0].Value + "' AND deuda.active = 1;";

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

                MySqlDataReader reader;

                reader = Cmm.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        idFact = (int)reader["CODIGODEUDA"];
                        Fact = (string)reader["FACTURA"];
                    }

                    if (idFact > 0)
                    {
                        row.Cells[7].Value = "SI";
                        row.Cells[7].ReadOnly = true;
                        row.Cells[7].Style.BackColor = Color.Red;
                    }
                    else
                    {
                        row.Cells[7].Value = "NO";
                        row.Cells[7].ReadOnly = true;
                        row.Cells[7].Style.BackColor = Color.Green;
                    }
                }

                Cmm.Connection.Close();
            }
            RecalcularTotales();
        }

        public void RecalcularTotales()
        {
            Double totalizacion = 0;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                totalizacion += Convert.ToDouble(row.Cells[5].Value);
            }
            lblCantidadEnDeuda.Text = Convert.ToString(dgvData.Rows.Count);
            lblTotalizarDeudas.Text = totalizacion.ToString();
        }

        private void refreshData()
        {
            dgvData.DataSource = null;
        }
        
        /*
         * Generar Excel
         */
        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount - 1; i++)
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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            //ExportToExcel();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Ventas del mes - " + dtpFecha.Value.Month + dtpFecha.Value.Year + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dgvData, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }

        private void dgvData_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvR = new DataGridViewRow();
            dgvR = dgvData.Rows[this.dgvData.CurrentCell.RowIndex];

            VistaDetalleFactura detalle = new VistaDetalleFactura(dgvR.Cells[0].Value.ToString().Trim());
            detalle.ShowDialog();
        }

        private void VentasMes_Load(object sender, EventArgs e)
        {

        }
    }
}
