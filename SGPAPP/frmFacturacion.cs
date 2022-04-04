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
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace SGPAPP
{
    public partial class frmFacturacion : Form
    {
        public frmFacturacion()
        {
            InitializeComponent();
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            GridViewCommandColumn commandColumn2 = new GridViewCommandColumn();
            commandColumn2.Name = "CommandColumn2";
            commandColumn2.UseDefaultText = true;
            commandColumn2.Image = Properties.Resources.icons8_delete_35;
            commandColumn2.ImageAlignment = ContentAlignment.MiddleCenter;
            commandColumn2.FieldName = "select";
            commandColumn2.HeaderText = "Eliminar";
            radGridView1.MasterTemplate.Columns.Add(commandColumn2);
            radGridView1.CommandCellClick += new CommandCellClickEventHandler(radGridView1_CommandCellClick);
        }

        private void radGridView1_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (this.radGridView1.Rows.Count > 0)
            {
                DialogResult resulta = MessageBox.Show("Seguro desea eliminar este producto de la facturacion?", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                    radGridView1.Rows.RemoveAt(this.radGridView1.SelectedRows[0].Index);
                    Importes();
                }
            }

            }

        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        DataTable dt = new DataTable();
        String Descripcion;
        String Importe;
        int Cant;
        Double Precio;
        int ClienteID;
        int id;
        String FacturaID;
        SqlCommand cmd = null;
        String Sql;
        private void radScrollablePanel3_Click(object sender, EventArgs e)
        {

        }

        private void radLabel8_Click(object sender, EventArgs e)
        {

        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            GetProductos();
        }

        public void GetProductos()
        {
            if (txtProd.Text.Length > 0)
            {
                frmAddFact add = new frmAddFact();
                add.ProductCod = txtProd.Text;
                add.ShowDialog();

                if (add.DialogResult == DialogResult.OK)
                {
                    bool existe = false;
                    int i = 0;
                    if (radGridView1.RowCount > 0)
                    {
                        for (i = 0; i < radGridView1.RowCount; i++)
                        {
                            if (Convert.ToString(radGridView1.Rows[i].Cells["Codigo"].Value) == add.ProductCod)
                            {
                                existe = true;
                                break;
                            }
                        }

                        if (existe == true)
                        {
                            if (int.Parse(radGridView1.Rows[i].Cells["Cant"].Value.ToString()) + int.Parse(add.txtCant.Text) > int.Parse(add.Stock))
                            {
                                MessageBox.Show("No hay stock suficiente de este articulo.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                Cant = int.Parse(radGridView1.Rows[i].Cells["Cant"].Value.ToString()) + int.Parse(add.txtCant.Text);
                                Precio = Double.Parse(add.Venta);
                                Importe = (Precio * (double)Cant).ToString();
                                radGridView1.Rows[i].Cells["Cant"].Value = Cant;
                                radGridView1.Rows[i].Cells["Importe"].Value = Importe;
                            }
                        }
                        else
                        {
                            Precio = Double.Parse(add.Venta);
                            Cant = int.Parse(add.txtCant.Text);
                            Descripcion = add.Serial + " " + add.Marca + " " + add.Modelo;
                            Importe = (Precio * (double)Cant).ToString();

                            radGridView1.Rows.Add(add.ProductCod, Descripcion, add.txtCant.Text, add.Venta, Importe);
                        }
                    }
                    else
                    {
                        Precio = Double.Parse(add.Venta);
                        Cant = int.Parse(add.txtCant.Text);
                        Descripcion = add.Serial + " " + add.Marca + " " + add.Modelo;
                        Importe = (Precio * (double)Cant).ToString();

                        radGridView1.Rows.Add(add.ProductCod, Descripcion, add.txtCant.Text, add.Venta, Importe);

                    }
                }
                txtProd.Text = "";
            }
            else
            {
                MessageBox.Show("Debe colocar el codigo del producto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Importes();

        }

        public void Importes()
        {

            if (radGridView1.RowCount > 0)
            {
                double val1 = 0;
                double val2 = 0;
                foreach (GridViewRowInfo rowInfo in radGridView1.Rows)
                {
                    val2 = Double.Parse(radGridView1.Rows[rowInfo.Index].Cells[4].Value.ToString());
                    val1 = val1 + val2;
                    lblSubt.Text = String.Format("{0:n}", val1);
                }
                if (txtDesc.Text != "0" && txtDesc.Text.Length > 0 && int.Parse(txtDesc.Text) < 100)
                {
                    double valsubt = Double.Parse(lblSubt.Text);
                    double valdesc = double.Parse(txtDesc.Text) / 100;
                    double descresult = valsubt * valdesc;
                    lblDescuento.Text = String.Format("{0:n}", descresult);
                }
                else
                {
                    lblDescuento.Text = "0.00";
                }
                double valtotal = double.Parse(lblSubt.Text) - double.Parse(lblDescuento.Text);
                lblTotal.Text = String.Format("{0:n}", valtotal);
                lblPendiente.Text = lblTotal.Text;

                ImportesV2();
            }
            else
            {
                lblSubt.Text = "0.00";
                lblDescuento.Text = "0.00";
                lblPendiente.Text = "0.00";
                lblDevuelta.Text = "0.00";
                lblTotal.Text = "0.00";
            }    
        }
        private void radGridView1_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
           
        }

        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            ValidaCaja();
            txtProd.Select();
            cbbMetodo.SelectedIndex = 0;
        }
        public void ValidaCaja()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();              
                using (SqlCommand comand = new SqlCommand("SELECT cacodigo as Codigo from tbcaja where uid = '" + UserCache.UserID + "' and caEstado = 'Abierta'", con))
                {


                    using (SqlDataReader leer = comand.ExecuteReader())
                    {
                        if (leer.Read() == false)
                        {
                           
                            MessageBox.Show("Debe abrir caja con este usuario para poder facturar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                        else
                        {
                            UserCache.CajaID = leer["Codigo"].ToString();
                        }
                    }
                }
                con.Close();
            }
        }
        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
           
            Importes();
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtDesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
          
        }

        private void txtDesc_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtDesc_Click(object sender, EventArgs e)
        {
           txtDesc.SelectAll();
        }

        private void txtDesc_MouseDown(object sender, MouseEventArgs e)
        {
          

        }

        private void txtMonto_Click(object sender, EventArgs e)
        {
            txtMonto.SelectAll();
        }

        public void ImportesV2()
        {
            if (txtMonto.Text != "0" && txtMonto.Text.Length > 0)
            {
                double valtotal = Double.Parse(lblTotal.Text);
                double valmonto = double.Parse(txtMonto.Text);
                double Pendresult = 0;
                if (valtotal < valmonto)
                {
                    Pendresult = valmonto - valtotal;
                    lblDevuelta.Text = String.Format("{0:n}", Pendresult);
                }
                else
                {
                    lblDevuelta.Text = "0.00";
                }
                if (valmonto < valtotal && txtMonto.Text != "0" && txtMonto.Text.Length > 0)
                {
                    Pendresult = valtotal - valmonto;
                    lblPendiente.Text = String.Format("{0:n}", Pendresult);
                }
                else
                {
                    lblPendiente.Text = "0.00";
                }


            }
            else
            {
                lblPendiente.Text = lblTotal.Text;
            }
        }

        private void txtMonto_TextChanged(object sender, EventArgs e)
        {
            ImportesV2();
        }

        private void txtProd_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                GetProductos();
            }

            }

        private void radButton1_Click(object sender, EventArgs e)
        {
            frmConsultaClientes cl = new frmConsultaClientes();
            cl.clfact = true;
            cl.ShowDialog();
            
            if (cl.DialogResult == DialogResult.OK)
            {
                txtCliente.Text = cl.Cliente;
                ClienteID = cl.Clienteid;
            }
        }
        public void GetID()
        {

            using (var con = new SqlConnection(conect))
            {
                con.Open();

                using (SqlCommand comand = new SqlCommand("SELECT COUNT (Distinct factcodigo) as [Id de Factura] from tbFacturado", con))
                {


                    using (SqlDataReader leer = comand.ExecuteReader())
                    {
                        if (leer.Read() == true)
                        {
                            id = Convert.ToInt32(leer["Id de Factura"].ToString());
                            id = id + 1;
                            FacturaID = "FACT00" + id.ToString();
                        }
                    }
                }
                con.Close();
            }

        }
        public void Limpiar()
        {
            radGridView1.Rows.Clear();
            txtProd.Text = "";
            txtCliente.Text = "";
            ClienteID = 0;
            cbbMetodo.SelectedIndex = 0;
            txtComment.Text = "";
            txtMonto.Text = "0";
            txtDesc.Text = "0";
            lblSubt.Text = "0.00";
            lblDescuento.Text = "0.00";
            lblPendiente.Text = "0.00";
            lblDevuelta.Text = "0.00";
            lblTotal.Text = "0.00";
        }
        private void btnSav_Click(object sender, EventArgs e)
        {
            if (radGridView1.RowCount > 0)
            {
                DialogResult resulta = MessageBox.Show("Seguro desea procesar esta factura?", "Facturacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resulta == DialogResult.Yes)
                {
                    if (txtMonto.Text.Length < 1)
                    {
                        MessageBox.Show("Debe colocar el monto a pagar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (cbbMetodo.SelectedIndex == 0)
                    {
                        MessageBox.Show("Debe seleccionar el monto de pago!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (double.Parse(txtMonto.Text) < double.Parse(lblTotal.Text))
                    {
                        MessageBox.Show("El monto a pagar no puede ser menor al monto a facturar!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                    
                    else
                    {
                        try
                        {
                        
                            ValidaCaja();
                            GetID();
                            Facturar();
                            Ventas();
                            MessageBox.Show("Facturacion concluida de manera satisfactoria!", "Facturacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe agregar articulos para poder facturar!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Facturar()
        {
            int Cant = 0;
            

                using (var con = new SqlConnection(conect))
            {

                foreach (GridViewRowInfo rowInfo in radGridView1.Rows)
                {
                    Cant = int.Parse(radGridView1.Rows[rowInfo.Index].Cells[2].Value.ToString()) + Cant;
                }

                con.Open();
                cmd = new SqlCommand(Sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spInsertFacturados";
                cmd.Parameters.Add(new SqlParameter("@factcodigo", SqlDbType.NChar)).Value = FacturaID;
                cmd.Parameters.Add(new SqlParameter("@cant", SqlDbType.Int)).Value = Cant;
                cmd.Parameters.Add(new SqlParameter("@importe", SqlDbType.Float)).Value = lblSubt.Text;
                cmd.Parameters.Add(new SqlParameter("@descuento", SqlDbType.Float)).Value = lblDescuento.Text;
                cmd.Parameters.Add(new SqlParameter("@total", SqlDbType.Float)).Value = lblTotal.Text;
                if (ClienteID <= 0)
                {
                    cmd.Parameters.Add(new SqlParameter("@clid", SqlDbType.Int)).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@clid", SqlDbType.Int)).Value = ClienteID;
                }
                cmd.Parameters.Add(new SqlParameter("@metodo", SqlDbType.VarChar)).Value = cbbMetodo.Text;
                cmd.Parameters.Add(new SqlParameter("@comment", SqlDbType.VarChar)).Value = txtComment.Text;
                cmd.Parameters.Add(new SqlParameter("@uid", SqlDbType.Int)).Value = UserCache.UserID;
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = DateTime.Now;
                cmd.Parameters.Add(new SqlParameter("@caid", SqlDbType.NChar)).Value = UserCache.CajaID;

                try
                {
                    cmd.ExecuteNonQuery();
                    Logs log = new Logs();
                    log.Accion = "Factura #: " + FacturaID + " Generada por: "+UserCache.Usuario+" Caja: "+UserCache.CajaID+"";
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
        public void Ventas()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();
                foreach (GridViewRowInfo rowInfo in radGridView1.Rows) 
                {
                    double valsubt = Double.Parse(radGridView1.Rows[rowInfo.Index].Cells[3].Value.ToString());
                    double valdesc = double.Parse(txtDesc.Text) / 100;
                    double descresult = valsubt * valdesc;
                    descresult = valsubt - descresult;

                    cmd = new SqlCommand(Sql, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spInsertVentas";
                    cmd.Parameters.Add(new SqlParameter("@factcodigo", SqlDbType.NChar)).Value = FacturaID;
                    cmd.Parameters.Add(new SqlParameter("@prcodigo", SqlDbType.NChar)).Value = radGridView1.Rows[rowInfo.Index].Cells[0].Value.ToString();
                    cmd.Parameters.Add(new SqlParameter("@prserial", SqlDbType.NChar)).Value = DBNull.Value;
                    cmd.Parameters.Add(new SqlParameter("@veDescripcion", SqlDbType.VarChar)).Value = radGridView1.Rows[rowInfo.Index].Cells[1].Value.ToString();
                    cmd.Parameters.Add(new SqlParameter("@vecant", SqlDbType.Int)).Value = radGridView1.Rows[rowInfo.Index].Cells[2].Value.ToString();
                    cmd.Parameters.Add(new SqlParameter("@precio", SqlDbType.Float)).Value = descresult;
                    cmd.Parameters.Add(new SqlParameter("@descuento", SqlDbType.Int)).Value = txtDesc.Text;
                    cmd.Parameters.Add(new SqlParameter("@uid", SqlDbType.Int)).Value = UserCache.UserID;
                    cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = DateTime.Now;
                    cmd.Parameters.Add(new SqlParameter("@caid", SqlDbType.NChar)).Value = UserCache.CajaID;

                    try
                    {
                        cmd.ExecuteNonQuery();                        
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                      

                    }
                }
                con.Close();
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
