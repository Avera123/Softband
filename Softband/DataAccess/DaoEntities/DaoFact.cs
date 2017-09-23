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

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    newAccount = new Account();
                    newAccount.Id = (int)reader["id"];
                    newAccount.Code = (string)reader["code"];
                    newAccount.Name = (string)reader["name"];
                    newAccount.Active = (bool)reader["active"];

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
                    "', fecha='" + _Invoice.Fecha +
                    "', amount='" + _Invoice.Amount +
                    "', idaccountin='" + _Invoice.IdAccountIn +
                    "', active='" + Active +
                    " WHERE code='" + _Invoice.Code.Trim() + "';";
                }
                else
                {
                    Query = "INSERT INTO factura(code, identification, fecha, amount, idaccountin, active) values('" +
                    _Invoice.Code.Trim() + "','" +
                    _Invoice.Identification.Trim() + "','" +
                    _Invoice.Fecha.ToString() + "','" +
                    _Invoice.Amount + "','" +
                    _Invoice.IdAccountIn + "','" +
                    Active + "');";
                }

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();
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

            if (reader.Read())
            {
                newAccount.Id = (int)reader["id"];
                newAccount.Code = (string)reader["code"];
                newAccount.Name = (string)reader["name"];
                newAccount.IdBank = (int)reader["idbank"];
                newAccount.Description = (string)reader["description"];
                newAccount.Type = (int)reader["type"];
                newAccount.Active = (bool)reader["active"];
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

            if (reader.Read())
            {
                newAccount = new Account();
                newAccount.Id = (int)reader["id"];
                newAccount.Code = (string)reader["code"];
                newAccount.Name = (string)reader["name"];
                newAccount.IdBank = (int)reader["idbank"];
                newAccount.Description = (string)reader["description"];
                newAccount.Type = (int)reader["type"];
                newAccount.Active = (bool)reader["active"];
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ndeleteBand", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ExistInvoice(string _Code)
        {
            string Query = "SELECT * FROM factura WHERE code ='" + _Code + "';";

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
    }
}
