namespace Softband.Maestros
{
    partial class Bandas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bandas));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodeBand = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbActive = new MetroFramework.Controls.MetroCheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtNameBand = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PnlMenu = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDeleteBand = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lvBands = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.PnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tauri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(372, -1);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 30);
            this.label1.TabIndex = 14;
            this.label1.Text = "Grupos o Bandas";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCodeBand);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ckbActive);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtNameBand);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(20, 53);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(517, 170);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // txtCodeBand
            // 
            this.txtCodeBand.Font = new System.Drawing.Font("Tauri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodeBand.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtCodeBand.Location = new System.Drawing.Point(125, 37);
            this.txtCodeBand.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodeBand.MaxLength = 5;
            this.txtCodeBand.Name = "txtCodeBand";
            this.txtCodeBand.Size = new System.Drawing.Size(329, 34);
            this.txtCodeBand.TabIndex = 15;
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
            this.ckbActive.Location = new System.Drawing.Point(4, 146);
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
            this.btnSearch.Location = new System.Drawing.Point(461, 37);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(40, 34);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtNameBand
            // 
            this.txtNameBand.Font = new System.Drawing.Font("Tauri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameBand.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtNameBand.Location = new System.Drawing.Point(125, 78);
            this.txtNameBand.Margin = new System.Windows.Forms.Padding(4);
            this.txtNameBand.MaxLength = 250;
            this.txtNameBand.Name = "txtNameBand";
            this.txtNameBand.Size = new System.Drawing.Size(375, 34);
            this.txtNameBand.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tauri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(24, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre:";
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
            this.PnlMenu.Size = new System.Drawing.Size(1022, 37);
            this.PnlMenu.TabIndex = 19;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.White;
            this.btnMinimize.BackgroundImage = global::Softband.Properties.Resources.minimize_window_50__1_;
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimize.Location = new System.Drawing.Point(942, 0);
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
            this.btnClose.Location = new System.Drawing.Point(982, 0);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnDeleteBand);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 239);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1022, 58);
            this.panel1.TabIndex = 20;
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
            this.btnSave.Size = new System.Drawing.Size(178, 58);
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
            // btnDeleteBand
            // 
            this.btnDeleteBand.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDeleteBand.Font = new System.Drawing.Font("Tauri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteBand.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDeleteBand.Image = global::Softband.Properties.Resources.delete_30;
            this.btnDeleteBand.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteBand.Location = new System.Drawing.Point(188, 0);
            this.btnDeleteBand.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteBand.Name = "btnDeleteBand";
            this.btnDeleteBand.Size = new System.Drawing.Size(183, 58);
            this.btnDeleteBand.TabIndex = 18;
            this.btnDeleteBand.Text = "BORRAR";
            this.btnDeleteBand.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteBand.UseVisualStyleBackColor = false;
            this.btnDeleteBand.Click += new System.EventHandler(this.btnDeleteBand_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tauri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(611, 53);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(331, 28);
            this.label8.TabIndex = 33;
            this.label8.Text = "LISTADO DE GRUPOS O BANDAS";
            // 
            // lvBands
            // 
            this.lvBands.Font = new System.Drawing.Font("Tauri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBands.Location = new System.Drawing.Point(553, 84);
            this.lvBands.Name = "lvBands";
            this.lvBands.Size = new System.Drawing.Size(454, 139);
            this.lvBands.TabIndex = 32;
            this.lvBands.UseCompatibleStateImageBehavior = false;
            this.lvBands.View = System.Windows.Forms.View.List;
            // 
            // Bandas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1022, 297);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lvBands);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PnlMenu);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Bandas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bandas";
            this.Load += new System.EventHandler(this.Bandas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PnlMenu.ResumeLayout(false);
            this.PnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNameBand;
        private System.Windows.Forms.Button btnSearch;
        private MetroFramework.Controls.MetroCheckBox ckbActive;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtCodeBand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteBand;
        private System.Windows.Forms.Panel PnlMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView lvBands;
    }
}