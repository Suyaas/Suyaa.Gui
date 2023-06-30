using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll DispatchMessage */
    public partial class User32
    {
        ///// <summary>
        ///// 分发消息
        ///// </summary>
        ///// <param name="msg"></param>
        ///// <returns></returns>
        //[LibraryImport("user32.dll", CharSet = CharSet.Auto)]
        //public static partial int DispatchMessage(ref MSG msg);

        ///// <summary>
        ///// 分发消息
        ///// </summary>
        ///// <param name="msg"></param>
        ///// <returns></returns>
        //[LibraryImport(Libraries.User32, ExactSpelling = true)]
        //public static partial IntPtr DispatchMessageA(ref MSG msg);
        /// <summary>
        /// 分发消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [LibraryImport(Libraries.User32, SetLastError = true)]
        public static partial IntPtr DispatchMessageW(ref MSG msg);
    }
}
