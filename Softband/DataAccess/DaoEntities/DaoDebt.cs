using MySql.Data.MySqlClient;
using Softband.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Softband.DataAccess.DaoEntities
{
    public class DaoDebt
    {
        ConectionDB ConectDB = new ConectionDB();
        string Query = "";
        Debt newDebt = new Debt();
        double saldo = 0;

        public void insertDebt(Debt _debt)
        {
            try
            {
                if (!ExistDebt(_debt.Id))
                {
                    Query = "INSERT INTO deuda(IDClient, IDBanda, nameClient, codeFact, amount, date, active) " +
                            "VALUES('" + _debt.IDClient + "','" + _debt.IDBanda + "','" + _debt.NameClient + "','" 
                            + _debt.CodFact + "','" + _debt.Amount + "','" + _debt.Date + "',"
                            + _debt.Active + ");";
                }
                else
                {
                    Query = "UPDATE deuda SET amount='" + _debt.Amount +"' WHERE id='"+_debt.Id+"';";
                }
                
                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertDebt", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ExistDebt(int _Id)
        {
            string Query = "SELECT * FROM deuda WHERE id ='" + _Id + "' AND active = 1;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Double getSaldoByIDCliente(string _Id)
        {
            string Query = "SELECT IDClient AS IDENTIFICACION, SUM(amount) AS SALDO, nameClient AS NOMBRECLIENTE FROM deuda WHERE IDClient = '"+_Id+"' AND active = 1 GROUP BY IDClient;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            if (reader.Read())
            {
                saldo = (double)reader["SALDO"];
            }
            else
            {
                saldo = 0;
            }

            return saldo;
        }

        public DataTable fillDebtsDT()
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT t1.id AS ID, t1.IDClient AS IDENTIFICACION, t1.nameClient AS CLIENTE,t2.name AS BANDA, t1.codeFact AS FACTURA, t1.amount AS MONTO, t1.date AS FECHA, IF(active = 0, 'SALDADA', 'VIGENTE') AS ESTADO FROM deuda t1, banda t2 WHERE t1.IDBanda = t2.id AND t1.active = 1;", ConectDB.getConection());
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la carga de deudas: " + ex.Message);
            }
            return dt;
        }

        public DataTable fillDebtsTotalClientDT()
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT SUM(t1.amount) AS MONTO, t1.nameClient AS CLIENTE, t2.name AS BANDA, t1.IDClient AS IDENTIFICACION FROM deuda t1, banda t2 WHERE t1.IDBanda = t2.id AND t1.active = 1 GROUP BY t1.IDClient, t1.nameClient, t2.name;", ConectDB.getConection());
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la carga de deudas: " + ex.Message);
            }
            return dt;
        }

        public DataTable fillDebtsDTSaldadas()
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT t1.id AS ID, t1.IDClient AS IDENTIFICACION, t1.nameClient AS CLIENTE,t2.name AS BANDA, t1.codeFact AS FACTURA, t1.amount AS MONTO, t1.date AS FECHA, IF(active = 0, 'SALDADA', 'VIGENTE') AS ESTADO FROM deuda t1, banda t2 WHERE t1.IDBanda = t2.id AND t1.active = 0;", ConectDB.getConection());
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la carga de deudas: " + ex.Message);
            }
            return dt;
        }

        public DataTable fillDebtsDTTodas()
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT t1.id AS ID, t1.IDClient AS IDENTIFICACION, t1.nameClient AS CLIENTE,t2.name AS BANDA, t1.codeFact AS FACTURA, t1.amount AS MONTO, t1.date AS FECHA, IF(active = 0, 'SALDADA', 'VIGENTE') AS ESTADO FROM deuda t1, banda t2 WHERE t1.IDBanda = t2.id;", ConectDB.getConection());
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la carga de deudas: " + ex.Message);
            }
            return dt;
        }

        public void changeState(int _Id)
        {
            try
            {
                string Query = "UPDATE deuda SET active =0 WHERE id = '" + _Id + "';";

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nchangeState", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable getSaldos()
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT IDClient AS IDENTIFICACION, SUM(amount) AS SALDO, nameClient AS NOMBRECLIENTE FROM deuda GROUP BY IDClient;", ConectDB.getConection());
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la carga de deudas: " + ex.Message);
            }
            return dt;            
        }
    }
}
