using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Softband.Entities;

namespace Softband.DataAccess.DaoEntities
{
    public class DaoBand
    {
        ConectionDB ConectDB = new ConectionDB();
        Band newBand = new Band();
        List<Band> Bands = new List<Band>();
        private string Query;

        public List<Band> getAllBands()
        {
            List<Band> ListBands = new List<Band>();

            string Query = "SELECT * FROM banda;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            while (reader.Read())
            {
                newBand = new Band();

                newBand.Id =     (int)reader["id"];
                newBand.Code =   (string)reader["code"];
                newBand.Name =   (string)reader["name"];
                newBand.Active = (bool)reader["active"];

                ListBands.Add(newBand);
            }

            return ListBands;
        }

        public void insertBand(Band _Band)
        {
            int Active = 0;
            if (_Band.Active){Active = 1; }

            try
            {
                if (ExistBand(_Band.Code))
                {
                    Query = "UPDATE banda SET name='"+ _Band.Name.Trim() +"', active="+ Active +" WHERE code='"+ _Band.Code.Trim() +"';";
                }
                else
                {
                    Query = "INSERT INTO banda(code, name, active) values('" + _Band.Code.Trim() + "','" + _Band.Name.Trim() + "','" + Active + "');";
                }
                
                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertBand", "Error del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void deleteBand(string _Code)
        {
            try
            {
                string Query = "DELETE FROM banda WHERE code = '"+ _Code.Trim() +"';";

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ndeleteBand", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public Band selectBand(string _Code)
        {
            string Query = "SELECT * FROM banda WHERE code ='" + _Code + "';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            if (reader.Read())
            {
                newBand.Id = (int)reader["id"];
                newBand.Code = (string)reader["code"];
                newBand.Name = (string)reader["name"];
                newBand.Active = (bool)reader["active"];
            }

            return newBand;
        }

        public bool ExistBand(string _Code)
        {
            string Query = "SELECT * FROM banda WHERE code ='" + _Code + "';";

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
