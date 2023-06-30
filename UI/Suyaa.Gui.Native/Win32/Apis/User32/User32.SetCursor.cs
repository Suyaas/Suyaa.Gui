using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll SetCursor */
    public partial class User32
    {
        // 设置鼠标光标
        [LibraryImport(Libraries.User32)]
        private static partial IntPtr SetCursor(IntPtr hCursor);

        /// <summary>
        /// 设置鼠标
        /// </summary>
        /// <param name="hCursor"></param>
        /// <returns></returns>
        public static IntPtr SetCursor(IHandle? hCursor)
        {
            IntPtr handle = hCursor?.Handle ?? IntPtr.Zero;
            //Debug.WriteLine($"[User32] SetCursor 0x{handle.ToString("x").PadLeft(12, '0')}");
            IntPtr result = SetCursor(handle);
            GC.KeepAlive(hCursor);
            return result;
        }
    }
}
