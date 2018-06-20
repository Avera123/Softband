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
    public class DaoPromo
    {
        ConectionDB ConectDB = new ConectionDB();
        Promotion newPromo = new Promotion();
        List<Promotion> Promos = new List<Promotion>();
        private string Query;

        public List<Promotion> getAllPromos()
        {
            List<Promotion> ListPromos = new List<Promotion>();

            string Query = "SELECT * FROM promo;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            Cmm.Connection.Close();

            while (reader.Read())
            {
                newPromo = new Promotion();

                newPromo.Id = (int)reader["id"];
                newPromo.Code = (string)reader["code"];
                newPromo.Name = (string)reader["name"];
                newPromo.Description = (string)reader["description"];
                newPromo.Active = (bool)reader["active"];
                newPromo.Percent = (int)reader["percent"];

                ListPromos.Add(newPromo);
            }

            return ListPromos;
        }

        public void insertPromo(Promotion _Promo)
        {
            int Active = 0;
            if (_Promo.Active) { Active = 1; }

            try
            {
                if (ExistPromo(_Promo.Code))
                {
                    Query = "UPDATE promo SET name='" + _Promo.Name.Trim()
                        + "', description='" + _Promo.Description.Trim()
                        + "', active='" + Active
                        + "', percent='" + _Promo.Percent
                        + "' WHERE code='" + _Promo.Code.Trim() + "';";
                }
                else
                {
                    Query = "INSERT INTO promo(code, name, description, active, percent) values('" 
                        + _Promo.Code.Trim() + "','" 
                        + _Promo.Name.Trim() + "','"
                        + _Promo.Description.Trim() + "','"
                        + Active + "','"
                        + _Promo.Percent +"');";
                }

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertPromo", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void deletePromo(string _Code)
        {
            try
            {
                string Query = "DELETE FROM promo WHERE code = '" + _Code.Trim() + "';";

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ndeletePromo", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Promotion selectPromo(string _Code)
        {
            string Query = "SELECT * FROM promo WHERE code ='" + _Code + "';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            Cmm.Connection.Close();

            if (reader.Read())
            {
                newPromo.Id = (int)reader["id"];
                newPromo.Code = (string)reader["code"];
                newPromo.Name = (string)reader["name"];
                newPromo.Description = (string)reader["description"];
                newPromo.Active = (bool)reader["active"];
                newPromo.Percent = (int)reader["percent"];
            }

            return newPromo;
        }

        public bool ExistPromo(string _Code)
        {
            string Query = "SELECT * FROM promo WHERE code ='" + _Code + "';";

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
