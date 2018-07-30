using Softband.DataAccess.Generics;
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
    public partial class RepMovimientosMonetariosMensuales : Form
    {
        public RepMovimientosMonetariosMensuales()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DaoRepMovimientosMonetarios daoRepTransMoves = new DaoRepMovimientosMonetarios();
            DataSet dsData = daoRepTransMoves.getRepoTranferencias(dtpFecha.Value.ToShortDateString());
            refreshData();
            dgvData.DataSource = dsData.Tables[0];
            RecalcularTotales();
        }
        
        public void RecalcularTotales()
        {
            Double totalizacion = 0;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                totalizacion += Convert.ToDouble(row.Cells[5].Value);
            }
            lblTotalizarMovimientos.Text = totalizacion.ToString();
        }

        private void refreshData()
        {
            dgvData.DataSource = null;
        }

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
            sfd.FileName = "Transferencias del mes - " + dtpFecha.Value.Month + dtpFecha.Value.Year + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dgvData, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }
    }
}
