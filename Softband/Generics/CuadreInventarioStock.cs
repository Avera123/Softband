using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Softband.Entities;
using Softband.DataAccess.DaoEntities;
using System.IO;

namespace Softband.Generics
{
    public partial class CuadreInventarioStock : Form
    {
        DaoProduct daoPoduct = new DaoProduct();
        List<Product> Products = new List<Product>();

        public CuadreInventarioStock()
        {
            InitializeComponent();
            CargaProductos();
        }
        
        private void CuadreInventarioStock_Load(object sender, EventArgs e)
        {

        }

        public void CargaProductos()
        {
            dgvProductos.Rows.Clear();

            Products = daoPoduct.getAllProducts();

            dgvProductos.Rows.Clear();

            foreach (Product _product in Products)
            {
                dgvProductos.Rows.Add(_product.Id, _product.Code, _product.Name, _product.CostSale, _product.Stock);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            CargaProductos();
        }

        private void dgvProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dgvProductos.Rows.Count; i++)
            {
                double total = Convert.ToDouble(dgvProductos.Rows[i].Cells[4].Value) - Convert.ToDouble(dgvProductos.Rows[i].Cells[5].Value);
                dgvProductos.Rows[i].Cells[6].Value = total;

                if (total < 0)
                {
                    dgvProductos.Rows[i].Cells[6].Style.BackColor = Color.Red;
                }
                else if (total == 0)
                {
                    dgvProductos.Rows[i].Cells[6].Style.BackColor = Color.Green;
                }
                else if (total > 0)
                {
                    dgvProductos.Rows[i].Cells[6].Style.BackColor = Color.Blue;
                }
            }
        }

        private void btnGenerarTotales_Click(object sender, EventArgs e)
        {
            GenerarTotales();
        }

        public void GenerarTotales()
        {
            Double TotalSistema = 0;
            Double TotalReal = 0;
            Double TotalCruce = 0;

            for (int i = 0; i < dgvProductos.Rows.Count; i++)
            {
                TotalSistema += Convert.ToDouble(dgvProductos.Rows[i].Cells[4].Value);
                TotalReal += Convert.ToDouble(dgvProductos.Rows[i].Cells[5].Value);
            }

            TotalCruce = TotalSistema - TotalReal;

            dgvProductos.Rows.Add("","","","TOTALES: ", TotalSistema, TotalReal, TotalCruce);
        }

        //Botón Exportar a Excel
        #region Botón de ExportExcel
        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Documentos de Excel (*.xls)|*.xls";
            sfd.FileName = "Softband - Cuadre de Inventario - " + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToExcel(dgvProductos, sfd.FileName); // Here dataGridview1 is your grid view name
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
