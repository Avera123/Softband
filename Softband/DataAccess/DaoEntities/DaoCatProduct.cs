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
    public class DaoCatProduct
    {
        ConectionDB ConectDB = new ConectionDB();
        CategoriaProduct newCatProduct = new CategoriaProduct();
        List<CategoriaProduct> Cats = new List<CategoriaProduct>();
        private string Query;


        public List<CategoriaProduct> getAllCats()
        {
            List<CategoriaProduct> ListCats = new List<CategoriaProduct>();

            string Query = "SELECT * FROM categoriaproducto;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            while (reader.Read())
            {
                newCatProduct = new CategoriaProduct();
                
                newCatProduct.Id = (int)reader["id"];
                newCatProduct.Code = (string)reader["code"];
                newCatProduct.Name = (string)reader["name"];
                newCatProduct.Active = (bool)reader["active"];

                ListCats.Add(newCatProduct);
            }

            return ListCats;
        }

        public void insertCatproduct(CategoriaProduct _CatProduct)
        {
            int Active = 0;
            if (_CatProduct.Active) { Active = 1; }

            try
            {
                if (ExistCatProduct(_CatProduct.Code))
                {
                    Query = "UPDATE categoriaproducto SET name='" + _CatProduct.Name.Trim() + "', active=" + Active + " WHERE code='" + _CatProduct.Code.Trim() + "';";
                }
                else
                {
                    Query = "INSERT INTO categoriaproducto(code, name, active) values('" + _CatProduct.Code.Trim() + "','" + _CatProduct.Name.Trim() + "','" + Active + "');";
                }

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertCatProducto", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool deleteCatProduct(string _Code)
        {
            try
            {
                string Query = "DELETE FROM categoriaproducto WHERE code='" + _Code.Trim() + "';";

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                return Convert.ToBoolean(Cmm.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ndeleteCatProduct", 
                    "Error del Sistema", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return false;
            }
        }

        public CategoriaProduct selectCatProduct(string _Code)
        {
            string Query = "SELECT * FROM categoriaproducto WHERE code ='" + _Code + "';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            if (reader.Read())
            {
                newCatProduct.Id = (int)reader["id"];
                newCatProduct.Code = (string)reader["code"];
                newCatProduct.Name = (string)reader["name"];
                newCatProduct.Active = (bool)reader["active"];
            }

            return newCatProduct;
        }

        public bool ExistCatProduct(string _Code)
        {
            string Query = "SELECT * FROM categoriaproducto WHERE code ='" + _Code + "';";

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
