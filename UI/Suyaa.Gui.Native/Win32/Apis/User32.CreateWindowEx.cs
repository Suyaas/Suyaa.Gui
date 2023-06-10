using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll CreateWindowEx */
    public partial class User32
    {
        ///// <summary>
        ///// CreateWindowEx
        ///// </summary>
        ///// <param name="dwExStyle"></param>
        ///// <param name="lpszClassName"></param>
        ///// <param name="lpszWindowName"></param>
        ///// <param name="style"></param>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        ///// <param name="width"></param>
        ///// <param name="height"></param>
        ///// <param name="hWndParent"></param>
        ///// <param name="hMenu"></param>
        ///// <param name="hInst"></param>
        ///// <param name="pvParam"></param>
        ///// <returns></returns>
        //[LibraryImport(Libraries.User32, CharSet = CharSet.Auto)]
        //public static partial IntPtr CreateWindowEx(int dwExStyle, string lpszClassName, string lpszWindowName, int style, int x, int y, int width, int height, IntPtr hWndParent, IntPtr hMenu, IntPtr hInst, IntPtr pvParam);

        /// <summary>
        /// 创建窗口
        /// </summary>
        /// <param name="dwExStyle"></param>
        /// <param name="lpClassName"></param>
        /// <param name="lpWindowName"></param>
        /// <param name="dwStyle"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="nWidth"></param>
        /// <param name="nHeight"></param>
        /// <param name="hWndParent"></param>
        /// <param name="hMenu"></param>
        /// <param name="hInst"></param>
        /// <param name="lpParam"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32, SetLastError = true)]
        public unsafe static partial IntPtr CreateWindowExW(
            WS_EX dwExStyle,
            char* lpClassName,
            char* lpWindowName,
            WS dwStyle,
            int X,
            int Y,
            int nWidth,
            int nHeight,
            IntPtr hWndParent,
            IntPtr hMenu,
            IntPtr hInst,
            IntPtr lpParam);
    }
}
