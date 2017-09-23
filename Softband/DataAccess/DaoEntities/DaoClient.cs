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

            return newClient;
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
                return true;
            }
            else
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ndeleteClient", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
