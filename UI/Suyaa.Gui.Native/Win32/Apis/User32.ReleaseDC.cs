using System.Runtime.InteropServices;

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
        [DllImport(Libraries.User32)]
        public static extern bool ReleaseDC(IntPtr hwnd, IntPtr hdc);
    }
}
