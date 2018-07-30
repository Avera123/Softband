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
using Softband.Reports;
using Softband.Reports.Reports;

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
        }

        private void categoríasDeMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CategoriaMovimientos newCate = new CategoriaMovimientos();
            newCate.Show();
        }

        private void ingresosEgresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresosYEgresos newInEg = new IngresosYEgresos();
            newInEg.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas ven = new Ventas();
            ven.ShowDialog();
        }

        private void movimientosEntreCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovCuentas accountMovs = new MovCuentas();
            accountMovs.ShowDialog();
        }

        private void diarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentasDia ventas = new VentasDia();
            ventas.Show();
        }

        private void mensualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentasMes ventasMes = new VentasMes();
            ventasMes.Show();
        }

        private void anualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentasAnual ventasAnual = new VentasAnual();
            ventasAnual.Show();
        }

        private void cuadreDeCajasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CuadreCajas cuadre = new CuadreCajas();
            cuadre.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedores provider = new Proveedores();
            provider.Show();
        }

        private void cuadreDeInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CuadreInventarioStock newStock = new CuadreInventarioStock();
            newStock.Show();
        }

        private void registroDeComprasYActualizaciónDeInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Compras comp = new Compras();
            comp.Show();
        }

        private void deudasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deudas newDeuda = new Deudas();
            newDeuda.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Deudas newDeuda = new Deudas();
            newDeuda.ShowDialog();
        }

        private void diarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ComprasDias newRepCom = new ComprasDias();
            newRepCom.ShowDialog();
        }

        private void mensualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ComprasMes newRepCom = new ComprasMes();
            newRepCom.ShowDialog();
        }

        private void anualToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ComprasAno newRepCom = new ComprasAno();
            newRepCom.ShowDialog();
        }

        private void díariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresosEgresos ingEgr = new IngresosEgresos();
            ingEgr.ShowDialog();
        }

        private void mensualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresosEgresosMes ingEgr = new IngresosEgresosMes();
            ingEgr.ShowDialog();
        }

        private void anualesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IngresosEgresosAno ingEgr = new IngresosEgresosAno();
            ingEgr.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Control_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click_1(object sender, EventArgs e)
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

        private void btnIngresoSalida_Click_1(object sender, EventArgs e)
        {
            IngresosYEgresos nn = new IngresosYEgresos();
            nn.Show();
        }

        private void btnMovimientos_Click_1(object sender, EventArgs e)
        {
            btnMovimientos_Click(null, null);
        }

        private void btnSales_Click_1(object sender, EventArgs e)
        {
            btnSales_Click(null, null);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Deudas dd = new Deudas();
            dd.Show();
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void diarioToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void mensualToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            RepMovimientosMonetariosMensuales rep = new RepMovimientosMonetariosMensuales();
            rep.Show();
        }
    }
}
