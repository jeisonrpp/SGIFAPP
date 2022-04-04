using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGPAPP
{
    public partial class frmCaja : Form
    {
        public frmCaja()
        {
            InitializeComponent();
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Aperturar Caja") || UserCache.Nivel == "Admin")
            {
                frmAbrirCaja abrircaja = new frmAbrirCaja();
                abrircaja.ShowDialog();
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

         
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Facturacion") || UserCache.Nivel == "Admin")
            {
                frmFacturacion fact = new frmFacturacion();
                fact.Show();
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (UserCache.RoleList.Any(item => item.RoleName == "Cierre Caja") || UserCache.Nivel == "Admin")
            {
               
           
            //iterate through
            if (Application.OpenForms.OfType<frmFacturacion>().Any())
            {
                    MessageBox.Show("Debe cerrar la facturacion para poder continuar.", "Cerrar Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    frmCerrarCaja cerrar = new frmCerrarCaja();
                    cerrar.ShowDialog();
                }

            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Consultas Facturacion") || UserCache.Nivel == "Admin")
            {
                frmConsultaGenerica cfact = new frmConsultaGenerica();
                cfact.Consulta = "Facturacion";
                cfact.Show();
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Consultas Caja") || UserCache.Nivel == "Admin")
            {
                frmConsultaGenerica cafact = new frmConsultaGenerica();
                cafact.Consulta = "Caja";
                cafact.Show();
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }


           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Consultas Ventas") || UserCache.Nivel == "Admin")
            {
                frmConsultaGenerica cVentas = new frmConsultaGenerica();
                cVentas.Consulta = "Ventas";
                cVentas.Show();
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            
        }

        private void frmCaja_Load(object sender, EventArgs e)
        {

        }
    }
}
