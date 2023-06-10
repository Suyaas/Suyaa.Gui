using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll RegisterClass */
    public partial class User32
    {
        /// <summary>
        /// RegisterClass
        /// </summary>
        /// <param name="wc"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32, SetLastError = true)]
        public static partial IntPtr RegisterClassW(ref WNDCLASS wc);
    }
}
