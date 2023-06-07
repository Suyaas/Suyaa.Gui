using System.Runtime.InteropServices;
using static Suyaa.Gui.Native.Win32.Apis.Enums;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll IsWindowUnicode */
    public partial class User32
    {
        /// <summary>
        /// 判断窗口字符集是否为Unicode
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport(Libraries.User32)]
        public static extern BOOL IsWindowUnicode(IntPtr hWnd);
        ///// <summary>
        ///// 判断窗口字符集是否为Unicode
        ///// </summary>
        ///// <param name="hWnd"></param>
        ///// <returns></returns>
        //[LibraryImport(Libraries.User32)]
        //public static partial BOOL IsWindowUnicode(IntPtr hWnd);
    }
}
