namespace Softband.Maestros
{
    partial class Cliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cliente));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefreshGrid = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRefreshBandas = new System.Windows.Forms.Button();
            this.btnBanda = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCreditClient = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbBands = new System.Windows.Forms.ComboBox();
            this.txtCelClient = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPhoneClient = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmailClient = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddressClient = new System.Windows.Forms.TextBox();
            this.txtNameClient = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIDClient = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rdBand = new System.Windows.Forms.RadioButton();
            this.rdIdentification = new System.Windows.Forms.RadioButton();
            this.rdName = new System.Windows.Forms.RadioButton();
            this.txtSearchNameClient = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnRefreshGrid);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 694);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 47);
            this.panel1.TabIndex = 39;
            // 
            // btnRefreshGrid
            // 
            this.btnRefreshGrid.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefreshGrid.BackgroundImage = global::Softband.Properties.Resources.undo_5_256;
            this.btnRefreshGrid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshGrid.Location = new System.Drawing.Point(733, 4);
            this.btnRefreshGrid.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefreshGrid.Name = "btnRefreshGrid";
            this.btnRefreshGrid.Size = new System.Drawing.Size(40, 40);
            this.btnRefreshGrid.TabIndex = 66;
            this.btnRefreshGrid.UseVisualStyleBackColor = false;
            this.btnRefreshGrid.Click += new System.EventHandler(this.btnRefreshGrid_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExport.BackgroundImage = global::Softband.Properties.Resources.excel_3_256;
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(778, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(40, 40);
            this.btnExport.TabIndex = 20;
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDelete.Image = global::Softband.Properties.Resources.delete_30;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(50, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(40, 40);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSave.Image = global::Softband.Properties.Resources.save_30;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 40);
            this.btnSave.TabIndex = 15;
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnClear.Image = global::Softband.Properties.Resources.eraser_30;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(96, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(40, 40);
            this.btnClear.TabIndex = 16;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRefreshBandas);
            this.groupBox1.Controls.Add(this.btnBanda);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cbBands);
            this.groupBox1.Controls.Add(this.txtCelClient);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtPhoneClient);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtEmailClient);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtAddressClient);
            this.groupBox1.Controls.Add(this.txtNameClient);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtIDClient);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(795, 253);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Cliente";
            // 
            // btnRefreshBandas
            // 
            this.btnRefreshBandas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefreshBandas.BackgroundImage = global::Softband.Properties.Resources.undo_5_256;
            this.btnRefreshBandas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshBandas.Location = new System.Drawing.Point(708, 93);
            this.btnRefreshBandas.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefreshBandas.Name = "btnRefreshBandas";
            this.btnRefreshBandas.Size = new System.Drawing.Size(30, 30);
            this.btnRefreshBandas.TabIndex = 65;
            this.btnRefreshBandas.UseVisualStyleBackColor = false;
            this.btnRefreshBandas.Click += new System.EventHandler(this.btnRefreshBandas_Click);
            // 
            // btnBanda
            // 
            this.btnBanda.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBanda.BackgroundImage = global::Softband.Properties.Resources.plus_2_64;
            this.btnBanda.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBanda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBanda.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnBanda.Location = new System.Drawing.Point(743, 93);
            this.btnBanda.Name = "btnBanda";
            this.btnBanda.Size = new System.Drawing.Size(30, 30);
            this.btnBanda.TabIndex = 64;
            this.btnBanda.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBanda.UseVisualStyleBackColor = false;
            this.btnBanda.Click += new System.EventHandler(this.btnBanda_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCreditClient);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(410, 141);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(363, 97);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            // 
            // txtCreditClient
            // 
            this.txtCreditClient.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCreditClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCreditClient.ForeColor = System.Drawing.Color.Red;
            this.txtCreditClient.Location = new System.Drawing.Point(12, 41);
            this.txtCreditClient.MaxLength = 250;
            this.txtCreditClient.Name = "txtCreditClient";
            this.txtCreditClient.Size = new System.Drawing.Size(342, 27);
            this.txtCreditClient.TabIndex = 30;
            this.txtCreditClient.Text = "0.00";
            this.txtCreditClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(5, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 20);
            this.label10.TabIndex = 27;
            this.label10.Text = "Crédito";
            // 
            // cbBands
            // 
            this.cbBands.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBands.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cbBands.FormattingEnabled = true;
            this.cbBands.Location = new System.Drawing.Point(420, 93);
            this.cbBands.Margin = new System.Windows.Forms.Padding(2);
            this.cbBands.Name = "cbBands";
            this.cbBands.Size = new System.Drawing.Size(285, 30);
            this.cbBands.TabIndex = 26;
            // 
            // txtCelClient
            // 
            this.txtCelClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCelClient.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtCelClient.Location = new System.Drawing.Point(591, 39);
            this.txtCelClient.Margin = new System.Windows.Forms.Padding(2);
            this.txtCelClient.Mask = "000-000-0000";
            this.txtCelClient.Name = "txtCelClient";
            this.txtCelClient.Size = new System.Drawing.Size(182, 27);
            this.txtCelClient.TabIndex = 25;
            this.txtCelClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(580, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 20);
            this.label9.TabIndex = 24;
            this.label9.Text = "Celular";
            // 
            // txtPhoneClient
            // 
            this.txtPhoneClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneClient.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtPhoneClient.Location = new System.Drawing.Point(423, 39);
            this.txtPhoneClient.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhoneClient.Mask = "000-0000";
            this.txtPhoneClient.Name = "txtPhoneClient";
            this.txtPhoneClient.Size = new System.Drawing.Size(164, 27);
            this.txtPhoneClient.TabIndex = 23;
            this.txtPhoneClient.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(407, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Teléfono";
            // 
            // txtEmailClient
            // 
            this.txtEmailClient.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtEmailClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailClient.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtEmailClient.Location = new System.Drawing.Point(21, 211);
            this.txtEmailClient.MaxLength = 250;
            this.txtEmailClient.Name = "txtEmailClient";
            this.txtEmailClient.Size = new System.Drawing.Size(354, 27);
            this.txtEmailClient.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(5, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Correo Eletrónico";
            // 
            // txtAddressClient
            // 
            this.txtAddressClient.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddressClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddressClient.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtAddressClient.Location = new System.Drawing.Point(20, 154);
            this.txtAddressClient.MaxLength = 250;
            this.txtAddressClient.Name = "txtAddressClient";
            this.txtAddressClient.Size = new System.Drawing.Size(354, 27);
            this.txtAddressClient.TabIndex = 19;
            // 
            // txtNameClient
            // 
            this.txtNameClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtNameClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNameClient.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNameClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameClient.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtNameClient.Location = new System.Drawing.Point(20, 93);
            this.txtNameClient.MaxLength = 250;
            this.txtNameClient.Name = "txtNameClient";
            this.txtNameClient.Size = new System.Drawing.Size(354, 27);
            this.txtNameClient.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(6, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Nombre Completo:";
            // 
            // txtIDClient
            // 
            this.txtIDClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtIDClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtIDClient.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDClient.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtIDClient.Location = new System.Drawing.Point(80, 30);
            this.txtIDClient.MaxLength = 11;
            this.txtIDClient.Name = "txtIDClient";
            this.txtIDClient.Size = new System.Drawing.Size(261, 27);
            this.txtIDClient.TabIndex = 15;
            this.txtIDClient.Leave += new System.EventHandler(this.txtIDClient_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(8, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Cedula:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(404, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Banda o Grupo:";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch.BackgroundImage = global::Softband.Properties.Resources.magnifying_glass_3_30;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Location = new System.Drawing.Point(345, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(30, 30);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(5, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Dirección:";
            // 
            // dgvClients
            // 
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.AllowUserToOrderColumns = true;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvClients.Location = new System.Drawing.Point(0, 397);
            this.dgvClients.Margin = new System.Windows.Forms.Padding(2);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.RowTemplate.Height = 24;
            this.dgvClients.Size = new System.Drawing.Size(821, 297);
            this.dgvClients.TabIndex = 40;
            this.dgvClients.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClients_CellDoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(305, 268);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 18);
            this.label8.TabIndex = 41;
            this.label8.Text = "LISTADO DE CLIENTES";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.txtSearchNameClient);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(4, 283);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(800, 110);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label11.Location = new System.Drawing.Point(8, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 20);
            this.label11.TabIndex = 32;
            this.label11.Text = "Término:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rdBand);
            this.groupBox4.Controls.Add(this.rdIdentification);
            this.groupBox4.Controls.Add(this.rdName);
            this.groupBox4.Location = new System.Drawing.Point(105, 14);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(681, 49);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            // 
            // rdBand
            // 
            this.rdBand.AutoSize = true;
            this.rdBand.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBand.Location = new System.Drawing.Point(136, 16);
            this.rdBand.Name = "rdBand";
            this.rdBand.Size = new System.Drawing.Size(72, 22);
            this.rdBand.TabIndex = 34;
            this.rdBand.TabStop = true;
            this.rdBand.Text = "Banda";
            this.rdBand.UseVisualStyleBackColor = true;
            // 
            // rdIdentification
            // 
            this.rdIdentification.AutoSize = true;
            this.rdIdentification.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdIdentification.Location = new System.Drawing.Point(240, 16);
            this.rdIdentification.Name = "rdIdentification";
            this.rdIdentification.Size = new System.Drawing.Size(117, 22);
            this.rdIdentification.TabIndex = 33;
            this.rdIdentification.TabStop = true;
            this.rdIdentification.Text = "Identificación";
            this.rdIdentification.UseVisualStyleBackColor = true;
            // 
            // rdName
            // 
            this.rdName.AutoSize = true;
            this.rdName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdName.Location = new System.Drawing.Point(23, 16);
            this.rdName.Name = "rdName";
            this.rdName.Size = new System.Drawing.Size(82, 22);
            this.rdName.TabIndex = 32;
            this.rdName.TabStop = true;
            this.rdName.Text = "Nombre";
            this.rdName.UseVisualStyleBackColor = true;
            // 
            // txtSearchNameClient
            // 
            this.txtSearchNameClient.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSearchNameClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchNameClient.ForeColor = System.Drawing.Color.Black;
            this.txtSearchNameClient.Location = new System.Drawing.Point(105, 68);
            this.txtSearchNameClient.MaxLength = 250;
            this.txtSearchNameClient.Name = "txtSearchNameClient";
            this.txtSearchNameClient.Size = new System.Drawing.Size(681, 27);
            this.txtSearchNameClient.TabIndex = 30;
            this.txtSearchNameClient.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchNameClient_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(5, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Buscar por:";
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(821, 741);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvClients);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Cliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.Cliente_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNameClient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIDClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbBands;
        private System.Windows.Forms.MaskedTextBox txtCelClient;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtPhoneClient;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmailClient;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAddressClient;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtCreditClient;
        private System.Windows.Forms.Button btnBanda;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.Button btnRefreshBandas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdBand;
        private System.Windows.Forms.RadioButton rdIdentification;
        private System.Windows.Forms.RadioButton rdName;
        private System.Windows.Forms.TextBox txtSearchNameClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnRefreshGrid;
    }
}