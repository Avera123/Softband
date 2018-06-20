using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softband.DataAccess.Generics
{
    public class DaoRepVentas
    {
        ConectionDB ConectDB = new ConectionDB();

        public DataSet getVentasDia(String Fecha)
        {
            DataSet ds = new DataSet();

            string Query = "SELECT factura.code AS CódigoFactura, factura.identification AS IDCliente, factura.nameClient AS NombreCliente, factura.banda AS Banda, factura.fecha AS Fecha, factura.amount AS Valor, cuenta.name AS CuentaAfectada FROM(factura INNER JOIN cuenta ON factura.idaccountin = cuenta.id) WHERE factura.fecha = '" + Fecha + "';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataAdapter da = new MySqlDataAdapter(Cmm);

            da.Fill(ds);
            Cmm.Connection.Close();

            return ds;
        }

        public DataSet getVentasMes(String Fecha)
        {
            string mesAno = Fecha.Substring(Fecha.IndexOf("/"),8);

            DataSet ds = new DataSet();

            string Query = "SELECT factura.code AS CódigoFactura, factura.identification AS IDCliente, factura.nameClient AS NombreCliente, factura.banda AS Banda, factura.fecha AS Fecha, factura.amount AS Valor, cuenta.name AS CuentaAfectada FROM(factura INNER JOIN cuenta ON factura.idaccountin = cuenta.id) WHERE factura.fecha LIKE '%" + mesAno + "%';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataAdapter da = new MySqlDataAdapter(Cmm);

            da.Fill(ds);

            Cmm.Connection.Close();

            return ds;
        }

        public DataSet getVentasAnual(String Anio)
        {
            string mesAno = Anio.Substring(Anio.Length-4,4);

            DataSet ds = new DataSet();

            string Query = "SELECT factura.code AS CódigoFactura, factura.identification AS IDCliente, factura.nameClient AS NombreCliente, factura.banda AS Banda, factura.fecha AS Fecha, factura.amount AS Valor, cuenta.name AS CuentaAfectada FROM(factura INNER JOIN cuenta ON factura.idaccountin = cuenta.id) WHERE factura.fecha LIKE '%" + mesAno + "%';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataAdapter da = new MySqlDataAdapter(Cmm);

            da.Fill(ds);

            Cmm.Connection.Close();

            return ds;
        }
    }
}
