using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll PostQuitMessage */
    public partial class User32
    {
        /// <summary>
        /// PostQuitMessage
        /// </summary>
        /// <param name="nExitCode"></param>
        [LibraryImport(Libraries.User32, SetLastError = true)]
        public static partial void PostQuitMessage(int nExitCode);
    }
}
