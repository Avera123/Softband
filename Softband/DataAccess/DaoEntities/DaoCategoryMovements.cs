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
    public class DaoCategoryMovements
    {
        ConectionDB ConectDB = new ConectionDB();
        CategoryMovements newCatMovements = new CategoryMovements();
        List<CategoryMovements> Cats = new List<CategoryMovements>();
        private string Query;


        public List<CategoryMovements> getAllCats()
        {
            List<CategoryMovements> ListCats = new List<CategoryMovements>();

            string Query = "SELECT * FROM categoriamovimientos;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            while (reader.Read())
            {
                newCatMovements = new CategoryMovements();

                newCatMovements.Id = (int)reader["id"];
                newCatMovements.Code = (string)reader["code"];
                newCatMovements.Name = (string)reader["name"];
                newCatMovements.Description = (string)reader["description"];

                ListCats.Add(newCatMovements);
            }

            return ListCats;
        }

        public void insertCatproduct(CategoryMovements _CatMovement)
        {
            try
            {
                if (ExistCatMovement(_CatMovement.Code))
                {
                    Query = "UPDATE categoriamovimientos SET name='" + _CatMovement.Name.Trim() + "', description='" + _CatMovement.Description + "' WHERE code='" + _CatMovement.Code.Trim() + "';";
                }
                else
                {
                    Query = "INSERT INTO categoriamovimientos(code, name, description) VALUES('" + _CatMovement.Code.Trim() + "','" + _CatMovement.Name.Trim() + "','" + _CatMovement.Description + "');";
                }

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertCatMoviments", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool deleteCatMovements(string _Code)
        {
            try
            {
                string Query = "DELETE FROM categoriamovimientos WHERE code='" + _Code.Trim() + "';";

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

        public CategoryMovements selectCatMovements(string _Code)
        {
            string Query = "SELECT * FROM categoriamovimientos WHERE code ='" + _Code + "';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            if (reader.Read())
            {
                newCatMovements.Id = (int)reader["id"];
                newCatMovements.Code = (string)reader["code"];
                newCatMovements.Name = (string)reader["name"];
                newCatMovements.Description = (string)reader["description"];
            }

            return newCatMovements;
        }

        public bool ExistCatMovement(string _Code)
        {
            string Query = "SELECT * FROM categoriamovimientos WHERE code ='" + _Code + "';";

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
