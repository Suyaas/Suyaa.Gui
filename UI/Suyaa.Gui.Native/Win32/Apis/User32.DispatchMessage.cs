using System.Runtime.InteropServices;

namespace Suyaa.Gui.Native.Win32.Apis
{
    /* user32.dll DispatchMessage */
    public partial class User32
    {
        /// <summary>
        /// 分发消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int DispatchMessage(ref MSG msg);
        /// <summary>
        /// 分发消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [DllImport(Libraries.User32, ExactSpelling = true)]
        public static extern IntPtr DispatchMessageA(ref MSG msg);
        /// <summary>
        /// 分发消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [DllImport(Libraries.User32, ExactSpelling = true)]
        public static extern IntPtr DispatchMessageW(ref MSG msg);
    }
}
