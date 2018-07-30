namespace Softband.Mae
{
    partial class Deudas
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Deudas));
            this.dgvDeudas = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTodas = new System.Windows.Forms.Button();
            this.btnSaldadas = new System.Windows.Forms.Button();
            this.btnVigentes = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbAccounts = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtFact = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNameCliente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnNewCliente = new System.Windows.Forms.Button();
            this.txtIDClient = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDeudasClientes = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalizarDeudas = new System.Windows.Forms.Label();
            this.btnTotalizarDeudas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeudas)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeudasClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDeudas
            // 
            this.dgvDeudas.AllowUserToAddRows = false;
            this.dgvDeudas.AllowUserToDeleteRows = false;
            this.dgvDeudas.AllowUserToOrderColumns = true;
            this.dgvDeudas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeudas.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDeudas.Location = new System.Drawing.Point(0, 256);
            this.dgvDeudas.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDeudas.Name = "dgvDeudas";
            this.dgvDeudas.ReadOnly = true;
            this.dgvDeudas.RowTemplate.Height = 24;
            this.dgvDeudas.Size = new System.Drawing.Size(704, 367);
            this.dgvDeudas.TabIndex = 36;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(256, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 18);
            this.label8.TabIndex = 35;
            this.label8.Text = "LISTADO DE DEUDAS";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnTodas);
            this.panel1.Controls.Add(this.btnSaldadas);
            this.panel1.Controls.Add(this.btnVigentes);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 655);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1031, 50);
            this.panel1.TabIndex = 34;
            // 
            // btnTodas
            // 
            this.btnTodas.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTodas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTodas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTodas.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnTodas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTodas.Location = new System.Drawing.Point(920, 12);
            this.btnTodas.Name = "btnTodas";
            this.btnTodas.Size = new System.Drawing.Size(61, 29);
            this.btnTodas.TabIndex = 22;
            this.btnTodas.Text = "Todas";
            this.btnTodas.UseVisualStyleBackColor = false;
            this.btnTodas.Click += new System.EventHandler(this.btnTodas_Click);
            // 
            // btnSaldadas
            // 
            this.btnSaldadas.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSaldadas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaldadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaldadas.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSaldadas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaldadas.Location = new System.Drawing.Point(761, 12);
            this.btnSaldadas.Name = "btnSaldadas";
            this.btnSaldadas.Size = new System.Drawing.Size(77, 29);
            this.btnSaldadas.TabIndex = 21;
            this.btnSaldadas.Text = "Saldadas";
            this.btnSaldadas.UseVisualStyleBackColor = false;
            this.btnSaldadas.Click += new System.EventHandler(this.btnSaldadas_Click);
            // 
            // btnVigentes
            // 
            this.btnVigentes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnVigentes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVigentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVigentes.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnVigentes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVigentes.Location = new System.Drawing.Point(844, 12);
            this.btnVigentes.Name = "btnVigentes";
            this.btnVigentes.Size = new System.Drawing.Size(70, 29);
            this.btnVigentes.TabIndex = 20;
            this.btnVigentes.Text = "Vigentes";
            this.btnVigentes.UseVisualStyleBackColor = false;
            this.btnVigentes.Click += new System.EventHandler(this.button1_Click);
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
            this.btnExport.Location = new System.Drawing.Point(987, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(40, 40);
            this.btnExport.TabIndex = 19;
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.BackgroundImage = global::Softband.Properties.Resources.save_128;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(3, 5);
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
            this.btnClear.BackgroundImage = global::Softband.Properties.Resources.eraser_30;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(95, 5);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(40, 40);
            this.btnClear.TabIndex = 16;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDelete.BackgroundImage = global::Softband.Properties.Resources.fullscreen_exit_128;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(49, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(40, 40);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.txtFact);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblNameCliente);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.btnNewCliente);
            this.groupBox1.Controls.Add(this.txtIDClient);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1012, 220);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la Deuda";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbAccounts);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(988, 63);
            this.groupBox2.TabIndex = 82;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cuenta para saldar";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(18, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 17);
            this.label6.TabIndex = 80;
            this.label6.Text = "Cuenta:";
            // 
            // cbAccounts
            // 
            this.cbAccounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAccounts.FormattingEnabled = true;
            this.cbAccounts.Items.AddRange(new object[] {
            "CUENTA DE AHORROS",
            "CUENTA CORRIENTE",
            "EFECTIVO"});
            this.cbAccounts.Location = new System.Drawing.Point(117, 21);
            this.cbAccounts.Name = "cbAccounts";
            this.cbAccounts.Size = new System.Drawing.Size(859, 28);
            this.cbAccounts.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(21, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 78;
            this.label5.Text = "Fecha:";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(123, 111);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(185, 26);
            this.dtpDate.TabIndex = 77;
            // 
            // txtFact
            // 
            this.txtFact.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtFact.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtFact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFact.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFact.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtFact.Location = new System.Drawing.Point(410, 80);
            this.txtFact.MaxLength = 5000;
            this.txtFact.Multiline = true;
            this.txtFact.Name = "txtFact";
            this.txtFact.Size = new System.Drawing.Size(590, 57);
            this.txtFact.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(314, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 75;
            this.label4.Text = "Descripción:";
            // 
            // lblNameCliente
            // 
            this.lblNameCliente.AutoSize = true;
            this.lblNameCliente.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameCliente.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblNameCliente.Location = new System.Drawing.Point(121, 60);
            this.lblNameCliente.Name = "lblNameCliente";
            this.lblNameCliente.Size = new System.Drawing.Size(23, 17);
            this.lblNameCliente.TabIndex = 74;
            this.lblNameCliente.Text = "---";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(21, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 73;
            this.label2.Text = "Cliente:";
            // 
            // txtAmount
            // 
            this.txtAmount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtAmount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAmount.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtAmount.Location = new System.Drawing.Point(124, 80);
            this.txtAmount.MaxLength = 250;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(184, 25);
            this.txtAmount.TabIndex = 72;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(21, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 71;
            this.label1.Text = "Monto:";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch.BackgroundImage = global::Softband.Properties.Resources.magnifying_glass_3_30;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Location = new System.Drawing.Point(935, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(30, 30);
            this.btnSearch.TabIndex = 70;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnNewCliente
            // 
            this.btnNewCliente.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNewCliente.BackgroundImage = global::Softband.Properties.Resources.plus_2_64;
            this.btnNewCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCliente.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnNewCliente.Location = new System.Drawing.Point(971, 27);
            this.btnNewCliente.Name = "btnNewCliente";
            this.btnNewCliente.Size = new System.Drawing.Size(30, 30);
            this.btnNewCliente.TabIndex = 68;
            this.btnNewCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewCliente.UseVisualStyleBackColor = false;
            this.btnNewCliente.Click += new System.EventHandler(this.btnNewCliente_Click);
            // 
            // txtIDClient
            // 
            this.txtIDClient.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtIDClient.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtIDClient.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtIDClient.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDClient.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtIDClient.Location = new System.Drawing.Point(123, 30);
            this.txtIDClient.MaxLength = 250;
            this.txtIDClient.Name = "txtIDClient";
            this.txtIDClient.Size = new System.Drawing.Size(805, 25);
            this.txtIDClient.TabIndex = 4;
            this.txtIDClient.Leave += new System.EventHandler(this.txtIDClient_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(21, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Identificación:";
            // 
            // dgvDeudasClientes
            // 
            this.dgvDeudasClientes.AllowUserToAddRows = false;
            this.dgvDeudasClientes.AllowUserToDeleteRows = false;
            this.dgvDeudasClientes.AllowUserToOrderColumns = true;
            this.dgvDeudasClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeudasClientes.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvDeudasClientes.Location = new System.Drawing.Point(712, 256);
            this.dgvDeudasClientes.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDeudasClientes.Name = "dgvDeudasClientes";
            this.dgvDeudasClientes.ReadOnly = true;
            this.dgvDeudasClientes.RowTemplate.Height = 24;
            this.dgvDeudasClientes.Size = new System.Drawing.Size(312, 368);
            this.dgvDeudasClientes.TabIndex = 37;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(736, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(273, 18);
            this.label7.TabIndex = 38;
            this.label7.Text = "LISTADO DE DEUDAS TOTALIZADO";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label9.Location = new System.Drawing.Point(4, 630);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 18);
            this.label9.TabIndex = 39;
            this.label9.Text = "TOTAL EN DEUDAS:";
            // 
            // lblTotalizarDeudas
            // 
            this.lblTotalizarDeudas.AutoSize = true;
            this.lblTotalizarDeudas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalizarDeudas.ForeColor = System.Drawing.Color.Red;
            this.lblTotalizarDeudas.Location = new System.Drawing.Point(166, 630);
            this.lblTotalizarDeudas.Name = "lblTotalizarDeudas";
            this.lblTotalizarDeudas.Size = new System.Drawing.Size(76, 19);
            this.lblTotalizarDeudas.TabIndex = 40;
            this.lblTotalizarDeudas.Text = "$ 500000";
            // 
            // btnTotalizarDeudas
            // 
            this.btnTotalizarDeudas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTotalizarDeudas.BackgroundImage = global::Softband.Properties.Resources.fullscreen_exit_128;
            this.btnTotalizarDeudas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTotalizarDeudas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotalizarDeudas.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnTotalizarDeudas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTotalizarDeudas.Location = new System.Drawing.Point(271, 626);
            this.btnTotalizarDeudas.Name = "btnTotalizarDeudas";
            this.btnTotalizarDeudas.Size = new System.Drawing.Size(25, 25);
            this.btnTotalizarDeudas.TabIndex = 23;
            this.btnTotalizarDeudas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTotalizarDeudas.UseVisualStyleBackColor = false;
            this.btnTotalizarDeudas.Click += new System.EventHandler(this.btnTotalizarDeudas_Click);
            // 
            // Deudas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1031, 705);
            this.Controls.Add(this.btnTotalizarDeudas);
            this.Controls.Add(this.lblTotalizarDeudas);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvDeudasClientes);
            this.Controls.Add(this.dgvDeudas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Deudas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deudas";
            this.Load += new System.EventHandler(this.Deudas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeudas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeudasClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDeudas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIDClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNewCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtFact;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNameCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbAccounts;
        private System.Windows.Forms.Button btnVigentes;
        private System.Windows.Forms.Button btnTodas;
        private System.Windows.Forms.Button btnSaldadas;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView dgvDeudasClientes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotalizarDeudas;
        private System.Windows.Forms.Button btnTotalizarDeudas;
    }
}