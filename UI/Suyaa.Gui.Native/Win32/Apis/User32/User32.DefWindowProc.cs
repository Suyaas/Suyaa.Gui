using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll DefWindowProc */
    public partial class User32
    {
        /// <summary>
        /// DefWindowProc
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32)]
        public static partial IntPtr DefWindowProcW(
            IntPtr hWnd,
            WM msg,
            IntPtr wParam,
            IntPtr lParam);

        //[LibraryImport(Libraries.User32, CharSet = CharSet.Auto)]
        //public static partial int DefWindowProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    }
}
