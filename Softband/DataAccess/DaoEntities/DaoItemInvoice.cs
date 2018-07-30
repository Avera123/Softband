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
    public class DaoItemInvoice
    {
        ConectionDB ConectDB = new ConectionDB();
        InvoiceItemcs newItem = new InvoiceItemcs();
        private string Query;

        public List<InvoiceItemcs> getAllAccounts()
        {
            List<InvoiceItemcs> ListAccount = new List<InvoiceItemcs>();

            string Query = "SELECT id, code, name, price, quantity, codeinvoice, nota FROM facturaitem WHERE active=1;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            Cmm.Connection.Close();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    newItem = new InvoiceItemcs();
                    newItem.Id = (int)reader["id"];
                    newItem.Code = (string)reader["code"];
                    newItem.Name = (string)reader["name"];
                    newItem.Price = (double)reader["price"];
                    newItem.Quantity = (int)reader["quantity"];
                    newItem.CodeInvoice = (string)reader["codeinvoice"];
                    newItem.Note = (string)reader["nota"];

                    ListAccount.Add(newItem);
                }
            }

            return ListAccount;
        }

        public DataTable fillItemsDT(string daoFac)
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM facturaitem WHERE codeinvoice ='"+daoFac+"';", ConectDB.getConection());
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la carga de items: " + ex.Message);
            }

            return dt;
        }

        public void insertItemInvoice(InvoiceItemcs _ItemInvoice)
        {
            try
            {
                Query = "INSERT INTO facturaitem(code, name, price, quantity, codeinvoice, nota) values('" +
                _ItemInvoice.Code.Trim() + "','" +
                _ItemInvoice.Name.Trim() + "','" +
                _ItemInvoice.Price.ToString() + "','" +
                _ItemInvoice.Quantity + "','" +
                _ItemInvoice.CodeInvoice + "','" +
                _ItemInvoice.Note + "');";    

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();

                updateStock(_ItemInvoice.Code, _ItemInvoice.Quantity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertBand", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void updateStock(String _code, int _stock)
        {
            try
            {
                int stockVal = 0;
                Query = "SELECT stock FROM producto WHERE code='"+ _code +"';";

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                
                MySqlDataReader reader = Cmm.ExecuteReader();

                while (reader.Read())
                {
                    stockVal = (int)reader["stock"];
                }

                Query = "UPDATE producto SET stock = "+ (stockVal - _stock).ToString() + " WHERE code='" + _code + "';";

                Cmm = new MySqlCommand(Query, ConectDB.getConection());

                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nupdate stock", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*public Account selectAccount(string _Code)
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
        }*/

        public bool ExistAccount(string _Code)
        {
            string Query = "SELECT * FROM cuenta WHERE code ='" + _Code + "';";

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
    }
}
