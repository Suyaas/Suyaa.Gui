using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll RegisterClass */
    public partial class User32
    {
        /// <summary>
        /// RegisterClass
        /// </summary>
        /// <param name="wc"></param>
        /// <returns></returns>
        [DllImport(Libraries.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr RegisterClass(WNDCLASS wc);
    }
}
