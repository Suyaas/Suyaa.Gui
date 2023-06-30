using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll DefWindowProc */
    public partial class User32
    {
        /// <summary>
        /// GetDC
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32, EntryPoint = "GetDC", SetLastError = true)]
        public static partial IntPtr GetDC(IntPtr hWnd);
    }
}
