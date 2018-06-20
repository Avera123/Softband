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
    public class DaoAccount
    {
        ConectionDB ConectDB = new ConectionDB();
        Account newAccount = new Account();
        private string Query;
        
        public List<Account> getCajas()
        {
            List<Account> ListAccount = new List<Account>();

            string Query = "SELECT id, name, amount  FROM cuenta;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();
            
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    newAccount = new Account();
                    newAccount.Id = (int)reader["id"];
                    newAccount.Name = (string)reader["name"];
                    newAccount.Amount = Convert.ToDouble(reader["amount"]);

                    ListAccount.Add(newAccount);
                }
            }

            Cmm.Connection.Close();

            return ListAccount;
        }

        public List<Account> getAllAccounts()
        {
            List<Account> ListAccount = new List<Account>();

            string Query = "SELECT id, name  FROM cuenta;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();
            
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

            Cmm.Connection.Close();

            return ListAccount;
        }

        public void insertAccount(Account _Account)
        {
            try
            {
                if (ExistAccount(_Account.Id))
                {
                    try
                    {
                        DialogResult result = MessageBox.Show("¿Realmente desea actualizar el monto actual de esta Cuenta?",
                            "Confirmación",
                            MessageBoxButtons.YesNoCancel);
                        if (result == DialogResult.Yes)
                        {
                            Query = "UPDATE cuenta SET name='" + _Account.Name.Trim() +
                            "', idbank='" + _Account.IdBank +
                            "', description='" + _Account.Description +
                            "', type='" + _Account.Type +
                            "', amount='" + _Account.Amount.ToString() + "'" +
                            " WHERE id='" + _Account.Id + "';";
                        }
                        else
                        {
                            DialogResult result2 = MessageBox.Show("¿Desea actualizar los datos de la Cuenta sin el monto actual?",
                            "Confirmación",
                            MessageBoxButtons.YesNoCancel);
                            if (result2 == DialogResult.Yes)
                            {
                                Query = "UPDATE cuenta SET name='" + _Account.Name.Trim() +
                                "', idbank='" + _Account.IdBank +
                                "', description='" + _Account.Description +
                                "', type='" + _Account.Type +
                                "' WHERE id='" + _Account.Id + "';";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al Actualizar monto Cuenta:\n" + ex.Message,
                            "Error del Sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Query = "INSERT INTO cuenta(name, idbank, description, type, amount) values('" +
                    _Account.Name.Trim() + "','" +
                    _Account.IdBank.ToString() + "','" +
                    _Account.Description.Trim() + "','" +
                    _Account.Type.ToString() + "','" +
                    _Account.Amount +"');";
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

        public Account selectAccount(int Id_)
        {
            string Query = "SELECT * FROM cuenta WHERE id ='" + Id_ + "';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();
            
            if (reader.Read())
            {
                newAccount.Id = (int)reader["id"];
                newAccount.Name = (string)reader["name"];
                newAccount.IdBank = (int)reader["idbank"];
                newAccount.Description = (string)reader["description"];
                newAccount.Type = (int)reader["type"];
                newAccount.Amount = Convert.ToDouble(reader["amount"]);
            }

            Cmm.Connection.Close();

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
                newAccount.Name = (string)reader["name"];
                newAccount.IdBank = (int)reader["idbank"];
                newAccount.Description = (string)reader["description"];
                newAccount.Type = (int)reader["type"];
                newAccount.Amount = Convert.ToDouble(reader["amount"]);
            }

            Cmm.Connection.Close();

            return newAccount;
        }

        public void deleteAccount(int _Id)
        {
            try
            {
                string Query = "DELETE FROM cuenta WHERE id = '" + _Id + "';";

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ndeleteBand", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ExistAccount(int _Id)
        {
            string Query = "SELECT * FROM cuenta WHERE id ='" + _Id + "';";

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

        public DataTable fillAccountsDT()
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT t1.id, t1.name, t1.idbank, t2.name AS bank, t1.description, t1.type, t1.amount FROM cuenta t1, banco t2 WHERE t1.idbank = t2.id;", ConectDB.getConection());
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la carga de bandas: " + ex.Message);
            }

            return dt;
        }
    }
}
