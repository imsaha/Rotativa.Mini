using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rotativa.Mini
{
    public class RotativaMiniConverter : WkhtmlDriver
    {
        private const string wkhtmlExe = "wkhtmltopdf.exe";

        /// <summary>
        /// Converts given HTML string to PDF.
        /// </summary>
        /// <param name="wkhtmltopdfPath">Path to wkthmltopdf.</param>
        /// <param name="switches">Switches that will be passed to wkhtmltopdf binary.</param>
        /// <param name="html">String containing HTML code that should be converted to PDF.</param>
        /// <returns>PDF as byte array.</returns>
        public static byte[] ConvertHtml(string wkhtmltopdfPath, RotativaMiniOptions switches, string html)
        {
            return Convert(wkhtmltopdfPath, switches.ToString(), html, wkhtmlExe);
        }

        /// <summary>
        /// Converts given URL to PDF.
        /// </summary>
        /// <param name="wkhtmltopdfPath">Path to wkthmltopdf.</param>
        /// <param name="switches">Switches that will be passed to wkhtmltopdf binary.</param>
        /// <returns>PDF as byte array.</returns>
        public static byte[] Convert(string wkhtmltopdfPath, string switches)
        {
            return Convert(wkhtmltopdfPath, switches, null, wkhtmlExe);
        }
    }
}
