using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGPAPP
{
    public partial class frmPrinter : Form
    {
        public frmPrinter()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        bool Exist;

        private void frmPrinter_Load(object sender, EventArgs e)
        {
            GetPrinter();
            lblHost.Text = Environment.MachineName;
        }

        public void GetPrinter()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
  
                using (SqlCommand comand = new SqlCommand("SELECT print_name as printer from tbprinter where print_host = '"+ Environment.MachineName + "'", con))
                {


                    using (SqlDataReader leer = comand.ExecuteReader())
                    {
                        if (leer.Read() == true)
                        {
                            cbbPrinters.Items.Add(leer["printer"].ToString());
                            Exist = true;
                        }
                        else
                        {

                        }

                        foreach (String strPrinter in PrinterSettings.InstalledPrinters)
                        {
                            cbbPrinters.Items.Add(strPrinter);                           
                        }
                        cbbPrinters.SelectedIndex = 1;
                    }
                }
                con.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbbPrinters.Text != "Seleccione la Impresora")
            {
                DialogResult resulta = MessageBox.Show("Seguro quiere guardar esta configuracion?", "Configuracion Impresoras", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                    using (var con = new SqlConnection(conect))
                    {
                        if (Exist == true)
                        {
                            try
                            {
                                string sql = "update tbPrinter set print_name = '" + cbbPrinters.Text + "' where print_host = '" + Environment.MachineName + "'";

                                SqlCommand cmd = new SqlCommand(sql, con);
                                cmd.CommandType = CommandType.Text;
                                con.Open();

                                int i = cmd.ExecuteNonQuery();
                                if (i > 0)
                                    MessageBox.Show("Configuracion Actualizada Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                con.Close();
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                con.Close();
                            }
                        }
                        else
                        {
                            try
                            {
                                string Sql2 = "insert into tbprinter(print_name, print_host) values ('" + cbbPrinters.Text + "', '" + Environment.MachineName + "')";
                                // con = new SqlConnection(cs.ConnectionString);
                                cmd = new SqlCommand(Sql2, con);
                                cmd.CommandType = CommandType.Text;
                                con.Open();

                                int i = cmd.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Configuracion Guardada Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                con.Close();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar una impresora del listado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
