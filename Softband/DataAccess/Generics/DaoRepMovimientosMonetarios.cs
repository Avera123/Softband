using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softband.DataAccess.Generics
{
    public class DaoRepMovimientosMonetarios
    {
        ConectionDB ConectDB = new ConectionDB();

        public DataSet getRepoTranferencias(String Fecha)
        {
            string mesAno = Fecha.Substring(Fecha.IndexOf("/"), 8);
            
            DataSet ds = new DataSet();

            string Query = "SELECT t1.id AS CODIGOMOVIMIENTO, t1.idaccountout AS IDCUENTADERETIRO, t2.name AS CUENTADERETIRO, t1.idaccountin AS IDCUENTADEINGRESO, t3.name AS CUENTADEINGRESO, t1.amount AS VALOR, t1.dateMove AS FECHA FROM transferenciacuentas t1 INNER JOIN cuenta t2 INNER JOIN cuenta t3 ON t1.idaccountin = t2.id AND t1.idaccountout = t3.id WHERE t1.dateMove LIKE '%" + mesAno + "%';";
            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataAdapter da = new MySqlDataAdapter(Cmm);

            da.Fill(ds);

            Cmm.Connection.Close();

            return ds;
        }
    }
}
