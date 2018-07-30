using MySql.Data.MySqlClient;
using Softband.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Softband.DataAccess.DaoEntities
{
    public class DaoFact
    {
        ConectionDB ConectDB = new ConectionDB();
        Account newAccount = new Account();
        private string Query;

        public List<Account> getAllAccounts()
        {
            List<Account> ListAccount = new List<Account>();

            string Query = "SELECT id, code, name, active  FROM cuenta WHERE active=1;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            Cmm.Connection.Close();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    newAccount = new Account();
                    newAccount.Id = (int)reader["id"];
                    newAccount.Name = (string)reader["name"];

                    ListAccount.Add(newAccount);
                }
            }

            return ListAccount;
        }

        public void insertInvoice(Invoice _Invoice)
        {
            int Active = 0;
            if (_Invoice.Active) { Active = 1; }

            try
            {
                if (ExistInvoice(_Invoice.Code))
                {
                    Query = "UPDATE factura SET identification='" + _Invoice.Identification.Trim() +
                    "', nameClient='" + _Invoice.NameClient +
                    "', banda='" + _Invoice.Band +
                    "', fecha='" + _Invoice.Fecha +
                    "', amount='" + _Invoice.Amount +
                    "', idaccountin='" + _Invoice.IdAccountIn +
                    "', active='" + Active +
                    " WHERE code='" + _Invoice.Code.Trim() + "';";
                }
                else
                {
                    Query = "INSERT INTO factura(code, identification,nameClient, banda, fecha, amount, idaccountin, active) values('" +
                    _Invoice.Code.Trim() + "','" +
                    _Invoice.Identification.Trim() + "','" +
                    _Invoice.NameClient.Trim() + "','" +
                    _Invoice.Band.Trim() + "','" +
                    _Invoice.Fecha + "','" +
                    _Invoice.Amount + "','" +
                    _Invoice.IdAccountIn + "','" +
                    Active + "');";
                }

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertBand", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Account selectAccount(string _Code)
        {
            string Query = "SELECT * FROM cuenta WHERE code ='" + _Code + "';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            Cmm.Connection.Close();

            if (reader.Read())
            {
                newAccount.Id = (int)reader["id"];
                newAccount.Name = (string)reader["name"];
                newAccount.IdBank = (int)reader["idbank"];
                newAccount.Description = (string)reader["description"];
                newAccount.Type = (int)reader["type"];
                newAccount.Amount = Convert.ToDouble(reader["amount"]);
            }

            return newAccount;
        }

        public Account selectAccountId(int _Id)
        {
            string Query = "SELECT * FROM cuenta WHERE id ='" + _Id + "';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            Cmm.Connection.Close();

            if (reader.Read())
            {
                newAccount = new Account();
                newAccount.Id = (int)reader["id"];
                newAccount.Name = (string)reader["name"];
                newAccount.IdBank = (int)reader["idbank"];
                newAccount.Description = (string)reader["description"];
                newAccount.Type = (int)reader["type"];
                newAccount.Amount = Convert.ToDouble(reader["amount"]);
            }

            return newAccount;
        }

        public void deleteAccount(string _Code)
        {
            try
            {
                string Query = "DELETE FROM cuenta WHERE code = '" + _Code.Trim() + "';";

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ndeleteBand", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Invoice getInvoice(string _Code)
        {
            Invoice inv = new Invoice();
            string Query = "SELECT * FROM factura WHERE code ='" + _Code + "';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();
            if (reader.Read())
            {
                inv.Id = (int)reader["id"];
                inv.Code = (string)reader["code"];
                inv.Identification = (string)reader["identification"];
                inv.NameClient = (string)reader["nameClient"];
                inv.Band = (string)reader["banda"];
                inv.Amount = (double)reader["amount"];
                inv.Band = (string)reader["banda"];
                inv.Fecha = (string)reader["fecha"];
                inv.Active = (bool)reader["active"];
            }

            Cmm.Connection.Close();
            return inv;
        }

        public bool ExistInvoice(string _Code)
        {
            string Query = "SELECT * FROM factura WHERE code ='" + _Code + "';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            Cmm.Connection.Close();

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
            double saldo;
            string Query = "SELECT IDClient AS IDENTIFICACION, SUM(amount) AS SALDO, nameClient AS NOMBRECLIENTE FROM deuda WHERE IDClient = '" + _Id + "' AND active = 1 GROUP BY IDClient;";

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
    }
}
