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

namespace Softband.Reports.Reports
{
    public partial class IngresosEgresosAno : Form
    {
        public IngresosEgresosAno()
        {
            InitializeComponent();
            RecalcularTotales();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DaoRepIngEgr daoRepCompras = new DaoRepIngEgr();
            DataSet dsData = daoRepCompras.getIngEgrAnual(dtpFecha.Value.ToShortDateString());
            refreshData();
            dgvData.DataSource = dsData.Tables[0];
            RecalcularTotales();
        }

        public void RecalcularTotales()
        {
            Double totalizacionIngresos = 0;
            Double totalizacionEgresos = 0;
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (row.Cells[5].Value.ToString().Equals("INGRESO"))
                {
                    totalizacionIngresos += Convert.ToDouble(row.Cells[6].Value);
                }
                else
                {
                    totalizacionEgresos += Convert.ToDouble(row.Cells[6].Value);
                }
            }
            lblIngresos.Text = totalizacionIngresos.ToString("C");
            lblEgresos.Text = totalizacionEgresos.ToString("C");
        }

        public void refreshData()
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
            sfd.FileName = "Ingresos y Egresos del año - " + dtpFecha.Value.ToShortDateString().Replace("/", "") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dgvData, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }
    }
}
