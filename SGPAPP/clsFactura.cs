using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPAPP
{
    public class clsFactura
    {
        public String FactCod { get; set; }
        public int Cant { get; set; }
        public String Importe { get; set; }
        public String Descuento { get; set; }

        public String Total { get; set; }
        public String Cliente { get; set; }

        public String Metodo { get; set; }

        public String Fecha { get; set; }

    }
}
