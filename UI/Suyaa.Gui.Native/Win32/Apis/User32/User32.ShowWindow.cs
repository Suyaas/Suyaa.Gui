using System.Runtime.InteropServices;
using static Suyaa.Gui.Native.Win32.Apis.Enums;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll ShowWindow */
    public partial class User32
    {
        ///// <summary>
        ///// ShowWindow
        ///// </summary>
        ///// <param name="hWnd"></param>
        ///// <param name="nCmdShow"></param>
        ///// <returns></returns>
        //[LibraryImport(Libraries.User32, CharSet = CharSet.Auto)]
        //public static partial bool ShowWindow(IntPtr hWnd, int nCmdShow);

        /// <summary>
        /// ShowWindow
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32)]
        public static partial BOOL ShowWindow(IntPtr hWnd, SW nCmdShow);

        /// <summary>
        /// ShowWindow
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        public static BOOL ShowWindow(IHandle hWnd, SW nCmdShow)
        {
            BOOL result = ShowWindow(hWnd.Handle, nCmdShow);
            GC.KeepAlive(hWnd);
            return result;
        }
    }
}
