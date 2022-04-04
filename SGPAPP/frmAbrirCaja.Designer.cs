
namespace SGPAPP
{
    partial class frmAbrirCaja
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
            this.radScrollablePanel3 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtMontoAnterior = new System.Windows.Forms.TextBox();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtCaja = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel3)).BeginInit();
            this.radScrollablePanel3.PanelContainer.SuspendLayout();
            this.radScrollablePanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.PanelContainer.SuspendLayout();
            this.radScrollablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            this.SuspendLayout();
            // 
            // radScrollablePanel3
            // 
            this.radScrollablePanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radScrollablePanel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.radScrollablePanel3.Location = new System.Drawing.Point(12, 28);
            this.radScrollablePanel3.Name = "radScrollablePanel3";
            // 
            // radScrollablePanel3.PanelContainer
            // 
            this.radScrollablePanel3.PanelContainer.BackColor = System.Drawing.Color.White;
            this.radScrollablePanel3.PanelContainer.Controls.Add(this.btnCerrar);
            this.radScrollablePanel3.PanelContainer.Controls.Add(this.radLabel2);
            this.radScrollablePanel3.PanelContainer.Controls.Add(this.txtMontoAnterior);
            this.radScrollablePanel3.PanelContainer.Controls.Add(this.btnAdd);
            this.radScrollablePanel3.PanelContainer.Controls.Add(this.radLabel1);
            this.radScrollablePanel3.PanelContainer.Controls.Add(this.txtCaja);
            this.radScrollablePanel3.PanelContainer.Controls.Add(this.txtUsuario);
            this.radScrollablePanel3.PanelContainer.Controls.Add(this.radScrollablePanel1);
            this.radScrollablePanel3.PanelContainer.Size = new System.Drawing.Size(420, 219);
            this.radScrollablePanel3.Size = new System.Drawing.Size(422, 221);
            this.radScrollablePanel3.TabIndex = 155;
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
            this.btnCerrar.Location = new System.Drawing.Point(380, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 35);
            this.btnCerrar.TabIndex = 160;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.radLabel2.Location = new System.Drawing.Point(30, 93);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(130, 22);
            this.radLabel2.TabIndex = 159;
            this.radLabel2.Text = "Monto Anterior:";
            this.radLabel2.Visible = false;
            // 
            // txtMontoAnterior
            // 
            this.txtMontoAnterior.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMontoAnterior.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMontoAnterior.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMontoAnterior.Enabled = false;
            this.txtMontoAnterior.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoAnterior.ForeColor = System.Drawing.Color.DimGray;
            this.txtMontoAnterior.Location = new System.Drawing.Point(20, 113);
            this.txtMontoAnterior.MaxLength = 50;
            this.txtMontoAnterior.Name = "txtMontoAnterior";
            this.txtMontoAnterior.Size = new System.Drawing.Size(145, 19);
            this.txtMontoAnterior.TabIndex = 158;
            this.txtMontoAnterior.Text = "0.00";
            this.txtMontoAnterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMontoAnterior.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAdd.Location = new System.Drawing.Point(125, 168);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(156, 34);
            this.btnAdd.TabIndex = 155;
            this.btnAdd.Text = "Abrir Caja";
            this.btnAdd.ThemeName = "Office2013Light";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.radLabel1.Location = new System.Drawing.Point(54, 35);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(49, 22);
            this.radLabel1.TabIndex = 157;
            this.radLabel1.Text = "Caja:";
            // 
            // txtCaja
            // 
            this.txtCaja.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCaja.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCaja.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCaja.Enabled = false;
            this.txtCaja.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaja.ForeColor = System.Drawing.Color.DimGray;
            this.txtCaja.Location = new System.Drawing.Point(8, 63);
            this.txtCaja.MaxLength = 50;
            this.txtCaja.Name = "txtCaja";
            this.txtCaja.Size = new System.Drawing.Size(140, 19);
            this.txtCaja.TabIndex = 156;
            this.txtCaja.Text = "Caja";
            this.txtCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUsuario.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.DimGray;
            this.txtUsuario.Location = new System.Drawing.Point(18, 12);
            this.txtUsuario.MaxLength = 50;
            this.txtUsuario.Multiline = true;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(363, 38);
            this.txtUsuario.TabIndex = 155;
            this.txtUsuario.Text = "Usuario";
            // 
            // radScrollablePanel1
            // 
            this.radScrollablePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radScrollablePanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.radScrollablePanel1.Location = new System.Drawing.Point(171, 63);
            this.radScrollablePanel1.Name = "radScrollablePanel1";
            // 
            // radScrollablePanel1.PanelContainer
            // 
            this.radScrollablePanel1.PanelContainer.BackColor = System.Drawing.Color.White;
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.txtMonto);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radLabel5);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(211, 74);
            this.radScrollablePanel1.Size = new System.Drawing.Size(213, 76);
            this.radScrollablePanel1.TabIndex = 154;
            // 
            // txtMonto
            // 
            this.txtMonto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMonto.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMonto.Font = new System.Drawing.Font("MS Reference Sans Serif", 18.25F, System.Drawing.FontStyle.Bold);
            this.txtMonto.ForeColor = System.Drawing.Color.DimGray;
            this.txtMonto.Location = new System.Drawing.Point(15, 32);
            this.txtMonto.MaxLength = 50;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(193, 30);
            this.txtMonto.TabIndex = 158;
            this.txtMonto.Text = "0";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // radLabel5
            // 
            this.radLabel5.BackColor = System.Drawing.Color.Transparent;
            this.radLabel5.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.radLabel5.Location = new System.Drawing.Point(22, 5);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(127, 22);
            this.radLabel5.TabIndex = 151;
            this.radLabel5.Text = "Monto de Caja:";
            // 
            // frmAbrirCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(446, 276);
            this.Controls.Add(this.radScrollablePanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAbrirCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAbrirCaja";
            this.Load += new System.EventHandler(this.frmAbrirCaja_Load);
            this.radScrollablePanel3.PanelContainer.ResumeLayout(false);
            this.radScrollablePanel3.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel3)).EndInit();
            this.radScrollablePanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            this.radScrollablePanel1.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel3;
        internal System.Windows.Forms.Button btnCerrar;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        public System.Windows.Forms.TextBox txtMontoAnterior;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.TextBox txtCaja;
        private System.Windows.Forms.TextBox txtUsuario;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
        public System.Windows.Forms.TextBox txtMonto;
        private Telerik.WinControls.UI.RadLabel radLabel5;
    }
}