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
    public class DaoClient
    {
        Client newClient = new Client();
        List<Client> ListClients = new List<Client>();
        ConectionDB ConectDB = new ConectionDB();
        string Query = "";

        public List<Client> getAllClients()
        {
            List<Client> ListClients = new List<Client>();
            string Query = "SELECT id, identification, name, idband, email, address, phone, mobilephone, credit FROM cliente;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            Cmm.Connection.Close();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    newClient = new Client();
                    newClient.Id = (int)reader["id"];
                    newClient.ID = (string)reader["identification"];
                    newClient.Name = (string)reader["name"];
                    newClient.IdBand = (int)reader["idband"];
                    newClient.Email = (string)reader["email"];
                    newClient.Address = (string)reader["address"];
                    newClient.Phone = (string)reader["phone"];
                    newClient.MobilePhone = (string)reader["mobilephone"];
                    newClient.Credit = (double)reader["credit"];

                    ListClients.Add(newClient);
                }
            }

            return ListClients;
        }

        public Client selectClient(string _ID)
        {
            string Query = "SELECT * FROM cliente WHERE identification ='" + _ID + "';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            if (reader.Read())
            {
                newClient.Id = (int)reader["id"];
                newClient.ID = (string)reader["identification"];
                newClient.Name = (string)reader["name"];
                newClient.IdBand = (int)reader["idband"];
                newClient.Email = (string)reader["email"];
                newClient.Address = (string)reader["address"];
                newClient.Phone = (string)reader["phone"];
                newClient.MobilePhone = (string)reader["mobilephone"];
                newClient.Credit = (double)reader["credit"];
            }
            reader.Close();

            Cmm.Connection.Close();

            return newClient;
        }

        public void autoCompleteClientID(TextBox txtIN)
        {
            string Query = "SELECT identification FROM cliente;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            if (reader.Read())
            {
                txtIN.AutoCompleteCustomSource.Add(reader["identification"].ToString());
            }
            reader.Close();
            Cmm.Connection.Close();
        }

        public void autoCompleteClientName(TextBox txtIN)
        {
            string Query = "SELECT name FROM cliente;";

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

        public void insertClient(Client _Client)
        {
            try
            {
                if (ExistClient(_Client.ID))
                {
                    Query = "UPDATE cliente SET identification='" + _Client.ID.Trim() +
                    "', name='" + _Client.Name +
                    "', idband='" + _Client.IdBand +
                    "', email='" + _Client.Email +
                    "', address='" + _Client.Address +
                    "', phone='" + _Client.Phone +
                    "', mobilephone='" + _Client.MobilePhone +
                    "', credit='" + _Client.Credit +
                    "' WHERE identification='" + _Client.ID.Trim() + "';";
                }
                else
                {
                    Query = "INSERT INTO cliente(identification, name, idband, email, address, phone, mobilephone, credit) VALUES('" +
                    _Client.ID.Trim() + "','" +
                    _Client.Name.Trim() + "','" +
                    _Client.IdBand.ToString() + "','" +
                    _Client.Email.Trim() + "','" +
                    _Client.Address + "','" +
                    _Client.Phone + "','" +
                    _Client.MobilePhone + "','" +
                    _Client.Credit + "');";
                }

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertClient", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ExistClient(string _ID)
        {
            string Query = "SELECT * FROM cliente WHERE identification ='" + _ID + "';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                Cmm.Connection.Close();
                return true;
            }
            else
            {
                reader.Close();
                Cmm.Connection.Close();
                return false;
            }
        }

        public void deleteClient(string _ID)
        {
            try
            {
                string Query = "DELETE FROM cliente WHERE identification = '" + _ID.Trim() + "';";

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ndeleteClient", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable fillClientsDT()
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("Select t1.id, t1.identification, t1.name, t2.id AS idBanda, t2.name AS banda, t1.email, t1.address, t1.phone, t1.mobilephone, t1.credit From cliente t1, banda t2 WHERE t1.idband = t2.id", ConectDB.getConection());
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
