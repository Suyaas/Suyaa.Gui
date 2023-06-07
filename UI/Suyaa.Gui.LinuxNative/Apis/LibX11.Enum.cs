using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Suyaa.Gui.LinuxNative.Apis
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
            XStringStyle,       /* STRING */
            XCompoundTextStyle,     /* COMPOUND_TEXT */
            XTextStyle,         /* text in owner's encoding (current locale)*/
            XStdICCTextStyle,       /* STRING, else COMPOUND_TEXT */
            /* The following is an XFree86 extension, introduced in November 2000 */
            XUTF8StringStyle		/* UTF8_STRING */
        }

    }
}
