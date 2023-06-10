using System.Runtime.InteropServices;
using static Suyaa.Gui.Native.Win32.Apis.Enums;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll SystemParametersInfo */
    public partial class User32
    {
        /// <summary>
        /// SystemParametersInfoW
        /// </summary>
        /// <param name="uiAction"></param>
        /// <param name="uiParam"></param>
        /// <param name="pvParam"></param>
        /// <param name="fWinIni"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32, SetLastError = true)]
        private unsafe static partial BOOL SystemParametersInfoW(SPI uiAction, uint uiParam, void* pvParam, uint fWinIni);

        /// <summary>
        /// SystemParametersInfoW
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uiAction"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public unsafe static bool SystemParametersInfoW<T>(SPI uiAction, ref T value) where T : unmanaged
        {
            fixed (void* p = &value)
            {
                return SystemParametersInfoW(uiAction, 0, p, 0).IsTrue();
            }
        }

        /// <summary>
        /// 获取系统工作区
        /// </summary>
        /// <returns></returns>
        public static RECT GetSystemWorkarea()
        {
            var rect = new RECT();
            SystemParametersInfoW(SPI.GETWORKAREA, ref rect);
            return rect;
        }
    }
}
