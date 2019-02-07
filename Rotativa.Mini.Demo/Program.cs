using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotativa.Mini.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var rotativaPath = @"C:\Users\siraj\source\repos\Rotativa.Mini\Rotativa.Mini.Demo\Rotativa";
            var style = @"C:\Users\siraj\source\repos\Rotativa.Mini\Rotativa.Mini.Demo\Stylesheet1.css";

            var fileHtml = File.ReadAllText(@"C:\Users\siraj\source\repos\Rotativa.Mini\Rotativa.Mini.Demo\dddd.html");

            


            var options =
              new RotativaMiniOptions()
               .SetWindowStatusIdentifier("ready_to_print")
               .SetCopies(2)
               .SetPageSize(Size.A4)
               .SetStyleSheet(style)
               .SetFooter(@"C:\Users\siraj\source\repos\Rotativa.Mini\Rotativa.Mini.Demo\ddFooter.html")
               .SetPageMargins(1, 1, 5, 1);

            var pdfData = RotativaMiniConverter.ConvertHtml(rotativaPath, options, fileHtml);

            File.WriteAllBytes("Test.pdf", pdfData);

        }
    }
}
