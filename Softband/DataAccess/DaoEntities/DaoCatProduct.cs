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
    public class DaoCatProduct
    {
        ConectionDB ConectDB = new ConectionDB();
        CategoriaProduct newCatProduct = new CategoriaProduct();
        List<CategoriaProduct> Cats = new List<CategoriaProduct>();
        private string Query;

        //Metodo de carga de datos para grid
        public DataTable fillCategoriesDT()
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("Select id, name From categoriaproducto", ConectDB.getConection());
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la carga de bancos: " + ex.Message);
            }

            return dt;
        }

        public void insertCatproduct(CategoriaProduct _CatProduct)
        {
            try
            {
                if (ExistCatProduct(_CatProduct.Id))
                {
                    Query = "UPDATE categoriaproducto SET name='" + _CatProduct.Name.Trim() + "' WHERE id='" + _CatProduct.Id + "';";
                }
                else
                {
                    Query = "INSERT INTO categoriaproducto(name) values('" + _CatProduct.Name.Trim() + "');";
                }

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertCatProducto", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool deleteCatProduct(int _Id)
        {
            try
            {
                string Query = "DELETE FROM categoriaproducto WHERE id='" + _Id + "';";

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

        public CategoriaProduct selectCatProduct(int _Id)
        {
            string Query = "SELECT * FROM categoriaproducto WHERE id ='" + _Id + "';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            Cmm.Connection.Close();

            if (reader.Read())
            {
                newCatProduct.Id = (int)reader["id"];
                newCatProduct.Name = (string)reader["name"];
            }

            return newCatProduct;
        }

        public bool ExistCatProduct(int _Id)
        {
            string Query = "SELECT * FROM categoriaproducto WHERE id ='" + _Id + "';";

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
            string Query = "SELECT name FROM categoriaproducto;";

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
