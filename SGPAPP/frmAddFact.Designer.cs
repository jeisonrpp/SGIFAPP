
namespace SGPAPP
{
    partial class frmAddFact
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
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.radScrollablePanel1 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtCant = new System.Windows.Forms.TextBox();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel3)).BeginInit();
            this.radScrollablePanel3.PanelContainer.SuspendLayout();
            this.radScrollablePanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).BeginInit();
            this.radScrollablePanel1.PanelContainer.SuspendLayout();
            this.radScrollablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.SuspendLayout();
            // 
            // radScrollablePanel3
            // 
            this.radScrollablePanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radScrollablePanel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.radScrollablePanel3.Location = new System.Drawing.Point(12, 12);
            this.radScrollablePanel3.Name = "radScrollablePanel3";
            // 
            // radScrollablePanel3.PanelContainer
            // 
            this.radScrollablePanel3.PanelContainer.BackColor = System.Drawing.Color.White;
            this.radScrollablePanel3.PanelContainer.Controls.Add(this.btnCerrar);
            this.radScrollablePanel3.PanelContainer.Controls.Add(this.radLabel2);
            this.radScrollablePanel3.PanelContainer.Controls.Add(this.txtPrecio);
            this.radScrollablePanel3.PanelContainer.Controls.Add(this.btnAdd);
            this.radScrollablePanel3.PanelContainer.Controls.Add(this.radLabel1);
            this.radScrollablePanel3.PanelContainer.Controls.Add(this.txtStock);
            this.radScrollablePanel3.PanelContainer.Controls.Add(this.txtArticulo);
            this.radScrollablePanel3.PanelContainer.Controls.Add(this.radScrollablePanel1);
            this.radScrollablePanel3.PanelContainer.Size = new System.Drawing.Size(436, 219);
            this.radScrollablePanel3.Size = new System.Drawing.Size(438, 221);
            this.radScrollablePanel3.TabIndex = 154;
            // 
            // txtArticulo
            // 
            this.txtArticulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtArticulo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtArticulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtArticulo.Enabled = false;
            this.txtArticulo.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtArticulo.ForeColor = System.Drawing.Color.DimGray;
            this.txtArticulo.Location = new System.Drawing.Point(18, 12);
            this.txtArticulo.MaxLength = 50;
            this.txtArticulo.Multiline = true;
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(363, 38);
            this.txtArticulo.TabIndex = 155;
            this.txtArticulo.Text = "Articulo";
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
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.txtCant);
            this.radScrollablePanel1.PanelContainer.Controls.Add(this.radLabel5);
            this.radScrollablePanel1.PanelContainer.Size = new System.Drawing.Size(227, 74);
            this.radScrollablePanel1.Size = new System.Drawing.Size(229, 76);
            this.radScrollablePanel1.TabIndex = 154;
            // 
            // radLabel5
            // 
            this.radLabel5.BackColor = System.Drawing.Color.Transparent;
            this.radLabel5.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.radLabel5.Location = new System.Drawing.Point(22, 5);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(76, 22);
            this.radLabel5.TabIndex = 151;
            this.radLabel5.Text = "Cantidad";
            // 
            // txtStock
            // 
            this.txtStock.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtStock.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStock.Enabled = false;
            this.txtStock.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStock.ForeColor = System.Drawing.Color.DimGray;
            this.txtStock.Location = new System.Drawing.Point(41, 75);
            this.txtStock.MaxLength = 50;
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(92, 19);
            this.txtStock.TabIndex = 156;
            this.txtStock.Text = "Stock";
            this.txtStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Transparent;
            this.radLabel1.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.radLabel1.Location = new System.Drawing.Point(61, 56);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(51, 22);
            this.radLabel1.TabIndex = 157;
            this.radLabel1.Text = "Stock";
            // 
            // txtCant
            // 
            this.txtCant.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCant.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCant.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCant.Font = new System.Drawing.Font("MS Reference Sans Serif", 18.25F, System.Drawing.FontStyle.Bold);
            this.txtCant.ForeColor = System.Drawing.Color.DimGray;
            this.txtCant.Location = new System.Drawing.Point(159, 32);
            this.txtCant.MaxLength = 50;
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(50, 30);
            this.txtCant.TabIndex = 158;
            this.txtCant.Text = "0";
            this.txtCant.TextChanged += new System.EventHandler(this.txtCant_TextChanged);
            this.txtCant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCant_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAdd.Location = new System.Drawing.Point(141, 168);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(156, 34);
            this.btnAdd.TabIndex = 155;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.ThemeName = "Office2013Light";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.Transparent;
            this.radLabel2.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.radLabel2.Location = new System.Drawing.Point(44, 116);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(95, 22);
            this.radLabel2.TabIndex = 159;
            this.radLabel2.Text = "Precio und.";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPrecio.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrecio.Enabled = false;
            this.txtPrecio.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.ForeColor = System.Drawing.Color.DimGray;
            this.txtPrecio.Location = new System.Drawing.Point(42, 135);
            this.txtPrecio.MaxLength = 50;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(92, 19);
            this.txtPrecio.TabIndex = 158;
            this.txtPrecio.Text = "0.00";
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.btnCerrar.Location = new System.Drawing.Point(396, 4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 35);
            this.btnCerrar.TabIndex = 160;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmAddFact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(462, 245);
            this.Controls.Add(this.radScrollablePanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddFact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAddFact";
            this.Load += new System.EventHandler(this.frmAddFact_Load);
            this.radScrollablePanel3.PanelContainer.ResumeLayout(false);
            this.radScrollablePanel3.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel3)).EndInit();
            this.radScrollablePanel3.ResumeLayout(false);
            this.radScrollablePanel1.PanelContainer.ResumeLayout(false);
            this.radScrollablePanel1.PanelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel1)).EndInit();
            this.radScrollablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel3;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel1;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private System.Windows.Forms.TextBox txtArticulo;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.TextBox txtStock;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        public System.Windows.Forms.TextBox txtCant;
        public System.Windows.Forms.TextBox txtPrecio;
        internal System.Windows.Forms.Button btnCerrar;
    }
}