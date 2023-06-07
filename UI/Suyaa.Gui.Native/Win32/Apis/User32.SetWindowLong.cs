using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll SetWindowLong */
    public partial class User32
    {
        // We only ever call this on 32 bit so IntPtr is correct

        /// <summary>
        /// SetWindowLongW
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <param name="dwNewLong"></param>
        /// <returns></returns>
        [DllImport(Libraries.User32, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr SetWindowLongW(IntPtr hWnd, GWL nIndex, nint dwNewLong);

        /// <summary>
        /// SetWindowLongPtrW
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <param name="dwNewLong"></param>
        /// <returns></returns>
        [DllImport(Libraries.User32, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr SetWindowLongPtrW(IntPtr hWnd, GWL nIndex, nint dwNewLong);

        /// <summary>
        /// SetWindowLong
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <param name="dwNewLong"></param>
        /// <returns></returns>
        public static IntPtr SetWindowLong(IntPtr hWnd, GWL nIndex, nint dwNewLong)
        {
            if (!Environment.Is64BitProcess)
            {
                return SetWindowLongW(hWnd, nIndex, dwNewLong);
            }

            return SetWindowLongPtrW(hWnd, nIndex, dwNewLong);
        }
    }
}
