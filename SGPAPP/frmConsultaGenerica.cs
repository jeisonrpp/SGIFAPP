using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.Export;
using Telerik.WinControls.UI;

namespace SGPAPP
{
    public partial class frmConsultaGenerica : Form
    {
        public frmConsultaGenerica()
        {
            InitializeComponent();
            GridViewCommandColumn commandColumn2 = new GridViewCommandColumn();
            commandColumn2.Name = "CommandColumn2";
            commandColumn2.UseDefaultText = true;
            commandColumn2.Image = Properties.Resources.icons8_search_16;
            commandColumn2.ImageAlignment = ContentAlignment.MiddleCenter;
            commandColumn2.FieldName = "select";
            commandColumn2.HeaderText = "Seleccionar";
            radGridView1.MasterTemplate.Columns.Add(commandColumn2);
            radGridView1.CommandCellClick += new CommandCellClickEventHandler(radGridView1_CommandCellClick);
        }

        private void radGridView1_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            GridViewRowInfo row = radGridView1.CurrentRow;
            if (Consulta == "Facturacion")
            {
                if (e.Row.Cells[11].Value.ToString() != "Anulado")
                {
                    frmMensaje msg = new frmMensaje();
                    msg.ShowDialog();

                    if (msg.DialogResult == DialogResult.OK)
                    {
                        //clsPrinterSet printerset = new clsPrinterSet();
                        print.GetPrinter();
                        String Printer = clsPrinterSet.Printer;
                        print.FactCod = e.Row.Cells[0].Value.ToString();
                        printDocument1 = new PrintDocument();
                        PrinterSettings ps = new PrinterSettings();
                        printDocument1.PrinterSettings = ps;
                        printDocument1.PrintPage += print.Imprimir;
                        //ps.PrinterName = "Nitro PDF Creator";
                        ps.PrinterName = Printer;
                        printDocument1.Print();


                        string GS = Convert.ToString((char)29);
                        string ESC = Convert.ToString((char)27);

                        string COMMAND = "";
                        COMMAND = ESC + "@";
                        COMMAND += GS + "V" + (char)1;
                        //RawPrinterHelper.SendStringToPrinter(ps.PrinterName = Printer, COMMAND);

                        // GetDataFact();
                    }
                    if (msg.DialogResult == DialogResult.Yes)
                    {
                        //clsPrinterSet printerset = new clsPrinterSet();
                        print.GetPrinter();
                        String Printer = clsPrinterSet.Printer;
                        print.FactCod = e.Row.Cells[0].Value.ToString();
                        printDocument1 = new PrintDocument();
                        PrinterSettings ps = new PrinterSettings();
                        printDocument1.PrinterSettings = ps;
                        printDocument1.PrintPage += print.Imprimir;
                        ps.PrinterName = "Microsoft Print to PDF";
                        string file = print.FactCod;
                        string directory = "C:\\SGP\\";
                        ps.PrintToFile = true;
                        ps.PrintFileName = Path.Combine(directory, file + ".pdf");
                        printDocument1.Print();
                        Thread.Sleep(2000);
                        Process prc = new Process();
                        prc.StartInfo.FileName = Path.Combine(directory, file + ".pdf");
                        prc.Start();
                    }
                  
                }
                else
                {
                    MessageBox.Show("Esta factura ha sido anulada, no puede ser reimpresa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (Consulta == "Caja")
            {
                
                frmConsultaGenerica congen = new frmConsultaGenerica();
                congen.Consulta = "Facturacion";
                congen.Parametro = e.Row.Cells[0].Value.ToString();
                txtConsulta.Enabled = false;
                congen.ShowDialog();
            }
           
        }

     

        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        public String Consulta;
        public String Parametro="";
        clsPrintFact print = new clsPrintFact();
        private void frmConsultaGenerica_Load(object sender, EventArgs e)
        {
            Consulta = "Facturacion";
            if (Consulta == "Facturacion")
            {
                btnAnular.Visible = true;
                this.Text = "Consulta Facturacion";
                GetDataFact();
            }
            if (Consulta == "Caja")
            {
                this.Text = "Consulta Caja";
                GetDataCaja();
            }
            if(Consulta=="Ventas")
            {
                this.Text = "Consulta Ventas";
                GetDataVentas();
            }
        }
        public void GetDataFact()
        {
            try
            {
                
                using (var con = new SqlConnection(conect))
                {
                    SqlDataAdapter da = new SqlDataAdapter("spgetFacturas", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    if (txtConsulta.Text != "Buscar")
                    {
                        da.SelectCommand.Parameters.AddWithValue("@Parametro", txtConsulta.Text);
                    }
                    else if (Parametro != "")
                    {
                        da.SelectCommand.Parameters.AddWithValue("@Parametro", Parametro);
                    }
                    else
                    {
                        da.SelectCommand.Parameters.AddWithValue("@Parametro", (object)DBNull.Value);
                    } 
                    da.Fill(dt);
                    this.radGridView1.DataSource = dt;
                    this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    foreach (GridViewColumn col in radGridView1.MasterTemplate.Columns)
                    {
                        col.TextAlignment = ContentAlignment.MiddleCenter;
                    }
                    if (radGridView1.Columns[0].Name == "CommandColumn2")
                    {
                        radGridView1.Columns.Move(0, 12);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetDataCaja()
        {
            try
            {
               
                using (var con = new SqlConnection(conect))
                {
                    SqlDataAdapter da = new SqlDataAdapter("spGetCajaValores", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    if (txtConsulta.Text != "Buscar")
                    {
                        da.SelectCommand.Parameters.AddWithValue("@Parametro", txtConsulta.Text);
                    }
                    else
                    {
                        da.SelectCommand.Parameters.AddWithValue("@Parametro", (object)DBNull.Value);
                    }
                    da.Fill(dt);
                    this.radGridView1.DataSource = dt;
                    this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    foreach (GridViewColumn col in radGridView1.MasterTemplate.Columns)
                    {
                        col.TextAlignment = ContentAlignment.MiddleCenter;
                    }
                    if (radGridView1.Columns[0].Name == "CommandColumn2")
                    {
                        radGridView1.Columns.Move(0, 10);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetDataVentas()
        {
            try
            {
               
                using (var con = new SqlConnection(conect))
                {
                    SqlDataAdapter da = new SqlDataAdapter("spGetVentas", con);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    if (txtConsulta.Text != "Buscar")
                    {
                        da.SelectCommand.Parameters.AddWithValue("@Parametro", txtConsulta.Text);
                    }
                    else
                    {
                        da.SelectCommand.Parameters.AddWithValue("@Parametro", (object)DBNull.Value);
                    }
                    da.Fill(dt);
                    this.radGridView1.DataSource = dt;
                    this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
                    foreach (GridViewColumn col in radGridView1.MasterTemplate.Columns)
                    {
                        col.TextAlignment = ContentAlignment.MiddleCenter;
                    }
                    radGridView1.Columns[0].IsVisible = false;
                    
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtConsulta_Leave(object sender, EventArgs e)
        {
            if (txtConsulta.Text == "")
            {
                txtConsulta.Text = "Buscar";
                txtConsulta.ForeColor = Color.Silver;
                if (Consulta == "Facturacion")
                {                   
                    GetDataFact();
                }
                if (Consulta == "Caja")
                {
                    GetDataCaja();
                }
                if (Consulta == "Ventas")
                {
                    GetDataVentas();
                }
            }
        }

        private void txtConsulta_Enter(object sender, EventArgs e)
        {
            if (txtConsulta.Text == "Buscar")
            {
                txtConsulta.Text = "";
                txtConsulta.ForeColor = Color.MidnightBlue;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            String FileExp = "C:\\SGP\\exportedFile" + DateTime.Now.ToString("yyyy-mm-dd") + ".xlsx";
            GridViewSpreadExport spreadExporter = new GridViewSpreadExport(this.radGridView1);
            SpreadExportRenderer exportRenderer = new SpreadExportRenderer();
            spreadExporter.RunExport(FileExp, exportRenderer);
            Process prc = new Process();
            prc.StartInfo.FileName = FileExp;
            prc.Start();
        }

        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConsulta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                if (txtConsulta.Text != "" || txtConsulta.Text != "Buscar")
                {                    
                    if (Consulta == "Facturacion")
                    {
                        GetDataFact();
                    }
                    if (Consulta == "Caja")
                    {
                        GetDataCaja();
                    }
                    if (Consulta == "Ventas")
                    {
                        GetDataVentas();
                    }
                }
            }

            }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            int rowIndex = radGridView1.CurrentCell.RowIndex;
            DialogResult resulta = MessageBox.Show("Seguro que desea Anular la factura: "+ this.radGridView1.Rows[rowIndex].Cells["Codigo Factura"].Value + "?", "Anular Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resulta == DialogResult.Yes)
            {
                using (var con = new SqlConnection(conect))
                {
                    try
                    {
                        string sql = "update tbfacturado set factstatus = 'Anulado' where factcodigo = '" + this.radGridView1.Rows[rowIndex].Cells["Codigo Factura"].Value + "'";

                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.CommandType = CommandType.Text;
                        con.Open();

                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                            MessageBox.Show("Factura anulada correctamente", "Anular Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        con.Close();
                    }
                }
            }
            // = e.Row.Cells[0].Value.ToString();
        }
    }
}
