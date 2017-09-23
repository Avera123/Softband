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
    public class DaoBank
    {
        ConectionDB ConectDB = new ConectionDB();
        Bank newBank = new Bank();
        private string Query;

        public void insertBank(Bank _Bank)
        {
            int Active = 0;
            if (_Bank.Active) { Active = 1; }

            try
            {
                if (ExistBank(_Bank.Code))
                {
                    Query = "UPDATE banco SET name='" + _Bank.Name.Trim() + "', active=" + Active + " WHERE code='" + _Bank.Code.Trim() + "';";
                }
                else
                {
                    Query = "INSERT INTO banco(code, name, active) values('" + _Bank.Code.Trim() + "','" + _Bank.Name.Trim() + "','" + Active + "');";
                }

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertBank", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void deleteBank(string _Code)
        {
            try
            {
                string Query = "DELETE FROM banco WHERE code = '" + _Code.Trim() + "';";

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ndeleteBand", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Bank selectBank(string _Code)
        {
            string Query = "SELECT * FROM banco WHERE code ='" + _Code + "';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            if (reader.Read())
            {
                newBank.Id = (int)reader["id"];
                newBank.Code = (string)reader["code"];
                newBank.Name = (string)reader["name"];
                newBank.Active = (bool)reader["active"];
            }

            return newBank;
        }

        public bool ExistBank(string _Code)
        {
            string Query = "SELECT * FROM banco WHERE code ='" + _Code + "';";

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

        public List<Bank> getAllBanks()
        {
            List<Bank> ListBanks = new List<Bank>();

            string Query = "SELECT * FROM banco;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            while (reader.Read())
            {
                newBank = new Bank();

                newBank.Id = (int)reader["id"];
                newBank.Code = (string)reader["code"];
                newBank.Name = (string)reader["name"];
                newBank.Active = (bool)reader["active"];

                ListBanks.Add(newBank);
            }

            return ListBanks;
        }

    }
}
