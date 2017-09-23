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
                Query = "INSERT INTO movimientosmonetarios(idaccount, idcatmovement, idtypemovement, amount, description) VALUES('" +
                _MovementMoney.IdAccount.ToString() + "','" +
                _MovementMoney.IdCatMovement.ToString() + "','" +
                _MovementMoney.IdTypeMovement.ToString() + "','" +
                _MovementMoney.Amount.ToString()+ "','" +
                _MovementMoney.Description.Trim() + "');";
            
                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertBand", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void insertMovementMoneyAccount(MovementMoney _MovementMoney)
        {
            try
            {
                Query = "INSERT INTO transferenciacuentas(idaccountin,idaccountout, amount) VALUES('" +
                _MovementMoney.IdAccount.ToString() + "','" +
                _MovementMoney.IdCatMovement.ToString() + "','" +
                _MovementMoney.IdTypeMovement.ToString() + "','" +
                _MovementMoney.Amount.ToString() + "','" +
                _MovementMoney.Description.Trim() + "');";

                MySqlCommand Cmm = new MySqlCommand(Query, ConectDB.getConection());
                Cmm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\ninsertBand", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
