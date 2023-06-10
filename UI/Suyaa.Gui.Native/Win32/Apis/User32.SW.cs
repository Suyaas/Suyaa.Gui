using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll SW */
    public partial class User32
    {
        /// <summary>
        ///  Show window flags
        /// </summary>
        public enum SW : int
        {
            /// <summary>
            /// HIDE
            /// </summary>
            HIDE = 0,
            /// <summary>
            /// NORMAL
            /// </summary>
            NORMAL = 1,
            /// <summary>
            /// SHOWMINIMIZED
            /// </summary>
            SHOWMINIMIZED = 2,
            /// <summary>
            /// SHOWMAXIMIZED
            /// </summary>
            SHOWMAXIMIZED = 3,
            /// <summary>
            /// MAXIMIZE
            /// </summary>
            MAXIMIZE = 3,
            /// <summary>
            /// SHOWNOACTIVATE
            /// </summary>
            SHOWNOACTIVATE = 4,
            /// <summary>
            /// SHOW
            /// </summary>
            SHOW = 5,
            /// <summary>
            /// MINIMIZE
            /// </summary>
            MINIMIZE = 6,
            /// <summary>
            /// SHOWMINNOACTIVE
            /// </summary>
            SHOWMINNOACTIVE = 7,
            /// <summary>
            /// SHOWNA
            /// </summary>
            SHOWNA = 8,
            /// <summary>
            /// RESTORE
            /// </summary>
            RESTORE = 9,
            /// <summary>
            /// SHOWDEFAULT
            /// </summary>
            SHOWDEFAULT = 10,
            /// <summary>
            /// FORCEMINIMIZE
            /// </summary>
            FORCEMINIMIZE = 11,
            /// <summary>
            /// MAX
            /// </summary>
            MAX = 11
        }
    }
}
