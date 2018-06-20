using Softband.DataAccess.Generics;
using Softband.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Softband
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        GenericQuerys Query = new GenericQuerys();
        private void Login_Load(object sender, EventArgs e)
        {
            string ruta;
            ruta = "C:/xampp/xampp-control.exe";
            System.Diagnostics.Process.Start(ruta);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            User _USER = new User();
            if (txtUser.Text.Trim()!="" && txtPassword.Text.Trim() !="")
            {
                _USER.NickName = txtUser.Text.Trim();
                _USER.Password = txtPassword.Text.Trim();

                if (Query.ValidateUser(_USER))
                {
                    this.Hide();
                    Control Control = new Control();
                    Control.Show();
                }
                else
                {
                    MessageBox.Show("ERROR DE VALIDACIÓN", "Usuario no Existente o Contraseña Digitada Erróneamente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("ERROR DE VALIDACIÓN", "Digite su usario y contraseña.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
