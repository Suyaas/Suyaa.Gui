using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll CreateWindowEx */
    public partial class User32
    {
        /// <summary>
        /// CreateWindowEx
        /// </summary>
        /// <param name="dwExStyle"></param>
        /// <param name="lpszClassName"></param>
        /// <param name="lpszWindowName"></param>
        /// <param name="style"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="hWndParent"></param>
        /// <param name="hMenu"></param>
        /// <param name="hInst"></param>
        /// <param name="pvParam"></param>
        /// <returns></returns>
        [DllImport(Libraries.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr CreateWindowEx(int dwExStyle, string lpszClassName, string lpszWindowName, int style, int x, int y, int width, int height, IntPtr hWndParent, IntPtr hMenu, IntPtr hInst, IntPtr pvParam);
    }
}
