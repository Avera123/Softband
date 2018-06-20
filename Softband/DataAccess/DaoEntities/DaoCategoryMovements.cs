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
    public class DaoCategoryMovements
    {
        ConectionDB ConectDB = new ConectionDB();
        CategoryMovements newCatMovements = new CategoryMovements();
        List<CategoryMovements> Cats = new List<CategoryMovements>();
        private string Query;

        //Metodo de carga de datos para grid
        public DataTable fillCategoriesDT()
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("Select id, name, description From categoriamovimientos", ConectDB.getConection());
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la carga de bancos: " + ex.Message);
            }

            return dt;
        }

        //Metodo de inserccion de Categorias
        public void insertCatproduct(CategoryMovements _CatMovement)
        {
            try
            {
                if (ExistCatMovement(_CatMovement.Id))
                {
                    Query = "UPDATE categoriamovimientos SET name='" + _CatMovement.Name.Trim() + "', description='" + _CatMovement.Description + "' WHERE id='" + _CatMovement.Id + "';";
                }
                else
                {
                    Query = "INSERT INTO categoriamovimientos(name, description) VALUES('" + _CatMovement.Name.Trim() + "','" + _CatMovement.Description + "');";
                }

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertCatMoviments", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Metodo de eliminacion de CAtegorias
        public bool deleteCatMovements(int _Id)
        {
            try
            {
                string Query = "DELETE FROM categoriamovimientos WHERE id='" + _Id + "';";

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                return Convert.ToBoolean(Cmm.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ndeleteCatMovements",
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        //Metodo para seleccionar una categoria
        public CategoryMovements selectCatMovements(int _Id)
        {
            string Query = "SELECT * FROM categoriamovimientos WHERE id ='" + _Id + "';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            Cmm.Connection.Close();

            if (reader.Read())
            {
                newCatMovements.Id = (int)reader["id"];
                newCatMovements.Name = (string)reader["name"];
                newCatMovements.Description = (string)reader["description"];
            }

            return newCatMovements;
        }

        //Metodo para verificar existencia de una categoria
        public bool ExistCatMovement(int _Id)
        {
            string Query = "SELECT * FROM categoriamovimientos WHERE id ='" + _Id + "';";

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

        public void autoCompleteCatName(TextBox txtIN)
        {
            string Query = "SELECT name FROM categoriamovimientos;";

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
