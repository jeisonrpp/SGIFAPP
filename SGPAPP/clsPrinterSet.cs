using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPAPP
{
    public class clsPrinterSet
    {
    public String Printer { get; set; }
    public String Hostname { get; set; }

    public static List<clsPrinterSet> PrinterSettings = new List<clsPrinterSet>();
}
}
