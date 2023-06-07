using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.Native.Linux.Apis
{
    /*
     * 枚举
     */
    public partial class LibX11
    {

        /// <summary>
        /// XICCEncodingStyle
        /// </summary>
        public enum XICCEncodingStyle
        {
            /// <summary>
            /// XStringStyle
            /// </summary>
            XStringStyle,       /* STRING */
            /// <summary>
            /// XCompoundTextStyle
            /// </summary>
            XCompoundTextStyle,     /* COMPOUND_TEXT */
            /// <summary>
            /// XTextStyle
            /// </summary>
            XTextStyle,         /* text in owner's encoding (current locale)*/
            /// <summary>
            /// XStdICCTextStyle
            /// </summary>
            XStdICCTextStyle,       /* STRING, else COMPOUND_TEXT */
            /* The following is an XFree86 extension, introduced in November 2000 */
            /// <summary>
            /// XUTF8StringStyle
            /// </summary>
            XUTF8StringStyle		/* UTF8_STRING */
        }

    }
}
