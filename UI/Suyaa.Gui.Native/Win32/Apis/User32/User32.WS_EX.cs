using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll WS_EX */
    public partial class User32
    {
        /// <summary>
        ///  Extended Window Styles
        /// </summary>
        [Flags]
        public enum WS_EX : uint
        {
            /// <summary>
            /// DEFAULT
            /// </summary>
            DEFAULT = 0x00000000,
            /// <summary>
            /// DLGMODALFRAME
            /// </summary>
            DLGMODALFRAME = 0x00000001,
            /// <summary>
            /// NOPARENTNOTIFY
            /// </summary>
            NOPARENTNOTIFY = 0x00000004,
            /// <summary>
            /// TOPMOST
            /// </summary>
            TOPMOST = 0x00000008,
            /// <summary>
            /// ACCEPTFILES
            /// </summary>
            ACCEPTFILES = 0x00000010,
            /// <summary>
            /// TRANSPARENT
            /// </summary>
            TRANSPARENT = 0x00000020,
            /// <summary>
            /// MDICHILD
            /// </summary>
            MDICHILD = 0x00000040,
            /// <summary>
            /// TOOLWINDOW
            /// </summary>
            TOOLWINDOW = 0x00000080,
            /// <summary>
            /// WINDOWEDGE
            /// </summary>
            WINDOWEDGE = 0x00000100,
            /// <summary>
            /// CLIENTEDGE
            /// </summary>
            CLIENTEDGE = 0x00000200,
            /// <summary>
            /// CONTEXTHELP
            /// </summary>
            CONTEXTHELP = 0x00000400,
            /// <summary>
            /// RIGHT
            /// </summary>
            RIGHT = 0x00001000,
            /// <summary>
            /// LEFT
            /// </summary>
            LEFT = 0x00000000,
            /// <summary>
            /// RTLREADING
            /// </summary>
            RTLREADING = 0x00002000,
            /// <summary>
            /// LTRREADING
            /// </summary>
            LTRREADING = 0x00000000,
            /// <summary>
            /// LEFTSCROLLBAR
            /// </summary>
            LEFTSCROLLBAR = 0x00004000,
            /// <summary>
            /// RIGHTSCROLLBAR
            /// </summary>
            RIGHTSCROLLBAR = 0x00000000,
            /// <summary>
            /// CONTROLPARENT
            /// </summary>
            CONTROLPARENT = 0x00010000,
            /// <summary>
            /// STATICEDGE
            /// </summary>
            STATICEDGE = 0x00020000,
            /// <summary>
            /// APPWINDOW
            /// </summary>
            APPWINDOW = 0x00040000,
            /// <summary>
            /// OVERLAPPEDWINDOW
            /// </summary>
            OVERLAPPEDWINDOW = WINDOWEDGE | CLIENTEDGE,
            /// <summary>
            /// PALETTEWINDOW
            /// </summary>
            PALETTEWINDOW = WINDOWEDGE | TOOLWINDOW | TOPMOST,
            /// <summary>
            /// LAYERED
            /// </summary>
            LAYERED = 0x00080000,
            /// <summary>
            /// NOINHERITLAYOUT
            /// </summary>
            NOINHERITLAYOUT = 0x00100000,
            /// <summary>
            /// NOREDIRECTIONBITMAP
            /// </summary>
            NOREDIRECTIONBITMAP = 0x00200000,
            /// <summary>
            /// LAYOUTRTL
            /// </summary>
            LAYOUTRTL = 0x00400000,
            /// <summary>
            /// COMPOSITED
            /// </summary>
            COMPOSITED = 0x02000000,
            /// <summary>
            /// NOACTIVATE
            /// </summary>
            NOACTIVATE = 0x08000000
        }
    }
}
