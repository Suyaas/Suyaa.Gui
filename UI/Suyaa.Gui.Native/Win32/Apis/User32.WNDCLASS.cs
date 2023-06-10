using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll WNDCLASS */
    public partial class User32
    {
        /// <summary>
        ///  Class styles for <see cref="WNDCLASS"/>
        /// </summary>
        [Flags]
        public enum CS : uint
        {
            /// <summary>
            /// VREDRAW
            /// </summary>
            VREDRAW = 0x0001,
            /// <summary>
            /// HREDRAW
            /// </summary>
            HREDRAW = 0x0002,
            /// <summary>
            /// DBLCLKS
            /// </summary>
            DBLCLKS = 0x0008,
            /// <summary>
            /// DROPSHADOW
            /// </summary>
            DROPSHADOW = 0x00020000,
            /// <summary>
            /// SAVEBITS
            /// </summary>
            SAVEBITS = 0x0800
        }

        /// <summary>
        /// WNDCLASS
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public unsafe struct WNDCLASS
        {
            /// <summary>
            /// style
            /// </summary>
            public CS style;
            /// <summary>
            /// lpfnWndProc
            /// </summary>
            public IntPtr lpfnWndProc;
            /// <summary>
            /// cbClsExtra
            /// </summary>
            public int cbClsExtra;
            /// <summary>
            /// cbWndExtra
            /// </summary>
            public int cbWndExtra;
            /// <summary>
            /// hInstance
            /// </summary>
            public IntPtr hInstance;
            /// <summary>
            /// hIcon
            /// </summary>
            public IntPtr hIcon;
            /// <summary>
            /// hCursor
            /// </summary>
            public IntPtr hCursor;
            /// <summary>
            /// hbrBackground
            /// </summary>
            public Gdi32.HBRUSH hbrBackground;
            /// <summary>
            /// lpszMenuName
            /// </summary>
            public char* lpszMenuName;
            /// <summary>
            /// lpszClassName
            /// </summary>
            public char* lpszClassName;
        }
    }
}
