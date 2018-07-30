using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softband.DataAccess.Generics
{
    public class DaoRepIngEgr
    {
        ConectionDB ConectDB = new ConectionDB();

        public DataSet getIngEgrDia(String Fecha)
        {
            DataSet ds = new DataSet();

            string Query = "SELECT movimientosmonetarios.id AS CODIGOMOVIMIENTO, movimientosmonetarios.idaccount AS IDCUENTAAFECTADA, cuenta.name AS NOMBRECUENTAAFECTADA, movimientosmonetarios.idcatmovement AS IDCATEGORIAMOVIMIENTO, categoriamovimientos.name AS CATEGORIAMOVIMIENTO, IF(idtypemovement = 0, 'INGRESO', 'EGRESO') AS TIPOMOVIMIENTO, movimientosmonetarios.amount AS VALOR, movimientosmonetarios.description AS DESCRIPCION, movimientosmonetarios.date AS FECHA FROM(movimientosmonetarios INNER JOIN cuenta ON movimientosmonetarios.idaccount = cuenta.id INNER JOIN categoriamovimientos ON movimientosmonetarios.idcatmovement = categoriamovimientos.id) WHERE movimientosmonetarios.date ='" + Fecha + "';";
            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataAdapter da = new MySqlDataAdapter(Cmm);

            da.Fill(ds);
            Cmm.Connection.Close();

            return ds;
        }

        public DataSet getIngEgrMes(String Fecha)
        {
            string mesAno = Fecha.Substring(Fecha.IndexOf("/"), 8);

            DataSet ds = new DataSet();

            string Query = "SELECT movimientosmonetarios.id AS CODIGOMOVIMIENTO, movimientosmonetarios.idaccount AS IDCUENTAAFECTADA, cuenta.name AS NOMBRECUENTAAFECTADA, movimientosmonetarios.idcatmovement AS IDCATEGORIAMOVIMIENTO, categoriamovimientos.name AS CATEGORIAMOVIMIENTO, IF(idtypemovement = 0, 'INGRESO', 'EGRESO') AS TIPOMOVIMIENTO, movimientosmonetarios.amount AS VALOR, movimientosmonetarios.description AS DESCRIPCION, movimientosmonetarios.date AS FECHA FROM(movimientosmonetarios INNER JOIN cuenta ON movimientosmonetarios.idaccount = cuenta.id INNER JOIN categoriamovimientos ON movimientosmonetarios.idcatmovement = categoriamovimientos.id) WHERE movimientosmonetarios.date LIKE '%" + mesAno + "%';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataAdapter da = new MySqlDataAdapter(Cmm);

            da.Fill(ds);

            Cmm.Connection.Close();

            return ds;
        }

        public DataSet getIngEgrAnual(String Anio)
        {
            string mesAno = Anio.Substring(Anio.Length - 4, 4);

            DataSet ds = new DataSet();

            string Query = "SELECT movimientosmonetarios.id AS CODIGOMOVIMIENTO, movimientosmonetarios.idaccount AS IDCUENTAAFECTADA, cuenta.name AS NOMBRECUENTAAFECTADA, movimientosmonetarios.idcatmovement AS IDCATEGORIAMOVIMIENTO, categoriamovimientos.name AS CATEGORIAMOVIMIENTO, IF(idtypemovement = 0, 'INGRESO', 'EGRESO') AS TIPOMOVIMIENTO, movimientosmonetarios.amount AS VALOR, movimientosmonetarios.description AS DESCRIPCION, movimientosmonetarios.date AS FECHA FROM(movimientosmonetarios INNER JOIN cuenta ON movimientosmonetarios.idaccount = cuenta.id INNER JOIN categoriamovimientos ON movimientosmonetarios.idcatmovement = categoriamovimientos.id) WHERE movimientosmonetarios.date LIKE '%" + mesAno + "%';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataAdapter da = new MySqlDataAdapter(Cmm);

            da.Fill(ds);

            Cmm.Connection.Close();

            return ds;
        }
    }
}
