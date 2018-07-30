using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softband.DataAccess.Generics
{
    public class DaoRepCompras
    {
        ConectionDB ConectDB = new ConectionDB();

        public DataSet getComprasDia(String Fecha)
        {
            DataSet ds = new DataSet();

            string Query = "SELECT compra.id AS CódigoCompra, compra.idproveedor AS IDProveedor, proveedor.name AS NombreProveedor, compra.idaccountout AS CuentaAfectada, cuenta.name AS NombreCuentaAfectada, compra.description AS Descripcion, compra.amount AS Valor, compra.date FROM(compra INNER JOIN cuenta ON compra.idaccountout = cuenta.id INNER JOIN proveedor ON compra.idproveedor = proveedor.id) WHERE compra.date ='" + Fecha + "';";
            
            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataAdapter da = new MySqlDataAdapter(Cmm);

            da.Fill(ds);
            Cmm.Connection.Close();

            return ds;
        }

        public DataSet getComprasMes(String Fecha)
        {
            string mesAno = Fecha.Substring(Fecha.IndexOf("/"), 8);

            DataSet ds = new DataSet();

            string Query = "SELECT compra.id AS CódigoCompra, compra.idproveedor AS IDProveedor, proveedor.name AS NombreProveedor, compra.idaccountout AS CuentaAfectada, cuenta.name AS NombreCuentaAfectada, compra.description AS Descripcion, compra.amount AS Valor, compra.date FROM(compra INNER JOIN cuenta ON compra.idaccountout = cuenta.id INNER JOIN proveedor ON compra.idproveedor = proveedor.id) WHERE compra.date LIKE '%" + mesAno + "%';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataAdapter da = new MySqlDataAdapter(Cmm);

            da.Fill(ds);

            Cmm.Connection.Close();

            return ds;
        }

        public DataSet getComprasAnual(String Anio)
        {
            string mesAno = Anio.Substring(Anio.Length - 4, 4);

            DataSet ds = new DataSet();

            string Query = "SELECT compra.id AS CódigoCompra, compra.idproveedor AS IDProveedor, proveedor.name AS NombreProveedor, compra.idaccountout AS CuentaAfectada, cuenta.name AS NombreCuentaAfectada, compra.description AS Descripcion, compra.amount AS Valor, compra.date FROM(compra INNER JOIN cuenta ON compra.idaccountout = cuenta.id INNER JOIN proveedor ON compra.idproveedor = proveedor.id) WHERE compra.date LIKE '%" + mesAno + "%';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataAdapter da = new MySqlDataAdapter(Cmm);

            da.Fill(ds);

            Cmm.Connection.Close();

            return ds;
        }
    }
}
