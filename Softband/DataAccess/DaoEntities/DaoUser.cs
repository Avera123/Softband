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
    public class DaoUser
    {
        User newUser = new User();
        List<User> Users = new List<User>();
        ConectionDB ConectDB = new ConectionDB();
        string Query = "";

        public List<User> getAllUsers()
        {
            List<User> ListUsers = new List<User>();
            string Query = "SELECT id, identification, name, nickName, password, active  FROM usuario;";
            
            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    newUser = new User();
                    newUser.Id = (int)reader["id"];
                    newUser.ID = (string)reader["identification"];
                    newUser.Name = (string)reader["name"];
                    newUser.NickName = (string)reader["nickName"];
                    newUser.Password = (string)reader["password"];
                    newUser.Active = (bool)reader["active"];

                    ListUsers.Add(newUser);
                }
            }

            return ListUsers;
        }

        public void insertUser(User _User)
        {
            int Active = 0;
            if (_User.Active) { Active = 1; }

            try
            {
                if (ExistUser(_User.ID))
                {
                    Query = "UPDATE usuario SET name='" + _User.Name.Trim() +
                    "', nickName='" + _User.NickName +
                    "', password='" + _User.Password +
                    "', active=" + Active +
                    " WHERE identification='" + _User.ID.Trim() + "';";
                }
                else
                {
                    Query = "INSERT INTO usuario(identification, name, nickName, password, active) values('" +
                    _User.ID.Trim() + "','" +
                    _User.Name.Trim() + "','" +
                    _User.NickName.ToString() + "','" +
                    _User.Password.Trim() + "','" +
                    Active + "');";
                }

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertUser", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public User selectUser(string _ID)
        {
            string Query = "SELECT * FROM usuario WHERE identification ='" + _ID + "';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            if (reader.Read())
            {
                newUser.Id = (int)reader["id"];
                newUser.ID = (string)reader["identification"];
                newUser.Name = (string)reader["name"];
                newUser.NickName = (string)reader["nickName"];
                newUser.Password = (string)reader["password"];
                newUser.Active = (bool)reader["active"];
            }

            return newUser;
        }

        public bool ExistUser(string _ID)
        {
            string Query = "SELECT * FROM usuario WHERE identification ='" + _ID + "';";

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

        public void deleteUser(string _ID)
        {
            try
            {
                string Query = "DELETE FROM usuario WHERE identification = '" + _ID.Trim() + "';";

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ndeleteBand", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
