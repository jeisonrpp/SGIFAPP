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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        DateTime Fecha = DateTime.Now;
        String cambiada2;
        public String ProductCod = null;
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCod.Text == "" || txtDesc.Text == "" || cbbMarca.Text == "" || cbbCategoria.Text == "" || txtStock.Text == "")
            {
                MessageBox.Show("Debe completar los campos faltantes");
            }
            else
            {
                if (ProductCod != null)
                {
                    using (var con = new SqlConnection(conect))
                    {
                        try
                        {
                            string sql = "update tbproductos set [prserial] ='" + txtSerial.Text + "' ,[prcategoria] = '" + cbbCategoria.Text + "',[prproveedor] ='" + cbbProveedor.Text + "',[prdesc] ='" + txtDesc.Text + "',[prmarca] = '" + cbbMarca.Text + "',[prmodelo] = '" + cbbModelo.Text + "',[prpreciocompra] ='" + txtCompra.Text + "',[prprecioventa] = '" + txtVenta.Text + "' ,[prstock] ='" + txtStock.Text + "',[prcomentario] = '" + txtComment.Text + "' where prcodigo = '"+txtCod.Text+"' ";

                            SqlCommand cmd = new SqlCommand(sql, con);
                            cmd.CommandType = CommandType.Text;
                            con.Open();

                            int i = cmd.ExecuteNonQuery();
                            //if (i > 0)
                            // SaveLog();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            con.Close();
                        }

                        finally
                        {
                            con.Close();
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }
                else
                {
                    using (var con = new SqlConnection(conect))
                    {
                        con.Open();
                        string ct = "select prcodigo from tbProductos where prcodigo = '" + txtCod.Text + "'";

                        cmd = new SqlCommand(ct);
                        cmd.Connection = con;
                        rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                            MessageBox.Show("Este Producto ya se encuentra esta registrado", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //con.Close();
                            return;
                        }

                        else if ((rdr != null))
                        {
                            con.Close();
                            Fechadehoy();
                            GuardaProductos();
          
                        }
                    }
                }
            }
        }

        public void GuardarMarca()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                string ct = "select mmarcas from tbmarcas where mmarcas = '" + cbbMarca.Text + "'";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                
                if ((rdr.Read() == false))
                {
                    con.Close();
                    string Sql2 = "insert into tbmarcas(mmarcas) values ('" + cbbMarca.Text + "')";
                    cmd = new SqlCommand(Sql2, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    
                }
            }
        }
        public void GuardarModelo()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                string ct = "select momodelo from tbmodelos where mmarcas = '" + cbbMarca.Text + "' and momodelo ='"+cbbModelo.Text+"' ";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
              
                if ((rdr.Read() == false))
                {
                    con.Close();
                    string Sql2 = "insert into tbmodelos(mmarcas, momodelo) values ('" + cbbMarca.Text + "', '" + cbbModelo.Text + "')";
                    cmd = new SqlCommand(Sql2, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    int i = cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
        }
        public void GuardarCategorias()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                string ct = "select catcategoria from tbCategorias where catcategoria = '" + cbbCategoria.Text + "' ";

                cmd = new SqlCommand(ct);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
              
                if ((rdr.Read() == false))
                {
                    con.Close();
                    string Sql2 = "insert into tbcategorias(catcategoria) values ('" + cbbCategoria.Text + "')";
                    cmd = new SqlCommand(Sql2, con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();

                    int i = cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
        }
        public void cargacbbmarcas()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter("Select (mmarcas) as Marcas from tbMarcas order by mmarcas", con);

                da.Fill(ds, "Marcas");
                cbbMarca.DataSource = ds.Tables[0].DefaultView;
                cbbMarca.ValueMember = "Marcas";
                cbbMarca.Text = "Seleccione la Marca";


                con.Close();
            }
        }
        public void cargacbbModelos()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter("Select (momodelo) as Modelos from tbModelos where mmarcas = '"+cbbMarca.Text+"' order by momodelo", con);

                da.Fill(ds, "Modelos");
                cbbModelo.DataSource = ds.Tables[0].DefaultView;
                cbbModelo.ValueMember = "Modelos";
                cbbModelo.Text = "Seleccione el Modelo";


                con.Close();
            }
        }
        public void cargacbbCategorias()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter("Select (catCategoria) as Categoria from tbCategorias order by catcategoria", con);

                da.Fill(ds, "Categoria");
                cbbCategoria.DataSource = ds.Tables[0].DefaultView;
                cbbCategoria.ValueMember = "Categoria";
                cbbCategoria.Text = "Seleccione la Categoria";


                con.Close();
            }
        }
        public void cargacbbProveedores()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter("Select (provNombre) as Proveedor from tbProveedores order by provnombre", con);

                da.Fill(ds, "Proveedor");
                cbbProveedor.DataSource = ds.Tables[0].DefaultView;
                cbbProveedor.ValueMember = "Proveedor";
                cbbProveedor.Text = "Seleccione el Proveedor";


                con.Close();
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
            public void GuardaProductos()
            {
               
                using (var con = new SqlConnection(conect))
                {
                    string Sql = "insert into tbproductos([prcodigo],[prserial],[prcategoria],[prproveedor],[prdesc],[prmarca],[prmodelo],[prpreciocompra],[prprecioventa],[prstock],[prcomentario], [prfechareg]) values ('" + txtCod.Text + "', '" + txtSerial.Text + "', '" + cbbCategoria.Text + "', '" + cbbProveedor.Text + "','" + txtDesc.Text + "', '" + cbbMarca.Text + "', '" + cbbModelo.Text + "', '" + txtCompra.Text + "', '" + txtVenta.Text + "',  '" + txtStock.Text + "','" + txtComment.Text + "',  '" + cambiada2 + "')";

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
                    GuardarCategorias();
                    GuardarMarca();
                    GuardarModelo();
                    MessageBox.Show("Producto Guardado Correctamente", "Guardado Satisfactorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Logs log = new Logs();
                        log.Accion = "Producto: " + txtCod.Text + " Guardado";
                        log.Form = "Registro de Productos";
                        log.SaveLog();
                        this.Close();


                    }
                }

            }
        public void getProduct()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    string sql = "Select RTRIM(prcodigo),RTRIM(prserial),RTRIM(prcategoria),RTRIM(prproveedor),RTRIM(prdesc),RTRIM(prmarca),RTRIM(prmodelo),RTRIM(prpreciocompra),RTRIM(prprecioventa),RTRIM(prstock),RTRIM(prcomentario) from tbproductos where prcodigo = '" + ProductCod + "'  ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader;
                    cmd.CommandType = CommandType.Text;
                    con.Open();


                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtCod.Text = reader[0].ToString();
                        txtSerial.Text = reader[1].ToString();
                        cbbCategoria.Text = reader[2].ToString();
                        cbbProveedor.Text = reader[3].ToString();
                        txtDesc.Text = reader[4].ToString();
                        cbbMarca.Text = reader[5].ToString();
                        cbbModelo.Text = reader[6].ToString();
                        txtCompra.Text = reader[7].ToString();
                        txtVenta.Text = reader[8].ToString();
                        txtStock.Text = reader[9].ToString();
                        txtComment.Text = reader[10].ToString();                      

                    }
                    else
                    {
                        MessageBox.Show("No se ha encontrado registro!");
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

        private void frmProductos_Load(object sender, EventArgs e)
        {
            if (ProductCod != null)
            {
                cargacbbmarcas();
               
                cargacbbCategorias();
                cargacbbProveedores();
                getProduct();
               // txtCod.Enabled = false;
            }
            else
            {
                cargacbbmarcas();
                //cargacbbModelos();
                cargacbbCategorias();
                cargacbbProveedores();
            }
        }

        private void cbbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargacbbModelos();
            cbbModelo.Enabled = true;
        }
    }
}
