using System.Linq;
using System.Text;
using System.Reflection;
using System.Globalization;

namespace Rotativa.Mini
{
    public class RotativaMiniOptions : RotativaSwitchBase
    {
        /// <summary>
        /// Sets the page margins.
        /// </summary>
        /// <param name="top">Page top margin in mm.</param>
        /// <param name="right">Page right margin in mm.</param>
        /// <param name="bottom">Page bottom margin in mm.</param>
        /// <param name="left">Page left margin in mm.</param>
        public RotativaMiniOptions SetPageMargins(int top, int right, int bottom, int left)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
            return this;
        }

        /// <summary>
        /// Sets copies of pages, default 1
        /// </summary>
        /// <param name="copies">number of copies</param>
        /// <returns></returns>
        public RotativaMiniOptions SetCopies(int copies)
        {
            Copies = copies;
            return this;
        }

        /// <summary>
        /// Set the window.status identifier
        /// </summary>
        /// <param name="key">wait until window.status is equal to this</param>
        /// <returns></returns>
        public RotativaMiniOptions SetWindowStatusIdentifier(string key)
        {
            WindowStatus = key;
            return this;
        }

        /// <summary>
        /// Set as GrayScale
        /// </summary>
        /// <returns></returns>
        public RotativaMiniOptions AsGrayScale()
        {
            IsGrayScale = true;
            return this;
        }

        /// <summary>
        /// Set as low quality
        /// </summary>
        /// <returns></returns>
        public RotativaMiniOptions AsLowQuality()
        {
            IsLowQuality= true;
            return this;
        }

        /// <summary>
        /// Set page orientation, default portrait
        /// </summary>
        /// <param name="orientation"></param>
        /// <returns></returns>
        public RotativaMiniOptions SetPageOrientation(Orientation orientation)
        {
            PageOrientation = orientation;
            return this;
        }

        /// <summary>
        /// Set page size, default A4
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public RotativaMiniOptions SetPageSize(Size size)
        {
            PageSize = size;
            return this;
        }

        /// <summary>
        /// Specify a user style sheet, to load with every page
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public RotativaMiniOptions SetStyleSheet(string url)
        {
            StyleSheetUrl = url;
            return this;
        }

        /// <summary>
        /// Set as Disable the intelligent shrinking 
        /// </summary>
        /// <returns></returns>
        public RotativaMiniOptions DisableSmartShrinking()
        {
            IsDisableSmartShrinking = true;
            return this;
        }

        /// <summary>
        /// Applies default footer if nothing is passed in parameter customHtmlUrl
        /// </summary>
        /// <param name="customHtmlUrl">Provide custom html</param>
        /// <returns></returns>
        public RotativaMiniOptions SetFooter(string customHtmlUrl=null)
        {
            string defaultFooter = (" --page-offset 0" +
                " --footer-font-name Calibri" +
                " --footer-center [page]/[toPage]" +
                " --footer-left [title]" +
                " --footer-right [date]@[time]" +
                " --footer-spacing -5 --footer-font-size 10");

            if (!string.IsNullOrWhiteSpace(customHtmlUrl))
                defaultFooter = $" --footer-html {customHtmlUrl}";

            DefaultFooter = defaultFooter;
            return this;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            FieldInfo[] fields = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo fi in fields)
            {
                var of = fi.GetCustomAttributes(typeof(OptionFlag), true).FirstOrDefault() as OptionFlag;
                if (of == null)
                    continue;
                object value = fi.GetValue(this);

                if (of.IsCusotm)
                {
                    result.AppendFormat(CultureInfo.InvariantCulture, " {0}", value);
                    continue;
                }
                //If boolean add no value
                if (fi.FieldType == typeof(bool))
                    if ((bool)value) result.AppendFormat(CultureInfo.InvariantCulture, " {0}", of.Name);
                    else continue;
                else
                {
                    if (value != null)
                        result.AppendFormat(CultureInfo.InvariantCulture, " {0} {1}", of.Name, value);
                }
            }

            return result.ToString().Trim();
        }
    }
}
