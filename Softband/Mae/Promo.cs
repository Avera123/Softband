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
    public partial class Promo : Form
    {
        DaoPromo DaoPromo = new DaoPromo();
        Promotion newPromo = new Promotion();
        List<Promotion> ListPromos = new List<Promotion>();
        public Promo()
        {
            InitializeComponent();
            tbPercentPromo.Value = 1;
            lblTb.Text = 1.ToString();
            GetAllPromos();
        }

        public void GetAllPromos()
        {
            ListPromos = DaoPromo.getAllPromos();

            lvPromos.Clear();

            ListViewItem listBanks = new ListViewItem();

            foreach (Promotion _promo in ListPromos)
            {
                string active = "";
                if (_promo.Active) { active = "ACTIVO"; } else { active = "INACTIVO"; };
                ListViewItem lista = new ListViewItem(_promo.Id.ToString() + " | " + _promo.Code.ToString() + " | " + _promo.Name.ToString() + " | " + "PORCENTAJE: "+_promo.Percent.ToString() + " | ESTADO* " + active);
                lvPromos.Items.Add(lista);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodePromo.Text.Trim() != "")
                {
                    if (DaoPromo.ExistPromo(txtCodePromo.Text.Trim()))
                    {
                        newPromo = DaoPromo.selectPromo(txtCodePromo.Text.Trim());

                        txtCodePromo.Text = newPromo.Code.Trim();
                        txtNamePromo.Text = newPromo.Name.Trim();
                        txtDescriptionPromo.Text = newPromo.Description.Trim();
                        ckbActive.Checked = newPromo.Active;
                        tbPercentPromo.Value = newPromo.Percent;
                        lblTb.Text = tbPercentPromo.Value.ToString();
                    }
                    else
                    {
                        btnClear_Click(null, null);
                        MessageBox.Show("El promoción no existente",
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
                MessageBox.Show("Error al cargar datos de la Promoción:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtCodePromo.Text = "";
            this.txtNamePromo.Text = "";
            this.txtDescriptionPromo.Text = "";
            this.ckbActive.Checked = true;
            tbPercentPromo.Value = 1;
            lblTb.Text = tbPercentPromo.Value.ToString();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodePromo.Text.Trim() != "" && txtNamePromo.Text.Trim() != "")
                {
                    newPromo.Code = txtCodePromo.Text.Trim();
                    newPromo.Name = txtNamePromo.Text.Trim();
                    newPromo.Description = txtDescriptionPromo.Text.Trim();
                    newPromo.Active = ckbActive.Checked;
                    newPromo.Percent = tbPercentPromo.Value;

                    DaoPromo.insertPromo(newPromo);
                    MessageBox.Show("Promoción guardada:\n" + newPromo.Name,
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

        private void tbPercentPromo_Scroll(object sender, EventArgs e)
        {
            lblTb.Text = tbPercentPromo.Value.ToString();
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
                    if (txtCodePromo.Text.Trim() != "")
                    {
                        DaoPromo.deletePromo(txtCodePromo.Text.Trim());
                        btnClear_Click(null, null);
                        MessageBox.Show("Promoción Eliminada Correctamente.",
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
                    txtCodePromo.Text = "";
                    txtNamePromo.Text = "";
                    txtDescriptionPromo.Text = "";
                    ckbActive.Checked = false;
                    tbPercentPromo.Value = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Eliminar Promoción:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Promo_Load(object sender, EventArgs e)
        {

        }
    }
}
