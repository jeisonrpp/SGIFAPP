namespace SGPAPP
{
    partial class frmPrinter
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
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.btnAdd = new Telerik.WinControls.UI.RadButton();
            this.lblHost = new Telerik.WinControls.UI.RadLabel();
            this.cbbPrinters = new System.Windows.Forms.ComboBox();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.radScrollablePanel3 = new Telerik.WinControls.UI.RadScrollablePanel();
            this.btnCerrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel3)).BeginInit();
            this.radScrollablePanel3.PanelContainer.SuspendLayout();
            this.radScrollablePanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // radLabel2
            // 
            this.radLabel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.radLabel2.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.radLabel2.Location = new System.Drawing.Point(36, 124);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(93, 22);
            this.radLabel2.TabIndex = 161;
            this.radLabel2.Text = "Hostname:";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAdd.Location = new System.Drawing.Point(107, 191);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(156, 34);
            this.btnAdd.TabIndex = 160;
            this.btnAdd.Text = "Guardar";
            this.btnAdd.ThemeName = "Office2013Light";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblHost
            // 
            this.lblHost.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblHost.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.lblHost.Location = new System.Drawing.Point(145, 124);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(86, 22);
            this.lblHost.TabIndex = 162;
            this.lblHost.Text = "Hostname";
            // 
            // cbbPrinters
            // 
            this.cbbPrinters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbPrinters.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbbPrinters.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F);
            this.cbbPrinters.ForeColor = System.Drawing.Color.DimGray;
            this.cbbPrinters.FormattingEnabled = true;
            this.cbbPrinters.Items.AddRange(new object[] {
            "Seleccione la Impresora"});
            this.cbbPrinters.Location = new System.Drawing.Point(145, 73);
            this.cbbPrinters.Name = "cbbPrinters";
            this.cbbPrinters.Size = new System.Drawing.Size(182, 27);
            this.cbbPrinters.TabIndex = 163;
            // 
            // radLabel10
            // 
            this.radLabel10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.radLabel10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.radLabel10.Font = new System.Drawing.Font("MS Reference Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(54)))), ((int)(((byte)(75)))));
            this.radLabel10.Location = new System.Drawing.Point(34, 75);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(95, 22);
            this.radLabel10.TabIndex = 164;
            this.radLabel10.Text = "Impresora:";
            this.radLabel10.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radScrollablePanel3
            // 
            this.radScrollablePanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radScrollablePanel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.radScrollablePanel3.Location = new System.Drawing.Point(12, 17);
            this.radScrollablePanel3.Name = "radScrollablePanel3";
            // 
            // radScrollablePanel3.PanelContainer
            // 
            this.radScrollablePanel3.PanelContainer.BackColor = System.Drawing.Color.White;
            this.radScrollablePanel3.PanelContainer.Controls.Add(this.btnCerrar);
            this.radScrollablePanel3.PanelContainer.Size = new System.Drawing.Size(355, 223);
            this.radScrollablePanel3.Size = new System.Drawing.Size(357, 225);
            this.radScrollablePanel3.TabIndex = 165;
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
            this.btnCerrar.Location = new System.Drawing.Point(317, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 35);
            this.btnCerrar.TabIndex = 161;
            this.btnCerrar.Text = "X";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmPrinter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(381, 254);
            this.Controls.Add(this.cbbPrinters);
            this.Controls.Add(this.radLabel10);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.radScrollablePanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPrinter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPrinter";
            this.Load += new System.EventHandler(this.frmPrinter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            this.radScrollablePanel3.PanelContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radScrollablePanel3)).EndInit();
            this.radScrollablePanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton btnAdd;
        private Telerik.WinControls.UI.RadLabel lblHost;
        private System.Windows.Forms.ComboBox cbbPrinters;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadScrollablePanel radScrollablePanel3;
        internal System.Windows.Forms.Button btnCerrar;
    }
}