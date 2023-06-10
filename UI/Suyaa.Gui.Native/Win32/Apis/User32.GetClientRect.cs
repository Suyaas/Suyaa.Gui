using Suyaa.Gui.Drawing;
using Suyaa.Gui.Native.Helpers;
using System.Runtime.InteropServices;
using static Suyaa.Gui.Native.Win32.Apis.Enums;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll GetClientRect */
    public partial class User32
    {
        /// <summary>
        /// GetClientRect
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpRect"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32)]
        public static partial BOOL GetClientRect(IntPtr hWnd, ref RECT lpRect);

        /// <summary>
        /// GetClientRect
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        public static Rectangle GetClientRect(IntPtr hWnd)
        {
            RECT lpRect = new RECT();
            GetClientRect(hWnd, ref lpRect);
            return lpRect.ToRectangle();
        }
    }
}
