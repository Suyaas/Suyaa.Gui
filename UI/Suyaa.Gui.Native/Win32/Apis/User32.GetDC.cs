using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll DefWindowProc */
    public partial class User32
    {
        /// <summary>
        /// GetDC
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport(Libraries.User32, EntryPoint = "GetDC", CharSet = CharSet.Auto)]
        public extern static IntPtr GetDC(IntPtr hWnd);
    }
}
