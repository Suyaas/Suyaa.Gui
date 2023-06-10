using System.Runtime.InteropServices;
using static Suyaa.Gui.Native.Win32.Apis.Enums;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll ReleaseDC */
    public partial class User32
    {
        /// <summary>
        /// 释放用过的设备句柄
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="hdc"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32)]
        public static partial BOOL ReleaseDC(IntPtr hwnd, IntPtr hdc);
    }
}
