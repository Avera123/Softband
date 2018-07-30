using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softband.DataAccess.Generics
{
    public class DaoRepFacturas
    {
        ConectionDB ConectDB = new ConectionDB();

        public DataSet getFacturasDia(String Fecha)
        {
            DataSet ds = new DataSet();

            string Query = "SELECT factura.id AS ID, factura.code AS CODIGO, factura.identification AS IDCLIENTE, factura.nameClient AS NOMBRECLIENTE, factura.banda AS BANDA, factura.fecha AS FECHA, factura.amount AS VALOR, cuenta.name AS CUENTAAFECTADA FROM(factura INNER JOIN cuenta ON factura.idaccountin = cuenta.id) WHERE factura.fecha = '" + Fecha + "';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataAdapter da = new MySqlDataAdapter(Cmm);

            da.Fill(ds);
            Cmm.Connection.Close();

            return ds;
        }

        public DataSet getFacturasMes(String Fecha)
        {
            string mesAno = Fecha.Substring(Fecha.IndexOf("/"), 8);

            DataSet ds = new DataSet();

            string Query = "SELECT factura.id AS ID, factura.code AS CODIGO, factura.identification AS IDCLIENTE, factura.nameClient AS NOMBRECLIENTE, factura.banda AS BANDA, factura.fecha AS FECHA, factura.amount AS VALOR, cuenta.name AS CUENTAAFECTADA FROM(factura INNER JOIN cuenta ON factura.idaccountin = cuenta.id) WHERE factura.fecha LIKE '%" + mesAno + "%';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataAdapter da = new MySqlDataAdapter(Cmm);

            da.Fill(ds);

            Cmm.Connection.Close();

            return ds;
        }

        public DataSet getFacturasAnual(String Anio)
        {
            string mesAno = Anio.Substring(Anio.Length - 4, 4);

            DataSet ds = new DataSet();

            string Query = "SELECT factura.id AS ID, factura.code AS CODIGO, factura.identification AS IDCLIENTE, factura.nameClient AS NOMBRECLIENTE, factura.banda AS BANDA, factura.fecha AS FECHA, factura.amount AS VALOR, cuenta.name AS CUENTAAFECTADA FROM(factura INNER JOIN cuenta ON factura.idaccountin = cuenta.id) WHERE factura.fecha LIKE '%" + mesAno + "%';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataAdapter da = new MySqlDataAdapter(Cmm);

            da.Fill(ds);

            Cmm.Connection.Close();

            return ds;
        }
    }
}
