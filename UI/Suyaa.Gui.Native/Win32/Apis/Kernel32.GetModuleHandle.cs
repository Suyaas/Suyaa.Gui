using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* kernel32.dll GetModuleHandle */
    public partial class Kernel32
    {
        /// <summary>
        /// GetModuleHandle
        /// </summary>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        [DllImport(Libraries.Kernel32, CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string? moduleName);
    }
}
