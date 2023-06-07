using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll UpdateWindow */
    public partial class User32
    {
        /// <summary>
        /// UpdateWindow
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport(Libraries.User32, CharSet = CharSet.Auto)]
        public static extern bool UpdateWindow(IntPtr hWnd);
    }
}
