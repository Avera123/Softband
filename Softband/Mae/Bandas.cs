using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Softband.DataAccess;
using Softband.Entities;
using Softband.DataAccess.DaoEntities;

namespace Softband.Maestros
{
    public partial class Bandas : Form
    {
        Band newBand = new Band();
        DaoBand DaoBand = new DaoBand();
        List<Band> Bands = new List<Band>();

        public Bandas()
        {
            InitializeComponent();
            GetAllBands();
        }

        public void GetAllBands()
        {
            Bands = DaoBand.getAllBands();
            lvBands.Clear();
            ListViewItem listBands = new ListViewItem();

            foreach (Band _band in Bands)
            {
                string active = "";
                if (_band.Active) { active = "ACTIVO"; } else { active = "INACTIVO"; };
                ListViewItem lista = new ListViewItem(_band.Id.ToString() + " | " + _band.Code.ToString() + " | " + _band.Name.ToString() + " | ESTADO* " + active);
                lvBands.Items.Add(lista);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNameBand.Text.Trim() != "" && txtCodeBand.Text.Trim() != "")
                {
                    newBand.Name = txtNameBand.Text.Trim();
                    newBand.Code = txtCodeBand.Text.Trim();
                    newBand.Active = ckbActive.Checked;

                    DaoBand.insertBand(newBand);
                    MessageBox.Show("Banda guardada:\n" + newBand.Name, 
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
                MessageBox.Show("Error:\n"+ex.Message, 
                    "Error al insertar", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            
        }
        
        private void btnDeleteBand_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Realmente desea Eliminar esta banda?", 
                    "Confirmación", 
                    MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (txtCodeBand.Text.Trim() != "")
                    {
                        DaoBand.deleteBand(txtCodeBand.Text.Trim());
                        btnClear_Click(null, null);
                        MessageBox.Show("Banda Eliminada Correctamente.",
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
                    txtNameBand.Text = "";
                    txtCodeBand.Text = "";
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtCodeBand.Text = "";
            this.txtNameBand.Text = "";
            this.ckbActive.Checked = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodeBand.Text.Trim() != "")
                {
                    if (DaoBand.ExistBand(txtCodeBand.Text.Trim()))
                    {
                        newBand = DaoBand.selectBand(txtCodeBand.Text.Trim());

                        txtCodeBand.Text = newBand.Code.Trim();
                        txtNameBand.Text = newBand.Name.Trim();
                        ckbActive.Checked = newBand.Active;
                    }
                    else
                    {
                        btnClear_Click(null, null);
                        MessageBox.Show("Banda no existente", 
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
                MessageBox.Show("Error al cargar datos de la Banda:\n" + ex.Message, 
                    "Error del Sistema", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
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

        private void Bandas_Load(object sender, EventArgs e)
        {

        }
    }
}
