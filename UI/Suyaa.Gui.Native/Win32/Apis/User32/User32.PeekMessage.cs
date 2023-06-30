using System.Runtime.InteropServices;
using static Suyaa.Gui.Native.Win32.Apis.Enums;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll PeekMessage */
    public partial class User32
    {
        /// <summary>
        /// PeekMessage
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="hwnd"></param>
        /// <param name="msgMin"></param>
        /// <param name="msgMax"></param>
        /// <param name="remove"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32, SetLastError = true)]
        public static partial BOOL PeekMessage(
            ref MSG msg,
            IntPtr hwnd = default,
            uint msgMin = 0,
            uint msgMax = 0,
            uint remove = 0);

        /// <summary>
        /// PeekMessageA
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="hwnd"></param>
        /// <param name="msgMin"></param>
        /// <param name="msgMax"></param>
        /// <param name="remove"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32, SetLastError = true)]
        public static partial BOOL PeekMessageA(
            ref MSG msg,
            IntPtr hwnd = default,
            WM msgMin = (WM)0,
            WM msgMax = (WM)0,
            PM remove = PM.NOREMOVE);

        /// <summary>
        /// PeekMessageW
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="hwnd"></param>
        /// <param name="msgMin"></param>
        /// <param name="msgMax"></param>
        /// <param name="remove"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32, SetLastError = true)]
        public static partial BOOL PeekMessageW(
            ref MSG msg,
            IntPtr hwnd = default,
            WM msgMin = (WM)0,
            WM msgMax = (WM)0,
            PM remove = PM.NOREMOVE);

        /// <summary>
        /// PeekMessageW
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="hwnd"></param>
        /// <param name="msgMin"></param>
        /// <param name="msgMax"></param>
        /// <param name="remove"></param>
        /// <returns></returns>
        public static BOOL PeekMessageW(
            ref MSG msg,
            IHandle hwnd,
            WM msgMin = (WM)0,
            WM msgMax = (WM)0,
            PM remove = PM.NOREMOVE)
        {
            BOOL result = PeekMessageW(ref msg, hwnd.Handle, msgMin, msgMax, remove);
            GC.KeepAlive(hwnd);
            return result;
        }

        /// <summary>
        /// PM
        /// </summary>
        [Flags]
        public enum PM : uint
        {
            /// <summary>
            /// NOREMOVE
            /// </summary>
            NOREMOVE = 0x0000,
            /// <summary>
            /// REMOVE
            /// </summary>
            REMOVE = 0x0001,
            /// <summary>
            /// NOYIELD
            /// </summary>
            NOYIELD = 0x0002
        }
    }
}
