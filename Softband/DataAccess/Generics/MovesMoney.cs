using MySql.Data.MySqlClient;
using Softband.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Softband.DataAccess.Generics
{
    public class MovesMoney
    {
        ConectionDB ConectDB = new ConectionDB();
        string Query = "";
        public void insertMovementMoney(MovementMoney _MovementMoney)
        {
            try
            {
                Query = "INSERT INTO movimientosmonetarios(idaccount, idcatmovement, idtypemovement, amount, description, date) VALUES('" +
                _MovementMoney.IdAccount.ToString() + "','" +
                _MovementMoney.IdCatMovement.ToString() + "','" +
                _MovementMoney.IdTypeMovement.ToString() + "','" +
                _MovementMoney.Amount.ToString()+ "','" +
                _MovementMoney.Description.ToString() + "','" +
                _MovementMoney.Date.Trim() + "');";
            
                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertBand", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void insertTransferMoneyAccount(Transfer _MovementMoney)
        {
            try
            {
                Query = "INSERT INTO transferenciacuentas(idaccountin,idaccountout, amount, dateMove, description) VALUES('" +
                _MovementMoney.IdAccountIn.ToString() + "','" +
                _MovementMoney.IdAccountOut.ToString() + "','" +
                _MovementMoney.Amount.ToString() + "','" +
                _MovementMoney.Date + "','" +
                _MovementMoney.Description + "');";

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();

                Cmm.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertBand\nQuery: " + Query, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
