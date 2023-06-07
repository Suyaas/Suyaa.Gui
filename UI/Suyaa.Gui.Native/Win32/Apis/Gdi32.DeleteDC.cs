using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* gdi32.dll DeleteDC */
    public partial class Gdi32
    {
        /// <summary>
        /// DeleteDC
        /// </summary>
        /// <param name="hdc"></param>
        /// <returns></returns>
        [DllImport(Libraries.Gdi32)]
        public static extern int DeleteDC(IntPtr hdc);
    }
}
