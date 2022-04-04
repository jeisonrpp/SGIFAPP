
namespace SGPAPP
{
    partial class frmConsultas
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultas));
            this.btnCerrar = new System.Windows.Forms.Button();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.office2013LightTheme1 = new Telerik.WinControls.Themes.Office2013LightTheme();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.PanelValores = new Telerik.WinControls.UI.RadScrollablePanel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtGanancia = new System.Windows.Forms.TextBox();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtInversion = new System.Windows.Forms.TextBox();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.PanelContainer = new Telerik.WinControls.UI.RadScrollablePanelContainer();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.PanelContainer.SuspendLayout();
            this.radScrollablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelValores)).BeginInit();
            this.PanelValores.PanelContainer.SuspendLayout();
            this.PanelValores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.SystemColors.Control;
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Ebrima", 12F);
            this.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCerrar.Location = new System.Drawing.Point(845, 23);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 35);
            this.btnCerrar.TabIndex = 119;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // txtConsulta
            // 
            this.txtConsulta.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtConsulta.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.txtConsulta.ForeColor = System.Drawing.Color.DimGray;
            this.txtConsulta.Location = new System.Drawing.Point(18, 34);
            this.txtConsulta.Margin = new System.Windows.Forms.Padding(2);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(225, 26);
            this.txtConsulta.TabIndex = 99;
            this.txtConsulta.Text = "Buscar Productos";
            this.txtConsulta.TextChanged += new System.EventHandler(this.txtConsulta_TextChanged);
            this.txtConsulta.Enter += new System.EventHandler(this.txtConsulta_Enter);
            this.txtConsulta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsulta_KeyPress);
            this.txtConsulta.Leave += new System.EventHandler(this.txtConsulta_Leave);
            // 
            // radGridView1
            // 
            this.radGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView1.Location = new System.Drawing.Point(31, 98);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            this.radGridView1.MasterTemplate.AllowEditRow = false;
            this.radGridView1.MasterTemplate.EnableFiltering = true;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(849, 416);
            this.radGridView1.TabIndex = 132;
            this.radGridView1.ThemeName = "Office2013Light";
            this.radGridView1.CellPaint += new Telerik.WinControls.UI.GridViewCellPaintEventHandler(this.radGridView1_CellPaint);
            this.radGridView1.CreateCell += new Telerik.WinControls.UI.GridViewCreateCellEventHandler(this.radGridView1_CreateCell);
            this.radGridView1.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.radGridView1_RowFormatting);
            this.radGridView1.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.radGridView1_CellFormatting);
            this.radGridView1.CellBeginEdit += new Telerik.WinControls.UI.GridViewCellCancelEventHandler(this.radGridView1_CellBeginEdit);
            this.radGridView1.CurrentCellChanged += new Telerik.WinControls.UI.CurrentCellChangedEventHandler(this.radGridView1_CurrentCellChanged);
            this.radGridView1.SelectionChanged += new System.EventHandler(this.radGridView1_SelectionChanged);
            this.radGridView1.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridView1_CellClick);
            this.radGridView1.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridView1_CellDoubleClick);
            this.radGridView1.Click += new System.EventHandler(this.radGridView1_Click);
            // 
            // radScrollablePanel1
            // 
            this.radScrollablePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radScrollablePanel1.BackColor = System.Drawing.Color.White;
            this.radScrollablePanel1.Location = new System.Drawing.Point(12, 12);
            this.radScrollablePanel1.Name = "radScrollablePanel1";
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.PanelValores);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radButton2);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.txtConsulta);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radButton1);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(879, 506);
            this.radScrollablePanel1.Size = new System.Drawing.Size(881, 508);
            this.radScrollablePanel1.TabIndex = 1;
            // 
            // PanelValores
            // 
            this.PanelValores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelValores.BackColor = System.Drawing.Color.WhiteSmoke;
            this.PanelValores.Location = new System.Drawing.Point(467, 10);
            this.PanelValores.Name = "PanelValores";
            // 
            // PanelValores.PanelContainer
            // 
            this.PanelValores.PanelContainer.BackColor = System.Drawing.Color.White;
            this.PanelValores.PanelContainer.Controls.Add(this.radLabel1);
            this.PanelValores.PanelContainer.Controls.Add(this.txtGanancia);
            this.PanelValores.PanelContainer.Controls.Add(this.radLabel4);
            this.PanelValores.PanelContainer.Controls.Add(this.txtInversion);
            this.PanelValores.PanelContainer.Size = new System.Drawing.Size(313, 67);
            this.PanelValores.Size = new System.Drawing.Size(315, 69);
            this.PanelValores.TabIndex = 163;
            this.PanelValores.Visible = false;
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.radLabel1.Location = new System.Drawing.Point(3, 35);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(130, 22);
            this.radLabel1.TabIndex = 169;
            this.radLabel1.Text = "Ganancia Total:";
            // 
            // txtGanancia
            // 
            this.txtGanancia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtGanancia.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtGanancia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGanancia.Enabled = false;
            this.txtGanancia.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGanancia.ForeColor = System.Drawing.Color.DimGray;
            this.txtGanancia.Location = new System.Drawing.Point(130, 36);
            this.txtGanancia.MaxLength = 50;
            this.txtGanancia.Name = "txtGanancia";
            this.txtGanancia.Size = new System.Drawing.Size(180, 19);
            this.txtGanancia.TabIndex = 168;
            this.txtGanancia.Text = "0.00";
            this.txtGanancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radLabel4
            // 
            this.radLabel4.BackColor = System.Drawing.Color.Transparent;
            this.radLabel4.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.radLabel4.Location = new System.Drawing.Point(3, 7);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(131, 22);
            this.radLabel4.TabIndex = 167;
            this.radLabel4.Text = "Inversion Total:";
            // 
            // txtInversion
            // 
            this.txtInversion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtInversion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtInversion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInversion.Enabled = false;
            this.txtInversion.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInversion.ForeColor = System.Drawing.Color.DimGray;
            this.txtInversion.Location = new System.Drawing.Point(130, 8);
            this.txtInversion.MaxLength = 50;
            this.txtInversion.Name = "txtInversion";
            this.txtInversion.Size = new System.Drawing.Size(180, 19);
            this.txtInversion.TabIndex = 165;
            this.txtInversion.Text = "0.00";
            this.txtInversion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radButton2
            // 
            this.radButton2.Image = ((System.Drawing.Image)(resources.GetObject("radButton2.Image")));
            this.radButton2.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.radButton2.Location = new System.Drawing.Point(260, 22);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(58, 51);
            this.radButton2.TabIndex = 100;
            this.radButton2.Text = "Producto";
            this.radButton2.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.radButton2.ThemeName = "Office2013Light";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // radButton1
            // 
            this.radButton1.Image = ((System.Drawing.Image)(resources.GetObject("radButton1.Image")));
            this.radButton1.ImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.radButton1.Location = new System.Drawing.Point(336, 22);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(58, 51);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "Exportar";
            this.radButton1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.radButton1.ThemeName = "Office2013Light";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click_1);
            // 
            // PanelContainer
            // 
            this.PanelContainer.AutoScroll = false;
            this.PanelContainer.BackColor = System.Drawing.Color.White;
            this.PanelContainer.Dock = System.Windows.Forms.DockStyle.None;
            this.PanelContainer.Location = new System.Drawing.Point(0, 0);
            this.PanelContainer.Size = new System.Drawing.Size(269, 67);
            // 
            // frmConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(905, 532);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.radScrollablePanel1);
            this.Name = "frmConsultas";
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.frmConsultas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            this.radScrollablePanel1.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            this.PanelValores.PanelContainer.ResumeLayout(false);
            this.PanelValores.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PanelValores)).EndInit();
            this.PanelValores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.Themes.Office2013LightTheme office2013LightTheme1;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadScrollablePanel PanelValores;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        public System.Windows.Forms.TextBox txtGanancia;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        public System.Windows.Forms.TextBox txtInversion;
        private Telerik.WinControls.UI.RadScrollablePanelContainer PanelContainer;
    }
}