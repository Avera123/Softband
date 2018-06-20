using Softband.DataAccess.DaoEntities;
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

namespace Softband.Generics
{
    public partial class CuadreCajas : Form
    {
        public CuadreCajas()
        {
            InitializeComponent();
            CargaCajas();
        }
        DaoAccount DaoAccount = new DaoAccount();
        List<Account> Accounts = new List<Account>();

        private void CuadreCajas_Load(object sender, EventArgs e)
        {
            
        }

        public void CargaCajas()
        {
            dgvCajas.Rows.Clear();
            
            Accounts = DaoAccount.getCajas();

            dgvCajas.Rows.Clear();

            foreach (Account _account in Accounts)
            {
                dgvCajas.Rows.Add(_account.Id, _account.Name, _account.Amount);
            }
        }

        public void GenerarTotales()
        {
            Double TotalSistema = 0;
            Double TotalReal = 0;
            Double TotalCruce = 0;

            for (int i = 0; i < dgvCajas.Rows.Count; i++)
            {
                TotalSistema += Convert.ToDouble(dgvCajas.Rows[i].Cells[2].Value);
                TotalReal += Convert.ToDouble(dgvCajas.Rows[i].Cells[3].Value);
            }

            TotalCruce = TotalSistema - TotalReal;

            dgvCajas.Rows.Add("", "TOTALES: ", TotalSistema, TotalReal, TotalCruce);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargaCajas();
        }

        private void dgvCajas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dgvCajas.Rows.Count; i++)
            {
                double total = Convert.ToDouble(dgvCajas.Rows[i].Cells[2].Value) - Convert.ToDouble(dgvCajas.Rows[i].Cells[3].Value);
                dgvCajas.Rows[i].Cells[4].Value = total;

                if (total < 0)
                {
                    dgvCajas.Rows[i].Cells[4].Style.BackColor = Color.Red;
                }
                else if (total == 0)
                {
                    dgvCajas.Rows[i].Cells[4].Style.BackColor = Color.Green;
                }
                else if (total > 0)
                {
                    dgvCajas.Rows[i].Cells[4].Style.BackColor = Color.Blue;
                }
            }
        }

        private void btnGenerarTotales_Click(object sender, EventArgs e)
        {
            GenerarTotales();
        }


        //Botón Exportar a Excel
        #region Botón de ExportExcel
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Documentos de Excel (*.xls)|*.xls";
            sfd.FileName = "Softband - Cuadre de Caja - " + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToExcel(dgvCajas, sfd.FileName); // Here dataGridview1 is your grid view name
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
