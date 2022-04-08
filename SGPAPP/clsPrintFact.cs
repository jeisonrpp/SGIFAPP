using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPAPP
{
    public class clsPrintFact
    {
        public String FactCod;
        public static List<clsFactura> Factura = new List<clsFactura>();
        
        public static List<clsVentas> Ventas = new List<clsVentas>();
        static string conect = ConfigurationManager.ConnectionStrings["Connection"].ToString();
        SqlCommand cmd = null;
        SqlDataReader rdr = null;
        String Sql;

        int Cantf;
        String Importef;
        String MontoDescuentof;
        String Totalf;
        String Clientef;
        String Metodof;
        String Fechaf;

         String ProductoCodf;
         String Descripcionf;
        String Cantidadf;
        String PrecioVentaf;
        String Descuentosf;
        public void GetPrinter()
        {
            using (var con = new SqlConnection(conect))
            {
                con.Open();

                using (SqlCommand comand = new SqlCommand("SELECT * from tbprinter where print_host = '" + Environment.MachineName + "'", con))
                {


                    using (SqlDataReader leer = comand.ExecuteReader())
                    {
                        while (leer.Read() == true)
                        {
                            clsPrinterSet item = new clsPrinterSet();
                            item.Printer = leer.GetString(1);
                            item.Hostname = leer.GetString(2);
                        }
                    }
                }
                con.Close();
            }
        }
        public void Imprimir(object sender, PrintPageEventArgs e)
        {
            Factura.Clear();
            Ventas.Clear();
            if (FactCod.Length > 0)
            {
                using (var con = new SqlConnection(conect))
                {
                    con.Open();
                    var command = con.CreateCommand();
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "spGetFacturas";
                    command.Parameters.AddWithValue("@Parametro", FactCod);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clsFactura item = new clsFactura();
                            item.FactCod = reader.GetString(0);
                            item.Importe = reader.GetString(2);
                            item.Descuento = reader.GetString(3);
                            item.Total = reader.GetString(4);
                            if (reader.IsDBNull(5))
                            { }
                            else
                            {
                                item.Cliente = reader.GetString(5);
                            }
                            item.Metodo = reader.GetString(6);
                            item.Fecha = reader.GetString(10);
                            Factura.Add(item);
                        }
                    }
                    con.Close();

                    con.Open();
                    var command2 = con.CreateCommand();
                    command2.CommandType = System.Data.CommandType.StoredProcedure;
                    command2.CommandText = "spGetVentas";
                    command2.Parameters.AddWithValue("@Parametro", FactCod);
                    using (var reader2 = command2.ExecuteReader())
                    {
                        while (reader2.Read())
                        {
                            clsVentas item2 = new clsVentas();
                            item2.ProductoCod = reader2.GetString(1);
                            item2.Descripcion = reader2.GetString(2);
                            item2.Cantidad = reader2.GetString(3);
                            item2.PrecioVenta = reader2.GetString(4);
                            item2.Descuento = reader2.GetString(7);
                            Ventas.Add(item2);
                        }
                    }
                    con.Close();
                }
            }
            foreach (clsFactura item in Factura)
            {
                Importef = item.Importe; 
                MontoDescuentof = item.Descuento; 
                Totalf = item.Total;  
                Clientef = item.Cliente; 
                Metodof = item.Metodo; 
                Fechaf = item.Fecha;
            }

            int RowS = 215;
            String imagen = Environment.CurrentDirectory + @"\\resourses\VPNLogo.png";
            System.Drawing.Image img = System.Drawing.Image.FromFile(imagen);
            e.Graphics.DrawImage(img, new System.Drawing.Rectangle(20, 20, 206, 103));
            System.Drawing.Font font = new System.Drawing.Font("Calibri", 12, FontStyle.Bold, GraphicsUnit.Point);
            System.Drawing.Font fontcita = new System.Drawing.Font("Calibri", 8, FontStyle.Bold, GraphicsUnit.Point);
            e.Graphics.DrawString("VAPENATION", font, Brushes.Black, new RectangleF(70, 130, 200, 80));
            e.Graphics.DrawString("C/Central, esq. C/6 Los Frailes 1, Santo Domingo.", fontcita, Brushes.Black, new RectangleF(20, 150, 250, 120));
            e.Graphics.DrawString(DateTime.Now.ToString(), fontcita, Brushes.Black, new RectangleF(150, 170, 200, 80));
            System.Drawing.Font font1 = new System.Drawing.Font("Calibri", 10, FontStyle.Regular, GraphicsUnit.Point);
            System.Drawing.Font font2 = new System.Drawing.Font("Calibri", 14, FontStyle.Bold, GraphicsUnit.Point);
            e.Graphics.DrawString("Factura #: " + FactCod, font1, Brushes.Black, new RectangleF(10, 190, 300, 80));
            e.Graphics.DrawString("_________________________________", font1, Brushes.Black, new RectangleF(10, 195, 250, 80));
            e.Graphics.DrawString("DESCRIPCION                    PRECIO                    CANT.", fontcita, Brushes.Black, new RectangleF(10, 210, 250, 80));
            foreach (clsVentas item in Ventas)
            {
                ProductoCodf = item.ProductoCod;
                Descripcionf = item.Descripcion;
                Cantidadf = item.Cantidad;
                PrecioVentaf = item.PrecioVenta;
                Descuentosf = item.Descuento;
                int caractdesc = Descripcionf.Length;
                caractdesc = 45 - caractdesc;
                int caractprec = PrecioVentaf.Length;
                caractprec = 35 - caractprec;
                RowS = RowS + 10;
                e.Graphics.DrawString(Descripcionf.PadRight(caractdesc) + PrecioVentaf.PadRight(caractprec) +Cantidadf, fontcita, Brushes.Black, new RectangleF(10, RowS, 250, 80));
            }
            RowS = RowS + 5;
            e.Graphics.DrawString("_________________________________", font1, Brushes.Black, new RectangleF(10, RowS, 250, 80));
            RowS = RowS + 25;
            e.Graphics.DrawString("Subtotal:               " + Importef, font2, Brushes.Black, new RectangleF(10, RowS, 300, 80));
            if (MontoDescuentof != "RD$0.00")
            {
                RowS = RowS + 25;
                e.Graphics.DrawString("Descuento:         " + MontoDescuentof, font2, Brushes.Black, new RectangleF(10, RowS, 300, 80));
            }
            RowS = RowS + 25;
            e.Graphics.DrawString("Total a Pagar:         " + Totalf, font2, Brushes.Black, new RectangleF(10, RowS, 300, 80));
            RowS = RowS + 35;
            e.Graphics.DrawString("Mentodo de Pago:         " + Metodof, fontcita, Brushes.Black, new RectangleF(70, RowS, 200, 80));
            //e.Graphics.DrawString("Contraseña: " + contraseniaAleatoria, font2, Brushes.Black, new RectangleF(40, 280, 200, 80));
            //e.Graphics.DrawString("www.cgelaboratorio.com", font1, Brushes.Black, new RectangleF(40, 350, 200, 80));
        }
        
    }
}
