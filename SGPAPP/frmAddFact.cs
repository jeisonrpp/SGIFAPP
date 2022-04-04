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
    public partial class frmAddFact : Form
    {

        public frmAddFact()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        public String ProductCod;
        public String Serial;
        public String Marca;
        public String Modelo;
        public String Venta;
        public String Stock;

        private void frmAddFact_Load(object sender, EventArgs e)
        {
            GetProduct();
            txtCant.Select();
        }

        private void txtCant_LostFocus(object sender, EventArgs e)
        {
            txtCant.Select();
        }
        public void GetProduct()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    string sql = "Select RTRIM(prcodigo),RTRIM(prserial),RTRIM(prmarca),RTRIM(prmodelo),RTRIM(prprecioventa),RTRIM(prstock) from tbproductos where prcodigo = '" + ProductCod + "'  ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader;
                    cmd.CommandType = CommandType.Text;
                    con.Open();


                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        ProductCod = reader[0].ToString();
                        Serial = reader[1].ToString();
                        Marca = reader[2].ToString();
                        Modelo = reader[3].ToString();
                        Venta = reader[4].ToString();
                        Stock = reader[5].ToString();

                        txtArticulo.Text = ProductCod + " - " + Marca + "-" + Modelo;
                        txtPrecio.Text = Venta;
                        txtStock.Text = Stock;
                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado este producto!");
                    }
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (int.Parse(Stock) >= int.Parse(txtCant.Text) && int.Parse(Stock) > 0)
            {
                if(int.Parse(txtCant.Text) > 0)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Debe indicar una cantidad valida.", "Cantidad Invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay stock suficiente de este articulo.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCant_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                if (int.Parse(Stock) >= int.Parse(txtCant.Text) && int.Parse(Stock) > 0)
                {
                    if (int.Parse(txtCant.Text) > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Debe indicar una cantidad valida.", "Cantidad Invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No hay stock suficiente de este articulo.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            }
    }
}
