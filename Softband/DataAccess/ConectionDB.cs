using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Softband.DataAccess
{
    public class ConectionDB
    {
        public MySqlConnection getConection()
        {
            var cadena = ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString;
            
            MySqlConnection conection = new MySqlConnection(cadena);

            conection.ClearAllPoolsAsync();

            conection.Open();
                        
            return conection;
        }
    }
}
