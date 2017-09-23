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

namespace Softband.Mae
{
    public partial class Bancos : Form
    {
        Bank newBank = new Bank();
        DaoBank DaoBank = new DaoBank();
        List<Bank> Banks = new List<Bank>();

        public Bancos()
        {
            InitializeComponent();
            GetAllBanks();
        }

        public void GetAllBanks()
        {
            Banks = DaoBank.getAllBanks();

            lvBanks.Clear();

            ListViewItem listBanks = new ListViewItem();

            foreach (Bank _bank in Banks)
            {
                string active = "";
                if (_bank.Active) { active = "ACTIVO"; } else { active = "INACTIVO"; };
                ListViewItem lista = new ListViewItem(_bank.Id.ToString() + " | " + _bank.Code.ToString() + " | " + _bank.Name.ToString() +" | ESTADO* "+active);
                lvBanks.Items.Add(lista);
            }

        }


        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodeBanc.Text.Trim() != "")
                {
                    if (DaoBank.ExistBank(txtCodeBanc.Text.Trim()))
                    {
                        newBank = DaoBank.selectBank(txtCodeBanc.Text.Trim());

                        txtCodeBanc.Text = newBank.Code.Trim();
                        txtNameBanc.Text = newBank.Name.Trim();
                        ckbActive.Checked = newBank.Active;
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
                    MessageBox.Show("El Campo Código no debe estar vacío",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del Banco:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtCodeBanc.Text = "";
            this.txtNameBanc.Text = "";
            this.ckbActive.Checked = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Realmente desea Eliminar este Banco?",
                    "Confirmación",
                    MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (txtCodeBanc.Text.Trim() != "")
                    {
                        DaoBank.deleteBank(txtCodeBanc.Text.Trim());
                        btnClear_Click(null, null);
                        MessageBox.Show("Banco Eliminado Correctamente.",
                            "Información",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Campos obligatorios:\n*Código",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                else if (result == DialogResult.No)
                {
                    txtNameBanc.Text = "";
                    txtCodeBanc.Text = "";
                    ckbActive.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar Banda:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodeBanc.Text.Trim() != "" && txtNameBanc.Text.Trim() != "")
                {
                    newBank.Code = txtCodeBanc.Text.Trim();
                    newBank.Name = txtNameBanc.Text.Trim();
                    newBank.Active = ckbActive.Checked;

                    DaoBank.insertBank(newBank);
                    MessageBox.Show("Banco guardado:\n" + newBank.Name,
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Campos obligatorios:\n*Código\n*Nombre",
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

        private void Bancos_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
