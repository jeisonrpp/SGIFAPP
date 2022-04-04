using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Net.Sockets;
using System.Net;
using System.Globalization;
using System.Security.Cryptography;
using System.Drawing.Printing;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace SGPAPP
{
    public partial class frmRegPac : Form
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);
        int Desc;
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        String Sex;
        String PacienteId;
        String cambiada1;
        String cambiada2;
        DateTime Fecha = DateTime.Now;
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        SqlDataReader rdr = null;
        String expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        String pass;
        string contraseniaAleatoria;
        String Cedula;
        clsMail cm = new clsMail();
        public frmRegPac()
        {
            InitializeComponent();
        }

        private void txtNom_Enter(object sender, EventArgs e)
        {
      
        }

        private void txtNom_Leave(object sender, EventArgs e)
        {
     
        }

        private void txtCed_Enter(object sender, EventArgs e)
        {

        }

        private void txtCed_Leave(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {

        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {

        }

        private void txtEmailC_Enter(object sender, EventArgs e)
        {

        }

        private void txtEmailC_Leave(object sender, EventArgs e)
        {

        }

        private void txtTel_Enter(object sender, EventArgs e)
        {
           
        }

        private void txtTel_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtDir_Enter(object sender, EventArgs e)
        {

        }

        private void txtDir_Leave(object sender, EventArgs e)
        {

        }

        private void txtCel_Enter(object sender, EventArgs e)
        {

        }

        private void txtCel_Leave(object sender, EventArgs e)
        {

        }

        private void cbbSeguro_Enter(object sender, EventArgs e)
        {

        }

        private void cbbSeguro_Leave(object sender, EventArgs e)
        {

        }

        private void txtSeg_Enter(object sender, EventArgs e)
        {

        }

        private void txtSeg_Leave(object sender, EventArgs e)
        {

        }

        private void txtFecha_Enter(object sender, EventArgs e)
        {


        }

        private void txtFecha_Leave(object sender, EventArgs e)
        {

        }

        private void txtNom_MouseClick(object sender, MouseEventArgs e)
        {
            //this.txtNom.Select(0, 0);
        }

        private void txtFecha_MouseClick(object sender, MouseEventArgs e)
        {
            this.txtFecha.Select(0, 0);
        }

        private void txtSeg_MouseClick(object sender, MouseEventArgs e)
        {
            //this.txtCel.Select(0, 0);
            //this.txtCed.Select(0, 0);
            //this.txtDir.Select(0, 0);
            //this.txtEmail.Select(0, 0);
            //this.txtEmailC.Select(0, 0);

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
       
        public void conviertefecha()
        {
            try
            {
                DateTime fecha1;
                if (txtFecha.Text == "No Aplica")
                {
                    cambiada1 = "1900-01-01";
                }
                else
                {
                    fecha1 = DateTime.ParseExact(txtFecha.Text, "dd-MM-yyyy", null);


                    String day = fecha1.Day.ToString();
                    String mes = fecha1.Month.ToString();
                    String year = fecha1.Year.ToString();

                    if(int.Parse(day) <= 9)
                    {
                        day = "0" + day;
                    }
                    if (int.Parse(mes) <= 9)
                    {
                        mes = "0" + mes;
                    }

                    cambiada1 = year + "-" + mes + "-" + day;
                    contraseniaAleatoria = day + mes + year;
                }
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }
        }
        public void Fechadehoy()
        {
            try
            {
                DateTime fecha2;


                fecha2 = Fecha;

                String day = fecha2.Day.ToString();
                String mes = fecha2.Month.ToString();
                String year = fecha2.Year.ToString();

                cambiada2 = year + "-" + mes + "-" + day;

            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);

            }
        }


    
        public void limpiar()
        {
            txtNom.Text = "";
            txtFecha.Text = "";
            txtCed.Text = "";
            txtCel.Text = "";
       
            txtEmail.Text = "";
            txtEmailC.Text = "";
            label6.Visible = false;
            txtDir.Text = "";

            rbF.Checked = false;
            rbM.Checked = false;
            chkFecha.Checked = false;
            chkCed.Checked = false;
            cbbDoc.SelectedIndex = 0;
        }

        public void GuardaClientes()
        {
            string Email = txtEmail.Text;
            //if (txtEmailC.Text.Length > 0)
            //{
            //    String email2 = txtEmailC.Text;
            //    if (Regex.IsMatch(email2, expresion))
            //    {
            //        if (Regex.Replace(email2, expresion, String.Empty).Length == 0)
            //        {
            //            Email = txtEmail.Text + ", " + txtEmailC.Text;
            //        }
            //    }
            //}
            using (var con = new SqlConnection(conect))
            {
                string Sql = "insert into tbClientes(clNom, clCed, clSex, clfecha, clDir, clCel, clEmail, clemail2, clFechareg) values ('" + txtNom.Text + "', '" + txtCed.Text + "', '" + Sex + "', '" + cambiada1 + "','" + txtDir.Text + "', '" + txtCel.Text + "', '" + Email + "', '" + txtEmailC.Text + "','" + cambiada2 + "')";

                cmd = new SqlCommand(Sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.ToString());
                    return;
                }
                finally
                {
                    con.Close();
                    MessageBox.Show("Cliente Guardado Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logs log = new Logs();
                    log.Accion = "Cliente: " + txtNom.Text + " Guardado";
                    log.Form = "Registro de Clientes";
                    log.SaveLog();
                    this.DialogResult = DialogResult.OK;
                }
            }

        }


        private void txtFecha_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cbbSeguro_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }

        private void cbbSeguro_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void rbF_CheckedChanged(object sender, EventArgs e)
        {
            if (rbF.Checked == true)
            {
                rbM.Checked = false;
                Sex = "Femenino";
            }
        }

        private void rbM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbM.Checked == true)
            {
                rbF.Checked = false;
                Sex = "Masculino";
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);
        }

        private void txtEmailC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsWhiteSpace(e.KeyChar);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

           

        }
       
     

        private void txtEmailC_TextChanged(object sender, EventArgs e)
        {
            //if (txtEmailC.Text != txtEmail.Text)
            //{
            //    label6.Visible = true;
            //    label6.Text = "El email ingresado no coincide.";
            //    btnSave.Enabled = false;
            //}
            //else
            //{
            //    label6.Visible = false;
            //    btnSave.Enabled = true;
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
           
        }

        private void frmRegPac_Load(object sender, EventArgs e)
        {
            rbF.Select();
            cbbDoc.SelectedIndex = 0;
            Fechadehoy();
   
        }

        private void rbF_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                rbM.Focus();
            }
        }

        private void rbM_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtNom.Focus();
            }
        }

        private void txtNom_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtFecha.Focus();
            }
        }

        private void txtCed_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtEmail.Focus();
            }
        }

        private void txtFecha_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                cbbDoc.Focus();
            }
        }

        private void txtEmail_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtEmailC.Focus();
            }
        }

        private void txtEmailC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtCel.Focus();
            }
        }

        private void txtCel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtDir.Focus();
            }
        }

        private void txtDir_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                //cbbSeguro.Focus();
            }
        }

        private void cbbSeguro_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                btnGuardar.Focus();
            }
        }

        private void txtSeg_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                btnGuardar.Focus();
            }
        }

        private void btnSave_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                btnCancelar.Focus();
            }
        }

        private void btnCancel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                btnCerrar.Focus();
            }
        }

        private void chkCed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCed.Checked == true)
            {
                txtCed.Mask = "";
                txtCed.Text = "No Aplica";
                txtCed.Enabled = false;
            }
            else
            {
                txtCed.Text = "";
                txtCed.Enabled = true;
            }
        }

        private void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFecha.Checked == true)
            {
                txtFecha.Mask = "";
                txtFecha.Text = "No Aplica";
                txtFecha.Enabled = false;
            }
            else
            {
                txtFecha.Mask = "00-00-0000";
                txtFecha.Text = "";
                txtFecha.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void cbbDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDoc.Text == "Cedula")
            {
                txtCed.Mask = "000-0000000-0";
            }
            else
            {
                txtCed.Mask = "";
            }
        }

        private void cbbDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
             e.Handled = true;
        }

        private void cbbDoc_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
                txtCed.Focus();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (InternetGetConnectedState(out Desc, 0).ToString() == "True")
            {
                try
                {
                    
                    if (txtNom.Text == "" || txtCed.Text == "" )
                    {
                        MessageBox.Show("Debe completar los campos faltantes");
                    }
                    else
                    {
                        String email = txtEmail.Text;
                        String email2 = txtEmailC.Text;


                        if (txtEmail.Text.Length > 0)
                        {
                            if (Regex.IsMatch(email, expresion))
                            {

                                if (txtEmailC.Text.Length > 0)
                                {
                                    if (Regex.IsMatch(email2, expresion))
                                    {

                                    }
                                    else
                                    {
                                        MessageBox.Show("El email opcional ingresado no es valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        txtEmailC.Focus();
                                        return;
                                    }


                                }
                            }
                            else
                            {
                                MessageBox.Show("El email ingresado no es valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtEmail.Focus();
                                return;
                            }
                        }
                        using (var con = new SqlConnection(conect))
                            {
                                con.Open();
                                string ct = "select clced, clnom from tbclientes where clced = '" + txtCed.Text + "'";

                                cmd = new SqlCommand(ct);
                                cmd.Connection = con;
                                rdr = cmd.ExecuteReader();

                                if (rdr.Read() && txtCed.Text != "No Aplica")
                                {
                                    MessageBox.Show("Este Cliente ya se encuentra esta registrado", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //con.Close();
                                    return;
                                }

                                else if ((rdr != null))
                                {
                                    con.Close();
                                    conviertefecha();
                                    GuardaClientes();
                                }

                                limpiar();
                            }
                        
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Error de conexión, favor verifique su conexión de internet", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();

        }

        private void radButton2_Click(object sender, EventArgs e)
        {
          
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            conviertefecha();
        }
    }
}
