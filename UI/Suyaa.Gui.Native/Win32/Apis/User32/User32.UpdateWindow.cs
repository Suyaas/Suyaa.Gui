using System.Runtime.InteropServices;
using static Suyaa.Gui.Native.Win32.Apis.Enums;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll UpdateWindow */
    public partial class User32
    {
        ///// <summary>
        ///// UpdateWindow
        ///// </summary>
        ///// <param name="hWnd"></param>
        ///// <returns></returns>
        //[LibraryImport(Libraries.User32, CharSet = CharSet.Auto)]
        //public static partial bool UpdateWindow(IntPtr hWnd);

        /// <summary>
        /// UpdateWindow
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32)]
        public static partial BOOL UpdateWindow(IntPtr hWnd);
    }
}
