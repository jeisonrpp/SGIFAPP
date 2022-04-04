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
using System.IO;
using System.Configuration;
using System.Drawing.Printing;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using SGPAPP.Properties;
using Telerik.WinControls.Export;
using System.Diagnostics;

namespace SGPAPP
{
    public partial class frmConsultas : Form
    {
        public frmConsultas()
        {
            InitializeComponent();
            GridViewCommandColumn commandColumn2 = new GridViewCommandColumn();           
            commandColumn2.Name = "CommandColumn2";
            commandColumn2.UseDefaultText = true;
            commandColumn2.Image = Properties.Resources.icons8_search_16;
            commandColumn2.ImageAlignment = ContentAlignment.MiddleCenter;
            commandColumn2.FieldName = "select";
            commandColumn2.HeaderText = "Modificar";
            radGridView1.MasterTemplate.Columns.Add(commandColumn2);
            radGridView1.CommandCellClick += new CommandCellClickEventHandler(radGridView1_CommandCellClick);
        }
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;

        String Documentid;
        String Paciente;
        String contraseniaAleatoria;
        String ProductoCodigo;
        public void GetValores()
        {
            using (var con = new SqlConnection(conect))
            {
                try
                {
                    string sql = "select 'RD'+ FORMAT (sum(prpreciocompra* prstock), 'c', 'es-DO') as Inversion, 'RD'+ FORMAT (sum(prprecioventa* prstock), 'c', 'es-DO') as Ganancia from tbProductos ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader reader;
                    cmd.CommandType = CommandType.Text;
                    con.Open();


                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtInversion.Text = reader[0].ToString();
                        txtGanancia.Text = reader[1].ToString();                  
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
        public void GetData()
        {
            try
            {
               
                using (var con = new SqlConnection(conect))
                {
                    SqlDataAdapter da = new SqlDataAdapter("spGetProductos", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddWithValue("@Parametro", (object)DBNull.Value);
                    da.Fill(dt);
                    this.radGridView1.DataSource = dt;
                    this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    foreach (GridViewColumn col in radGridView1.MasterTemplate.Columns)
                    {
                        col.TextAlignment = ContentAlignment.MiddleCenter; 
                    }
                        if (radGridView1.Columns[0].Name == "CommandColumn2")
                    {
                        radGridView1.Columns.Move(0, 9);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmConsultas_Load(object sender, EventArgs e)
        {            

        
            this.radGridView1.TableElement.BeginUpdate();

            this.radGridView1.TableElement.EnableHotTracking = false;
            this.radGridView1.TableElement.RowHeight = 30;

            GetData();
            this.SetConditions();
            this.radGridView1.EnableHotTracking = true;

            this.radGridView1.TableElement.EndUpdate(true);
            if (UserCache.RoleList.Any(item => item.RoleName == "Consulta Valores") || UserCache.Nivel == "Admin")
            {
                PanelValores.Visible = true;
                GetValores();
            }
            


            
        }
       
        public void SetConditions()
        {
            ExpressionFormattingObject c1 = new ExpressionFormattingObject("Rojo, Stock Bajo", "Stock < 5", false);
            c1.RowBackColor = Color.FromArgb(255, 0, 0);
            c1.CellBackColor = Color.FromArgb(255, 0, 0);
            c1.RowForeColor = Color.Black;
            c1.CellForeColor = Color.Black;
            radGridView1.Columns["Stock"].ConditionalFormattingObjectList.Add(c1);


            ExpressionFormattingObject c2 = new ExpressionFormattingObject("Verde, Stock Normal", "Stock >= 5",  false);
            c2.RowBackColor = Color.FromArgb(59, 213, 12);
            c2.CellBackColor = Color.FromArgb(59, 213, 12);
            c2.RowForeColor = Color.Black;
            c2.CellForeColor = Color.Black;
            radGridView1.Columns["Stock"].ConditionalFormattingObjectList.Add(c2);

        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnExporta_Click(object sender, EventArgs e)
        {
           


        }

        private void ExportaExcl(RadGridView dgb)
        {
            //try
            //{
            //    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application(); // Instancia a la libreria de Microsoft Office
            //    excel.Application.Workbooks.Add(true); //Con esto añadimos una hoja en el Excel para exportar los archivos
            //    int IndiceColumna = 0;
            //    foreach (DataGridViewColumn columna in dgb.Columns) //Aquí empezamos a leer las columnas del listado a exportar
            //    {
            //        IndiceColumna++;
            //        excel.Cells[1, IndiceColumna] = columna.Name;
            //    }
            //    int IndiceFila = 0;
            //    foreach (DataGridViewRow fila in dgb.Rows) //Aquí leemos las filas de las columnas leídas
            //    {
            //        IndiceFila++;
            //        IndiceColumna = 0;
            //        foreach (DataGridViewColumn columna in dgb.Columns)
            //        {
            //            IndiceColumna++;
            //            excel.Cells[IndiceFila + 1, IndiceColumna] = fila.Cells[columna.Name].Value;
            //        }
            //    }
            //    excel.Visible = true;
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("No hay Registros a Exportar.");
            //}
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void advancedDataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
          
        }

        private void advancedDataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
         
        }

        private void dataGridView1_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {

        }

        private void dataGridView1_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
           
        }

        private void txtConsulta_Leave(object sender, EventArgs e)
        {
            if (txtConsulta.Text == "")
            {
                txtConsulta.Text = "Buscar Productos";
                txtConsulta.ForeColor = Color.Silver;
                GetData();
            }
        }

        private void txtConsulta_Enter(object sender, EventArgs e)
        {
            if (txtConsulta.Text == "Buscar Productos")
            {
                txtConsulta.Text = "";
                txtConsulta.ForeColor = Color.MidnightBlue;
            }
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
           
        }
        bool Cred= false;
      
            private void button1_Click(object sender, EventArgs e)
        {
           
        }
        public void Imprimir(object sender, PrintPageEventArgs e)
        {
            String imagen = Environment.CurrentDirectory + @"\\resourses\logocge.png";
            System.Drawing.Image img = System.Drawing.Image.FromFile(imagen);
            e.Graphics.DrawImage(img, new System.Drawing.Rectangle(20, 20, 206, 103));
            System.Drawing.Font font = new System.Drawing.Font("Calibri", 12, FontStyle.Bold, GraphicsUnit.Point);
            e.Graphics.DrawString("CREDENCIALES CONSULTA", font, Brushes.Black, new RectangleF(40, 130, 200, 80));
            e.Graphics.DrawString("RESULTADOS", font, Brushes.Black, new RectangleF(85, 150, 200, 80));
            System.Drawing.Font font1 = new System.Drawing.Font("Calibri", 12, FontStyle.Regular, GraphicsUnit.Point);
            System.Drawing.Font font2 = new System.Drawing.Font("Calibri", 12, FontStyle.Bold, GraphicsUnit.Point);
            e.Graphics.DrawString("Paciente: " +Paciente, font1, Brushes.Black, new RectangleF(30, 190, 300, 80));
            e.Graphics.DrawString("Usuario: " + Documentid, font2, Brushes.Black, new RectangleF(40, 250, 200, 80));
            e.Graphics.DrawString("Contraseña: " + contraseniaAleatoria, font2, Brushes.Black, new RectangleF(40, 280, 200, 80));
            e.Graphics.DrawString("www.cgelaboratorio.com", font1, Brushes.Black, new RectangleF(40, 350, 200, 80));

        }
       

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {

                if (txtConsulta.Text.Length == 0)
                {
                    GetData();
                }
                else
                {
                    try
                    {
                        using (var con = new SqlConnection(conect))
                        {
                            SqlDataAdapter da = new SqlDataAdapter("spgetProductos", con);
                            DataTable dt = new DataTable();
                            da.SelectCommand.CommandType = CommandType.StoredProcedure;
                            da.SelectCommand.Parameters.AddWithValue("@Parametro", txtConsulta.Text);
                            da.Fill(dt);
                            this.radGridView1.DataSource = dt;
                            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                            //radGridView1.Columns.Move(0, 9);

                            con.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }
     

        private void radGridView1_CreateCell(object sender, GridViewCreateCellEventArgs e)
        {
            
        }

        private void radGridView1_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {

        }

        private void radGridView1_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            //var senderGrid = (RadGridView)sender;

            //if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            //{
               
            //        PacienteID = (int)this.dgb1.Rows[e.RowIndex].Cells["ID"].Value;

            //        frmPacEdit ed = new frmPacEdit();
            //        ed.PacID = PacienteID.ToString();
            //        ed.ShowDialog();
            //        if (ed.DialogResult == DialogResult.OK)
            //        {
            //            GetData();
            //        }
            //    }
            
            //MessageBox.Show("VainaBien");
        }
        void btnImagenclick_Click(object sender, EventArgs e)
        {
           
        }



        private void radGridView1_CellPaint(object sender, GridViewCellPaintEventArgs e)
        {
            
        }

        private void radGridView1_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            if (e.RowElement.IsSelected)
            {
                e.RowElement.GradientStyle = GradientStyles.Solid;
                e.RowElement.BackColor = System.Drawing.Color.LightBlue;
                e.RowElement.DrawFill = true;

            }
            else
            {
                e.RowElement.ResetValue(LightVisualElement.DrawFillProperty, ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.BackColorProperty, ValueResetFlags.Local);
                e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty, ValueResetFlags.Local);
            }
        }

        private void radGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void radGridView1_CellClick(object sender, GridViewCellEventArgs e)
        {
            object cellValue = e.Row.Cells[0].Value;

        }

        private void radGridView1_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
           
            //if (e.Column.Name == "CommandColumn2")
            //{
            //    e.CellElement.DrawFill = true;
            //    e.CellElement.NumberOfColors = 1;
            //    e.CellElement.BackColor = System.Drawing.Color.Red;
            //GridImageCellElement imgCell = e.CellElement as GridImageCellElement;

            //if (imgCell != null)
            //{
            //    imgCell.Image = Properties.Resources.icons8_search_16;

            //    try
            //    {
            //        imgCell.Click -= btnImagenclick_Click;
            //    }
            //    catch
            //    {

            //    }

            //    imgCell.Click += btnImagenclick_Click;
            //}
        //}
        }
        void radGridView1_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Modificar Productos") || UserCache.Nivel == "Admin")
            {
               
            GridViewRowInfo row = radGridView1.CurrentRow;
            ProductoCodigo = e.Row.Cells[0].Value.ToString();
            frmProductos ed = new frmProductos();
            ed.ProductCod = ProductoCodigo.ToString();
            ed.ShowDialog();
            if (ed.DialogResult == DialogResult.OK)
            {
                GetData();
                    GetValores();
            }

            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void radGridView1_CurrentCellChanged(object sender, CurrentCellChangedEventArgs e)
        {

        }

        private void btnPass_Click(object sender, EventArgs e)
        {
           

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void radButton1_Click_1(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Exportar a Excel Inventario") || UserCache.Nivel == "Admin")
            {
                String FileExp = "C:\\SGP\\exportedFile" + DateTime.Now.ToString("yyyy-mm-dd") + ".xlsx";
                GridViewSpreadExport spreadExporter = new GridViewSpreadExport(this.radGridView1);
                SpreadExportRenderer exportRenderer = new SpreadExportRenderer();
                spreadExporter.RunExport(FileExp, exportRenderer);
                Process prc = new Process();
                prc.StartInfo.FileName = FileExp;
                prc.Start();
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }


           
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            if (UserCache.RoleList.Any(item => item.RoleName == "Agregar Productos") || UserCache.Nivel == "Admin")
            {
                frmProductos frm = new frmProductos();
                frm.ShowDialog();
            }
            else { MessageBox.Show("No cuenta con privilegios para realizar esta accion.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error); }

           
        }
    }
}
