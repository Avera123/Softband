using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Odbc;
using System.Data;
using System.Collections;

namespace Softband.DataAccess
{
    public class ConectionDB
    {
        MySqlConnection conection = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString);
        
        public MySqlConnection getConection()
        {
            if (conection.State == ConnectionState.Open)
            {
                conection.Dispose();
                conection.Open();
                return conection;
            }
            else
            {
                conection.Open();
                return conection;
            }
        }

        static public int KillSleepingConnections(int iMinSecondsToExpire)
        {
            string strSQL = "show processlist";
            System.Collections.ArrayList m_ProcessesToKill = new ArrayList();
            OdbcConnection myConn = new OdbcConnection(ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString);
            OdbcCommand myCmd = new OdbcCommand(strSQL, myConn);
            OdbcDataReader MyReader = null;
            try
            {
                myConn.Open();
                // Get a list of processes to kill.
                MyReader = myCmd.ExecuteReader();
                while (MyReader.Read())
                {
                    // Find all processes sleeping with a timeout value higher than our threshold.
                    int iPID = Convert.ToInt32(MyReader["Id"].ToString());
                    string strState = MyReader["Command"].ToString();
                    int iTime = Convert.ToInt32(MyReader["Time"].ToString());
                    if (strState == "Sleep" && iTime >= iMinSecondsToExpire && iPID > 0)
                    {
                        // This connection is sitting around doing nothing. Kill it.
                        m_ProcessesToKill.Add(iPID);
                    }
                }
                MyReader.Close();
                foreach (int aPID in m_ProcessesToKill)
                {
                    strSQL = "kill " + aPID;
                    myCmd.CommandText = strSQL;
                    myCmd.ExecuteNonQuery();
                }
            }
            catch (Exception excep)
            {
            }
            finally
            {
                if (MyReader != null && !MyReader.IsClosed)
                {
                    MyReader.Close();
                }
                if (myConn != null && myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            return m_ProcessesToKill.Count;
        }
    }
}
