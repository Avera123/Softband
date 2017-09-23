using Softband.DataAccess.DaoEntities;
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

namespace Softband.Maestros
{
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
            FillCbBands();
            GetAllClients();
        }

        DaoClient DaoClient = new DaoClient();
        Client newClient = new Client();
        List<Client> ListClients = new List<Client>();
        List<Band> ListBands = new List<Band>();
        GenericQuerys QueryBands = new GenericQuerys();

        public void FillCbBands()
        {
            cbBands.DataSource = null;
            ListBands = QueryBands.getAllBands();

            cbBands.DataSource = ListBands;
            cbBands.ValueMember = "Id";
            cbBands.DisplayMember = "Name";
        }

        public void GetAllClients()
        {
            ListClients = DaoClient.getAllClients();
            lvClients.Clear();
            ListViewItem listClient = new ListViewItem();

            foreach (Client _client in ListClients)
            {
                //string active = "";
                //if (_product.Active) { active = "ACTIVO"; } else { active = "INACTIVO"; };
                ListViewItem lista = new ListViewItem("°: " + _client.ID.ToString() + " | " + _client.Name.ToString() + " | " + _client.Phone.ToString() + " | " + _client.MobilePhone + " | " + _client.Credit.ToString("C"));
                lvClients.Items.Add(lista);
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtIDClient.Text = "";
            this.txtNameClient.Text = "";
            this.cbBands.SelectedIndex = 0;
            this.txtAddressClient.Text = "";
            this.txtEmailClient.Text = "";
            this.txtPhoneClient.Text = "";
            this.txtCelClient.Text = "";
            this.txtCreditClient.Text = "0.OO";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIDClient.Text.Trim() != "")
                {
                    if (DaoClient.ExistClient(txtIDClient.Text.Trim()))
                    {
                        newClient = DaoClient.selectClient(txtIDClient.Text.Trim());

                        txtIDClient.Text = newClient.ID.Trim();
                        txtNameClient.Text = newClient.Name.Trim();
                        cbBands.SelectedValue = newClient.IdBand;
                        txtEmailClient.Text = newClient.Email;
                        txtAddressClient.Text = newClient.Address;
                        txtPhoneClient.Text = newClient.Phone;
                        txtCelClient.Text = newClient.MobilePhone;
                        txtCreditClient.Text = newClient.Credit.ToString("C");
                    }
                    else
                    {
                        btnClear_Click(null, null);
                        MessageBox.Show("Cliente no existente",
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
                MessageBox.Show("Error al cargar datos del Cliente:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Cliente_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtIDClient.Text.Trim() != "" &&
                    txtNameClient.Text.Trim() != "" &&
                    txtCreditClient.Text != "")
                {

                    newClient.ID = txtIDClient.Text.Trim();
                    newClient.Name = txtNameClient.Text.Trim();
                    newClient.IdBand = (int)cbBands.SelectedValue;
                    newClient.Email = txtEmailClient.Text.Trim();
                    newClient.Address = txtAddressClient.Text.Trim();
                    newClient.Phone = txtPhoneClient.Text.Trim();
                    newClient.MobilePhone = txtCelClient .Text.Trim();
                    newClient.Credit = Convert.ToDouble(txtCreditClient.Text.Trim().Replace("$",""));
                    
                    DaoClient.insertClient(newClient);
                    MessageBox.Show("Cliente guardado:\n" + newClient.Name,
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    GetAllClients();
                }
                else
                {
                    MessageBox.Show("Campos obligatorios:\n*Identificación\n*Nombre",
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("¿Realmente desea Eliminar este Cliente?",
                    "Confirmación",
                    MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (txtIDClient.Text.Trim() != "")
                    {
                        DaoClient.deleteClient(txtIDClient.Text.Trim());
                        btnClear_Click(null, null);
                        MessageBox.Show("Cliente Eliminado Correctamente.",
                            "Información",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        GetAllClients();
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
                MessageBox.Show("Error al Eliminar Banda:\n" + ex.Message,
                    "Error del Sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
