using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll DeleteObject */
    public partial class Gdi32
    {
        /// <summary>
        /// CreateDIBSection
        /// </summary>
        /// <param name="hdc"></param>
        /// <param name="pbmi"></param>
        /// <param name="iUsage"></param>
        /// <param name="ppvBits"></param>
        /// <param name="hSection"></param>
        /// <param name="dwOffset"></param>
        /// <returns></returns>
        [DllImport(Libraries.Gdi32, EntryPoint = "CreateDIBSection")]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, ref BitmapInfo pbmi, uint iUsage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);
    }
}
