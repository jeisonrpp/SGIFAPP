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
    public partial class frmCerrarCaja : Form
    {
        public frmCerrarCaja()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        String Sql;
        private void frmCerrarCaja_Load(object sender, EventArgs e)
        {
            ValidaCaja();
        }
        public void ValidaCaja()
        {
            using (var con = new SqlConnection(conect))
            {
                String Query;
                con.Open();
                if (UserCache.Nivel == "Admin")
                {
                    Query = "SELECT cacodigo as Codigo, caEstado as Estado from tbcaja where caEstado = 'Abierta'";
                }
            else
                {
                    Query = "SELECT caEstado as Estado from tbcaja where uid = '" + UserCache.UserID + "' and caEstado = 'Abierta'";
                }
                    using (SqlCommand comand = new SqlCommand(Query, con))
                {


                    using (SqlDataReader leer = comand.ExecuteReader())
                    {
                        if (leer.Read() == false)
                        {
                            MessageBox.Show("No existe una caja abierta con este usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                        else
                        {
                            if (UserCache.Nivel == "Admin")
                            {
                                UserCache.CajaID = leer["Codigo"].ToString();
                            }
                            txtUsuario.Text = UserCache.LoginName;
                            txtCaja.Text = UserCache.CajaID;
                            GetCaja();
                            if (txtEfectivo.Text.Length == 0)
                            {
                                txtEfectivo.Text = "0.00";
                            }
                            if (txtTransferencia.Text.Length == 0)
                            {
                                txtTransferencia.Text = "0.00";
                            }
                        }
                    }
                }
                con.Close();
            }
        }
        public void GetCaja()
        {
            try
            {

                using (var con = new SqlConnection(conect))
                {
                    con.Open();
                    var command = con.CreateCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "spGetCaja";
                    command.Parameters.AddWithValue("@cajaid", UserCache.CajaID);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtMontoInicio.Text = reader["Inicio"].ToString();
                            txtEfectivo.Text = reader["Efectivo"].ToString();
                            txtTransferencia.Text = reader["Transferencias"].ToString();
                            txtMontoFinal.Text = reader["Final"].ToString();
                        }
                    }
                        con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CerrarCaja()
        {
            using (var con = new SqlConnection(conect))
            {
                

                con.Open();
                cmd = new SqlCommand(Sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spCerrarCaja";
                cmd.Parameters.Add(new SqlParameter("@importefinal", SqlDbType.Float)).Value = txtMontoFinal.Text;
                cmd.Parameters.Add(new SqlParameter("@efectivo", SqlDbType.Float)).Value = txtEfectivo.Text;
                cmd.Parameters.Add(new SqlParameter("@noefectivo", SqlDbType.Float)).Value = txtTransferencia.Text;
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = DateTime.Now;
                cmd.Parameters.Add(new SqlParameter("@comment", SqlDbType.VarChar)).Value = txtComment.Text;              
                cmd.Parameters.Add(new SqlParameter("@cajaid", SqlDbType.NChar)).Value = UserCache.CajaID;

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Caja cerrada satisfactoriamente.", "Cierre Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logs log = new Logs();
                    log.Accion = "Caja: " + UserCache.CajaID + " Generada por: " + UserCache.Usuario + " Cerrada";
                    log.Form = "Facturacion";
                    log.SaveLog();
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
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult resulta = MessageBox.Show("Esta seguro que desea procesar el cierre de caja?","Cierre de Caja", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (resulta == DialogResult.Yes)
            {
                CerrarCaja();
                this.Close();
            }
        }
    }
}
