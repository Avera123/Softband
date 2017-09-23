namespace Softband.Mae
{
    partial class Promo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Promo));
            this.label8 = new System.Windows.Forms.Label();
            this.lvPromos = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbPercentPromo = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescriptionPromo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodePromo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbActive = new MetroFramework.Controls.MetroCheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtNamePromo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.PnlMenu = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTb = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPercentPromo)).BeginInit();
            this.panel1.SuspendLayout();
            this.PnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tauri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(646, 44);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(283, 28);
            this.label8.TabIndex = 36;
            this.label8.Text = "LISTADO DE PROMOCIONES";
            // 
            // lvPromos
            // 
            this.lvPromos.Font = new System.Drawing.Font("Tauri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvPromos.Location = new System.Drawing.Point(540, 74);
            this.lvPromos.Name = "lvPromos";
            this.lvPromos.Size = new System.Drawing.Size(464, 353);
            this.lvPromos.TabIndex = 35;
            this.lvPromos.UseCompatibleStateImageBehavior = false;
            this.lvPromos.View = System.Windows.Forms.View.List;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTb);
            this.groupBox1.Controls.Add(this.tbPercentPromo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDescriptionPromo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCodePromo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ckbActive);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtNamePromo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(16, 44);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(517, 383);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // tbPercentPromo
            // 
            this.tbPercentPromo.Location = new System.Drawing.Point(125, 291);
            this.tbPercentPromo.Maximum = 100;
            this.tbPercentPromo.Minimum = 1;
            this.tbPercentPromo.Name = "tbPercentPromo";
            this.tbPercentPromo.Size = new System.Drawing.Size(375, 56);
            this.tbPercentPromo.TabIndex = 20;
            this.tbPercentPromo.Value = 1;
            this.tbPercentPromo.Scroll += new System.EventHandler(this.tbPercentPromo_Scroll);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tauri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(27, 260);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 28);
            this.label7.TabIndex = 19;
            this.label7.Text = "Porcentaje:";
            // 
            // txtDescriptionPromo
            // 
            this.txtDescriptionPromo.Font = new System.Drawing.Font("Tauri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescriptionPromo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtDescriptionPromo.Location = new System.Drawing.Point(125, 155);
            this.txtDescriptionPromo.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescriptionPromo.MaxLength = 250;
            this.txtDescriptionPromo.Multiline = true;
            this.txtDescriptionPromo.Name = "txtDescriptionPromo";
            this.txtDescriptionPromo.Size = new System.Drawing.Size(375, 94);
            this.txtDescriptionPromo.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tauri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(24, 123);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 28);
            this.label4.TabIndex = 16;
            this.label4.Text = "Descripción:";
            // 
            // txtCodePromo
            // 
            this.txtCodePromo.Font = new System.Drawing.Font("Tauri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodePromo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtCodePromo.Location = new System.Drawing.Point(125, 37);
            this.txtCodePromo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodePromo.MaxLength = 5;
            this.txtCodePromo.Name = "txtCodePromo";
            this.txtCodePromo.Size = new System.Drawing.Size(329, 34);
            this.txtCodePromo.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tauri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(24, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 28);
            this.label2.TabIndex = 14;
            this.label2.Text = "Código:";
            // 
            // ckbActive
            // 
            this.ckbActive.AutoSize = true;
            this.ckbActive.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ckbActive.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.ckbActive.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ckbActive.Location = new System.Drawing.Point(4, 359);
            this.ckbActive.Margin = new System.Windows.Forms.Padding(4);
            this.ckbActive.Name = "ckbActive";
            this.ckbActive.Size = new System.Drawing.Size(509, 20);
            this.ckbActive.TabIndex = 13;
            this.ckbActive.Text = "Activa";
            this.ckbActive.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSearch.BackgroundImage = global::Softband.Properties.Resources.magnifying_glass_3_30;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Location = new System.Drawing.Point(460, 36);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(40, 37);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtNamePromo
            // 
            this.txtNamePromo.Font = new System.Drawing.Font("Tauri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNamePromo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtNamePromo.Location = new System.Drawing.Point(125, 78);
            this.txtNamePromo.Margin = new System.Windows.Forms.Padding(4);
            this.txtNamePromo.MaxLength = 250;
            this.txtNamePromo.Name = "txtNamePromo";
            this.txtNamePromo.Size = new System.Drawing.Size(375, 34);
            this.txtNamePromo.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tauri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(24, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tauri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(454, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 30);
            this.label1.TabIndex = 14;
            this.label1.Text = "Promociones";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 449);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1029, 58);
            this.panel1.TabIndex = 34;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.Font = new System.Drawing.Font("Tauri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSave.Image = global::Softband.Properties.Resources.save_30;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(4, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(177, 58);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "GUARDAR";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnClear.Font = new System.Drawing.Font("Tauri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnClear.Image = global::Softband.Properties.Resources.eraser_30;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(377, 0);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(176, 58);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "LIMPIAR";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDelete.Font = new System.Drawing.Font("Tauri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDelete.Image = global::Softband.Properties.Resources.delete_30;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(188, 0);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(183, 58);
            this.btnDelete.TabIndex = 18;
            this.btnDelete.Text = "BORRAR";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // PnlMenu
            // 
            this.PnlMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PnlMenu.Controls.Add(this.btnMinimize);
            this.PnlMenu.Controls.Add(this.btnClose);
            this.PnlMenu.Controls.Add(this.pictureBox1);
            this.PnlMenu.Controls.Add(this.label1);
            this.PnlMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlMenu.Location = new System.Drawing.Point(0, 0);
            this.PnlMenu.Margin = new System.Windows.Forms.Padding(4);
            this.PnlMenu.Name = "PnlMenu";
            this.PnlMenu.Size = new System.Drawing.Size(1029, 37);
            this.PnlMenu.TabIndex = 33;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.White;
            this.btnMinimize.BackgroundImage = global::Softband.Properties.Resources.minimize_window_50__1_;
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.Location = new System.Drawing.Point(949, 0);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(40, 37);
            this.btnMinimize.TabIndex = 21;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.BackgroundImage = global::Softband.Properties.Resources.close_window_50;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.Location = new System.Drawing.Point(989, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 37);
            this.btnClose.TabIndex = 20;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Softband.Properties.Resources.Bandasx50;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 37);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // lblTb
            // 
            this.lblTb.AutoSize = true;
            this.lblTb.Font = new System.Drawing.Font("Tauri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTb.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTb.Location = new System.Drawing.Point(85, 296);
            this.lblTb.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTb.Name = "lblTb";
            this.lblTb.Size = new System.Drawing.Size(33, 19);
            this.lblTb.TabIndex = 21;
            this.lblTb.Text = "---";
            // 
            // Promo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1029, 507);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lvPromos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Promo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Promo";
            this.Load += new System.EventHandler(this.Promo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPercentPromo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.PnlMenu.ResumeLayout(false);
            this.PnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView lvPromos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCodePromo;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroCheckBox ckbActive;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtNamePromo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel PnlMenu;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtDescriptionPromo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tbPercentPromo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTb;
    }
}