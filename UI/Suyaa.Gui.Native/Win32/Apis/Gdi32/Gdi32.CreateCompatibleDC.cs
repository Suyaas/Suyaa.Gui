using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll DeleteObject */
    public partial class Gdi32
    {
        /// <summary>
        /// CreateCompatibleDC
        /// </summary>
        /// <param name="hdc"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.Gdi32)]
        public static partial IntPtr CreateCompatibleDC(IntPtr hdc);
    }
}
