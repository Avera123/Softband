using MySql.Data.MySqlClient;
using Softband.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Softband.DataAccess.Generics
{
    public class GenericQuerys
    {
        ConectionDB ConectDB = new ConectionDB();
        Bank newBank = new Bank();
        Band newBand = new Band();
        Promotion newPromo = new Promotion();
        CategoryMovements CatMovement = new CategoryMovements();
        Account newAccount = new Account();
        CategoriaProduct newCategory = new CategoriaProduct();

        public List<Bank> getAllBanks()
        {
            List<Bank> ListBanks = new List<Bank>();

            string Query = "SELECT id, name FROM banco;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;
           
            reader = Cmm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    newBank = new Bank();
                    newBank.Id = (int)reader["id"];
                    newBank.Name = (string)reader["name"];

                    ListBanks.Add(newBank);
                }
            }

            Cmm.Connection.Close();

            return ListBanks;
        }

        public List<Band> getAllBands()
        {
            List<Band> ListBands = new List<Band>();

            string Query = "SELECT id, name FROM banda;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    newBand = new Band();
                    newBand.Id = (int)reader["id"];
                    newBand.Name = (string)reader["name"];

                    ListBands.Add(newBand);
                }
            }

            Cmm.Connection.Close();

            return ListBands;
        }

        public List<Promotion> getAllPromos()
        {
            List<Promotion> ListPromos = new List<Promotion>();

            string Query = "SELECT * FROM promo WHERE active=1;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            if (reader.HasRows)
            {
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
            }

            Cmm.Connection.Close();

            return ListPromos;
        }

        public List<Account> getAllAccounts()
        {
            List<Account> ListAccounts = new List<Account>();

            string Query = "SELECT * FROM cuenta;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    newAccount = new Account();
                    newAccount.Id = (int)reader["id"];
                    newAccount.Name = (string)reader["name"];
                    newAccount.IdBank = (int)reader["idbank"];
                    newAccount.Description = (string)reader["description"];
                    newAccount.Type = (int)reader["type"];
                    newAccount.Amount = Convert.ToDouble(reader["amount"]);

                    ListAccounts.Add(newAccount);
                }
            }

            Cmm.Connection.Close();

            return ListAccounts;
        }

        public List<CategoryMovements> getAllCategoryMovements()
        {
            List<CategoryMovements> ListCategories = new List<CategoryMovements>();

            string Query = "SELECT * FROM categoriamovimientos;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    CatMovement = new CategoryMovements();
                    CatMovement.Id = (int)reader["id"];
                    CatMovement.Name = (string)reader["name"];
                    CatMovement.Description = (string)reader["description"];

                    ListCategories.Add(CatMovement);
                }
            }

            Cmm.Connection.Close();

            return ListCategories;
        }

        public List<CategoriaProduct> getAllCategoryProducts()
        {
            List<CategoriaProduct> ListCategory = new List<CategoriaProduct>();

            string Query = "SELECT id, name  FROM categoriaproducto;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    newCategory = new CategoriaProduct();
                    newCategory.Id = (int)reader["id"];
                    newCategory.Name = (string)reader["name"];

                    ListCategory.Add(newCategory);
                }
            }

            Cmm.Connection.Close();

            return ListCategory;
        }

        public void fillProducts(DataGridView dgv)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter("Select * From producto", ConectDB.getConection());
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la carga de datos: " + ex.Message);
            }
            
        }

        public DataTable fillProductsDS()
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("Select id AS ID, code AS CODIGO, name AS NOMBRE, description AS DESCRIPCION, costbuy AS COSTO, stock From producto", ConectDB.getConection());
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la carga de datos: " + ex.Message);
            }

            return dt;
        }

        public DataTable fillBanksDT()
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("Select id, name From banco", ConectDB.getConection());
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la carga de datos: " + ex.Message);
            }

            return dt;
        }

        public bool ValidateUser(User _USER)
        {
            string Query = "SELECT * FROM usuario WHERE nickname ='" + _USER.NickName + "' AND password='"+ _USER.Password +"';";

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

        public int Consecutivo()
        {
            string Query = "SELECT MAX(id) as id FROM factura;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            reader = Cmm.ExecuteReader();
            int Consec = 0;

            if (reader.Read())
            {
                if (reader["id"] != DBNull.Value || reader["id"].ToString().Trim() != "")
                {
                    if (Convert.ToInt32(reader["id"]) >= 1)
                    {
                        Consec = ((int)reader["id"] + 1);
                    }
                }
                else
                {
                    Consec = 1;
                }
            }

            Cmm.Connection.Close();
            reader.Close();

            return Consec;
        }
    }
}
