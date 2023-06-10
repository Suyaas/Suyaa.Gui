using System.Runtime.InteropServices;
using static Suyaa.Gui.Native.Win32.Apis.Enums;

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
        [LibraryImport(Libraries.Gdi32)]
        public static partial BOOL DeleteObject(IntPtr hdc);
    }
}
