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
    public class DaoBank
    {
        ConectionDB ConectDB = new ConectionDB();
        Bank newBank = new Bank();
        private string Query;

        //Metodo Insertar Banco
        public void insertBank(Bank _Bank)
        {
            try
            {
                //if (ExistBank(_Bank.Id))
                //{
                //    Query = "UPDATE banco SET name='" + _Bank.Name.Trim() + "' WHERE id='" + _Bank.Id + "';";
                //}
                //else
                //{
                Query = "INSERT INTO banco(name) values('" + _Bank.Name.Trim() + "');";
                //}

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertBank", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Metodo Delete Bank
        public void deleteBank(int _Id)
        {
            try
            {
                string Query = "DELETE FROM banco WHERE id = '" + _Id + "';";

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ndeleteBank", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //public Bank selectBank(int _Id)
        //{
        //    string Query = "SELECT * FROM banco WHERE id ='" + _Id + "';";

        //    MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

        //    MySqlDataReader reader;

        //    reader = Cmm.ExecuteReader();


        //    if (reader.Read())
        //    {
        //        newBank.Id = (int)reader["id"];
        //        newBank.Name = (string)reader["name"];
        //    }

        //    Cmm.Connection.Close();

        //    return newBank;
        //}

        // Metodo de validación de Existencia
        public bool ExistBank(int _Id)
        {
            string Query = "SELECT * FROM banco WHERE id ='" + _Id + "';";

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

        //public List<Bank> getAllBanks()
        //{
        //    List<Bank> ListBanks = new List<Bank>();

        //    string Query = "SELECT * FROM banco;";

        //    MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

        //    MySqlDataReader reader;

        //    reader = Cmm.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        newBank = new Bank();

        //        newBank.Id = (int)reader["id"];
        //        newBank.Name = (string)reader["name"];

        //        ListBanks.Add(newBank);
        //    }

        //    Cmm.Connection.Close();

        //    return ListBanks;
        //}

        //Metodo de Carga para Grid Bancos
        public DataTable fillBanksDT()
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("Select id, name From banco", ConectDB.getConection());
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la carga de bancos: " + ex.Message);
            }

            return dt;
        }

        //Metodo Autocomplete By Name
        public void autoCompleteBankName(TextBox txtIN){
            string Query = "SELECT name FROM banco;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            if (reader.Read())
            {
                txtIN.AutoCompleteCustomSource.Add(reader["name"].ToString());
            }
            reader.Close();
            Cmm.Connection.Close();
        }

    }
}
