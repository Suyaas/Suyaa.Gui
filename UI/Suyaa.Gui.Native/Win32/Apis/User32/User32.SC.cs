using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll SC */
    public partial class User32
    {
        /// <summary>
        /// SC
        /// </summary>
        public enum SC : uint
        {
            /// <summary>
            /// SIZE
            /// </summary>
            SIZE = 0xF000,
            /// <summary>
            /// MOVE
            /// </summary>
            MOVE = 0xF010,
            /// <summary>
            /// MINIMIZE
            /// </summary>
            MINIMIZE = 0xF020,
            /// <summary>
            /// MAXIMIZE
            /// </summary>
            MAXIMIZE = 0xF030,
            /// <summary>
            /// NEXTWINDOW
            /// </summary>
            NEXTWINDOW = 0xF040,
            /// <summary>
            /// PREVWINDOW
            /// </summary>
            PREVWINDOW = 0xF050,
            /// <summary>
            /// CLOSE
            /// </summary>
            CLOSE = 0xF060,
            /// <summary>
            /// VSCROLL
            /// </summary>
            VSCROLL = 0xF070,
            /// <summary>
            /// HSCROLL
            /// </summary>
            HSCROLL = 0xF080,
            /// <summary>
            /// MOUSEMENU
            /// </summary>
            MOUSEMENU = 0xF090,
            /// <summary>
            /// KEYMENU
            /// </summary>
            KEYMENU = 0xF100,
            /// <summary>
            /// ARRANGE
            /// </summary>
            ARRANGE = 0xF110,
            /// <summary>
            /// RESTORE
            /// </summary>
            RESTORE = 0xF120,
            /// <summary>
            /// TASKLIST
            /// </summary>
            TASKLIST = 0xF130,
            /// <summary>
            /// SCREENSAVE
            /// </summary>
            SCREENSAVE = 0xF140,
            /// <summary>
            /// HOTKEY
            /// </summary>
            HOTKEY = 0xF150,
            /// <summary>
            /// DEFAULT
            /// </summary>
            DEFAULT = 0xF160,
            /// <summary>
            /// MONITORPOWER
            /// </summary>
            MONITORPOWER = 0xF170,
            /// <summary>
            /// CONTEXTHELP
            /// </summary>
            CONTEXTHELP = 0xF180,
            /// <summary>
            /// SEPARATOR
            /// </summary>
            SEPARATOR = 0xF00F,
        }
    }
}
