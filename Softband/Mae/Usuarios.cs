using Softband.DataAccess.DaoEntities;
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

namespace Softband.Maestros
{
    public partial class Usuarios : Form
    {
        User newUser = new User();
        DaoUser DaoUser = new DaoUser();
        List<User> Users = new List<User>();

        public Usuarios()
        {
            InitializeComponent();
            GetAllUsers();
        }

        public void GetAllUsers()
        {
            Users = DaoUser.getAllUsers();

            lvUsers.Clear();

            foreach (User _user in Users)
            {
                string active = "";
                if (_user.Active) { active = "ACTIVO"; } else { active = "INACTIVO"; };
                ListViewItem lista = new ListViewItem(_user.Id.ToString() + " | " + _user.ID.ToString() + " | " + _user.Name.ToString() + " | ESTADO* " + active);
                lvUsers.Items.Add(lista);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtIDUser.Text = "";
            txtNameUser.Text = "";
            txtNickName.Text = "";
            txtPassword.Text = "";
            txtPassword2.Text = "";
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == txtPassword2.Text.Trim())
            {
                try
                {
                    if (txtIDUser.Text.Trim() != "" &&
                    txtNameUser.Text.Trim() != "" &&
                    txtNickName.Text.Trim() != "" &&
                    txtPassword.Text.Trim() != "" &&
                    txtPassword2.Text.Trim() != "")
                    {
                        newUser.ID = txtIDUser.Text.Trim();
                        newUser.Name = txtNameUser.Text.Trim();
                        newUser.NickName = txtNickName.Text.Trim();
                        newUser.Password = txtPassword.Text.Trim();
                        newUser.Active = ckbActive.Checked;

                        DaoUser.insertUser(newUser);
                        GetAllUsers();
                        MessageBox.Show("Cuenta guardada:\n" + newUser.Name,
                            "Información",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Campos obligatorios:\n* Identificación\n* Nombre\n* NickName\n* PassWord",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:\n" + ex.Message,
                        "Error al insertar",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Las Contraseñas ingresadas no coinciden",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIDUser.Text.Trim() != "")
                {
                    if (DaoUser.ExistUser(txtIDUser.Text.Trim()))
                    {
                        newUser = DaoUser.selectUser(txtIDUser.Text.Trim());

                        txtIDUser.Text = newUser.ID.Trim();
                        txtNameUser.Text = newUser.Name.Trim();
                        txtNickName.Text = newUser.NickName.Trim();
                        txtPassword.Text = newUser.Password.Trim();
                        txtPassword2.Text = newUser.Password.Trim();
                        ckbActive.Checked = newUser.Active;
                    }
                    else
                    {
                        btnClear_Click(null, null);
                        MessageBox.Show("El banco no existente",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    btnClear_Click(null, null);
                    MessageBox.Show("El Campo Identificación no debe estar vacío",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del Usuario:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Realmente desea Eliminar esta Usuario?",
                    "Confirmación",
                    MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (txtIDUser.Text.Trim() != "")
                    {
                        DaoUser.deleteUser(txtIDUser.Text.Trim());
                        btnClear_Click(null, null);
                        GetAllUsers();
                        MessageBox.Show("Usuario Eliminado Correctamente.",
                            "Información",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Campos obligatorios:\n*Identificación",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                else if (result == DialogResult.No)
                {
                    btnClear_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar Usuario:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
