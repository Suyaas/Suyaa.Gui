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
        [LibraryImport(Libraries.Kernel32, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
        public unsafe static partial IntPtr GetModuleHandleW(string? moduleName);
    }
}
