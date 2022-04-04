using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGPAPP
{
    public partial class frmAbrirCaja : Form
    {
        public frmAbrirCaja()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        String CajaID;
        int id;
        String Sql;
        private void frmAbrirCaja_Load(object sender, EventArgs e)
        {
            
            ValidaCaja();
            GetID();
            CargaDatos();
            txtUsuario.Text = UserCache.LoginName;
            txtCaja.Text = CajaID;
            txtMonto.Select();
            if(UserCache.Nivel == "Admin")
            {
                radLabel2.Visible = true;
                txtMontoAnterior.Visible = true;
            }
        }

        public void CargaDatos()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                id = id - 1;
                using (SqlCommand comand = new SqlCommand("SELECT caimportefinal as importe from tbcaja where cacodigo = 'CA00"+id+"'", con))
                {


                    using (SqlDataReader leer = comand.ExecuteReader())
                    {
                        if (leer.Read() == true)
                        {
                           txtMontoAnterior.Text = leer["importe"].ToString();
                          
                        }
                        else
                        {

                        }
                    }
                }
                con.Close();
            }
        }
        public void ValidaCaja()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                using (SqlCommand comand = new SqlCommand("SELECT caEstado as Estado from tbcaja where caEstado = 'Abierta'", con))
                {


                    using (SqlDataReader leer = comand.ExecuteReader())
                    {
                        if (leer.Read() == true)
                        {
                            MessageBox.Show("Ya existe una caja abierta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }                        
                    }
                }
                con.Close();
            }
        }
        public void GetID()
        {
           
                using (var con = new SqlConnection(conect))
                {
                    con.Open();

                    using (SqlCommand comand = new SqlCommand("SELECT COUNT (Distinct cacodigo) as [Id de Caja] from tbcaja", con))
                    {


                        using (SqlDataReader leer = comand.ExecuteReader())
                        {
                            if (leer.Read() == true)
                            {
                                id = Convert.ToInt32(leer["Id de Caja"].ToString());
                                id = id + 1;
                                CajaID = "CA00" + id.ToString();
                            }
                        }
                    }
                con.Close();
                }
           
        }
        public void AbrirCaja()
        {
            using (var con = new SqlConnection(conect))
            {
                 con.Open();
                cmd = new SqlCommand(Sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spAbrirCaja";
                cmd.Parameters.Add(new SqlParameter("@cacodigo", SqlDbType.NChar)).Value = CajaID;
                cmd.Parameters.Add(new SqlParameter("@uid", SqlDbType.Int)).Value = UserCache.UserID;
                cmd.Parameters.Add(new SqlParameter("@fechainicio", SqlDbType.DateTime)).Value = DateTime.Now;
                cmd.Parameters.Add(new SqlParameter("@status", SqlDbType.NChar)).Value = "Abierta";
                cmd.Parameters.Add(new SqlParameter("@monto", SqlDbType.Float)).Value = txtMonto.Text;

                try
                {
                    cmd.ExecuteNonQuery();
                    UserCache.CajaID = CajaID;
                    MessageBox.Show("Se ha abierto la caja Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logs log = new Logs();
                    log.Accion = "Caja: " + CajaID + " Abierta";
                    log.Form = "Facturacion";
                    log.SaveLog();
                    this.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();

                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtMonto.Text.Length == 0)
            {
                MessageBox.Show("Debe indicar un monto valido.", "Monto Invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                if (double.Parse(txtMontoAnterior.Text) != double.Parse(txtMonto.Text))
                {
                    DialogResult resulta =  MessageBox.Show("El monto Anterior no es igual al monto actual, Esta seguro que desea abril esta caja?", "Abrir Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resulta == DialogResult.Yes)
                    {
                        AbrirCaja();
                    }
                }
                else
                {
                    AbrirCaja();
                
                }
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                if (txtMonto.Text.Length == 0)
                {
                    MessageBox.Show("Debe indicar un monto valido.", "Monto Invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (double.Parse(txtMontoAnterior.Text) != double.Parse(txtMonto.Text))
                    {
                        DialogResult resulta = MessageBox.Show("El monto Anterior no es igual al monto actual, Esta seguro que desea abril esta caja?", "Abrir Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resulta == DialogResult.Yes)
                        {
                            AbrirCaja();
                        }
                    }
                    else
                    {
                        AbrirCaja();
                    }
                }

            }
            }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
