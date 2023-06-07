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
        [DllImport(Libraries.User32, CharSet = CharSet.Auto)]
        public static extern void PostQuitMessage(int nExitCode);
    }
}
