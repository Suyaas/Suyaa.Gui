using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll DeleteObject */
    public partial class Gdi32
    {
        /// <summary>
        /// 释放用过的画笔等资源
        /// </summary>
        /// <param name="hdc"></param>
        /// <returns></returns>
        [DllImport(Libraries.Gdi32)]
        public static extern bool DeleteObject(IntPtr hdc);
    }
}
