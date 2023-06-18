using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll LoadCursor */
    public partial class User32
    {
        /// <summary>
        /// 系统光标资源
        /// </summary>
        public static class CursorResourceId
        {
            /// <summary>
            /// IDC_ARROW
            /// </summary>
            public const int IDC_ARROW = 32512;
            /// <summary>
            /// IDC_IBEAM
            /// </summary>
            public const int IDC_IBEAM = 32513;
            /// <summary>
            /// IDC_WAIT
            /// </summary>
            public const int IDC_WAIT = 32514;
            /// <summary>
            /// IDC_CROSS
            /// </summary>
            public const int IDC_CROSS = 32515;
            /// <summary>
            /// IDC_SIZEALL
            /// </summary>
            public const int IDC_SIZEALL = 32646;
            /// <summary>
            /// IDC_SIZENWSE
            /// </summary>
            public const int IDC_SIZENWSE = 32642;
            /// <summary>
            /// IDC_SIZENESW
            /// </summary>
            public const int IDC_SIZENESW = 32643;
            /// <summary>
            /// IDC_SIZEWE
            /// </summary>
            public const int IDC_SIZEWE = 32644;
            /// <summary>
            /// IDC_SIZENS
            /// </summary>
            public const int IDC_SIZENS = 32645;
            /// <summary>
            /// IDC_UPARROW
            /// </summary>
            public const int IDC_UPARROW = 32516;
            /// <summary>
            /// IDC_NO
            /// </summary>
            public const int IDC_NO = 32648;
            /// <summary>
            /// IDC_HAND
            /// </summary>
            public const int IDC_HAND = 32649;
            /// <summary>
            /// IDC_APPSTARTING
            /// </summary>
            public const int IDC_APPSTARTING = 32650;
            /// <summary>
            /// IDC_HELP
            /// </summary>
            public const int IDC_HELP = 32651;
        }

        /// <summary>
        /// 加载光标
        /// </summary>
        /// <param name="hInstance"></param>
        /// <param name="lpCursorName"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32)]
        public static partial IntPtr LoadCursorW(IntPtr hInstance, IntPtr lpCursorName);
    }
}
