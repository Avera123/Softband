using Softband.DataAccess.DaoEntities;
using Softband.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            
            dgvUsers.Rows.Clear();
            
            foreach (User _user in Users)
            {
                dgvUsers.Rows.Add(_user.Id,_user.ID,_user.Name,_user.NickName,_user.Active);
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
                        MessageBox.Show("El usuario no existente",
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

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvR = new DataGridViewRow();
            dgvR = dgvUsers.Rows[this.dgvUsers.CurrentCell.RowIndex];


            User _userIn = new User();
            _userIn.Id = Convert.ToInt32(dgvR.Cells[0].Value);
            _userIn.ID = dgvR.Cells[1].Value.ToString();
            _userIn.Name = dgvR.Cells[2].Value.ToString();
            _userIn.NickName = dgvR.Cells[3].Value.ToString();
            _userIn.Active = Convert.ToBoolean(dgvR.Cells[4].Value);

            if (dgvR.Cells[1].Value.ToString() != "")
            {
                txtIDUser.Text = dgvR.Cells[1].Value.ToString().Trim();
                this.btnSearch_Click(null, null);
            }
            
        }

        //Boton Exportar Grid A Excel
        #region Exportar a excel
        private void btnExport_Click(object sender, EventArgs e)
        {
            //ExportToExcel();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Documentos de Excel (*.xls)|*.xls";
            sfd.FileName = "Softband - Listado de Usuarios - " + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ToExcel(dgvUsers, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }        

        private void ToExcel(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
           this.txtPassword.UseSystemPasswordChar = !metroCheckBox1.Checked;
           this.txtPassword2.UseSystemPasswordChar = !metroCheckBox1.Checked;
        }
    }
}
