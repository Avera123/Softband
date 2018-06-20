using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Softband.Entities;
using System.Data;

namespace Softband.DataAccess.DaoEntities
{
    public class DaoBand
    {
        ConectionDB ConectDB = new ConectionDB();
        Band newBand = new Band();
        List<Band> Bands = new List<Band>();
        private string Query;        

        public void insertBand(Band _Band)
        {
            try
            {
                //if (ExistBand(_Band.Id))
                //{
                //    Query = "UPDATE banda SET name='"+ _Band.Name.Trim() +"', active="+ Active +" WHERE code='"+ _Band.Code.Trim() +"';";
                //}
                //else
                //{
                    Query = "INSERT INTO banda(name) values('" + _Band.Name.Trim()+ "');";
                //}
                
                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertBand", "Error del Sistema",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void deleteBand(int _Id)
        {
            try
            {
                string Query = "DELETE FROM banda WHERE id = '"+ _Id +"';";

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
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

            Cmm.Connection.Close();

            if (reader.Read())
            {
                newBand.Id = (int)reader["id"];
                newBand.Name = (string)reader["name"];
            }

            return newBand;
        }

        public bool ExistBand(int _Id)
        {
            string Query = "SELECT * FROM banda WHERE id ='" + _Id + "';";

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

        public void autoCompleteBandName(TextBox txtIN)
        {
            string Query = "SELECT name FROM banda;";

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

                newBand.Id = (int)reader["id"];
                newBand.Name = (string)reader["name"];

                ListBands.Add(newBand);
            }

            Cmm.Connection.Close();
            return ListBands;
        }

        public DataTable fillBandsDT()
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("Select id, name From banda", ConectDB.getConection());
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
