﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;

namespace SGPAPP
{
    public partial class frmMain : Telerik.WinControls.UI.RadForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;
       static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        int Desc;
     
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.Panelcontenedor.Region = region;
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }

        private void openFormOnPanel<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelformularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca el formulario en la colecion.
            //si el formulario/instancia no existe/crea           
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelformularios.Controls.Add(formulario);
                panelformularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(closedForm);
            }

            else
            {
                //si la Formulario / instancia existe, lo traemos a frente
                formulario.BringToFront();
            }
        }

        //METODO/EVENTO AL CERRAR FORMS//METHOD / EVENT WHEN CLOSING FORMS
        private void closedForm(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["frmConsultaClientes"] == null)
            {
                btnClientes.BackColor = Color.FromArgb(37, 54, 75);
                //More Codes
            }
            if (Application.OpenForms["frmConsultas"] == null)
            {
                btnInventario.BackColor = Color.FromArgb(37, 54, 75);
                //More Codes
            }
            if (Application.OpenForms["frmCaja"] == null)
            {
                btnFact.BackColor = Color.FromArgb(37, 54, 75);
                //More Codes
            }
            if (Application.OpenForms["frmSetup"] == null)
            {
                btnSetup.BackColor = Color.FromArgb(37, 54, 75);
                //More Codes
            }
            if (Application.OpenForms["frmLogs"] == null)
            {
                btnSetup.BackColor = Color.FromArgb(37, 54, 75);
                //More Codes
            }
          
            
        }

        private void btnPacient_Click(object sender, EventArgs e)
        {
            openFormOnPanel<frmConsultaClientes>();
            btnClientes.BackColor = Color.FromArgb(0, 100, 182);
        }

        private void btnClinicalHistory_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            //openFormOnPanel<FormPrereg>();
            //btnCitas.BackColor = Color.FromArgb(0, 100, 182);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //openFormOnPanel<frmConsultap>();
            //btnPruebas.BackColor = Color.FromArgb(0, 100, 182);
        }

        private void btnResultados_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            Privilegios();
            lblUserName.Text = UserCache.Usuario;
            label1.Text = UserCache.Nivel;
            DelLogs();
            ValidaStatus();
       
        }
       
        
        public void ValidaStatus()
        {
            if (InternetGetConnectedState(out Desc, 0).ToString() == "True")
            {

                var timer = new System.Timers.Timer(TimeSpan.FromMinutes(1).TotalMilliseconds);
                timer.Elapsed += async (sender, e) =>
                {

                    using (var con = new SqlConnection(conect))
                    {
                        try
                        {
                        string sql = "SELECT (uStatus) as [Status] FROM tbUsuarios WHERE uUser = '" + UserCache.Usuario + "' AND uPassword = '" + UserCache.Password + "'";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        SqlDataReader reader;
                        cmd.CommandType = CommandType.Text;
                        con.Open();

                       
                            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                            if (reader.Read())
                            {
                                UserCache.Status = reader[0].ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            con.Close();
                        }
                    }
                    if (UserCache.Status == "Inactivo")
                    {
                        MessageBox.Show("Este Usuario se encuentra inhabilitado, contacte al administrador", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Application.Exit();

                    }
                };
                timer.Start();
            }
        }
            
        public void CloseFrm()
        { 
        }
        public void DelLogs()
        {
            
            DateTime Fecha = DateTime.Now.AddMonths(-5);

            string[] files = Directory.GetFiles(@"C:\SGP\");

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.LastWriteTime < DateTime.Now.AddDays(-7))
                    fi.Delete();
            }



            string day2 = Fecha.Day.ToString();
                string mes2 = Fecha.Month.ToString();
                string year2 = Fecha.Year.ToString();

                string cambiada1 = year2 + "-" + mes2 + "-" + day2;

            using (var con = new SqlConnection(conect))
            {
                try
                { 
                String Sql = "delete from tblogs where logfecha < '" + cambiada1 + "'";
                SqlCommand cmd = new SqlCommand(Sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();

                
                    int i = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    con.Close();
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resulta = MessageBox.Show("Seguro desea cerrar la aplicacion?", "Cerrar Aplicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                    UserCache.RoleList.Clear();        
                    Logs log = new Logs();
                    log.Accion = "Cierre de Aplicacion";
                    log.Form = "MainForm";
                    log.SaveLog();
                    Application.Exit();
                }
                else if (resulta == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnResultados_Click_1(object sender, EventArgs e)
        {
           
            //openFormOnPanel<frmConsultaR>();
            //btnResultados.BackColor = Color.FromArgb(0, 100, 182);
        }

       

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult resulta = MessageBox.Show("Seguro desea cerrar sesion?", "Cerrar Sesion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resulta == DialogResult.Yes)
            {
                FormLogin log = new FormLogin();
                log.Show();
                this.Hide();
            }
            
        }

        public void Privilegios()
        {


            if (UserCache.RoleList.Any(item => item.RoleName == "Clientes") || UserCache.Nivel == "Admin")
            {
                btnClientes.Enabled = true;
            }

            if (UserCache.RoleList.Any(item => item.RoleName == "Inventario") || UserCache.Nivel == "Admin")
            {
                btnInventario.Enabled = true;
            }
            if (UserCache.RoleList.Any(item => item.RoleName == "Facturacion") || UserCache.Nivel == "Admin")
            {
                btnFact.Enabled = true;
            }
            if (UserCache.RoleList.Any(item => item.RoleName == "Configuraciones") || UserCache.Nivel == "Admin")
            {
                btnSetup.Enabled = true;
            }

        }

        private void btnResultc_Click(object sender, EventArgs e)
        {
            openFormOnPanel<frmConsultas>();
            btnInventario.BackColor = Color.FromArgb(0, 100, 182);
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Configuraciones") || UserCache.Nivel == "Admin")
            {
                openFormOnPanel<frmSetup>();
                btnSetup.BackColor = Color.FromArgb(0, 100, 182);
            }    
        }

        private void ptbProfile_Click(object sender, EventArgs e)
        {
        }

        private void brnResultsm_Click(object sender, EventArgs e)
        {
            //openFormOnPanel<frmReporteMasivo>();
            //btnResultsm.BackColor = Color.FromArgb(0, 100, 182);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //openFormOnPanel<frmOperativos>();
            //button1.BackColor = Color.FromArgb(0, 100, 182);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChangelog ch = new frmChangelog();
            ch.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if(UserCache.RoleList.Any(item => item.RoleName == textBox1.Text))
            //{
            //    MessageBox.Show("existe");
            //}
        }

        private void btnFact_Click(object sender, EventArgs e)
        {
            openFormOnPanel<frmCaja>();
            btnFact.BackColor = Color.FromArgb(0, 100, 182);
        }
    }
}
