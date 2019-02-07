using System.Linq;
using System.Text;
using System.Reflection;
using System.Globalization;

namespace Rotativa.Mini
{
    public abstract class RotativaSwitchBase
    {
        #region Global Switches

        /// <summary>
        /// Number of copies to print into the PDF file.
        /// </summary>
        [OptionFlag("--copies")]
        internal int? Copies;

        /// <summary>
        /// Indicates whether the PDF should be generated in grayscale.
        /// </summary>
        [OptionFlag("--grayscale")]
        internal bool IsGrayScale;

        /// <summary>
        /// Indicates whether the PDF should be generated in lower quality.
        /// </summary>
        [OptionFlag("--lowquality")]
        internal bool IsLowQuality;

        /// <summary>
        /// Page bottom margin in mm.
        /// </summary>
        [OptionFlag("--margin-bottom")]
        internal int? Bottom;

        /// <summary>
        /// Page left margin in mm.
        /// </summary>
        [OptionFlag("--margin-left")]
        internal int? Left;

        /// <summary>
        /// Page right margin in mm.
        /// </summary>
        [OptionFlag("--margin-right")]
        internal int? Right;

        /// <summary>
        /// Page top margin in mm.
        /// </summary>
        [OptionFlag("--margin-top")]
        internal int? Top;

        /// <summary>
        /// Sets the page orientation.
        /// </summary>
        [OptionFlag("--orientation")]
        internal Orientation? PageOrientation;

        /// <summary>
        /// Sets the page size.
        /// </summary>
        [OptionFlag("--page-size")]
        internal Size? PageSize;

        /// <summary>
        /// Sets the page width in mm.
        /// </summary>
        /// <remarks>Has priority over <see cref="PageSize"/> but <see cref="PageHeight"/> has to be also specified.</remarks>
        [OptionFlag("--page-width")]
        internal double? PageWidth;

        /// <summary>
        /// Sets the page height in mm.
        /// </summary>
        /// <remarks>Has priority over <see cref="PageSize"/> but <see cref="PageWidth"/> has to be also specified.</remarks>
        [OptionFlag("--page-height")]
        internal double? PageHeight;

        #endregion

        #region Page Options

        [OptionFlag("--window-status")]
        internal string WindowStatus;

        [OptionFlag("--user-style-sheet")]
        internal string StyleSheetUrl;

        #endregion

        #region Header And Footer Options

        /// <summary>
        /// Set default footer
        /// </summary>
        [OptionFlag(true)]
        internal string DefaultFooter;


        #endregion
    }
}
