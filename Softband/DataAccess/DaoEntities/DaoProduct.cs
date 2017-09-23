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
    public class DaoProduct
    {
        Product newProduct = new Product();
        List<Product> ListProducts = new List<Product>();
        ConectionDB ConectDB = new ConectionDB();
        string Query = "";

        public List<Product> getAllProducts()
        {
            List<Product> ListProducts = new List<Product>();
            string Query = "SELECT id, code, name, idcategory, description, costsale, costbuy, stock FROM producto;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    newProduct = new Product();
                    newProduct.Id = (int)reader["id"];
                    newProduct.Code = (string)reader["code"];
                    newProduct.Name = (string)reader["name"];
                    newProduct.IdCategory = (int)reader["idcategory"];
                    newProduct.Description = (string)reader["description"];
                    newProduct.CostSale = (double)reader["costsale"];
                    newProduct.CostBuy = (double)reader["costbuy"];
                    newProduct.Stock = (int)reader["stock"];

                    ListProducts.Add(newProduct);
                }
            }

            return ListProducts;
        }
        
        public void insertProduct(Product _Product)
        {
            try
            {
                if (ExistProduct(_Product.Code))
                {
                    Query = "UPDATE producto SET name='" + _Product.Name.Trim() +
                    "', idcategory='" + _Product.IdCategory +
                    "', description='" + _Product.Description +
                    "', costsale='" + _Product.CostSale +
                    "', costbuy='"+ _Product.CostBuy +
                    "', stock='" + _Product.Stock +
                    "' WHERE code='" + _Product.Code.Trim() + "';";
                }
                else
                {
                    Query = "INSERT INTO producto(code, name, idcategory, description, costsale, costbuy, stock) VALUES('" +
                    _Product.Code.Trim() + "','" +
                    _Product.Name.Trim() + "','" +
                    _Product.IdCategory.ToString() + "','" +
                    _Product.Description.Trim() + "','" +
                    _Product.CostSale + "','" +
                    _Product.CostBuy + "','" +
                    _Product.Stock + "');";
                }

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertProduct", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public Product selectProduct(string _code)
        {
            string Query = "SELECT * FROM producto WHERE code ='" + _code + "';";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            if (reader.Read())
            {
                newProduct.Id = (int)reader["id"];
                newProduct.Code = (string)reader["code"];
                newProduct.Name = (string)reader["name"];
                newProduct.IdCategory = (int)reader["idcategory"];
                newProduct.Description = (string)reader["description"];
                newProduct.CostSale = (double)reader["costsale"];
                newProduct.CostBuy = (double)reader["costbuy"];
                newProduct.Stock = (int)reader["stock"];
            }

            return newProduct;
        }
        
        public bool ExistProduct(string _code)
        {
            string Query = "SELECT * FROM producto WHERE code ='" + _code + "';";

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
        /*
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
        }*/
    }
}
