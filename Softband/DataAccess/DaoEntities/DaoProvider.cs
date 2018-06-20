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
    public class DaoProvider
    {
        //Definición de Variables
        ConectionDB ConectDB = new ConectionDB();
        Provider newProvider = new Provider();
        private string Query;

        //Metodo insertar proveedor
        public void insertProvider(Provider _Provider)
        {
            try
            {
                if (ExistBank(_Provider.Identification))
                {
                    Query = "UPDATE proveedor SET "
                        +"name='" + _Provider.Name.Trim() + "',"
                        + "address='" + _Provider.Adress.Trim() + "',"
                        + "phone='" + _Provider.Phone.Trim()
                        + "' WHERE identification='" + _Provider.Identification + "';";
                }
                else
                {
                    Query = "INSERT INTO proveedor(identification, name, address, phone) values('" 
                        + _Provider.Identification +"','"
                        + _Provider.Name + "','"
                        + _Provider.Adress + "','"
                        + _Provider.Phone + "');";
                }

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertProvider", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Metodo eliminar proveedor
        public void deleteProvider(string _ProviderId)
        {
            try
            {
                if (ExistBank(_ProviderId))
                {
                    Query = "DELETE FROM proveedor WHERE identification='" + _ProviderId + "';";

                    MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                    Cmm.ExecuteNonQuery();

                    Cmm.Connection.Close();
                }
                else
                {
                    MessageBox.Show("Proveedor Inexistente","Advertencia del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertProvider", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Metodo validación de existencia de proveedor
        public bool ExistBank(string _Identification)
        {
            string Query = "SELECT * FROM proveedor WHERE identification ='" + _Identification + "';";

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

        //Metodo de cargar datatable para grid de proveedores
        public DataTable fillProviderDT()
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter("Select id, identification, name, address, phone From proveedor", ConectDB.getConection());
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la carga de datos: " + ex.Message);
            }
            
            return dt;
        }

        //Metodo de Seleccion unico por Identificacion
        public Provider selectProvider(string _Identification)
        {
            try
            {
                if (ExistBank(_Identification))
                {
                    string Query = "SELECT * FROM proveedor WHERE identification ='" + _Identification + "';";

                    MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());

                    MySqlDataReader reader;

                    reader = Cmm.ExecuteReader();

                    if (reader.Read())
                    {
                        newProvider.Id = (int)reader["id"];
                        newProvider.Identification = (string)reader["identification"];
                        newProvider.Name = (string)reader["name"];
                        newProvider.Adress = (string)reader["address"];
                        newProvider.Phone = (string)reader["phone"];
                    }

                    Cmm.Connection.Close();

                    return newProvider;
                }
                else
                {
                    MessageBox.Show("Proveedor Inexistente", "Advertencia del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return new Provider();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertProvider", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return new Provider();
            }
        }
    }
}
