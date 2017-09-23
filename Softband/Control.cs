using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Softband.Maestros;
using Softband.Mae;
using Softband.Generics;

namespace Softband
{
    public partial class Control : Form
    {
        public Control()
        {
            InitializeComponent();
        }

        private void Men_CatProductos_Click(object sender, EventArgs e)
        {
            CategoriaProducto Categorias = new CategoriaProducto();
            Categorias.ShowDialog();
        }

        private void Men_Clientes_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.ShowDialog();
        }

        private void bandasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bandas banda = new Bandas();
            banda.ShowDialog();
        }

        private void Men_Productos_Click(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            producto.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            usuario.ShowDialog();
        }

        private void cuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cuentas cuenta = new Cuentas();
            cuenta.ShowDialog();
        }

        private void bancosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bancos banco = new Bancos();
            banco.ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Realmente desea Salir de la Aplicación?",
                    "Confirmación",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Realmente desea Salir de la Aplicación?",
                    "Confirmación",
                    MessageBoxButtons.YesNoCancel,MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            MovCuentas MovCuentas = new MovCuentas();
            MovCuentas.ShowDialog();
        }

        private void btnIngresoSalida_Click(object sender, EventArgs e)
        {
            IngresosYEgresos IngresoEgreso = new IngresosYEgresos();
            IngresoEgreso.ShowDialog();
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            Ventas Venta = new Ventas();
            Venta.Show();
        }

        private void saldosDeCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnPromos_Click(object sender, EventArgs e)
        {
            Promo promo = new Promo();
            promo.ShowDialog();
        }
    }
}
