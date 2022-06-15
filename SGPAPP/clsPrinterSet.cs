using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGPAPP
{
    public class clsPrinterSet
    {
    public static string Printer { get; set; }
    public static string Hostname { get; set; }

    public static List<clsPrinterSet> PrinterSettings = new List<clsPrinterSet>();
}
}
