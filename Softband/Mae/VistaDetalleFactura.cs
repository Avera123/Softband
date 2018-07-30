using MySql.Data.MySqlClient;
using Softband.DataAccess;
using Softband.DataAccess.DaoEntities;
using Softband.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Softband.Mae
{
    public partial class VistaDetalleFactura : Form
    {
        public VistaDetalleFactura(string codFact)
        {
            InitializeComponent();
            getFactura(codFact);
        }

        ConectionDB ConectDB = new ConectionDB();
        DataTable ds = new DataTable();

        private void VistaDetalleFactura_Load(object sender, EventArgs e)
        {

        }

        public void getFactura(string code)
        {
            Invoice factura = new Invoice();
            DaoItemInvoice daoItemFact = new DaoItemInvoice();

            ds = daoItemFact.fillItemsDT(code);
            dgvListado.DataSource = ds;

            lblNameClient.Text = factura.NameClient;
            lblCantProductos.Text = factura.Code + "Fecha: " + factura.Fecha;
            lblFact.Text = factura.Identification;
            lblTotal.Text = factura.Amount.ToString();

            string Query = "SELECT * FROM factura WHERE code='"+ code +"';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();
            factura = new Invoice();

            if (reader.Read())
            {
                factura.Id = (int)reader["id"];
                factura.Code = (string)reader["code"];
                factura.Identification = (string)reader["identification"];
                factura.NameClient = (string)reader["nameClient"];
                factura.Band = (string)reader["banda"];
                factura.Fecha = (string)reader["fecha"];
                factura.Amount = (double)reader["amount"];
            }

            int intCantFact = dgvListado.Rows.Count - 1;
           
            Cmm.Connection.Close();

            lblBandName.Text = factura.Band.ToString();
            lblCantProductos.Text = intCantFact.ToString();
            lblFact.Text = factura.Code;
            lblNameClient.Text = factura.NameClient;
            lblTotal.Text = "$ " + factura.Amount.ToString();
            lblFecha.Text = factura.Fecha;
        }
    }
}
