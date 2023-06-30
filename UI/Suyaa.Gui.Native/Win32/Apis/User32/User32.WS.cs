using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll WS */
    public partial class User32
    {
        /// <summary>
        ///  Window styles
        /// </summary>
        [Flags]
        public enum WS : uint
        {
            /// <summary>
            /// OVERLAPPED
            /// </summary>
            OVERLAPPED = 0x00000000,
            /// <summary>
            /// POPUP
            /// </summary>
            POPUP = 0x80000000,
            /// <summary>
            /// CHILD
            /// </summary>
            CHILD = 0x40000000,
            /// <summary>
            /// MINIMIZE
            /// </summary>
            MINIMIZE = 0x20000000,
            /// <summary>
            /// VISIBLE
            /// </summary>
            VISIBLE = 0x10000000,
            /// <summary>
            /// DISABLED
            /// </summary>
            DISABLED = 0x08000000,
            /// <summary>
            /// CLIPSIBLINGS
            /// </summary>
            CLIPSIBLINGS = 0x04000000,
            /// <summary>
            /// CLIPCHILDREN
            /// </summary>
            CLIPCHILDREN = 0x02000000,
            /// <summary>
            /// MAXIMIZE
            /// </summary>
            MAXIMIZE = 0x01000000,
            /// <summary>
            /// CAPTION
            /// </summary>
            CAPTION = 0x00C00000,
            /// <summary>
            /// BORDER
            /// </summary>
            BORDER = 0x00800000,
            /// <summary>
            /// DLGFRAME
            /// </summary>
            DLGFRAME = 0x00400000,
            /// <summary>
            /// VSCROLL
            /// </summary>
            VSCROLL = 0x00200000,
            /// <summary>
            /// HSCROLL
            /// </summary>
            HSCROLL = 0x00100000,
            /// <summary>
            /// SYSMENU
            /// </summary>
            SYSMENU = 0x00080000,
            /// <summary>
            /// THICKFRAME
            /// </summary>
            THICKFRAME = 0x00040000,
            /// <summary>
            /// TABSTOP
            /// </summary>
            TABSTOP = 0x00010000,
            /// <summary>
            /// MINIMIZEBOX
            /// </summary>
            MINIMIZEBOX = 0x00020000,
            /// <summary>
            /// MAXIMIZEBOX
            /// </summary>
            MAXIMIZEBOX = 0x00010000,

            /// <summary>
            /// 混合
            /// </summary>
            OVERLAPPEDWINDOW = OVERLAPPED | CAPTION | SYSMENU | THICKFRAME | MINIMIZEBOX | MAXIMIZEBOX,
        }
    }
}
