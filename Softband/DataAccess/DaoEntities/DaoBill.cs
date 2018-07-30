using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softband.DataAccess.Generics;
using System.Windows.Forms;
using Softband.Entities;

namespace Softband.DataAccess.DaoEntities
{
    public class DaoBill
    {
        string Query = "";
        ConectionDB ConectDB = new ConectionDB();
        DaoAccount daoAccount = new DaoAccount();
        DaoProduct daoProduct = new DaoProduct();

        public void insertBill(int _Proveedor, int _AccoutOut, string _Description, double _amount, string _Date)
        {
            try
            {
                Query = "INSERT INTO compra(idproveedor, idaccountout, description, amount, date) values('" + _Proveedor + "','" + _AccoutOut + "','" + _Description + "','" + _amount +"','" + _Date + "');";

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                               
                Cmm.ExecuteNonQuery();                

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertCompra", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void insertBillProducts(int _idProducto, int _cantidad, string _costBuy)
        {
            try
            {
                int _idCompra = Consecutivo();
                Query = "INSERT INTO compraitem (idcompra, idproducto,cantidad,costbuy) values('" + _idCompra + "','" + _idProducto + "','" + _cantidad + "','" + _costBuy + "');";

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertCompra", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int Consecutivo()
        {
            Query = "SELECT MAX(id) as id FROM compra;";

            MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

            MySqlDataReader reader;

            Cmm.ExecuteNonQuery();

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

        public void updateAccount(int _AccoutOut, double Amount)
        {
            try
            {
                Account _account = new Account();
                _account = daoAccount.selectAccount(_AccoutOut);
                
                _account.Amount -= Amount;
                daoAccount.insertAccount(_account);
            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message + "\ninsertCompra updateAccount", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void updateProduc(string _Code, int stock)
        {
            try
            {
                Product _prod = new Product();
                _prod = daoProduct.selectProduct(_Code);

                _prod.Stock += stock;
                daoProduct.insertProduct(_prod);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertCompra", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
