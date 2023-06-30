using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll CreateIconIndirect */
    public partial class User32
    {
        /// <summary>
        /// CreateIconIndirect
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32)]
        public static partial nint CreateIconIndirect(ref ICONINFO info);
    }
}
