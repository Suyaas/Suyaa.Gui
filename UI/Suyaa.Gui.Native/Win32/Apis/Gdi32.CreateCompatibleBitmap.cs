using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll CreateCompatibleBitmap */
    public partial class Gdi32
    {
        /// <summary>
        /// CreateCompatibleBitmap
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="cx"></param>
        /// <param name="cy"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.Gdi32)]
        public static partial HBITMAP CreateCompatibleBitmap(HDC hdc, int cx, int cy);
    }
}
